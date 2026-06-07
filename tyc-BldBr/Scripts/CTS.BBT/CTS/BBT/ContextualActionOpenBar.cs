using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	internal class ContextualActionOpenBar : MenuContextualAction<Entrance>
	{
		[SerializeField]
		private string _closeBarName = "Close Bar";

		public override string GetDisplayName()
		{
			if (!CTSSingleton<LevelParameters>.Instance.IsOpen)
			{
				return "Open Bar";
			}
			return "Close Bar";
		}

		public override void Setup()
		{
		}

		protected override bool CanBePerformed()
		{
			return true;
		}

		protected override void Execution()
		{
			CTSSingleton<LevelParameters>.Instance.SetOpened(!CTSSingleton<LevelParameters>.Instance.IsOpen);
		}
	}
}
