using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.InfoMessages
{
	[Serializable]
	public class GameplayTipsScheduler : NSEipix.Base.Model
	{
		[SerializeField]
		private string tipNotificationId;

		[SerializeField]
		private int displayHour;

		[SerializeField]
		private string tipId;

		[SerializeField]
		private bool skipIfTutorialCompleted;

		public int DisplayHour => displayHour;

		public string TipId => tipId;

		public bool SkipIfTutorialCompleted => skipIfTutorialCompleted;

		public override string GetID()
		{
			return tipNotificationId;
		}
	}
}
