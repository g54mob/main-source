using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Sound;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SceneUIManager : MonoSingleton<SceneUIManager>
	{
		[SerializeField]
		private ClosableUIView loadingView;

		[SerializeField]
		private RoadmapView roadmapView;

		private ClosableUIView[] views = Array.Empty<ClosableUIView>();

		private PanelBase[] panels = Array.Empty<PanelBase>();

		private ClosableUIView previousView;

		private ClosableUIView currentView;

		public event Action<string> OnPanelOpenEvent;

		public event Action<string> OnPanelHideEvent;

		public event Action<string, bool> PanelToggleEvent;

		public event Action<string> OnViewShownEvent;

		public event Action OnProductionPanelOpenEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnProductionPanelOpenEvent = null;
			this.OnViewShownEvent = null;
			this.OnPanelOpenEvent = null;
			this.OnPanelHideEvent = null;
		}

		public void NotifyPanelToggle(string panelName, bool isOn)
		{
			this.PanelToggleEvent?.Invoke(panelName, isOn);
		}

		public void SetPanelOpen(string panelName)
		{
			PanelBase panelBase = FindPanel(panelName);
			if (!panelBase.MainPanel.activeSelf)
			{
				panelBase.OnPanelToggle();
				PanelOpen(panelName);
			}
		}

		public void TogglePanelTab(string panelName, int tabIndex)
		{
			FindPanel(panelName).OnPanelToggleTab(tabIndex);
			PanelOpen(panelName);
		}

		public void TogglePanel(string panelName)
		{
			PanelBase panelBase = FindPanel(panelName);
			panelBase.OnPanelToggle();
			if (panelBase.isActiveAndEnabled)
			{
				PanelOpen(panelName);
			}
		}

		public void TogglePanel(string panelName, string toggleEventId)
		{
			TogglePanel(panelName);
			float value = (FindPanel(panelName).gameObject.activeInHierarchy ? 0.1f : 0f);
			MonoSingleton<AudioManager>.Instance.PlaySound(toggleEventId, new Dictionary<string, float> { { "Enabled", value } });
		}

		public void PanelOpen(string panelName)
		{
			if (MonoSingleton<UIController>.Instance.GameStarted)
			{
				this.OnPanelOpenEvent?.Invoke(panelName);
			}
		}

		public void OnProductionPanelOpen()
		{
			this.OnProductionPanelOpenEvent?.Invoke();
		}

		public void RegisterCurrentView(ClosableUIView view)
		{
			currentView = view;
		}

		public void ShowNewView(ClosableUIView closableUIView)
		{
			SwitchViews(closableUIView);
		}

		public void ShowNewView(string newView)
		{
			SwitchViews(FindView(newView));
		}

		public void ShowPreviousView()
		{
			if ((bool)previousView)
			{
				SwitchViews(previousView);
			}
			else
			{
				CloseAllViews();
			}
		}

		public void CloseAllViews()
		{
			ClosableUIView[] array = views;
			foreach (ClosableUIView closableUIView in array)
			{
				if (closableUIView.isActiveAndEnabled && !closableUIView.name.Equals("HeraldryEditorView"))
				{
					closableUIView.Hide();
				}
			}
		}

		private void SwitchViews(ClosableUIView newView)
		{
			if (newView != null)
			{
				if ((bool)currentView && currentView != newView && currentView.name != "InGameMenuView")
				{
					currentView.Hide();
				}
				previousView = currentView;
				currentView = newView;
				currentView.Show();
				this.OnViewShownEvent?.Invoke(newView.name);
			}
		}

		public ClosableUIView FindView(string newView)
		{
			ClosableUIView[] array = views;
			foreach (ClosableUIView closableUIView in array)
			{
				if (closableUIView.name == newView)
				{
					return closableUIView;
				}
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\SceneUIManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("A 'UIView' type class named '");
				messageBuilder.AppendFormatted(newView);
				messageBuilder.AppendLiteral("' could not be find in ");
				messageBuilder.AppendFormatted(base.name);
				messageBuilder.AppendLiteral(" children!");
			}
			Log.Error(messageBuilder);
			return null;
		}

		public PanelBase FindPanel(string newPanel)
		{
			PanelBase[] array = panels;
			foreach (PanelBase panelBase in array)
			{
				if (panelBase.name == newPanel)
				{
					return panelBase;
				}
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(65, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\SceneUIManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("A 'PanelBase' type class named '");
				messageBuilder.AppendFormatted(newPanel);
				messageBuilder.AppendLiteral("' could not be find in ");
				messageBuilder.AppendFormatted(base.name);
				messageBuilder.AppendLiteral(" children!");
			}
			Log.Error(messageBuilder);
			return null;
		}

		private void Start()
		{
			if (loadingView != null)
			{
				loadingView.Show();
			}
			views = GetComponentsInChildren<ClosableUIView>(includeInactive: true);
			panels = GetComponentsInChildren<PanelBase>(includeInactive: true);
		}

		public void OnPanelHide(string panelName)
		{
			this.OnPanelHideEvent?.Invoke(panelName);
		}
	}
}
