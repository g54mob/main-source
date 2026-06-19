using Player.Weapons;
using UI.HUD;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Player.RangedActions
{
	public class EnemySpotter : MonoBehaviour
	{
		[Header("Params")]
		[SerializeField]
		private float _spottingRange;

		[SerializeField]
		private float _checkInterval;

		[SerializeField]
		private LayerMask _checkMask;

		[Header("Links")]
		[SerializeField]
		private PlayerItemOutliner _itemOutliner;

		[SerializeField]
		private RocketLauncher _playerRocketLauncher;

		private float _checkTimer;

		private Collider _currentTarget;

		[Inject]
		private PlayerHUDView _playerHUD;

		[Inject]
		private IInventoryUIService _inventoryUI;

		private void Awake()
		{
			_playerHUD.LeadTargetIndicator.SetWeapon(_playerRocketLauncher);
		}

		private void OnDisable()
		{
			_currentTarget = null;
			_playerHUD.LeadTargetIndicator.ClearTarget();
			_itemOutliner.enabled = true;
			_playerHUD.WorldUIHighlighter.DisableHighlight();
		}

		private void Update()
		{
			if (!_inventoryUI.InventoryOpened)
			{
				_checkTimer += Time.deltaTime;
				if (_checkTimer >= _checkInterval)
				{
					_checkTimer = 0f;
					CheckForEnemies();
				}
				if (_currentTarget != null)
				{
					_playerHUD.WorldUIHighlighter.UpdateFrame(_currentTarget.bounds, Camera.main);
				}
			}
		}

		private void CheckForEnemies()
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, _spottingRange, _checkMask);
			Collider collider = null;
			float num = float.PositiveInfinity;
			Collider[] array2 = array;
			foreach (Collider collider2 in array2)
			{
				float num2 = Vector3.Distance(base.transform.position, collider2.transform.position);
				if (num2 < num)
				{
					num = num2;
					collider = collider2;
				}
			}
			if (collider != null)
			{
				_currentTarget = collider;
				_playerHUD.LeadTargetIndicator.SetTarget(collider.transform);
				_itemOutliner.enabled = false;
				_playerHUD.WorldUIHighlighter.EnableHighlight();
			}
			else
			{
				_currentTarget = null;
				_playerHUD.LeadTargetIndicator.ClearTarget();
				_itemOutliner.enabled = true;
				_playerHUD.WorldUIHighlighter.DisableHighlight();
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, _spottingRange);
		}
	}
}
