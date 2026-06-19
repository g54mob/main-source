using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class PlotBuildingEffectComponent : MonoBehaviour
	{
		private const float TimeLife = 20f;

		private const float AnimSpeed = 32f;

		private float _time;

		private Vector3 _origin;

		private float _posY;

		private float _scale;

		private bool _popup;

		public void Initialise(Vector3 origin, float scale = 1f, bool popup = false)
		{
			_scale = scale;
			_origin = origin;
			_popup = popup;
			_posY = base.gameObject.transform.position.y;
		}

		private void LateUpdate()
		{
			Vector3 position = base.gameObject.transform.position;
			_time += GameTime.unscaledDeltaTime;
			if (_time >= 20f)
			{
				base.gameObject.transform.localScale = new Vector3(_scale, 1f, _scale);
				base.gameObject.transform.position = new Vector3(position.x, _posY, position.z);
				UnityEngine.Object.Destroy(this);
				return;
			}
			float num = (position.x - _origin.x + position.z - _origin.z) / 32f;
			float num2 = Mathf.Clamp(_time - num, 0f, 1f);
			num2 *= num2;
			float a = 1f - Mathf.Cos(num2 * (float)Math.PI * 5f);
			a = Mathf.Lerp(a, 1f, num2);
			if (_popup)
			{
				a += 0.001f;
				base.gameObject.transform.localScale = new Vector3(a * _scale, a, a * _scale);
				base.gameObject.transform.position = new Vector3(position.x, _posY + ((a > 0f) ? (1f - a) : (-1f)), position.z);
			}
			else
			{
				base.gameObject.transform.localScale = new Vector3(_scale, a + 0.001f, _scale);
				base.gameObject.transform.position = new Vector3(position.x, _posY + (1f - num2) * -0.1f, position.z);
			}
		}
	}
}
