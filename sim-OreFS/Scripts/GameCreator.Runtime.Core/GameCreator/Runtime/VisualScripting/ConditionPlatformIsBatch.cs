using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Batch mode")]
	[Description("Returns true if the running platform is in batch mode (no interface)")]
	[Category("Platforms/Is Batch mode")]
	[Keywords(new string[] { "Server" })]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Blue)]
	public class ConditionPlatformIsBatch : Condition
	{
		protected override string Summary => "is Batch mode";

		protected override bool Run(Args args)
		{
			return Application.isBatchMode;
		}
	}
}
