using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _changeVolume;

    private float _sirenDeltaVolume = 0.25f;

    public void ChangeVolume(float desiredVolume)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);

        _changeVolume = StartCoroutine(ChangeVolumeCoroutine(desiredVolume));
    }

    private IEnumerator ChangeVolumeCoroutine(float desiredVolume)
    {
        while (_audioSource.volume != desiredVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, desiredVolume, _sirenDeltaVolume * Time.deltaTime);
            yield return null;
        }
    }

    private void Start()
    {
        _audioSource.Play();
    }
}
