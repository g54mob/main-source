using System;
using Restory.AssetManagement.References;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.Disclaimer
{
	public class GUI_DisclaimerPanel : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private Button okButton;

		[SerializeField]
		private GameScenesAssetRef gamePresetToLoadRef;

		[SerializeField]
		private CanvasGroup canvasGroup;

		private GlobalStateMachine stateMachine;

		[Inject]
		private void Construct(GlobalStateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		public void Initialize()
		{
			if (stateMachine.ActiveState is MainMenuState)
			{
				okButton.onClick.AddListener(ResolveOnClick);
			}
			else
			{
				stateMachine.OnStateEntered += ResolveStateChanged;
			}
		}

		public void Dispose()
		{
			okButton.onClick.RemoveListener(ResolveOnClick);
			if (stateMachine != null)
			{
				stateMachine.OnStateEntered -= ResolveStateChanged;
			}
		}

		private void ResolveStateChanged()
		{
			if (stateMachine.ActiveState is MainMenuState)
			{
				stateMachine.OnStateEntered -= ResolveStateChanged;
				okButton.onClick.AddListener(ResolveOnClick);
				canvasGroup.alpha = 1f;
				canvasGroup.interactable = true;
			}
		}

		private void ResolveOnClick()
		{
			okButton.interactable = false;
			stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(gamePresetToLoadRef);
		}
	}
}
