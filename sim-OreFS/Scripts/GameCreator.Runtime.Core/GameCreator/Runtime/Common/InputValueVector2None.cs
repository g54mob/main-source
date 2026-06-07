using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("No input is executed")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class InputValueVector2None : TInputValueVector2
	{
		public override Vector2 Read()
		{
			return Vector2.zero;
		}
	}
}
