using JSAM;
using Loxodon.Framework.Contexts;
using Player;
using Services.Save;
using UI.HUD;
using UI.HUD.SystemInfo;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

namespace ComplexItems.SaveZone
{
	[RequireComponent(typeof(Collider))]
	public class SaveZoneObject : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _onTriggerEnter;

		[SerializeField]
		private UnityEvent _onTriggerExit;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private PlayerHUDView _hudView;

		private InfoCursorsViewModel _infoCursorsViewModel;

		private SystemInfoMessageSender _infoMessageSender;

		private Collider _triggerCollider;

		private bool _isPlayerInside;

		private PlayerBehaviour _playerInside;

		private void Awake()
		{
			_triggerCollider = GetComponent<Collider>();
		}

		private void OnEnable()
		{
			_saveService.OnSaveCompleted += OnSaveCompleted;
			_inputService.OnPlayerUse += SaveOnUse;
			_isPlayerInside = false;
			_playerInside = null;
		}

		private void OnDisable()
		{
			_saveService.OnSaveCompleted -= OnSaveCompleted;
			_inputService.OnPlayerUse -= SaveOnUse;
			_isPlayerInside = false;
			_playerInside = null;
		}

		private void OnSaveCompleted()
		{
			_infoMessageSender.SendSaveMessage();
		}

		private void Start()
		{
			_infoCursorsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			_infoMessageSender = _hudView.InfoMessageSender;
		}

		private void OnTriggerEnter(Collider other)
		{
			PlayerBehaviour component = other.GetComponent<PlayerBehaviour>();
			if ((object)component != null)
			{
				_isPlayerInside = true;
				_playerInside = component;
				_infoCursorsViewModel.EnableUseHintSeperately(value: true, "To Save");
				_onTriggerEnter?.Invoke();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ((bool)other.GetComponent<PlayerBehaviour>())
			{
				_isPlayerInside = false;
				_playerInside = null;
				_infoCursorsViewModel.EnableUseHintSeperately(value: false);
				_onTriggerExit?.Invoke();
			}
		}

		private bool IsPlayerStillInsideTrigger()
		{
			if (_playerInside == null)
			{
				return false;
			}
			if (_triggerCollider == null)
			{
				return false;
			}
			Collider characterController = _playerInside.CharacterController;
			if (characterController == null)
			{
				return true;
			}
			Vector3 direction;
			float distance;
			return Physics.ComputePenetration(_triggerCollider, _triggerCollider.transform.position, _triggerCollider.transform.rotation, characterController, characterController.transform.position, characterController.transform.rotation, out direction, out distance);
		}

		private void SaveOnUse(InputAction.CallbackContext context)
		{
			if (context.performed && _isPlayerInside)
			{
				if (!IsPlayerStillInsideTrigger())
				{
					_isPlayerInside = false;
					_playerInside = null;
					_infoCursorsViewModel?.EnableUseHintSeperately(value: false);
				}
				else
				{
					AudioManager.PlaySound(AmbientLibrarySounds.ToiletFlush);
					_saveService.SaveAll();
				}
			}
		}
	}
}
