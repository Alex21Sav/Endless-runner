using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }
    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startValue, float endValye, float duration, UnityAction<float> LerpingEnd)
    {
        float elepsed = 0;
        float nextValue;

        while(elepsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValye, elepsed / duration);
            _image.fillAmount = nextValue;
            elepsed += Time.deltaTime;
            yield return null;
        }
        LerpingEnd?.Invoke(endValye);
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }
    private void Fill(float value)
    {
        _image.fillAmount = value;
    }
}
