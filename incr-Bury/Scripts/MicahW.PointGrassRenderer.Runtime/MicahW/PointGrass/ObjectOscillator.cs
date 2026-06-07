using System;
using UnityEngine;

namespace MicahW.PointGrass
{
	public class ObjectOscillator : MonoBehaviour
	{
		public Vector3 oscStrength = Vector3.right;

		public Vector3 oscFrequency = Vector3.right;

		public Vector3 oscPhase = Vector3.zero;

		public Vector3 oscOffset = Vector3.zero;

		private Vector3 origin;

		private void Start()
		{
			origin = base.transform.position;
		}

		private void Update()
		{
			float num = Time.time * MathF.PI * 2f;
			Vector3 vector = oscPhase * MathF.PI * 2f;
			Vector3 vector2 = new Vector3(Mathf.Sin(oscFrequency.x * num + vector.x), Mathf.Sin(oscFrequency.y * num + vector.y), Mathf.Sin(oscFrequency.z * num + vector.z));
			vector2.Scale(oscStrength);
			vector2 += oscOffset;
			base.transform.position = origin + vector2;
		}
	}
}
