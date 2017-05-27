using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTrigger : MonoBehaviour {

    private int dano;
    public GameObject Player;
    private Vector2 Dano;
    private float PlayerRealizouGolpe;

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.isTrigger != true && col.CompareTag("Inimigo"))
        {
            dano = Random.RandomRange(1, 11);
            PlayerRealizouGolpe = Player.transform.position.x;
            Dano = new Vector2(dano, PlayerRealizouGolpe);
            col.SendMessage("Dano", Dano);
        }
    }
}
