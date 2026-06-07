using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class XZGridSettings : Settings
	{
		[SerializeField]
		private bool _isVisible = true;

		[SerializeField]
		private float _cellSizeX = 1f;

		[SerializeField]
		private float _cellSizeZ = 1f;

		[SerializeField]
		private float _yOffset;

		[SerializeField]
		private Vector3 _rotationAngles = Vector3.zero;

		[SerializeField]
		private float _upDownStep = 1f;

		public bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				_isVisible = value;
			}
		}

		public float CellSizeX
		{
			get
			{
				return _cellSizeX;
			}
			set
			{
				_cellSizeX = Mathf.Max(value, 0.01f);
			}
		}

		public float CellSizeZ
		{
			get
			{
				return _cellSizeZ;
			}
			set
			{
				_cellSizeZ = Mathf.Max(value, 0.01f);
			}
		}

		public Vector3 RotationAngles
		{
			get
			{
				return _rotationAngles;
			}
			set
			{
				_rotationAngles = value;
			}
		}

		public float YOffset
		{
			get
			{
				return _yOffset;
			}
			set
			{
				_yOffset = value;
			}
		}

		public float UpDownStep
		{
			get
			{
				return _upDownStep;
			}
			set
			{
				_upDownStep = Mathf.Max(0.0001f, value);
			}
		}
	}
}
