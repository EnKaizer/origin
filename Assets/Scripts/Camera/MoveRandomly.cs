using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour {

	public Vector3 PosicaoInicial;
    private Vector3 PosicaoFinal;
    private float VelocidadeDaCamera = 0f;

	// Use this for initialization
	private void Awake () {
        PosicaoInicial = gameObject.transform.position;
        StartCoroutine(TrocarDirecao());
	}

    private IEnumerator TrocarDirecao()
    {
        PosicaoInicial = new Vector3(PosicaoInicial.x, PosicaoInicial.y, PosicaoInicial.z);
        PosicaoFinal = PosicaoInicial += new Vector3(Random.Range(-15, 15), Random.Range(-7, 20));
        VelocidadeDaCamera = Random.Range(5, 15);
        yield return new WaitForSeconds(Random.Range(2, 15));
        StartCoroutine(TrocarDirecao());
    }
	
	// Update is called once per frame
	private void Update () {
        Vector3 posicao = gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(posicao, PosicaoFinal, VelocidadeDaCamera * Time.deltaTime);
	}
}
