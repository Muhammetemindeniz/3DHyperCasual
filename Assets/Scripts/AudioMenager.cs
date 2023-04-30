using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour
{
    public AudioSource hitobjSource, banchSource, cashSource, completedSource;
    public AudioClip hitobjClip, banchClip, cashClip, completedClip;

    public void HitObjSound()
    {
        hitobjSource.PlayOneShot(hitobjClip);
    }
    public void BanchSound()
    {
        banchSource.PlayOneShot(banchClip);
    }
    public void CashSound()
    {
        cashSource.PlayOneShot(cashClip);
    }
    public void CompletedSound()
    {
        completedSource.PlayOneShot(completedClip);
    }

}
