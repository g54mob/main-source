using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/GUI/MMRadialProgressBar")]
	public class MMRadialProgressBar : MonoBehaviour
	{
		public float StartValue;

		public float EndValue;

		public float Tolerance;

		public string PlayerID;

		protected Image _radialImage;

		protected float _newPercent;

		protected virtual void Awake()
		{
		}

		public virtual void UpdateBar(float currentValue, float minValue, float maxValue)
		{
		}
	}
}
