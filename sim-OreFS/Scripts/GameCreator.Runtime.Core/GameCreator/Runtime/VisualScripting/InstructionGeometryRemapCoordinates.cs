using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Remap Coordinates")]
	[Description("Changes each of the components of a Vector3 value")]
	[Category("Math/Geometry/Remap Coordinates")]
	[Parameter("Value", "The Vector3 value affected by the operation")]
	[Parameter("X", "Where the X coordinate component is remapped")]
	[Parameter("Y", "Where the Y coordinate component is remapped")]
	[Parameter("Z", "Where the Z coordinate component is remapped")]
	[Keywords(new string[] { "Change", "Vector3", "Vector2", "Component", "Towards", "Look", "Variable", "Axis" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	public class InstructionGeometryRemapCoordinates : Instruction
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
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private Remap m_X;

		[SerializeField]
		private Remap m_Y = Remap.Y;

		[SerializeField]
		private Remap m_Z = Remap.Z;

		public override string Title => $"Remap {m_Set} to ({m_X}, {m_Y}, {m_Z})";

		protected override Task Run(Args args)
		{
			Vector3 vector = m_Set.Get(args);
			Vector3 value = new Vector3(DoRemap(vector, m_X), DoRemap(vector, m_Y), DoRemap(vector, m_Z));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}

		private float DoRemap(Vector3 vector, Remap operation)
		{
			return operation switch
			{
				Remap.X => vector.x, 
				Remap.Y => vector.y, 
				Remap.Z => vector.z, 
				Remap.Zero => 0f, 
				Remap.One => 1f, 
				_ => throw new ArgumentOutOfRangeException("operation", operation, null), 
			};
		}
	}
}
