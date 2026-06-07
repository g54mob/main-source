using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconScale), ColorTheme.Type.Green)]
	[Title("Scale")]
	[Category("Transform/Scale")]
	[Description("Remembers the local scale of the object")]
	public class MemoryScale : Memory
	{
		public override string Title => "Scale";

		public override Token GetToken(GameObject target)
		{
			return new TokenScale(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenScale tokenScale)
			{
				Character character = target.Get<Character>();
				if (character != null)
				{
					character.Driver.SetScale(tokenScale.Scale);
				}
				else
				{
					target.transform.localScale = tokenScale.Scale;
				}
			}
		}
	}
}
