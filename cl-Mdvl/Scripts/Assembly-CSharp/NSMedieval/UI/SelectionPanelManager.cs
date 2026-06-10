using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Sound;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SelectionPanelManager : PanelBase
	{
		[SerializeField]
		private SelectionPanelView panelView;

		private const float UpdateFrequency = 0.2f;

		private float timeSinceLastUpdate;

		private int panelObjectId;

		private Func<InfoPanelData> updateCallback;

		private bool playSelectSound = true;

		public int PanelObjectId => panelObjectId;

		public SelectionPanelView PanelView => panelView;

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.LowerRight;
		}

		public void OnSelectUpdate(SelectableObject selectableObject)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(51, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\SelectionPanelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnSelectUpdate: ");
				messageBuilder.AppendFormatted(selectableObject);
				messageBuilder.AppendLiteral(", selected: ");
				messageBuilder.AppendFormatted(selectableObject.Selected);
				messageBuilder.AppendLiteral(" total selected count: ");
				messageBuilder.AppendFormatted(MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count);
			}
			Log.Debug(messageBuilder);
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count == 1)
			{
				InfoPanelData infoPanelData = selectableObject.GetInfoPanelData();
				if (infoPanelData != null)
				{
					ShowPanel(infoPanelData, selectableObject.gameObject.GetInstanceID(), selectableObject.UpdateCallback);
					MonoSingleton<UIController>.Instance.NotifySelectionPanelToggle(visible: true);
				}
			}
			else
			{
				panelView.ResetTabIndex();
				ShowPanel(MultiSelectPanelManager.GetInfoPanelData(selectableObject), 0, MultiSelectPanelManager.UpdateCallback);
				MonoSingleton<UIController>.Instance.NotifySelectionPanelToggle(visible: true);
			}
		}

		public void OnDeSelectUpdate(List<SelectableObject> deselectedObjects)
		{
			SelectableObject selectableObject = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.FirstOrDefault((SelectableObject obj) => obj.Selected);
			int num = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count;
			bool flag = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Intersect(deselectedObjects).Any();
			if (flag)
			{
				num--;
				if (num >= 2)
				{
					foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
					{
						if (!deselectedObjects.Contains(selectedObject))
						{
							selectableObject = selectedObject;
							break;
						}
					}
				}
			}
			if (num <= 0 || (num == 1 && flag) || selectableObject == null)
			{
				Hide();
			}
			else
			{
				OnSelectUpdate(selectableObject);
			}
		}

		public void ShowPanel(InfoPanelData infoPanelData, int instanceId, Func<InfoPanelData> updateCallback)
		{
			if (!base.Initialized)
			{
				panelView.Initialize();
			}
			if (playSelectSound)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_Select");
				playSelectSound = false;
			}
			this.updateCallback = updateCallback;
			panelObjectId = instanceId;
			Show();
			panelView.SetupPanel(infoPanelData);
			timeSinceLastUpdate = 0.2f;
		}

		public override void Hide()
		{
			updateCallback = null;
			base.Hide();
			panelView?.Hide();
			playSelectSound = true;
			MonoSingleton<UIController>.Instance.NotifySelectionPanelToggle(visible: false);
			MonoSingleton<UIController>.Instance.HideSelectionHighlight();
			MultiSelectPanelManager.ClearObjectsBySelectName();
		}

		protected override void EscKeySubscribe()
		{
			MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, base.gameObject);
		}

		protected override void EscKeyUnsubscribe()
		{
			MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, base.gameObject);
		}

		protected override void UpdatePanel()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MonoSingleton<SelectableObjectController>.Instance.DataUpdatedEvent += UpdateImmediate;
			MonoSingleton<SceneController>.Instance.UnscaledTick += UnscaledTick;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			updateCallback = null;
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.DataUpdatedEvent -= UpdateImmediate;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.UnscaledTick -= UnscaledTick;
			}
		}

		private void UnscaledTick(float deltaTime)
		{
			if (!LoadingController.IsLeavingMainScene && !LoadingController.IsSceneTransition)
			{
				timeSinceLastUpdate += deltaTime;
				if (!(timeSinceLastUpdate < 0.2f))
				{
					timeSinceLastUpdate = 0f;
					UpdateImmediate();
				}
			}
		}

		private void UpdateImmediate()
		{
			if (updateCallback != null)
			{
				InfoPanelData infoPanelData = updateCallback();
				if (infoPanelData != null)
				{
					panelView.UpdatePanelTick(infoPanelData);
				}
			}
		}
	}
}
