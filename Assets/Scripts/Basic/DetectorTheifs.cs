using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTheifs : MonoBehaviour
{
    [SerializeField] private Siren siren;

    private float _maxVolumeSiren = 1;
    private float _minVolumeSiren = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            StartCoroutine(siren.ChangeVolume(_maxVolumeSiren));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Theif>(out Theif theif))
        {
            StartCoroutine(siren.ChangeVolume(_minVolumeSiren));
        }
    }
}
