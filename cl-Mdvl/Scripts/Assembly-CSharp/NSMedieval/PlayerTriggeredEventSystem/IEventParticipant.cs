using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	public interface IEventParticipant
	{
		void GoapAttendPlayerTriggeredEvent(string goalId);

		void GoapLeavePlayerTriggeredEvent(string goalId);

		Sprite GetSprite();

		bool IsAtEvent();
	}
}
