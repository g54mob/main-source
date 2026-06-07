using System;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[Obsolete("This component is obsolete, it's recommended to use MMProgressBar instead", true)]
	public class MMRadialProgressBar : MonoBehaviour
	{
		public float StartValue = 1f;

		public float EndValue;

		public float Tolerance = 0.01f;

		public string PlayerID;

		protected Image _radialImage;

		protected float _newPercent;

		protected virtual void Awake()
		{
			_radialImage = GetComponent<Image>();
		}

		public virtual void UpdateBar(float currentValue, float minValue, float maxValue)
		{
			_newPercent = MMMaths.Remap(currentValue, minValue, maxValue, StartValue, EndValue);
			if (!(_radialImage == null))
			{
				_radialImage.fillAmount = _newPercent;
				if (_radialImage.fillAmount > 1f - Tolerance)
				{
					_radialImage.fillAmount = 1f;
				}
				if (_radialImage.fillAmount < Tolerance)
				{
					_radialImage.fillAmount = 0f;
				}
			}
		}
	}
}
