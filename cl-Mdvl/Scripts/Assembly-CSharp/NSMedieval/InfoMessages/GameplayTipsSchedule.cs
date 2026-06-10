using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.InfoMessages
{
	[Serializable]
	[FVSerializableKey("GameplayTipsSchedule", "TutorialSchedule")]
	public class GameplayTipsSchedule : IFVSerializable
	{
		[SerializeField]
		private string tipNotificationId;

		[SerializeField]
		private int displayHour;

		[SerializeField]
		private string tipId;

		[SerializeField]
		private bool isShown;

		[SerializeField]
		private bool skipIfTutorialCompleted;

		public int DisplayHour => displayHour;

		public string TipNotificationId => tipNotificationId;

		public bool IsShown => isShown;

		public string TipId => tipId;

		public bool SkipIfTutorialCompleted => skipIfTutorialCompleted;

		public GameplayTipsSchedule(string tipNotificationId, int displayHour, string tipId, bool skipIfTutorialCompleted)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\GameplayTipsSchedule.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(tipId);
				messageBuilder.AppendLiteral(" skip if tutorial: ");
				messageBuilder.AppendFormatted(skipIfTutorialCompleted);
			}
			Log.Trace(messageBuilder);
			this.tipNotificationId = tipNotificationId;
			this.displayHour = displayHour;
			this.tipId = tipId;
			this.skipIfTutorialCompleted = skipIfTutorialCompleted;
		}

		public GameplayTipsSchedule()
		{
		}

		public void SetTipShown()
		{
			isShown = true;
		}

		public override string ToString()
		{
			return $"{tipNotificationId} ({tipId}) scheduled for {displayHour} hour";
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("tutorialNotificationId", tipNotificationId);
			serializer.Write("displayHour", displayHour);
			serializer.Write("tutorialShown", isShown);
			serializer.Write("tipId", tipId);
		}

		public GameplayTipsSchedule(FVDeserializer deserializer)
		{
			tipNotificationId = deserializer.ReadString("tutorialNotificationId");
			displayHour = deserializer.ReadInt("displayHour");
			tipId = deserializer.ReadString("tipId");
			isShown = deserializer.ReadBool("tutorialShown");
		}
	}
}
