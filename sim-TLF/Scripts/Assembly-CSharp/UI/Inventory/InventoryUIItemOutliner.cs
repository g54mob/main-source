using Items;
using Player;
using Player.FSM;
using Player.RangedActions;
using UI.HUD;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemOutliner : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerDescriberViewInfo;

		[SerializeField]
		private Camera _inventoryCamera;

		private Collider _outlinedObject;

		private bool _objectSetFromOutside;

		private PlayerItemOutliner _playerItemOutliner;

		private EnemySpotter _enemySpotter;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerParametersManipulator;

		[Inject]
		private PlayerHUDView _hudView;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		private WorldUIOutliner _worldUIOutliner;

		private void Awake()
		{
			Transform root = (_playerParametersManipulator as PlayerBehaviourStateMachine).transform.root;
			_worldUIOutliner = _hudView.WorldUIHighlighter;
			_playerItemOutliner = root.GetComponent<PlayerItemOutliner>();
			_enemySpotter = root.GetComponentInChildren<EnemySpotter>();
		}

		private void OnEnable()
		{
			_playerItemOutliner.ClearOutlinedObject();
			_playerItemOutliner.enabled = false;
			_enemySpotter.enabled = false;
		}

		private void OnDisable()
		{
			IEquipable equipableAt = _playerEquipService.GetEquipableAt(EquipSide.RIGHT_HAND);
			if (equipableAt != null && equipableAt is EquipableWeaponItem)
			{
				_enemySpotter.enabled = true;
			}
			else
			{
				_enemySpotter.enabled = false;
			}
			_playerItemOutliner.enabled = true;
		}

		private void Update()
		{
			if (!_objectSetFromOutside)
			{
				TrySetOtlinedObjectInternally();
			}
		}

		private void LateUpdate()
		{
			if (_outlinedObject != null)
			{
				_worldUIOutliner.EnableHighlight();
				_worldUIOutliner.UpdateFrame(_outlinedObject.bounds, _inventoryCamera, _hudView.InventoryViewRenderImage, _hudView.InventoryView.RectTransform.anchoredPosition);
			}
			else
			{
				_worldUIOutliner.DisableHighlight();
			}
		}

		public void SetOutlinedObject(Collider collider)
		{
			_outlinedObject = collider;
			_objectSetFromOutside = true;
		}

		public void ClearOutlinedObject()
		{
			_outlinedObject = null;
			_objectSetFromOutside = false;
		}

		private void TrySetOtlinedObjectInternally()
		{
			if (_playerDescriberViewInfo.Hit.transform != null)
			{
				_outlinedObject = _playerDescriberViewInfo.Hit.collider;
			}
			else
			{
				_outlinedObject = null;
			}
		}
	}
}
