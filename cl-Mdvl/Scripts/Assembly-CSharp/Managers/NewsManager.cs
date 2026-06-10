using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Dialogs;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.WorldMap;

namespace Managers
{
	public class NewsManager : MonoSingleton<NewsManager>
	{
		public delegate void NewsDialogClosedHandler(uint newsId, int chosenOptionIndex);

		private readonly Dictionary<uint, WarningMessageData> idToView = new Dictionary<uint, WarningMessageData>();

		private List<NewsData> ActiveNews => GlobalSaveController.CurrentVillageData.ActiveNews;

		public event NewsDialogClosedHandler OnDialogClosed;

		public uint Publish(NewsData newsData)
		{
			ActiveNews.Add(newsData);
			CreateView(newsData);
			return newsData.Id;
		}

		public void Remove(uint newsId)
		{
			if (idToView.Remove(newsId, out var value))
			{
				MonoSingleton<WarningMessageController>.Instance.HideMessage(value);
				ActiveNews.RemoveWhere((NewsData news) => news.Id == newsId);
			}
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			MonoSingleton<SceneController>.Instance.Tick += RemoveExpiredNews;
		}

		private void OnGameLoaded(bool fromSave)
		{
			InitializeView();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= RemoveExpiredNews;
			}
		}

		private void RemoveExpiredNews(float _)
		{
			using (ProfilerSampleJanitor.Begin("NewsManager.Tick"))
			{
				if (ActiveNews == null || ActiveNews.Count == 0)
				{
					return;
				}
				List<NewsData> list = ListPool<NewsData>.Get();
				foreach (NewsData item in ActiveNews)
				{
					if (item.HasExpired)
					{
						list.Add(item);
					}
				}
				foreach (NewsData item2 in list)
				{
					Remove(item2.Id);
				}
				ListPool<NewsData>.Return(list);
			}
		}

		private void InitializeView()
		{
			foreach (NewsData item in ActiveNews)
			{
				CreateView(item);
			}
		}

		private void CreateView(NewsData news)
		{
			if (idToView.ContainsKey(news.Id))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NewsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("View already exists for news with ID '");
					messageBuilder.AppendFormatted(news.Id);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				WarningMessageData warningMessageData = new WarningMessageData(WarningMessageCategory.News, news.Message, news.Tooltip, news.IconName, OnClickOpen, null, news.DialogContent.ShowCloseButton ? new Action<WarningMessageData>(OnClickClose) : null, showInPlayerVillageOnly: false);
				idToView[news.Id] = warningMessageData;
				MonoSingleton<WarningMessageController>.Instance.ShowMessage(warningMessageData);
			}
			void OnClickClose(WarningMessageData _)
			{
				Remove(news.Id);
				MonoSingleton<DialogViewManager>.Instance.OnClose?.Invoke(0);
				this.OnDialogClosed?.Invoke(news.Id, 0);
			}
			void OnClickOpen(WarningMessageData msgData)
			{
				Remove(news.Id);
				MonoSingleton<DialogViewManager>.Instance.OpenDialog(news.DialogContent);
				DialogViewManager dialogViewManager = MonoSingleton<DialogViewManager>.Instance;
				dialogViewManager.OnClose = (Action<int>)Delegate.Combine(dialogViewManager.OnClose, new Action<int>(OnCloseDialog));
			}
			void OnCloseDialog(int chosenOptionIndex)
			{
				DialogViewManager dialogViewManager = MonoSingleton<DialogViewManager>.Instance;
				dialogViewManager.OnClose = (Action<int>)Delegate.Remove(dialogViewManager.OnClose, new Action<int>(OnCloseDialog));
				if (news.HasJumpTo(chosenOptionIndex))
				{
					MonoSingleton<TaskController>.Instance.WaitUntil((float _) => !MonoSingleton<CameraManager>.Instance.ShowingLowRes).Then(delegate
					{
						if (news.JumpToWorldMapMarker != null)
						{
							if (news.JumpToWorldMapMarker.Value != null && !news.JumpToWorldMapMarker.Value.HasDisposed)
							{
								MonoSingleton<WorldMap>.Instance.JumpToPlace(news.JumpToWorldMapMarker.Value);
							}
						}
						else
						{
							MonoSingleton<RtsCamera>.Instance.JumpTo(news.JumpToPosition);
						}
					});
				}
				this.OnDialogClosed?.Invoke(news.Id, chosenOptionIndex);
			}
		}
	}
}
