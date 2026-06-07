using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action")]
	[Category("Input/Input Action")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue)]
	[Description("The input value (decimal) of an enabled Input Action")]
	public class GetDecimalInputAction : PropertyTypeGetDecimal
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		public override string String => $"Input {m_Input}";

		public override double Get(Args args)
		{
			return m_Input.InputAction?.ReadValue<float>() ?? 0f;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Input.InputAction?.ReadValue<float>() ?? 0f;
		}
	}
}
