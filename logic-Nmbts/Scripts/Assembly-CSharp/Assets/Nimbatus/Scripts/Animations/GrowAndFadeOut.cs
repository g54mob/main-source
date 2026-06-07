using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class GrowAndFadeOut : MonoBehaviour
	{
		private float FadeOutDuration = 1.5f;

		private float FadeOutScale = 3f;

		private UITexture _uITexture;

		private float _startSizeX;

		private float _startSizeY;

		private Color _startColor;

		private float _startTime;

		private void Start()
		{
			_uITexture = GetComponent<UITexture>();
			_startSizeX = _uITexture.width;
			_startSizeY = _uITexture.height;
			_startColor = _uITexture.color;
		}

		private void Update()
		{
			if (_startTime < FadeOutDuration)
			{
				_startTime += Time.deltaTime;
				float num = Mathf.Pow(_startTime / FadeOutDuration, 3f);
				_uITexture.width = (int)Mathf.Lerp(_startSizeX, _startSizeX * FadeOutScale, 1f - Mathf.Pow(1f - num, 2f));
				_uITexture.height = (int)Mathf.Lerp(_startSizeY, _startSizeY * FadeOutScale, 1f - Mathf.Pow(1f - num, 2f));
				_uITexture.color = Color.Lerp(_startColor, new Color(_startColor.r, _startColor.g, _startColor.b, 0f), 1f - Mathf.Pow(1f - num, 2f));
			}
			else
			{
				_uITexture.enabled = false;
			}
		}
	}
}
