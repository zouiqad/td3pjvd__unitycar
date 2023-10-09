using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GestionVoiture
{
    private float essence;
    public GestionVoiture()
    { //Constructeur
        essence = 10;
        Debug.Log("Essence :" + essence);
    }
    public float getEssence()
    {
        return essence;
    }
    public void setEssence(float valeur)
    {
        essence = valeur;
    }
    public bool roule(float consommation)
    {
        essence -= consommation;

        if (essence > 0) return true;

        Debug.Log("false" + essence);
        return false;

    }

}
