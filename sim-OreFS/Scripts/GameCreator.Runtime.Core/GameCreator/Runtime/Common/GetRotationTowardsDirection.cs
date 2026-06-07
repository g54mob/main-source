using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Towards Direction")]
	[Category("Math/Towards Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow, typeof(OverlayPlus))]
	[Description("Rotation from an Identity rotation towards a direction vector")]
	public class GetRotationTowardsDirection : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionVector3Zero.Create();

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationTowardsDirection());

		public static PropertyGetRotation CreateForward => new PropertyGetRotation(new GetRotationTowardsDirection(Vector3.forward));

		public static PropertyGetRotation CreateBackward => new PropertyGetRotation(new GetRotationTowardsDirection(Vector3.back));

		public static PropertyGetRotation CreateLeft => new PropertyGetRotation(new GetRotationTowardsDirection(Vector3.left));

		public static PropertyGetRotation CreateRight => new PropertyGetRotation(new GetRotationTowardsDirection(Vector3.right));

		public override string String => $"Direction {m_Direction}";

		public GetRotationTowardsDirection()
		{
		}

		public GetRotationTowardsDirection(Vector3 direction)
			: this()
		{
			m_Direction = GetDirectionVector.Create(direction);
		}

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(m_Direction.Get(args));
		}
	}
}
