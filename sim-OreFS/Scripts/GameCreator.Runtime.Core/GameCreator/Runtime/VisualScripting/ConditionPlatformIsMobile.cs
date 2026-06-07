using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Mobile")]
	[Description("Returns true if the running platform is a smartphone or tablet")]
	[Category("Platforms/Is Mobile")]
	[Keywords(new string[] { "Smartphone", "Tablet", "iOS", "Android" })]
	[Image(typeof(IconMobile), ColorTheme.Type.Blue)]
	public class ConditionPlatformIsMobile : Condition
	{
		protected override string Summary => "is Mobile";

		protected override bool Run(Args args)
		{
			return Application.isMobilePlatform;
		}
	}
}
