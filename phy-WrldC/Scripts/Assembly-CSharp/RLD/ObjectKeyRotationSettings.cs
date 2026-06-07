using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectKeyRotationSettings : Settings
	{
		[SerializeField]
		private float _xRotationStep = 90f;

		[SerializeField]
		private float _yRotationStep = 90f;

		[SerializeField]
		private float _zRotationStep = 90f;

		public float XRotationStep
		{
			get
			{
				return _xRotationStep;
			}
			set
			{
				_xRotationStep = Mathf.Max(0.0001f, value);
			}
		}

		public float YRotationStep
		{
			get
			{
				return _yRotationStep;
			}
			set
			{
				_yRotationStep = Mathf.Max(0.0001f, value);
			}
		}

		public float ZRotationStep
		{
			get
			{
				return _zRotationStep;
			}
			set
			{
				_zRotationStep = Mathf.Max(0.0001f, value);
			}
		}
	}
}
