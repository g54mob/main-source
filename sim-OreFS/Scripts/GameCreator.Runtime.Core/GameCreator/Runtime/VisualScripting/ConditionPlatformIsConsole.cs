using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Console")]
	[Description("Returns true if the running platform is a console")]
	[Category("Platforms/Is Console")]
	[Keywords(new string[] { "PS4", "PS5", "Switch", "XBox", "Deck" })]
	[Image(typeof(IconConsole), ColorTheme.Type.Blue)]
	public class ConditionPlatformIsConsole : Condition
	{
		protected override string Summary => "is Console";

		protected override bool Run(Args args)
		{
			return Application.isConsolePlatform;
		}
	}
}
