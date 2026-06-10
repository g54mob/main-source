using Controller;
using NSMedieval;
using NSMedieval.Manager;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using UnityEngine;

namespace NSEipix.Base
{
	public class PopupView : View, IObserver
	{
		private GameObject mainView;

		protected virtual GameObject MainView
		{
			get
			{
				if (mainView == null)
				{
					mainView = base.gameObject;
				}
				return mainView;
			}
			set
			{
				mainView = value;
			}
		}

		protected virtual void OnShow()
		{
			MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, MainView);
		}

		protected virtual void OnHide()
		{
			MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, MainView);
		}

		protected void Show()
		{
			if (!IsShowing())
			{
				MainView.SetActive(value: true);
				if (!TutorialManager.IsTutorialActive)
				{
					MonoSingleton<GameplayPauseManager>.Instance.Register(this);
				}
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
				MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: true);
				MonoSingleton<AnalyticsManager>.Instance.OnScreenVisit(base.name);
				MonoSingleton<UIController>.Instance.PopupsActive++;
				if (MonoSingleton<CameraManager>.IsInstantiated())
				{
					MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: true);
				}
				OnShow();
			}
		}

		public virtual void Hide()
		{
			if (!IsShowing())
			{
				return;
			}
			MainView.SetActive(value: false);
			if (!TutorialManager.IsTutorialActive)
			{
				MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			}
			MonoSingleton<RtsCamera>.Instance.BlockCameraMovement(block: false);
			MonoSingleton<UIController>.Instance.PopupsActive--;
			if (MonoSingleton<UIController>.Instance.PopupsActive <= 0)
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
				if (MonoSingleton<CameraManager>.IsInstantiated())
				{
					MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
				}
			}
			OnHide();
		}

		public bool IsShowing()
		{
			return MainView.activeInHierarchy;
		}
	}
}
