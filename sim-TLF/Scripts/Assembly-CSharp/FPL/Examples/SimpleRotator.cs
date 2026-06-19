using System;
using UnityEngine;

namespace FPL.Examples
{
	public class SimpleRotator : MonoBehaviour
	{
		[Range(-5f, 5f)]
		public float speed = 0.1f;

		public bool xAxis;

		public bool yAxis;

		public bool zAxis;

		private void FixedUpdate()
		{
			base.transform.Rotate(speed * (float)Convert.ToInt32(xAxis), speed * (float)Convert.ToInt32(yAxis), speed * (float)Convert.ToInt32(zAxis));
		}
	}
}
