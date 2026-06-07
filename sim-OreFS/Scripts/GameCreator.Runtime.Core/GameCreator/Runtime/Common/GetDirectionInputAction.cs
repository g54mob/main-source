using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action")]
	[Category("Input/Input Action")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue)]
	[Description("The value of an enabled Input Action value")]
	public class GetDirectionInputAction : PropertyTypeGetDirection
	{
		private enum Axis
		{
			InputX = 0,
			InputY = 1,
			InputZ = 2,
			Zero = 3,
			One = 4
		}

		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		[SerializeField]
		private Axis m_X;

		[SerializeField]
		private Axis m_Y = Axis.InputY;

		[SerializeField]
		private Axis m_Z = Axis.Zero;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionInputAction());

		public override string String => $"Input {m_Input}";

		public override Vector3 Get(Args args)
		{
			Vector3 vector = m_Input.InputAction?.ReadValue<Vector2>() ?? ((Vector2)Vector3.zero);
			return new Vector3(m_X switch
			{
				Axis.InputX => vector.x, 
				Axis.InputY => vector.y, 
				Axis.InputZ => vector.z, 
				Axis.Zero => 0f, 
				Axis.One => 1f, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, m_Y switch
			{
				Axis.InputX => vector.x, 
				Axis.InputY => vector.y, 
				Axis.InputZ => vector.z, 
				Axis.Zero => 0f, 
				Axis.One => 1f, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, m_Z switch
			{
				Axis.InputX => vector.x, 
				Axis.InputY => vector.y, 
				Axis.InputZ => vector.z, 
				Axis.Zero => 0f, 
				Axis.One => 1f, 
				_ => throw new ArgumentOutOfRangeException(), 
			});
		}
	}
}
