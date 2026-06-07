using System;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Stop Highlighting UIButton", fileName = "StopHighlightingUIButton", order = 7)]
	public class StopHighlightingUIButtonSubQuestEventSO : AbstractSubQuestEventSO
	{
		public event Action OnStopHighlightingButton;

		public override void Execute()
		{
			this.OnStopHighlightingButton?.Invoke();
		}
	}
}
