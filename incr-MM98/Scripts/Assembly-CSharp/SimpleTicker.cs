using TMPro;
using UnityEngine;

public class SimpleTicker : MonoBehaviour
{
	[Header("Settings")]
	public float scrollSpeed = 100f;

	public int repeatCount = 3;

	private TMP_Text _text;

	private LocalizeStringHandler _stringHandler;

	private RectTransform _rectTransform;

	private float _textWidth;

	private Vector3 _startPosition;

	private string _originalText;

	private bool _needsUpdate;

	private void Start()
	{
		_text = GetComponent<TMP_Text>();
		_stringHandler = GetComponent<LocalizeStringHandler>();
		_rectTransform = GetComponent<RectTransform>();
		_stringHandler.PropertyChanged += MessageChanged;
		_startPosition = _rectTransform.localPosition;
		_needsUpdate = true;
	}

	private void MessageChanged()
	{
		_needsUpdate = true;
	}

	private void LateUpdate()
	{
		if (_needsUpdate)
		{
			_needsUpdate = false;
			UpdateTickerText();
		}
		_rectTransform.localPosition += Vector3.left * (scrollSpeed * Time.deltaTime);
		if (_rectTransform.localPosition.x <= _startPosition.x - _textWidth)
		{
			float num = _rectTransform.localPosition.x - (_startPosition.x - _textWidth);
			_rectTransform.localPosition = new Vector3(_startPosition.x + num, _rectTransform.localPosition.y, _rectTransform.localPosition.z);
		}
	}

	private void UpdateTickerText()
	{
		_originalText = _text.text;
		string text = "";
		for (int i = 0; i < repeatCount; i++)
		{
			text += _originalText;
			if (i < repeatCount - 1)
			{
				text += " ";
			}
		}
		_text.text = text;
		_text.ForceMeshUpdate();
		_textWidth = _text.GetRenderedValues(onlyVisibleCharacters: false).x / (float)repeatCount;
	}
}
