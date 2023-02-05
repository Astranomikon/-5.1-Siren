using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _sirenDeltaVolume = 0.01f;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine changeVolumeCoroutine;

    private void Start()
    {
        _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            changeVolumeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            changeVolumeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float desiredVolume)
    {
        while (_audioSource.volume != desiredVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, desiredVolume, _sirenDeltaVolume);
            yield return null;
        }
    }
}
