using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const string StartText = "Start counter";
    private const string StopText = "Stop counter";

    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField, Min(0)] private float _delay;

    private Coroutine _coroutine;
    private int _counter = 0;

    private void Awake()
    {
        _buttonText.text = StartText;
    }

    public void ChangeCoroutineState()
    {
        if (_coroutine == null)
        {
            _buttonText.text = StopText;
            _coroutine = StartCoroutine(Counting());
        }
        else
        {
            _buttonText.text = StartText;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Counting()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _counter++;
            _counterText.text = _counter.ToString();

            yield return wait;
        }
    }
}
