using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class ImageAttribute : Attribute
	{
		private readonly IIcon m_Icon;

		public Texture2D Image => m_Icon.Texture;

		public ImageAttribute(Type iconType, ColorTheme.Type color)
			: this(iconType, ColorTheme.Get(color))
		{
		}

		public ImageAttribute(Type iconType, Color color)
			: this(iconType, color, null)
		{
		}

		public ImageAttribute(Type iconType, ColorTheme.Type iconColor, Type overlayType)
			: this(iconType, ColorTheme.Get(iconColor), overlayType)
		{
		}

		public ImageAttribute(Type iconType, Color iconColor, Type overlayType)
		{
			IIcon icon = ((overlayType != null) ? (Activator.CreateInstance(overlayType, Color.white, null) as IIcon) : null);
			m_Icon = Activator.CreateInstance(iconType, iconColor, icon) as IIcon;
		}
	}
}
