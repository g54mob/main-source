using Logic.Factory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.FactoryFloor
{
	public class GameModeSwap : MonoBehaviour
	{
		[SerializeField]
		private EditorModeSO _levelEditorMode;

		[SerializeField]
		private CampaignModeSO _campaignMode;

		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private InputActionReference _swapGameModeInput;

		private void Start()
		{
			_swapGameModeInput.action.performed += SwapEditingLayer;
		}

		private void OnDestroy()
		{
			_swapGameModeInput.action.performed -= SwapEditingLayer;
		}

		private void SwapEditingLayer(InputAction.CallbackContext obj)
		{
			if (_currentGameMode.Mode == _campaignMode)
			{
				_currentGameMode.SwitchTo(_levelEditorMode);
			}
			else
			{
				_currentGameMode.SwitchTo(_campaignMode);
			}
		}
	}
}
