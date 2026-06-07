using System;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetClinometerLOD : CustomizerLODObject<GadgetBase>
	{
		private static readonly float REVERSE_THRESHOLD = 0f - Mathf.Cos((float)Math.PI * 89f / 180f);

		public IndicatorGauge indicator;

		public float smoothTime;

		private bool reverse;

		private void Start()
		{
			base.Base.AfterLinked += Linked;
			if (base.Base.IsLinked)
			{
				Linked();
			}
		}

		private void Linked(object _ = null, object __ = null)
		{
			reverse = false;
			if (base.IsOnTrainCar)
			{
				float num = Vector3.Dot(base.transform.right, base.Base.TrainCar.transform.right);
				reverse = num < REVERSE_THRESHOLD;
			}
		}

		private void Update()
		{
			Vector3 vector = (base.IsOnTrainCar ? base.Base.TrainCar.transform.forward : base.Base.transform.forward);
			if (reverse)
			{
				vector = -vector;
			}
			float target = vector.y * 100f / Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
			indicator.Value = NumberUtil.SmoothExponential(indicator.Value, target, smoothTime);
		}
	}
}
