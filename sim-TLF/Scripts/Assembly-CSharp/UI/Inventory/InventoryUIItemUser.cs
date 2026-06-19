using AssembleSystem;
using Items;
using Items.Box;
using JSAM;
using Player;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemUser : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _inventoryRaycaster;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		private void OnEnable()
		{
			_playerInputService.OnInventoryUse += OnItemUse;
		}

		private void OnDisable()
		{
			_playerInputService.OnInventoryUse -= OnItemUse;
		}

		private void OnItemUse(bool pressed)
		{
			if (!pressed)
			{
				return;
			}
			Transform transform = _inventoryRaycaster.Hit.transform;
			if (transform == null)
			{
				return;
			}
			Debug.Log("On Item Use " + transform);
			if (!transform.TryGetComponent<IUsable>(out var component) || component is ItemBoxView)
			{
				return;
			}
			MonoBehaviour monoBehaviour = component as MonoBehaviour;
			if (!(monoBehaviour == null) && !(monoBehaviour.gameObject == null))
			{
				string targetName = monoBehaviour.gameObject.name.Replace("(Clone)", "");
				if (_inventoryService.Items.Find(delegate(IInventoryManagable x)
				{
					MonoBehaviour monoBehaviour3 = x as MonoBehaviour;
					return monoBehaviour3 != null && monoBehaviour3.gameObject != null && monoBehaviour3.gameObject.name == targetName;
				}) is MonoBehaviour monoBehaviour2 && monoBehaviour2 != null)
				{
					Debug.Log("Removing " + monoBehaviour2.gameObject.name);
				}
				component.Use();
				AudioManager.PlaySound(InteractionLibrarySounds.UseItem);
			}
		}
	}
}
