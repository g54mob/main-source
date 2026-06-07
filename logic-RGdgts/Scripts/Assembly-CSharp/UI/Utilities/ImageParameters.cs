using System;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utilities
{
	[Serializable]
	public class ImageParameters
	{
		public ElementParameters parameterType;

		public Image image;

		public ImageParameters(ElementParameters parameterType, Sprite sprite)
		{
		}
	}
}
