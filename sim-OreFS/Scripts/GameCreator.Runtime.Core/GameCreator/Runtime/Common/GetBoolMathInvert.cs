using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Invert")]
	[Category("Math/Invert")]
	[Image(typeof(IconToggleOff), ColorTheme.Type.Red, typeof(OverlayArrowLeft))]
	[Description("Returns False if the Boolean field is True, and True otherwise")]
	[Keywords(new string[] { "Fail", "No", "Revert", "Opposite", "Change" })]
	public class GetBoolMathInvert : PropertyTypeGetBool
	{
		[SerializeField]
		private PropertyGetBool m_Boolean = GetBoolValue.Create(value: true);

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolMathInvert());

		public override string String => $"not {m_Boolean}";

		public override bool EditorValue => !m_Boolean.EditorValue;

		public override bool Get(Args args)
		{
			return !m_Boolean.Get(args);
		}

		public override bool Get(GameObject gameObject)
		{
			return !m_Boolean.Get(gameObject);
		}
	}
}
