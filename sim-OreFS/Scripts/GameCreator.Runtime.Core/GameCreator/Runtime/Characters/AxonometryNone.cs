using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconEmpty), ColorTheme.Type.TextNormal)]
	[Description("Do not use any kind of axonometric processing")]
	public class AxonometryNone : TAxonometry
	{
		public override object Clone()
		{
			return new AxonometryNone();
		}

		public override string ToString()
		{
			return "None";
		}
	}
}
