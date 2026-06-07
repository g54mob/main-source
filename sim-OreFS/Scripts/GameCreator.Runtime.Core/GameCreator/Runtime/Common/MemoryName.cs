using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconString), ColorTheme.Type.Green)]
	[Title("Name")]
	[Category("Game Object/Name")]
	[Description("Remembers the name of the object")]
	public class MemoryName : Memory
	{
		public override string Title => "Name";

		public override Token GetToken(GameObject target)
		{
			return new TokenName(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenName tokenName)
			{
				target.name = tokenName.Name;
			}
		}
	}
}
