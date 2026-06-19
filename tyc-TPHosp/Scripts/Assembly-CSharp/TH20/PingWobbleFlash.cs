using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class PingWobbleFlash : PingBehaviour
	{
		private readonly PingWobbleFlashInit _init;

		private Vector3 _cachedScale;

		private float _cachedRotZ;

		private Color _cachedColor;

		private GameObject _overlayGameObject;

		private Image _image;

		public PingWobbleFlash(PingWobbleFlashInit init)
		{
			_init = init;
		}

		public override void OnPingReset(Pingable pingable)
		{
			if (pingable.RectTransform != null)
			{
				pingable.RectTransform.localScale = _cachedScale;
				pingable.RectTransform.rotation = Quaternion.Euler(pingable.RectTransform.rotation.eulerAngles.x, pingable.RectTransform.rotation.eulerAngles.y, _cachedRotZ);
			}
			if (pingable.Image != null)
			{
				pingable.Image.color = _cachedColor;
			}
			if (_overlayGameObject != null)
			{
				_overlayGameObject.SetActive(value: false);
				Object.Destroy(_overlayGameObject);
			}
		}

		public override IEnumerator PingCoroutine(Pingable pingable)
		{
			_cachedScale = pingable.RectTransform.localScale;
			_cachedRotZ = pingable.RectTransform.rotation.eulerAngles.z;
			_cachedColor = pingable.Image.color;
			if (_init.PrefabOverlay != null && pingable.Image != null && _overlayGameObject == null)
			{
				_overlayGameObject = Object.Instantiate(_init.PrefabOverlay, pingable.Image.transform);
				_image = _overlayGameObject.GetComponent<Image>();
			}
			while (true)
			{
				float num = Mathf.PingPong(Time.unscaledTime, 1f / _init.WobbleSpeed) * _init.WobbleSpeed;
				float num2 = Mathf.PingPong(Time.unscaledTime, 1f / _init.ScaleSpeed) * _init.ScaleSpeed;
				float t = Mathf.PingPong(Time.unscaledTime, 1f / _init.FlashSpeed) * _init.FlashSpeed;
				if (pingable.RectTransform != null)
				{
					float z = (num - 0.5f) * _init.WobbleAmount;
					pingable.RectTransform.rotation = Quaternion.Euler(0f, 0f, z);
					float num3 = num2 * _init.ScaleAmount + 1f;
					pingable.RectTransform.localScale = new Vector3(num3, num3, 1f);
				}
				if (_image != null)
				{
					Color color = Color.Lerp(_init.StartColor, _init.TargetColor, t);
					_image.color = color;
				}
				yield return null;
			}
		}
	}
}
