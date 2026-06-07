using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Remap Direction")]
	[Category("Math/Remap Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("Remaps each component of a direction")]
	public class GetDirectionMathRemap : PropertyTypeGetDirection
	{
		private enum Remap
		{
			X = 0,
			Y = 1,
			Z = 2,
			Zero = 3,
			One = 4
		}

		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		[SerializeField]
		private Remap m_X;

		[SerializeField]
		private Remap m_Y = Remap.Y;

		[SerializeField]
		private Remap m_Z = Remap.Z;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathRemap());

		public override string String => $"{m_Direction}";

		public override Vector3 Get(Args args)
		{
			Vector3 direction = m_Direction.Get(args);
			return new Vector3(DoRemap(direction, m_X), DoRemap(direction, m_Y), DoRemap(direction, m_Z));
		}

		private float DoRemap(Vector3 direction, Remap operation)
		{
			return operation switch
			{
				Remap.X => direction.x, 
				Remap.Y => direction.y, 
				Remap.Z => direction.z, 
				Remap.Zero => 0f, 
				Remap.One => 1f, 
				_ => throw new ArgumentOutOfRangeException("operation", operation, null), 
			};
		}
	}
}
