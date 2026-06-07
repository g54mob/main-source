using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Normalize Direction")]
	[Category("Math/Normalize Direction")]
	[Image(typeof(IconAbsolute), ColorTheme.Type.Green)]
	[Description("Rescales the magnitude of a direction to one unit")]
	public class GetDirectionMathNormalize : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionMathNormalize());

		public override string String => $"|{m_Direction}|";

		public override Vector3 Get(Args args)
		{
			return Vector3.Normalize(m_Direction.Get(args));
		}
	}
}
