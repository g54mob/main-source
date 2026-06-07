using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("No input is executed")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class InputButtonNone : TInputButton
	{
		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonNone());
		}
	}
}
