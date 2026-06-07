using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("No input is executed")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class InputValueFloatNone : TInputValueFloat
	{
		public override float Read()
		{
			return 0f;
		}
	}
}
