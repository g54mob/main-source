using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkersPanelView : UIView
	{
		[SerializeField]
		private float maxHeight = 560f;

		[SerializeField]
		private OptimizedScrollView optimizedScrollView;

		private void Start()
		{
			MonoSingleton<WorkersViewManager>.Instance.WorkersListUpdatedEvent += OnWorkerListUpdate;
			MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent += OnPanelOpen;
			MonoSingleton<SceneUIManager>.Instance.OnPanelHideEvent += OnPanelHide;
			optimizedScrollView.Initialize();
		}

		private void OnEnable()
		{
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Combine(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
		}

		private void OnDisable()
		{
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Remove(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorkersViewManager>.IsInstantiated())
			{
				MonoSingleton<WorkersViewManager>.Instance.WorkersListUpdatedEvent -= OnWorkerListUpdate;
			}
			if (MonoSingleton<SceneUIManager>.IsInstantiated())
			{
				MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent -= OnPanelOpen;
				MonoSingleton<SceneUIManager>.Instance.OnPanelHideEvent -= OnPanelHide;
			}
			base.OnDestroy();
		}

		private void OnPanelOpen(string panel)
		{
			switch (panel)
			{
			case "JobPanelManager":
			case "ManagePanelManager":
			case "SchedulePanelManager":
				optimizedScrollView?.gameObject.SetActive(value: false);
				break;
			}
		}

		private void OnPanelHide(string panel)
		{
			switch (panel)
			{
			case "JobPanelManager":
			case "ManagePanelManager":
			case "SchedulePanelManager":
				optimizedScrollView?.gameObject.SetActive(value: true);
				break;
			}
		}

		private void OnWorkerListUpdate()
		{
			optimizedScrollView.RefreshVisibleEntries(MonoSingleton<WorkersViewManager>.Instance.Workers.Count);
		}

		private void OnUpdateScrollAction(RectTransform targetElement, int index)
		{
			if (MonoSingleton<WorkersViewManager>.Instance.Workers.Count <= index)
			{
				return;
			}
			WorkerEntryLayoutItemView component = targetElement.GetComponent<WorkerEntryLayoutItemView>();
			try
			{
				component.SetHumanoidInstance(MonoSingleton<WorkersViewManager>.Instance.Workers[index]);
			}
			catch (Exception value)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\WorkersPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Index ");
					messageBuilder.AppendFormatted(index);
					messageBuilder.AppendLiteral(" does not exist in list. List.Count: ");
					messageBuilder.AppendFormatted(MonoSingleton<WorkersViewManager>.Instance.Workers.Count);
				}
				Log.Info(messageBuilder);
				Console.WriteLine(value);
				throw;
			}
		}
	}
}
