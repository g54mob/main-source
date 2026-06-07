using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Title("Position")]
	[Category("Transform/Position")]
	[Description("Remembers the position of the object")]
	public class MemoryPosition : Memory
	{
		public override string Title => "Position";

		public override Token GetToken(GameObject target)
		{
			return new TokenPosition(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenPosition tokenPosition)
			{
				Character character = target.Get<Character>();
				if (character != null)
				{
					character.Driver.SetPosition(tokenPosition.Position);
				}
				else
				{
					target.transform.position = tokenPosition.Position;
				}
			}
		}
	}
}
