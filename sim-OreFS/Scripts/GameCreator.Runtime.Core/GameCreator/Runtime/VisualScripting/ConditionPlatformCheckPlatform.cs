using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Check Platform")]
	[Description("Check if the running platform matches the selected one")]
	[Category("Platforms/Check Platform")]
	[Image(typeof(IconComputer), ColorTheme.Type.Blue)]
	public class ConditionPlatformCheckPlatform : Condition
	{
		[SerializeField]
		private RuntimePlatform m_Platform = RuntimePlatform.WindowsPlayer;

		protected override string Summary => $"is {m_Platform}";

		protected override bool Run(Args args)
		{
			return Application.platform == m_Platform;
		}
	}
}
