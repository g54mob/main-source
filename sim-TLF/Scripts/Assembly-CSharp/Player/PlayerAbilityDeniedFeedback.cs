using JSAM;
using StarterAssets;
using UI.HUD;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerAbilityDeniedFeedback : MonoBehaviour
	{
		[Header("Abilities")]
		[SerializeField]
		private FirstPersonController _firstPersonController;

		[SerializeField]
		private PlayerViewZoomer _viewZoomer;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private PlayerHUDView _hudView;

		private void OnEnable()
		{
			_inputService.OnSprint += HandleSprintInput;
			_inputService.OnZoom += HandleZoomInput;
		}

		private void OnDisable()
		{
			_inputService.OnSprint -= HandleSprintInput;
			_inputService.OnZoom -= HandleZoomInput;
		}

		private void HandleSprintInput(bool pressed)
		{
			if (pressed && !(_firstPersonController == null) && !_firstPersonController.CanSprint)
			{
				ReportDenied(_hudView?.StatsView?.NicotineStatRow);
			}
		}

		private void HandleZoomInput(InputAction.CallbackContext context)
		{
			if (context.started && !(_viewZoomer == null) && !_viewZoomer.CanZoom)
			{
				ReportDenied(_hudView?.StatsView?.AlcoholStatRow);
			}
		}

		private void ReportDenied(StatSliderView statRow)
		{
			if (!(statRow == null) && statRow.PlayDeniedFeedback())
			{
				AudioManager.PlaySound(UILibrarySounds.UIRecieptCantBuild);
			}
		}
	}
}
