using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Color HDR")]
	[Category("Color HDR")]
	[Image(typeof(IconColor), ColorTheme.Type.Pink, typeof(OverlayDot))]
	[Description("Returns the color value with HDR settings")]
	[HideLabelsInEditor(true)]
	public class GetColorValueHDR : PropertyTypeGetColor
	{
		[SerializeField]
		[ColorUsage(true, true)]
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

		public GetColorValueHDR()
		{
		}

		public GetColorValueHDR(Color value)
			: this()
		{
			m_Value = value;
		}

		public static PropertyGetColor Create(Color value)
		{
			return new PropertyGetColor(new GetColorValueHDR(value));
		}
	}
}
