using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Has Save")]
	[Description("Returns true if there is at least one saved game")]
	[Category("Storage/Has Save")]
	[Keywords(new string[] { "Game", "Load", "Continue", "Resume", "Can", "Is" })]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
	public class ConditionHasSave : Condition
	{
		protected override string Summary => "has Saved Game";

		protected override bool Run(Args args)
		{
			return Singleton<SaveLoadManager>.Instance.HasSave();
		}
	}
}
