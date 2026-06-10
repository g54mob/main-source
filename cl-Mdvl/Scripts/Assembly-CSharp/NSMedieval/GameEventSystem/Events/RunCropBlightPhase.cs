using System;
using Managers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("RunCropBlightPhase", "")]
	public class RunCropBlightPhase : GameEventLinearPhaseBase
	{
		private const int BLIGHT_DIALOG_ID = 0;

		[SerializeField]
		private uint newsMessageId;

		private const string fvs_newsMessageId = "newsMessageId";

		public RunCropBlightPhase()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override bool OnStart()
		{
			newsMessageId = GameEventUtil.PublishNews(base.EventInstance, 0);
			Subscribe();
			InitBlight();
			return true;
		}

		private void Subscribe()
		{
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnNewsDialogClosed;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnNewsDialogClosed;
			}
		}

		private void OnNewsDialogClosed(uint newsId, int chosenOptionIndex)
		{
			if (newsId == newsMessageId)
			{
				Unsubscribe();
				if (chosenOptionIndex == 1)
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.JumpToBlightedCrop();
				}
			}
		}

		public override void OnLoaded(bool fromSave)
		{
			Subscribe();
			InitBlight();
		}

		private void InitBlight()
		{
			if (!CropBlightManager.IsBlightActive())
			{
				MonoSingleton<CropBlightManager>.Instance.StartBlight();
				MonoSingleton<GameSpeedManager>.Instance.SetSpeedPause();
			}
		}

		protected override bool TickShouldEnd()
		{
			return !CropBlightManager.IsBlightActive();
		}

		public override void OnEnd()
		{
			Unsubscribe();
			MonoSingleton<NewsManager>.Instance.Remove(newsMessageId);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("newsMessageId", newsMessageId);
		}

		public RunCropBlightPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			newsMessageId = deserializer.ReadUInt("newsMessageId");
		}
	}
}
