using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class T_PalletMachineOutputTrigger : MonoBehaviour
{
	[Header("References")]
	[Tooltip("Palet makinesi referansı")]
	[SerializeField]
	private T_PalletMachine palletMachine;

	[Header("Settings")]
	[Tooltip("Çıkış slot indeksi (0 = eski palet, 1 = delivery palet)")]
	[SerializeField]
	private int outputSlotIndex;

	[Tooltip("Paletin yerleştirileceği hedef transform (öncelikli)")]
	[SerializeField]
	private Transform snapPoint;

	[Tooltip("Paletin yerleştirileceği local pozisyon (snapPoint yoksa kullanılır)")]
	[SerializeField]
	private Vector3 outputLocalPosition = Vector3.zero;

	[Tooltip("Paletin yerleştirileceği local rotasyon (snapPoint yoksa kullanılır)")]
	[SerializeField]
	private Vector3 outputLocalRotation = Vector3.zero;

	private uint _currentPalletNetId;

	private bool _isOccupied;

	private float _checkInterval = 0.1f;

	private float _lastCheckTime;

	private bool _palletInTriggerThisFrame;

	private bool _palletInTriggerLastCheck;

	public bool IsOccupied => _isOccupied;

	public uint CurrentPalletNetId => _currentPalletNetId;

	public int SlotIndex => outputSlotIndex;

	public Vector3 OutputWorldPosition
	{
		get
		{
			if (!(snapPoint != null))
			{
				return base.transform.TransformPoint(outputLocalPosition);
			}
			return snapPoint.position;
		}
	}

	public Quaternion OutputWorldRotation
	{
		get
		{
			if (!(snapPoint != null))
			{
				return base.transform.rotation * Quaternion.Euler(outputLocalRotation);
			}
			return snapPoint.rotation;
		}
	}

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component != null && !component.isTrigger)
		{
			Debug.LogWarning("[PalletMachineOutputTrigger] Collider trigger değil, otomatik düzeltiliyor.");
			component.isTrigger = true;
		}
	}

	private void Update()
	{
		if (NetworkServer.active && _isOccupied && _currentPalletNetId != 0 && !(Time.time - _lastCheckTime < _checkInterval))
		{
			_lastCheckTime = Time.time;
			_palletInTriggerLastCheck = _palletInTriggerThisFrame;
			_palletInTriggerThisFrame = false;
			if (!IsPalletStillValid())
			{
				Debug.Log($"[PalletMachineOutputTrigger] Slot {outputSlotIndex} - Palet artık geçerli değil, temizleniyor");
				ClearSlot();
			}
		}
	}

	private bool IsPalletStillValid()
	{
		if (!NetworkServer.spawned.TryGetValue(_currentPalletNetId, out var value))
		{
			return false;
		}
		T_Pallet component = value.GetComponent<T_Pallet>();
		if (component != null)
		{
			if (component.IsLifted)
			{
				return false;
			}
			if (!_palletInTriggerLastCheck)
			{
				BuildingObject component2 = component.GetComponent<BuildingObject>();
				if (component2 != null && component2.IsPlaced)
				{
					return false;
				}
			}
			return true;
		}
		T_DeliveryPallet component3 = value.GetComponent<T_DeliveryPallet>();
		if (component3 != null)
		{
			if (component3.IsLifted)
			{
				return false;
			}
			if (!_palletInTriggerLastCheck)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private void ClearSlot()
	{
		_isOccupied = false;
		_currentPalletNetId = 0u;
		if (palletMachine != null)
		{
			palletMachine.ServerOnOutputSlotCleared(outputSlotIndex);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!NetworkServer.active || _isOccupied)
		{
			return;
		}
		uint netId = 0u;
		if (TryGetPalletNetId(other, out netId) && netId != 0)
		{
			_isOccupied = true;
			_currentPalletNetId = netId;
			if (palletMachine != null)
			{
				palletMachine.ServerOnOutputSlotOccupied(outputSlotIndex, netId);
			}
			Debug.Log($"[PalletMachineOutputTrigger] Slot {outputSlotIndex} doldu - NetId: {netId}");
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (NetworkServer.active && _isOccupied)
		{
			uint netId = 0u;
			if (TryGetPalletNetId(other, out netId) && netId != 0 && netId == _currentPalletNetId)
			{
				_palletInTriggerThisFrame = true;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!NetworkServer.active || !_isOccupied)
		{
			return;
		}
		uint netId = 0u;
		if (!TryGetPalletNetId(other, out netId) || netId == 0 || netId != _currentPalletNetId)
		{
			return;
		}
		if (NetworkServer.spawned.TryGetValue(netId, out var value))
		{
			T_Pallet component = value.GetComponent<T_Pallet>();
			if (component != null)
			{
				BuildingObject component2 = component.GetComponent<BuildingObject>();
				if (component2 != null && !component2.IsPlaced)
				{
					Debug.Log($"[PalletMachineOutputTrigger] Slot {outputSlotIndex} - Palet çıktı ama IsPlaced değil, bekliyor");
					return;
				}
			}
		}
		_isOccupied = false;
		_currentPalletNetId = 0u;
		if (palletMachine != null)
		{
			palletMachine.ServerOnOutputSlotCleared(outputSlotIndex);
		}
		Debug.Log($"[PalletMachineOutputTrigger] Slot {outputSlotIndex} boşaldı");
	}

	private bool TryGetPalletNetId(Collider other, out uint netId)
	{
		netId = 0u;
		if (!other.CompareTag("Pallet"))
		{
			return false;
		}
		T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
		if (component != null && component.Pallet != null)
		{
			NetworkIdentity component2 = component.Pallet.GetComponent<NetworkIdentity>();
			if (component2 != null)
			{
				netId = component2.netId;
				return true;
			}
		}
		T_DeliveryPallet componentInParent = other.GetComponentInParent<T_DeliveryPallet>();
		if (componentInParent != null)
		{
			NetworkIdentity component3 = componentInParent.GetComponent<NetworkIdentity>();
			if (component3 != null)
			{
				netId = component3.netId;
				return true;
			}
		}
		return false;
	}

	public void ForceClear()
	{
		_isOccupied = false;
		_currentPalletNetId = 0u;
	}

	public void ForceOccupy(uint palletNetId)
	{
		_isOccupied = true;
		_currentPalletNetId = palletNetId;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = ((outputSlotIndex == 0) ? Color.yellow : Color.cyan);
		Vector3 outputWorldPosition = OutputWorldPosition;
		Quaternion outputWorldRotation = OutputWorldRotation;
		Gizmos.DrawWireCube(outputWorldPosition, new Vector3(1.5f, 0.2f, 1.5f));
		Gizmos.DrawLine(outputWorldPosition, outputWorldPosition + outputWorldRotation * Vector3.forward * 0.5f);
	}
}
