using System;
using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Hover")]
	public class Hover : MonoBehaviour
	{
		public float amplitude = 0.5f;

		public float frequency = 1f;

		public Vector3 rotation = Vector3.zero;

		private Vector3 positionOffset;

		private Vector3 positionTemporary;

		private void Start()
		{
			positionOffset = base.transform.localPosition;
		}

		private void Update()
		{
			base.transform.Rotate(rotation * Time.deltaTime);
			positionTemporary = positionOffset;
			positionTemporary.y += Mathf.Sin(Time.fixedTime * MathF.PI * frequency) * amplitude;
			base.transform.localPosition = positionTemporary;
		}
	}
}
