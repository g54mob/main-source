using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TiltControl : CustomControllerControl
	{
		public enum TiltDirection
		{
			Both = 0,
			Horizontal = 1,
			Forward = 2
		}

		private const float maxFullTiltAngle = 180f;

		private const float maxAngleOffset = 90f;

		[SerializeField]
		[CustomObfuscation]
		private TiltDirection _allowedTiltDirections;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private float _horizontalTiltLimit;

		[CustomObfuscation]
		[SerializeField]
		private float _horizontalRestAngle;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private float _forwardTiltLimit;

		[CustomObfuscation]
		[SerializeField]
		private float _forwardRestAngle;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis2D _axis2D;

		private bool _useHAxis;

		private bool _useFAxis;

		private Func<Vector3> _getAccelerationValue;

		public TiltDirection axesToUse
		{
			get
			{
				return default(TiltDirection);
			}
			set
			{
			}
		}

		public CustomControllerElementTargetSetForFloat horizontalTiltCustomControllerElement => null;

		public float horizontalTiltLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float horizontalRestAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public CustomControllerElementTargetSetForFloat forwardTiltCustomControllerElement => null;

		public float forwardTiltLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float forwardRestAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AxisCalibration horizontalAxisCalibration => null;

		public AxisCalibration verticalAxisCalibration => null;

		[Obsolete]
		public Axis2DCalibration deadZoneType => null;

		public Axis2DCalibration axis2DCalibration => null;

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => null;

		private Vector3 hcGyxHpsZsmKeLajFqxSgCBnILNS => default(Vector3);

		[CustomObfuscation]
		internal TiltControl()
		{
		}

		public void SetAccelerationSourceCallback(Func<Vector3> callback)
		{
		}

		public void SetRestOrientation()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
		}

		public override void ClearValue()
		{
		}

		private void MaGXERvYSPERGOAfcEFdkGNuXzIr()
		{
		}

		private void iWYRfiiURzkAkCfnyCOuFmghZKHC()
		{
		}

		private void LoesNjgEUrYfdvEfknfJNxZeoYen(TiltDirection P_0)
		{
		}
	}
}
