using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Color")]
	[Category("Color")]
	[Image(typeof(IconColor), ColorTheme.Type.Pink)]
	[Description("Returns the color value")]
	[HideLabelsInEditor(true)]
	public class GetColorValue : PropertyTypeGetColor
	{
		[SerializeField]
		protected Color m_Value = Color.white;

		public override string String
		{
			get
			{
				if (!(m_Value.a >= 1f))
				{
					return "#" + ColorUtility.ToHtmlStringRGBA(m_Value);
				}
				return "#" + ColorUtility.ToHtmlStringRGB(m_Value);
			}
		}

		public override Color EditorValue => m_Value;

		public override Color Get(Args args)
		{
			return m_Value;
		}

		public override Color Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetColorValue()
		{
		}

		public GetColorValue(Color value)
			: this()
		{
			m_Value = value;
		}

		public static PropertyGetColor Create(Color value)
		{
			return new PropertyGetColor(new GetColorValue(value));
		}
	}
}
