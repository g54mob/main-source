using System;
using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.View;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public abstract class WorkerPanelManager : LimitedHeightPanel
	{
		[SerializeField]
		private Image[] markers;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton helpButton;

		[SerializeField]
		private OptimizedScrollView optimizedScrollView;

		[SerializeField]
		private SoundButton pasteAllButton;

		[SerializeField]
		private SoundButton pasteSelectedButton;

		private List<WorkerPanelGroup> groups = new List<WorkerPanelGroup>();

		protected abstract void OnHelpClick();

		public GameObject GetContentGameObject()
		{
			return optimizedScrollView.ContentRectTransform.gameObject;
		}

		public virtual void PasteToWorker(HumanoidInstance worker)
		{
		}

		protected void OnPasteSelectedClicked()
		{
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				if (selectedObject is WorkerView workerView)
				{
					PasteToWorker(workerView.HumanoidInstance);
				}
			}
			StartCoroutine(InitializeContent());
		}

		protected void OnPasteAllClicked()
		{
			foreach (HumanoidInstance item in WorkerManager.WorkersEverywhere)
			{
				PasteToWorker(item);
			}
			StartCoroutine(InitializeContent());
		}

		protected override IEnumerator InitializeContent()
		{
			optimizedScrollView.Initialize();
			SetPreferredHeight((float)MonoSingleton<WorkersViewManager>.Instance.Workers.Count * optimizedScrollView.SpacedElementHeight);
			yield return new WaitForEndOfFrame();
			optimizedScrollView.RefreshVisibleEntries(MonoSingleton<WorkersViewManager>.Instance.Workers.Count);
			yield return new WaitForSecondsRealtime(0.01f * (float)MonoSingleton<WorkersViewManager>.Instance.Workers.Count);
			yield return base.InitializeContent();
		}

		protected virtual void Awake()
		{
			closeButton.onClick.AddListener(Hide);
			helpButton.onClick.AddListener(OnHelpClick);
			pasteAllButton.onClick.AddListener(OnPasteAllClicked);
			pasteSelectedButton.onClick.AddListener(OnPasteSelectedClicked);
			if (TutorialManager.IsTutorialActive)
			{
				helpButton.gameObject.SetActive(value: false);
				pasteAllButton.gameObject.SetActive(value: false);
				pasteSelectedButton.gameObject.SetActive(value: false);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MonoSingleton<WorkersViewManager>.Instance.WorkersListUpdatedEvent += OnWorkerListUpdate;
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Combine(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
		}

		protected override void OnDisable()
		{
			if (MonoSingleton<WorkersViewManager>.IsInstantiated())
			{
				MonoSingleton<WorkersViewManager>.Instance.WorkersListUpdatedEvent -= OnWorkerListUpdate;
			}
			OptimizedScrollView obj = optimizedScrollView;
			obj.UpdateScrollItemAction = (OptimizedScrollView.UpdateScrollDelegate)Delegate.Remove(obj.UpdateScrollItemAction, new OptimizedScrollView.UpdateScrollDelegate(OnUpdateScrollAction));
			base.OnDisable();
		}

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.UpperLeft;
		}

		protected override void UpdatePanel()
		{
		}

		public override void Show()
		{
			base.Show();
			DelayedRefresh();
		}

		private void DelayedRefresh()
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				SetPreferredHeight((float)MonoSingleton<WorkersViewManager>.Instance.Workers.Count * optimizedScrollView.SpacedElementHeight);
			}).WaitForNextFrameUnscaled()
				.Then(delegate
				{
					optimizedScrollView.RefreshVisibleEntries(MonoSingleton<WorkersViewManager>.Instance.Workers.Count);
				});
		}

		private void OnWorkerListUpdate()
		{
			if (!(optimizedScrollView == null))
			{
				DelayedRefresh();
			}
		}

		protected void OnHoverToggle(Vector3 position, bool enabled)
		{
			Image[] array = markers;
			foreach (Image obj in array)
			{
				obj.rectTransform.SetPositionAndRotation(position, Quaternion.identity);
				obj.enabled = enabled;
			}
		}

		private void OnUpdateScrollAction(RectTransform rectTransform, int index)
		{
			if (MonoSingleton<WorkersViewManager>.Instance.Workers.Count <= index)
			{
				return;
			}
			WorkerPanelGroup component = rectTransform.GetComponent<WorkerPanelGroup>();
			try
			{
				component.SetWorker(MonoSingleton<WorkersViewManager>.Instance.Workers[index], this);
			}
			catch (Exception value)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\WorkerPanelManager.cs");
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
