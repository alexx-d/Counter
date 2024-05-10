using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _delay = 0.5f;

    private int _value;
    private bool _isCounting;
    private Coroutine _coroutine;

    private void Start()
    {
        _value = 0;
        _isCounting = false;
        _counterText.text = "Count: " + _value.ToString();
    }

    public void ToggleCounter()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _coroutine = StartCoroutine(IncrementCounter(_delay));
        }
        else
        {
            _isCounting = false;
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncrementCounter(float delay)
    {
        while (_isCounting)
        {
            _counterText.text = "Count: " + _value.ToString();
            _value++;
            yield return new WaitForSeconds(delay);
        }
    }
}
