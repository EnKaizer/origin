using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusLevel : MonoBehaviour {

    public float LimiteDistanciaX = 20f;
    public float LimiteDistanciaY = 25f;
    public float LimiteDistanciaZ = 15f;

    public Bounds FocusBounds;

    // Update is called once per frame
    void Update () {
        Vector3 posicao = gameObject.transform.position;
        Bounds limites = new Bounds();
        limites.Encapsulate(new Vector3(posicao.x - LimiteDistanciaX, posicao.y - LimiteDistanciaY, posicao.z - LimiteDistanciaZ));
        limites.Encapsulate(new Vector3(posicao.x + LimiteDistanciaX, posicao.y + LimiteDistanciaY, posicao.z + LimiteDistanciaZ));
        FocusBounds = limites;
    }
}
