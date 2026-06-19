using System;
using Loxodon.Framework.Contexts;
using Michsky.DreamOS;
using Player;
using UI.HUD;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Computer.World
{
	public class WorldComputerEventSetter : MonoBehaviour
	{
		[SerializeField]
		private WorldSpaceManager _worldSpaceManager;

		[Inject]
		private IPlayerInputService _inputService;

		private InfoCursorsViewModel _infoCursorsViewModel;

		public event Action OnEnter;

		private void Start()
		{
			_infoCursorsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void OnEnable()
		{
			_worldSpaceManager.onEnter.AddListener(OnComputerEnter);
			_worldSpaceManager.onExit.AddListener(OnComputerExit);
			_worldSpaceManager.onTriggerEnter.AddListener(ShowEnterHint);
			_worldSpaceManager.onTriggerExit.AddListener(HideEnterHint);
		}

		private void OnDisable()
		{
			_worldSpaceManager.onEnter.RemoveListener(OnComputerEnter);
			_worldSpaceManager.onExit.RemoveListener(OnComputerExit);
			_worldSpaceManager.onTriggerEnter.RemoveListener(ShowEnterHint);
			_worldSpaceManager.onTriggerExit.RemoveListener(HideEnterHint);
		}

		private void Update()
		{
			if (!(_worldSpaceManager == null) && _worldSpaceManager.isInSystem)
			{
				Keyboard current = Keyboard.current;
				if (current != null && current.escapeKey.wasPressedThisFrame)
				{
					_worldSpaceManager.GetOut();
				}
			}
		}

		private void HideEnterHint()
		{
			_infoCursorsViewModel.EnableUseHintSeperately(value: false);
		}

		private void ShowEnterHint()
		{
			_infoCursorsViewModel.EnableUseHintSeperately(value: true, "To Enter PC");
		}

		private void OnComputerExit()
		{
			CursorLockKeeper.Apply(CursorLockMode.Locked, visible: false);
			AudioManager.instance.audioSource.enabled = false;
			_inputService.EnableAllInput();
		}

		private void OnComputerEnter()
		{
			this.OnEnter?.Invoke();
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
			AudioManager.instance.audioSource.enabled = true;
			_inputService.DisableAllInput();
		}
	}
}
