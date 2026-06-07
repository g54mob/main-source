using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Green)]
	[Title("Is Active")]
	[Category("Game Object/Is Active")]
	[Description("Remembers if the object is active or not")]
	public class MemoryIsActive : Memory
	{
		public override string Title => "Is Active";

		public override Token GetToken(GameObject target)
		{
			return new TokenIsActive(target);
		}

		public override void OnRemember(GameObject target, Token token)
		{
			if (token is TokenIsActive tokenIsActive)
			{
				target.SetActive(tokenIsActive.IsActive);
			}
		}
	}
}
