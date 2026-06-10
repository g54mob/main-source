using System;
using NSEipix.Base;
using NSMedieval.Dialogs;
using NSMedieval.Dialogs.Data;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("ShowDialogPhase", "")]
	public class ShowDialogPhase : GameEventLinearPhaseBase
	{
		[SerializeField]
		public int dialogIndex;

		[SerializeField]
		public string dialogId;

		[SerializeField]
		protected bool dialogWasClosed;

		[SerializeField]
		protected string overrideDialogImage;

		private const string fvs_dialogIndex = "dialogIndex";

		private const string fvs_dialogId = "dialogId";

		private const string fvs_dialogWasClosed = "dialogWasClosed";

		protected ShowDialogPhase()
		{
			dialogWasClosed = false;
		}

		public ShowDialogPhase(int dialogIndex, string overrideDialogImage = null)
			: this()
		{
			this.dialogIndex = dialogIndex;
			dialogId = null;
			this.overrideDialogImage = overrideDialogImage;
		}

		public ShowDialogPhase(string dialogId)
			: this()
		{
			dialogIndex = -1;
			this.dialogId = dialogId;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<DialogViewManager>.IsInstantiated())
			{
				DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
				instance.OnClose = (Action<int>)Delegate.Remove(instance.OnClose, new Action<int>(OnClose));
			}
		}

		public override bool OnStart()
		{
			if (dialogId != null)
			{
				dialogIndex = base.Blueprint.GetDialogById(dialogId);
				if (dialogIndex == -1)
				{
					throw new Exception("Dialog with ID '" + dialogId + "' not found");
				}
			}
			if (dialogIndex == -1)
			{
				throw new Exception("Invalid dialog index");
			}
			DialogContent dialogContent = GameEventUtil.BuildDialogContent(base.EventInstance, dialogIndex);
			if (!string.IsNullOrEmpty(overrideDialogImage))
			{
				dialogContent.ContentBodyImagePath = overrideDialogImage;
			}
			DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
			instance.OnClose = (Action<int>)Delegate.Combine(instance.OnClose, new Action<int>(OnClose));
			MonoSingleton<DialogViewManager>.Instance.OpenDialog(dialogContent);
			return true;
		}

		public override void OnLoaded(bool fromSave)
		{
			if (!dialogWasClosed)
			{
				DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
				instance.OnClose = (Action<int>)Delegate.Combine(instance.OnClose, new Action<int>(OnClose));
			}
		}

		protected virtual void OnClose(int selectedOptionIndex)
		{
			dialogWasClosed = true;
			DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
			instance.OnClose = (Action<int>)Delegate.Remove(instance.OnClose, new Action<int>(OnClose));
			base.EventInstance.GetDialogContent(dialogIndex);
			MonoSingleton<GameEventSystemController>.Instance.EventOptionChosen(base.EventInstance, dialogIndex);
		}

		protected override bool TickShouldEnd()
		{
			return dialogWasClosed;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("dialogIndex", dialogIndex);
			serializer.Write("dialogId", dialogId);
			serializer.Write("dialogWasClosed", dialogWasClosed);
			serializer.Write("overrideDialogImage", overrideDialogImage);
		}

		public ShowDialogPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			dialogIndex = deserializer.ReadInt("dialogIndex");
			dialogId = deserializer.ReadString("dialogId");
			dialogWasClosed = deserializer.ReadBool("dialogWasClosed");
			overrideDialogImage = deserializer.ReadString("overrideDialogImage");
		}
	}
}
