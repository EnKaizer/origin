using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupCam : MonoBehaviour {

    public FocusLevel FocusLevel;

    public List<GameObject> Players;

    public float VelocidadeAtualizacaoPronfudidadeCamera = 5f;
    public float VelocidadeAtualizacaoAngulosCamera = 7f;
    public float VelocidadeAtualizacaoPosicaoCamera = 5f;

    public float ProfundidadeMax = -10f;
    public float ProfundidadeMin = -22f;

    public float AnguloMax = 11f;
    public float AnguloMin = 3f;

    private float CameraEulerX;
    private Vector3 PosicaoCamera;
    // Use this for initialization
    void Start () {
        Players.Add(FocusLevel.gameObject);
		
	}
	
	// Update is called once per frame
	private void LateUpdate () {
        CalcularPosicaoCamera();
        MoverCamera();
	}

    private void MoverCamera()
    {
        Vector3 Posicao = gameObject.transform.position;
        if(Posicao != PosicaoCamera)
        {
            Vector3 PosicaoAlvo = Vector3.zero;
            PosicaoAlvo.x = Mathf.MoveTowards(Posicao.x, PosicaoCamera.x, VelocidadeAtualizacaoPosicaoCamera * Time.deltaTime);
            PosicaoAlvo.y = Mathf.MoveTowards(Posicao.y, PosicaoCamera.y, VelocidadeAtualizacaoPosicaoCamera * Time.deltaTime);
            PosicaoAlvo.z = Mathf.MoveTowards(Posicao.z, PosicaoCamera.z, VelocidadeAtualizacaoPronfudidadeCamera * Time.deltaTime);
            gameObject.transform.position = PosicaoAlvo;
        }

        Vector3 AnguloAtual = gameObject.transform.localEulerAngles;
        if(AnguloAtual.x != CameraEulerX)
        {
            Vector3 DirecaoAngularAlvo = new Vector3(CameraEulerX, AnguloAtual.y, AnguloAtual.z);
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(AnguloAtual, DirecaoAngularAlvo, VelocidadeAtualizacaoAngulosCamera * Time.deltaTime);
        }
    }

    private void CalcularPosicaoCamera()
    {
        Vector3 VaricaoCentroCamera = Vector3.zero;
        Vector3 SomaPosicoes = Vector3.zero;
        Bounds LimiteJogador = new Bounds();

        for(int i = 0; i< Players.Count; i++)
        {
            Vector3 PosicaoJogador = Players[i].transform.position;

            if (!FocusLevel.FocusBounds.Contains(PosicaoJogador))
            {
                float JogadorX = Mathf.Clamp(PosicaoJogador.x, FocusLevel.FocusBounds.min.x, FocusLevel.FocusBounds.max.x);
                float JogadorY = Mathf.Clamp(PosicaoJogador.y, FocusLevel.FocusBounds.min.y, FocusLevel.FocusBounds.max.y);
                float JogadorZ = Mathf.Clamp(PosicaoJogador.z, FocusLevel.FocusBounds.min.z, FocusLevel.FocusBounds.max.z);

                PosicaoJogador = new Vector3(JogadorX, JogadorY, JogadorZ);
            }

            SomaPosicoes += PosicaoJogador;
            LimiteJogador.Encapsulate(PosicaoJogador);
        }

        VaricaoCentroCamera = (SomaPosicoes / Players.Count);

        float extents = (LimiteJogador.extents.x + LimiteJogador.extents.y);
        float MediaPorcentagem = Mathf.InverseLerp(0, (FocusLevel.LimiteDistanciaX + FocusLevel.LimiteDistanciaY) / 2, extents);
        //Quanto mais os jogadores estiverem distantes um dos outros, mais a camera se afastará
        float Profundidade = Mathf.Lerp(ProfundidadeMin, ProfundidadeMax, MediaPorcentagem);
        float Angulo = Mathf.Lerp(AnguloMax, AnguloMin, MediaPorcentagem);

        CameraEulerX = Angulo;
        PosicaoCamera = new Vector3(VaricaoCentroCamera.x, VaricaoCentroCamera.y, Profundidade);
    }
}
