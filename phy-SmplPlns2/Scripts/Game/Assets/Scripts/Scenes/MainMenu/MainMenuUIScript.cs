using System.Collections;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Scenes.Startup;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Scenes.MainMenu
{
	public class MainMenuUIScript : MonoBehaviour
	{
		private WidgetContext _context;

		private CustomizeCharacterScript _customizeFlyout;

		[SerializeField]
		private GameObject _environmentPrefab;

		private Widget _mainUI;

		private TextWidget _versionText;

		protected virtual void LateUpdate()
		{
			_context?.LateUpdate();
		}

		protected virtual void Start()
		{
			Game.Instance.OnStartup();
			GameObject obj = Object.Instantiate(_environmentPrefab);
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			_context = Game.Instance.UserInterface.CreateContext(GetComponent<RectTransform>(), this);
			_context.LoadWidgetFromXml("Xml/MainMenu/MainMenuUI", null);
			_context.Root.EventHandler = this;
			_mainUI = _context.Root.FindWidget("main-ui");
			_versionText = _context.Root.FindWidget<TextWidget>("version-text");
			_versionText.Text = $"v{Game.Version}";
			if (Game.Instance.Device.IsOsxBuild)
			{
				StartCoroutine(ToggleHdrHack());
			}
		}

		protected virtual void Update()
		{
			if (!SimplePlanesDevConsoleScript.IsConsoleOpen && Game.Instance.UserInterface.AllowKeyboardInputs && Game.Inputs.LoadClipboardAircraft.GetButtonDownIfEnabled())
			{
				Game.Instance.SceneManager.LoadDesigner(delegate
				{
					Designer.Instance.DesignerScript.LoadAircraftFromClipboardOrUrl();
				});
			}
		}

		private async void OnBuildClicked(Widget widget)
		{
			widget.Interactable = false;
			await UniTask.WaitForSeconds(0.35f);
			Game.Instance.SceneManager.LoadDesigner();
		}

		private void OnCloseFlyDialogClicked(Widget widget)
		{
			Widget flyDialog = _context.Root.FindWidget("fly-dialog");
			_context.Root.FindWidget("fly-dialog-panel").Hide(delegate
			{
				flyDialog.Visible = false;
			}, force: true);
		}

		private void OnCreateServerClicked(Widget widget)
		{
			OnCloseFlyDialogClicked(null);
			Game.Instance.UserInterface.CreateCreateServerDialog();
		}

		private void OnCustomizeCharacterClicked(Widget widget)
		{
			if (_customizeFlyout == null)
			{
				_customizeFlyout = Game.Instance.UserInterface.CreateCustomizeCharacterFlyout();
				_customizeFlyout.Flyout.Closed += OnCustomizeCharacterClosed;
			}
		}

		private void OnCustomizeCharacterClosed(IFlyout flyout)
		{
			_customizeFlyout = null;
		}

		private void OnExitClicked(Widget widget)
		{
			Application.Quit();
		}

		private void OnFlyClicked(Widget widget)
		{
			_context.Root.FindWidget("fly-dialog").Visible = true;
			_context.Root.FindWidget("fly-dialog-panel").Show(force: true);
		}

		private async void OnFlySoloClicked(Widget widget)
		{
			widget.Interactable = false;
			await UniTask.WaitForSeconds(0.35f);
			FlightSceneScript.IsPeacefulMode = false;
			Game.Instance.SceneManager.LoadFlight();
		}

		private void OnJoinServerClicked(Widget widget)
		{
			OnCloseFlyDialogClicked(null);
			Game.Instance.UserInterface.CreateServerBrowserDialog();
		}

		private void OnNewsClicked(Widget widget)
		{
			_context.Root.FindWidget("flyout-news").Show();
		}

		private void OnServerBrowserClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateServerBrowserDialog();
		}

		private void OnSettingsClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateSettingsDialog();
		}

		private IEnumerator ToggleHdrHack()
		{
			UniversalRenderPipelineAsset urpAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (urpAsset?.supportsHDR ?? false)
			{
				urpAsset.supportsHDR = false;
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				urpAsset.supportsHDR = true;
			}
		}
	}
}
