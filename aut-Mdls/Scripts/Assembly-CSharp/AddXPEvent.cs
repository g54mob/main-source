using Data.Statistics;
using Logic.Threading.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Progression/XP Request Event", fileName = "XPRequestEvent")]
public class AddXPEvent : MainThreadEventSO<AddXPEvent.Data>
{
	public struct Data
	{
		public int Amount;

		public XPEarnedSource EarnedSource;
	}

	public void Fire(int amount, XPEarnedSource earnedSource)
	{
		Fire(new Data
		{
			Amount = amount,
			EarnedSource = earnedSource
		});
	}
}
