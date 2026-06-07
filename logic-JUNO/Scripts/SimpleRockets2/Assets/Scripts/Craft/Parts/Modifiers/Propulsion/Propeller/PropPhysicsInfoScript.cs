using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class PropPhysicsInfoScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _sizeAtVector3One;

		public Vector3 SizeAtVector3One
		{
			get
			{
				return _sizeAtVector3One;
			}
			set
			{
				_sizeAtVector3One = value;
			}
		}

		public float GetHeightScalar()
		{
			return base.transform.lossyScale.y * _sizeAtVector3One.y;
		}

		public float GetLengthScalar()
		{
			return base.transform.lossyScale.x * _sizeAtVector3One.x;
		}

		public float GetWidthScalar()
		{
			return base.transform.lossyScale.z * _sizeAtVector3One.z;
		}

		public Vector3 GetWorldScaleVector3One()
		{
			return new Vector3(GetLengthScalar(), GetHeightScalar(), GetWidthScalar());
		}

		private void Awake()
		{
		}
	}
}
