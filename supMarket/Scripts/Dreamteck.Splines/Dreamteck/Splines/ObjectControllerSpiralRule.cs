using UnityEngine;

namespace Dreamteck.Splines
{
	[CreateAssetMenu(menuName = "Dreamteck/Splines/Object Controller Rules/Spiral Rule")]
	public class ObjectControllerSpiralRule : ObjectControllerCustomRuleBase
	{
		[SerializeField]
		private bool _useSplinePercent;

		[SerializeField]
		private float _revolve;

		[SerializeField]
		private Vector2 _startSize;

		[SerializeField]
		private Vector2 _endSize;

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

		public float revolve
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector2 startSize
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 endSize
		{
			get
			{
				return default(Vector2);
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

		public override Quaternion GetRotation()
		{
			return default(Quaternion);
		}

		private float GetPercent()
		{
			return 0f;
		}
	}
}
