using System;
using System.Collections.Generic;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Models;

namespace TwitchLib.PubSub.Events
{
	public class OnPredictionArgs : EventArgs
	{
		public PredictionType Type;

		public Guid Id;

		public string ChannelId;

		public DateTime? CreatedAt;

		public DateTime? LockedAt;

		public DateTime? EndedAt;

		public ICollection<Outcome> Outcomes;

		public PredictionStatus Status;

		public string Title;

		public Guid? WinningOutcomeId;

		public int PredictionTime;
	}
}
