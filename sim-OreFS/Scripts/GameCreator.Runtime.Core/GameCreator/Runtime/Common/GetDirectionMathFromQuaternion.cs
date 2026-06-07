using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("From Rotation")]
	[Category("Math/From Rotation")]
	[Image(typeof(IconRotation), ColorTheme.Type.Green)]
	[Description("Creates a direction a Quaternion rotation")]
	public class GetDirectionMathFromQuaternion : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetRotation m_Rotation;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathFromQuaternion());

		public override string String => m_Rotation.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Rotation.Get(args) * Vector3.forward;
		}

		public override Vector3 Get(GameObject args)
		{
			return m_Rotation.Get(args) * Vector3.forward;
		}
	}
}
