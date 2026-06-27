using System;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	[Serializable]
	public struct GraphicAndColorBlock
	{
		[SerializeField]
		private Graphic graphic;

		[SerializeField]
		private ColorBlock colors;

		public Graphic Graphic
		{
			get
			{
				return graphic;
			}
			set
			{
				graphic = value;
			}
		}

		public ColorBlock Colors
		{
			get
			{
				return colors;
			}
			set
			{
				colors = value;
			}
		}

		public void CrossFadeColor(Color color, bool instantly)
		{
			graphic.CrossFadeColor(color * colors.colorMultiplier, instantly ? 0f : colors.fadeDuration, ignoreTimeScale: true, useAlpha: true);
		}
	}
}
