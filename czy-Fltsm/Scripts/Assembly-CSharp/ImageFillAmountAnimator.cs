using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillAmountAnimator : MonoBehaviour
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	[Tooltip("The duration of the whole animation")]
	private float _duration;

	[SerializeField]
	[Tooltip("The duration of the fill animation, by having a Fill Duration that is lower than Duration the fill will not constantly animated.")]
	private float _fillDuration;

	private void OnEnable()
	{
		if (_image == null)
		{
			_image = GetComponent<Image>();
		}
		base.enabled = _image != null && _image.type == Image.Type.Filled;
		if (base.enabled)
		{
			Update();
		}
		else
		{
			Debug.LogException(new Exception($"Unable to animate fill amount for imaga '{this}'."));
		}
	}

	private void Update()
	{
		_image.fillAmount = Mathf.Clamp01(Time.realtimeSinceStartup % _duration / _fillDuration);
	}
}
