using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isThiefInDoor = false;
    private float _sirenDeltaVolume = 0.005f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            _audioSource.Play();
            _audioSource.volume = 0;
            _isThiefInDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
            _isThiefInDoor = false;
    }

    private void Update()
    {
        if (_isThiefInDoor)
            _audioSource.volume += _sirenDeltaVolume;
        else
            _audioSource.volume -= _sirenDeltaVolume;
    }
}
