using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("From To Direction")]
	[Category("Math/From To Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("Rotation from a direction towards another one")]
	public class GetRotationFromToDirection : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetDirection m_From = GetDirectionConstantForward.Create;

		[SerializeField]
		protected PropertyGetDirection m_To = GetDirectionConstantRight.Create;

		public override string String => $"[{m_From} -> {m_To}]";

		public GetRotationFromToDirection()
		{
		}

		public GetRotationFromToDirection(Vector3 from, Vector3 to)
			: this()
		{
			m_From = GetDirectionVector.Create(from);
			m_To = GetDirectionVector.Create(to);
		}

		public override Quaternion Get(Args args)
		{
			Vector3 fromDirection = m_From.Get(args);
			Vector3 toDirection = m_From.Get(args);
			return Quaternion.FromToRotation(fromDirection, toDirection);
		}

		public static PropertyGetRotation Create(Vector3 from, Vector3 to)
		{
			return new PropertyGetRotation(new GetRotationFromToDirection(from, to));
		}
	}
}
