using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("ShowDialogIfExistsPhase", "")]
	public class ShowDialogIfExistsPhase : ShowDialogPhase
	{
		public ShowDialogIfExistsPhase(int dialogIndex)
			: base(dialogIndex)
		{
		}

		public ShowDialogIfExistsPhase(string dialogId)
			: base(dialogId)
		{
		}

		public override bool OnStart()
		{
			if (dialogId != null)
			{
				dialogIndex = base.Blueprint.GetDialogById(dialogId);
				if (dialogIndex == -1)
				{
					FVLogger logger = GameEventPhaseBase.Logger;
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Common\\LinearPhases\\ShowDialogIfExistsPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Dialog with ID '");
						messageBuilder.AppendFormatted(dialogId);
						messageBuilder.AppendLiteral("' not found");
					}
					logger.Error(in messageBuilder);
					return false;
				}
			}
			if (dialogIndex < 0)
			{
				GameEventPhaseBase.Logger.Error("Invalid dialog index");
				return false;
			}
			if (dialogIndex < base.Blueprint.Dialogs.Count)
			{
				return base.OnStart();
			}
			dialogWasClosed = true;
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ShowDialogIfExistsPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
