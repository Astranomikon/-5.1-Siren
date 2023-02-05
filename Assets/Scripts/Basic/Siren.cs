using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _sirenDeltaVolume = 0.005f;
    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine increaseVolimeCoroutine;
    private Coroutine decreaseVolimeCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            increaseVolimeCoroutine = StartCoroutine(IncreaseVolume());
            StopCoroutine(decreaseVolimeCoroutine);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            decreaseVolimeCoroutine = StartCoroutine(DecreaseVolume());
            StopCoroutine(increaseVolimeCoroutine);
        }
    }

    private IEnumerator IncreaseVolume()
    {
        _audioSource.Play();

        for (float i = _audioSource.volume; i <= _maxVolume; i+= _sirenDeltaVolume)
        {
            _audioSource.volume = i;
            yield return null;
        }

        StopCoroutine(increaseVolimeCoroutine);
    }

    private IEnumerator DecreaseVolume()
    {
        for (float i = _audioSource.volume; i >= _minVolume; i -= _sirenDeltaVolume)
        {
            _audioSource.volume = i;
            yield return null;
        }

        StopCoroutine(decreaseVolimeCoroutine);
        _audioSource.Stop();
    }
}
