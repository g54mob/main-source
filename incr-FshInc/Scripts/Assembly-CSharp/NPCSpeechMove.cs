using System.Collections;
using UnityEngine;

public class NPCSpeechMove : MonoBehaviour
{
	public float jitterMagnitude = 2f;

	public float returnSpeed = 20f;

	[Range(1f, 10f)]
	public int jitterEveryNLetters = 3;

	private SuperTextMesh _stm;

	private RectTransform _rectTransform;

	private Vector3 _originalPosition;

	private bool _initialized;

	private int _jitterLetterCount;

	private Coroutine _moveCoroutine;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	public void Initialize(SuperTextMesh stm)
	{
		if (_rectTransform == null)
		{
			_rectTransform = GetComponent<RectTransform>();
		}
		if (_stm == null)
		{
			_stm = stm;
			_stm.OnPrintEvent -= OnCharacterPrinted;
			_stm.OnPrintEvent += OnCharacterPrinted;
		}
		_originalPosition = _rectTransform.localPosition;
		_jitterLetterCount = 0;
		_initialized = true;
	}

	private void OnCharacterPrinted()
	{
		if (!_initialized)
		{
			return;
		}
		_jitterLetterCount++;
		if (_jitterLetterCount % jitterEveryNLetters != 0)
		{
			return;
		}
		float x = Random.Range(0f - jitterMagnitude, jitterMagnitude);
		float y = Random.Range(0f - jitterMagnitude, jitterMagnitude);
		_rectTransform.localPosition += new Vector3(x, y, 0f);
		if (base.gameObject.activeInHierarchy)
		{
			if (_moveCoroutine != null)
			{
				StopCoroutine(_moveCoroutine);
			}
			StartCoroutine(ReturnToPosition());
		}
	}

	private IEnumerator ReturnToPosition()
	{
		while (Vector3.SqrMagnitude(_rectTransform.localPosition - _originalPosition) > 0.1f)
		{
			_rectTransform.localPosition = Vector3.Lerp(_rectTransform.localPosition, _originalPosition, Time.unscaledDeltaTime * returnSpeed);
			yield return null;
		}
		_rectTransform.localPosition = _originalPosition;
	}

	private void OnDestroy()
	{
		if (_stm != null)
		{
			_stm.OnPrintEvent -= OnCharacterPrinted;
		}
	}
}
