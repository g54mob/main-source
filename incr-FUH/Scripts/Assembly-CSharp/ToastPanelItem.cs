using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastPanelItem : MonoBehaviour
{
	private Image _image;

	private TMP_Text _text;

	private float _time = 5f;

	private void Start()
	{
		_image = GetComponent<Image>();
		_text = base.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
		_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0f);
		_image.DOFade(1f, 0.5f);
		_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0f);
		_text.DOFade(1f, 0.5f);
		_time = 5f;
	}

	private void Update()
	{
		if (!(_time <= 0f))
		{
			_time -= Time.deltaTime;
			if (_time <= 0f)
			{
				_text.DOFade(0f, 0.5f);
				_image.DOFade(0f, 0.5f).OnComplete(RemoveItem);
			}
		}
	}

	private void RemoveItem()
	{
		base.gameObject.SetActive(value: false);
		Object.Destroy(this, 1f);
	}

	public void Initialize(string text)
	{
		base.transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = text;
	}
}
