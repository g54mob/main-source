using System;
using UnityEngine;
using UnityEngine.VFX;

namespace VFXTools
{
	public class ChangeFXParameter : MonoBehaviour
	{
		private VisualEffect FX;

		private float time;

		public string parameterName = "Radius";

		public float minValue;

		public float maxValue = 1f;

		private void Start()
		{
			FX = GetComponent<VisualEffect>();
		}

		private void Update()
		{
			time += 2f * Time.deltaTime;
			DoChangeFX();
		}

		private void DoChangeFX()
		{
			FX.SetFloat(parameterName, minValue + (maxValue - minValue) * (float)Math.Abs(Math.Sin(time)));
		}
	}
}
