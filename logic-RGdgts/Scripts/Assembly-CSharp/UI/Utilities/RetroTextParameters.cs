using System;
using UI.Common;
using UI.Elements;

namespace UI.Utilities
{
	[Serializable]
	public class RetroTextParameters
	{
		public ElementParameters parameterType;

		public UIText text;

		public RetroTextParameters(ElementParameters parameterType, string text)
		{
		}
	}
}
