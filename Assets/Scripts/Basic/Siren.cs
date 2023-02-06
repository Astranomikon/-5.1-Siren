using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _sirenDeltaVolume = 0.01f;

    public IEnumerator ChangeVolume(float desiredVolume)
    {
        while (_audioSource.volume != desiredVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, desiredVolume, _sirenDeltaVolume);
            yield return null;
        }
    }

    private void Start()
    {
        _audioSource.Play();
    }
}
