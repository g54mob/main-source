using UnityEngine;

namespace DV.TerrainTools
{
	[ExecuteInEditMode]
	public class ControlPoint : Point
	{
		[SerializeField]
		private float _leftWiden = 3f;

		[SerializeField]
		private float _rightWiden = 3f;

		[SerializeField]
		private float _leftSlope = 15f;

		[SerializeField]
		private float _rightSlope = 15f;

		[SerializeField]
		private float _endingSlope = 2f;

		[SerializeField]
		private bool _isBridge;

		[SerializeField]
		private bool _isTunnel;

		public float LeftWiden
		{
			get
			{
				return _leftWiden;
			}
			set
			{
				SetProperty(ref _leftWiden, value, "LeftWiden");
			}
		}

		public float RightWiden
		{
			get
			{
				return _rightWiden;
			}
			set
			{
				SetProperty(ref _rightWiden, value, "RightWiden");
			}
		}

		public float LeftSlope
		{
			get
			{
				return _leftSlope;
			}
			set
			{
				SetProperty(ref _leftSlope, value, "LeftSlope");
			}
		}

		public float RightSlope
		{
			get
			{
				return _rightSlope;
			}
			set
			{
				SetProperty(ref _rightSlope, value, "RightSlope");
			}
		}

		public float EndingSlope
		{
			get
			{
				return _endingSlope;
			}
			set
			{
				SetProperty(ref _endingSlope, value, "EndingSlope");
			}
		}

		public bool IsBridge
		{
			get
			{
				return _isBridge;
			}
			set
			{
				SetProperty(ref _isBridge, value, "IsBridge");
			}
		}

		public bool IsTunnel
		{
			get
			{
				return _isTunnel;
			}
			set
			{
				SetProperty(ref _isTunnel, value, "IsTunnel");
			}
		}

		public void CopyDataFrom(ControlPoint other)
		{
			LeftWiden = other.LeftWiden;
			LeftSlope = other.LeftSlope;
			RightWiden = other.RightWiden;
			RightSlope = other.RightSlope;
			EndingSlope = other.EndingSlope;
			IsBridge = other.IsBridge;
			IsTunnel = other.IsTunnel;
		}

		public static bool AreSameKind(ControlPoint a, ControlPoint b)
		{
			if (a.IsBridge == b.IsBridge)
			{
				return a.IsTunnel == b.IsTunnel;
			}
			return false;
		}
	}
}
