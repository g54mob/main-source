using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Editor")]
	[Description("Returns true if the running platform is the Unity Editor")]
	[Category("Platforms/Is Editor")]
	[Keywords(new string[] { "Unity" })]
	[Image(typeof(IconUnity), ColorTheme.Type.Blue)]
	public class ConditionPlatformIsEditor : Condition
	{
		protected override string Summary => "is Editor";

		protected override bool Run(Args args)
		{
			return Application.isEditor;
		}
	}
}
