using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpeado : MonoBehaviour {

    private float forcaGolpeado = 0;
    public float DanoRecebido = 0;
    public int Velocidade = 5;
    public GameObject Personagem;

    private Vector2 PosicaoInicial;

    private bool LevouDano = false;

    private void Start()
    {
        PosicaoInicial = Personagem.transform.position;
    }

    private void Update()
    {
        forcaGolpeado = DanoRecebido;
    }

    public void Dano(Vector2 dano)
    {
        if (forcaGolpeado > 100 && forcaGolpeado < 200)
        {
            forcaGolpeado = DanoRecebido * 2.5f;
        }else if (forcaGolpeado >= 200)
        {
            forcaGolpeado = DanoRecebido * 3.2f;
        }
        LevouDano = true;
        DanoRecebido +=  dano.x;
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2((gameObject.transform.position.x - dano.y) * (dano.x /7) * Velocidade * forcaGolpeado/2, 1.8f * forcaGolpeado * Velocidade/2));
        //gameObject.GetComponent<Animation>().Play("Player_Golpeado");
    }
}
