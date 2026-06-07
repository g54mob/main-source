using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconLight), ColorTheme.Type.Green)]
	[Title("Color")]
	[Category("Light/Color")]
	[Description("Remembers the color of a Light component")]
	public class MemoryLightColor : Memory
	{
		public override string Title => "Color";

		public override Token GetToken(GameObject target)
		{
			return new TokenLightColor(target.Get<Light>());
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenLightColor tokenLightColor)
			{
				Light light = target.Get<Light>();
				if (light != null)
				{
					light.color = tokenLightColor.Color;
				}
			}
		}
	}
}
