using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Serialization;
using NSMedieval.Tools;

namespace NSMedieval.EventBase
{
	[FVSerializableKey("EventInstanceBase", "")]
	public abstract class EventInstanceBase : IFVSerializable
	{
		public readonly int DefaultDurationHours = 6;

		private EventBaseModel baseBlueprint;

		protected EventBaseModel BaseBlueprint => baseBlueprint;

		protected EventInstanceBase()
		{
		}

		public virtual void SetBlueprint(EventBaseModel eventBaseModel)
		{
			baseBlueprint = eventBaseModel;
		}

		public virtual bool CanStart()
		{
			return true;
		}

		public virtual bool ShouldEnd()
		{
			return false;
		}

		public virtual void Start()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\EventBase\\EventInstanceBase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("EventInstanceBase: Starting event ");
				messageBuilder.AppendFormatted(BaseBlueprint.GetID());
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
		}

		public virtual void End()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\EventBase\\EventInstanceBase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("EventInstanceBase: Ending event ");
				messageBuilder.AppendFormatted(BaseBlueprint.GetID());
				messageBuilder.AppendLiteral(".");
			}
			Log.Debug(messageBuilder);
		}

		public virtual bool IsCorrupted()
		{
			return false;
		}

		public virtual void Initialize()
		{
		}

		public GameEvent.DialogContent GetDialogContent(int dialogIndex)
		{
			if (dialogIndex < 0 || dialogIndex >= BaseBlueprint.Dialogs.Count)
			{
				throw new ArgumentException($"Invalid dialogIndex '{dialogIndex}' for blueprint dialog array of {BaseBlueprint.Dialogs.Count} elements");
			}
			return BaseBlueprint.Dialogs[dialogIndex];
		}

		public virtual string GetEventTitle(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetFormattedText(dialogContent.TypeTextKey);
		}

		public virtual string GetEventName(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetFormattedText(dialogContent.NameTextKey);
		}

		public virtual string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			return TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.DescriptionTextKey));
		}

		public virtual string GetEventImagePath(GameEvent.DialogContent dialogContent)
		{
			return dialogContent.ImagePath;
		}

		public virtual void Serialize(FVSerializer serializer)
		{
		}

		public EventInstanceBase(FVDeserializer deserializer)
		{
		}
	}
}
