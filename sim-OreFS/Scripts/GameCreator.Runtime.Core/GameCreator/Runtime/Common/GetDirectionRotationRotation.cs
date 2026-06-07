using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("From Rotation")]
	[Category("Rotation/From Rotation")]
	[Image(typeof(IconRotation), ColorTheme.Type.Green)]
	[Description("The forward direction defined by the Quaternion rotation")]
	[Keywords(new string[] { "Rotation", "Euler", "Angle", "Axis" })]
	public class GetDirectionRotationRotation : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetRotation m_Rotation = GetRotationEuler.Create();

		public override string String => $"{m_Rotation}";

		public override Vector3 EditorValue => m_Rotation.EditorValue * Vector3.forward;

		public GetDirectionRotationRotation()
		{
		}

		public GetDirectionRotationRotation(Vector3 angleAxis)
		{
			m_Rotation = GetRotationEuler.Create(angleAxis);
		}

		public override Vector3 Get(Args args)
		{
			return m_Rotation.Get(args) * Vector3.forward;
		}

		public static PropertyGetDirection Create(Vector3 angleAxis)
		{
			return new PropertyGetDirection(new GetDirectionRotationRotation(angleAxis));
		}
	}
}
