using System.Collections.Generic;
using UI.Common;
using UnityEngine;

namespace UI.Elements
{
	public struct ButtonParameters
	{
		public string buttonName;

		public Sprite buttonIcon;

		public Dictionary<ElementParameters, string> stringParameters;

		public Dictionary<ElementParameters, Sprite> spriteParameters;

		public ButtonParameters(string buttonName, Sprite buttonIcon)
		{
			this.buttonName = null;
			this.buttonIcon = null;
			stringParameters = null;
			spriteParameters = null;
		}
	}
}
