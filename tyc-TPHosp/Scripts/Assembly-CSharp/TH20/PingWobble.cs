using System.Collections;
using UnityEngine;

namespace TH20
{
	public class PingWobble : PingBehaviour
	{
		private readonly PingWobbleInit _init;

		private Vector3 _cachedScale;

		private float _cachedRotZ;

		public PingWobble(PingWobbleInit init)
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
		}

		public override IEnumerator PingCoroutine(Pingable pingable)
		{
			_cachedScale = pingable.RectTransform.localScale;
			_cachedRotZ = pingable.RectTransform.rotation.eulerAngles.z;
			while (true)
			{
				float num = Mathf.PingPong(Time.unscaledTime, 1f / _init.WobbleSpeed) * _init.WobbleSpeed;
				float num2 = Mathf.PingPong(Time.unscaledTime, 1f / _init.ScaleSpeed) * _init.ScaleSpeed;
				if (pingable.RectTransform != null)
				{
					float z = (num - 0.5f) * _init.WobbleAmount;
					pingable.RectTransform.rotation = Quaternion.Euler(0f, 0f, z);
					float num3 = num2 * _init.ScaleAmount + 1f;
					pingable.RectTransform.localScale = new Vector3(num3, num3, 1f);
				}
				yield return null;
			}
		}
	}
}
