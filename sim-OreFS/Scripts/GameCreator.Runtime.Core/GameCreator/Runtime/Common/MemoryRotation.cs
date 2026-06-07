using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconRotation), ColorTheme.Type.Green)]
	[Title("Rotation")]
	[Category("Transform/Rotation")]
	[Description("Remembers the rotation of the object")]
	public class MemoryRotation : Memory
	{
		public override string Title => "Rotation";

		public override Token GetToken(GameObject target)
		{
			return new TokenRotation(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenRotation tokenRotation)
			{
				Character character = target.Get<Character>();
				if (character != null)
				{
					character.Driver.SetRotation(tokenRotation.Rotation);
				}
				else
				{
					target.transform.rotation = tokenRotation.Rotation;
				}
			}
		}
	}
}
