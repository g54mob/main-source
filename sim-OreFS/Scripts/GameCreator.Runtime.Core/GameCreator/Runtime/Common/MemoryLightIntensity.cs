using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconLight), ColorTheme.Type.Green)]
	[Title("Intensity")]
	[Category("Light/Intensity")]
	[Description("Remembers the intensity of a Light component")]
	public class MemoryLightIntensity : Memory
	{
		public override string Title => "Intensity";

		public override Token GetToken(GameObject target)
		{
			return new TokenLightIntensity(target.Get<Light>());
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenLightIntensity tokenLightIntensity)
			{
				Light light = target.Get<Light>();
				if (light != null)
				{
					light.intensity = tokenLightIntensity.Intensity;
				}
			}
		}
	}
}
