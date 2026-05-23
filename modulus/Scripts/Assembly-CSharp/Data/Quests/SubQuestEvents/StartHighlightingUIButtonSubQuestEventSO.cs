using System;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Start Highlighting UIButton", fileName = "StartHighlightingUIButton", order = 7)]
	public class StartHighlightingUIButtonSubQuestEventSO : AbstractSubQuestEventSO
	{
		public event Action OnStartHighlightingButton;

		public override void Execute()
		{
			this.OnStartHighlightingButton?.Invoke();
		}
	}
}
