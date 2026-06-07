using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Invert Direction")]
	[Category("Math/Invert Direction")]
	[Image(typeof(IconContrast), ColorTheme.Type.Green)]
	[Description("Inverses the direction orientation")]
	public class GetDirectionMathInvert : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathInvert());

		public override string String => $"-{m_Direction}";

		public override Vector3 Get(Args args)
		{
			return m_Direction.Get(args) * -1f;
		}
	}
}
