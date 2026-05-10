using UnityEngine;

namespace Dreamteck.Splines
{
	[CreateAssetMenu(menuName = "Dreamteck/Splines/Object Controller Rules/Sine Rule")]
	public class ObjectControllerSineRule : ObjectControllerCustomRuleBase
	{
		[SerializeField]
		private bool _useSplinePercent;

		[SerializeField]
		private float _frequency;

		[SerializeField]
		private float _amplitude;

		[SerializeField]
		private float _angle;

		[SerializeField]
		private float _minScale;

		[SerializeField]
		private float _maxScale;

		[SerializeField]
		[Range(0f, 1f)]
		private float _offset;

		public bool useSplinePercent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float frequency
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float amplitude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float angle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float minScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override Vector3 GetOffset()
		{
			return default(Vector3);
		}

		public override Vector3 GetScale()
		{
			return default(Vector3);
		}

		private float GetSine()
		{
			return 0f;
		}
	}
}
