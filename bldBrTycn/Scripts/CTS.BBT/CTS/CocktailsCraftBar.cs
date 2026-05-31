using System;
using System.Linq;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CocktailsCraftBar : MonoSingleton<CocktailsCraftBar>
	{
		[SerializeField]
		private CameraFadeTraveling cameraBar;

		private MenuScreen _barUI;

		private float currentTimeScale;

		private CameraFadeTraveling _cameraCraftBar;

		public static event Action OnCraftBarEnter;

		public static event Action OnCraftBarExit;

		private void Start()
		{
			CraftBarButton.Instance.onButtonClick += GoToCraftBar;
			_cameraCraftBar = GetComponentInChildren<CameraFadeTraveling>();
			_barUI = (from x in UnityEngine.Object.FindObjectsOfType<MenuScreen>(includeInactive: true)
				where x.name == "BarUI"
				select x).ToArray()[0];
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void SingletonAwake()
		{
		}

		public void GoToCraftBar()
		{
			CraftBarButton.Instance.EnableButton(p_enable: false);
			CraftBarButton.Instance.onButtonClick -= GoToCraftBar;
			CameraFadeTraveling cameraFadeTraveling = cameraBar;
			cameraFadeTraveling.onFinishedMovement = (Action)Delegate.Combine(cameraFadeTraveling.onFinishedMovement, new Action(OnBarCameraGoToCraftBar));
			cameraBar.TestTravelingStart();
			MonoSingleton<FurnitureShop>.Instance?.SetFurnitureShopOpen(p_value: false);
			CocktailsCraftBar.OnCraftBarEnter?.Invoke();
		}

		public void QuitCraftBar()
		{
			BarButton.Instance.EnableButton(p_enable: false);
			MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
			CameraFadeTraveling cameraCraftBar = _cameraCraftBar;
			cameraCraftBar.onFinishedMovement = (Action)Delegate.Combine(cameraCraftBar.onFinishedMovement, new Action(OnCraftBarCameraGoToBar));
			_cameraCraftBar.TestBackTraveling();
			BarButton.Instance.onButtonClick -= QuitCraftBar;
		}

		private void OnBarCameraGoToCraftBar()
		{
			cameraBar.TeleportMeToMainCamera();
			_cameraCraftBar.TeleportMainCameraHere();
			CameraFadeTraveling cameraCraftBar = _cameraCraftBar;
			cameraCraftBar.onFinishedMovement = (Action)Delegate.Combine(cameraCraftBar.onFinishedMovement, new Action(OnCameraAgentEnterInCraftBar));
			_cameraCraftBar.TestTravelingStart();
			_barUI.gameObject.SetActive(value: false);
			CameraFadeTraveling cameraFadeTraveling = cameraBar;
			cameraFadeTraveling.onFinishedMovement = (Action)Delegate.Remove(cameraFadeTraveling.onFinishedMovement, new Action(OnBarCameraGoToCraftBar));
		}

		private void OnCameraAgentEnterInCraftBar()
		{
			CameraFadeTraveling cameraCraftBar = _cameraCraftBar;
			cameraCraftBar.onFinishedMovement = (Action)Delegate.Remove(cameraCraftBar.onFinishedMovement, new Action(OnCameraAgentEnterInCraftBar));
			BarButton.Instance.onButtonClick += QuitCraftBar;
			BarButton.Instance.EnableButton(p_enable: true);
		}

		public void OnCraftBarCameraGoToBar()
		{
			cameraBar.TeleportMainCameraHere();
			_barUI.gameObject.SetActive(value: true);
			cameraBar.TestBackTraveling();
			CameraFadeTraveling cameraCraftBar = _cameraCraftBar;
			cameraCraftBar.onFinishedMovement = (Action)Delegate.Remove(cameraCraftBar.onFinishedMovement, new Action(OnCraftBarCameraGoToBar));
			CocktailsCraftBar.OnCraftBarExit?.Invoke();
		}

		private void UnlockGoToCraftBarButton()
		{
			CraftBarButton.Instance.onButtonClick += GoToCraftBar;
			CameraFadeTraveling cameraFadeTraveling = cameraBar;
			cameraFadeTraveling.onFinishedMovement = (Action)Delegate.Remove(cameraFadeTraveling.onFinishedMovement, new Action(UnlockGoToCraftBarButton));
			CraftBarButton.Instance.EnableButton(p_enable: true);
		}
	}
}
