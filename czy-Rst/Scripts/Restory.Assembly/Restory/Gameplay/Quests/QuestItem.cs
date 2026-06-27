using System;
using Restory.Gameplay.Elements;

namespace Restory.Gameplay.Quests
{
	public class QuestItem : ElementBase
	{
		public event Action<QuestItem> OnDiscovered;

		public void Discover()
		{
			this.OnDiscovered?.Invoke(this);
		}
	}
}
