using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconLayers), ColorTheme.Type.Green)]
	[Title("Layers")]
	[Category("Game Object/Layers")]
	[Description("Remembers the Layers of the object")]
	public class MemoryLayers : Memory
	{
		public override string Title => "Layers";

		public override Token GetToken(GameObject target)
		{
			return new TokenLayers(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenLayers tokenLayers)
			{
				target.layer = tokenLayers.Layers;
			}
		}
	}
}
