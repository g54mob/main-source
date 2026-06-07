using Mirror;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class T_PalletMachineInputTrigger : MonoBehaviour
{
	[Header("References")]
	[Tooltip("Palet makinesi referansı")]
	[SerializeField]
	private T_PalletMachine palletMachine;

	[Header("Snap Settings")]
	[Tooltip("Paletin kilitleneceği hedef transform (öncelikli)")]
	[SerializeField]
	private Transform snapPoint;

	[Tooltip("Paletin kilitleneceği local pozisyon (snapPoint yoksa kullanılır)")]
	[SerializeField]
	private Vector3 snapLocalPosition = Vector3.zero;

	[Tooltip("Paletin kilitleneceği local rotasyon (snapPoint yoksa kullanılır)")]
	[SerializeField]
	private Vector3 snapLocalRotation = Vector3.zero;

	private T_Pallet _currentPallet;

	private uint _currentPalletNetId;

	private float _checkInterval = 0.5f;

	private float _lastCheckTime;

	public bool HasPallet
	{
		get
		{
			if (_currentPallet != null)
			{
				return _currentPalletNetId != 0;
			}
			return false;
		}
	}

	public uint CurrentPalletNetId => _currentPalletNetId;

	public T_Pallet CurrentPallet => _currentPallet;

	private void Awake()
	{
		Collider component = GetComponent<Collider>();
		if (component != null && !component.isTrigger)
		{
			Debug.LogWarning("[PalletMachineInputTrigger] Collider trigger değil, otomatik düzeltiliyor.");
			component.isTrigger = true;
		}
	}

	private void Update()
	{
		if (NetworkServer.active && HasPallet && !(Time.time - _lastCheckTime < _checkInterval))
		{
			_lastCheckTime = Time.time;
			if (!IsPalletStillValid())
			{
				Debug.Log("[PalletMachineInputTrigger] Palet artık geçerli değil, temizleniyor");
				ReleasePallet();
			}
		}
	}

	private bool IsPalletStillValid()
	{
		if (_currentPallet == null)
		{
			return false;
		}
		if (_currentPallet.IsLifted)
		{
			return false;
		}
		NetworkIdentity component = _currentPallet.GetComponent<NetworkIdentity>();
		if (component == null || component.netId != _currentPalletNetId)
		{
			return false;
		}
		return true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!NetworkServer.active || HasPallet || !other.CompareTag("Pallet"))
		{
			return;
		}
		T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
		if (component == null)
		{
			return;
		}
		T_Pallet pallet = component.Pallet;
		if (!(pallet == null) && (!(pallet.buildingObject != null) || pallet.buildingObject.IsPlaced))
		{
			NetworkIdentity component2 = pallet.GetComponent<NetworkIdentity>();
			if (!(component2 == null) && !pallet.IsLifted)
			{
				AcceptPallet(pallet, component2);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!NetworkServer.active || HasPallet || !other.CompareTag("Pallet"))
		{
			return;
		}
		T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
		if (component == null)
		{
			return;
		}
		T_Pallet pallet = component.Pallet;
		if (!(pallet == null) && (!(pallet.buildingObject != null) || pallet.buildingObject.IsPlaced))
		{
			NetworkIdentity component2 = pallet.GetComponent<NetworkIdentity>();
			if (!(component2 == null) && !pallet.IsLifted)
			{
				AcceptPallet(pallet, component2);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!NetworkServer.active || !HasPallet || !other.CompareTag("Pallet"))
		{
			return;
		}
		T_PalletInputTrigger component = other.GetComponent<T_PalletInputTrigger>();
		if (component == null)
		{
			return;
		}
		T_Pallet pallet = component.Pallet;
		if (!(pallet == null))
		{
			NetworkIdentity component2 = pallet.GetComponent<NetworkIdentity>();
			if (!(component2 == null) && component2.netId == _currentPalletNetId)
			{
				ReleasePallet();
			}
		}
	}

	private void AcceptPallet(T_Pallet pallet, NetworkIdentity palletNi)
	{
		_currentPallet = pallet;
		_currentPalletNetId = palletNi.netId;
		SnapPalletToPosition(pallet);
		if (palletMachine != null)
		{
			palletMachine.ServerOnPalletEnter(pallet);
		}
		Debug.Log($"[PalletMachineInputTrigger] Palet kabul edildi - NetId: {_currentPalletNetId}");
	}

	private void ReleasePallet()
	{
		T_Pallet currentPallet = _currentPallet;
		_currentPallet = null;
		_currentPalletNetId = 0u;
		if (palletMachine != null && currentPallet != null)
		{
			palletMachine.ServerOnPalletExit(currentPallet);
		}
		Debug.Log("[PalletMachineInputTrigger] Palet serbest bırakıldı");
	}

	private void SnapPalletToPosition(T_Pallet pallet)
	{
		if (!(pallet == null))
		{
			Transform obj = pallet.transform;
			NetworkTransformHybrid component = pallet.GetComponent<NetworkTransformHybrid>();
			if (component != null)
			{
				component.enabled = false;
			}
			Transform transform = palletMachine?.GetInputSnapPoint();
			Vector3 vector = (obj.position = ((transform != null) ? transform.position : ((!(snapPoint != null)) ? base.transform.TransformPoint(snapLocalPosition) : snapPoint.position)));
			if (component != null)
			{
				component.enabled = true;
			}
			Debug.Log($"[PalletMachineInputTrigger] Palet snap pozisyonuna kilitlendi - Pos: {vector}");
		}
	}

	public void ClearCurrentPallet()
	{
		_currentPallet = null;
		_currentPalletNetId = 0u;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Vector3 vector;
		Quaternion quaternion;
		if (snapPoint != null)
		{
			vector = snapPoint.position;
			quaternion = snapPoint.rotation;
		}
		else
		{
			vector = base.transform.TransformPoint(snapLocalPosition);
			quaternion = base.transform.rotation * Quaternion.Euler(snapLocalRotation);
		}
		Gizmos.DrawWireCube(vector, new Vector3(1.5f, 0.2f, 1.5f));
		Gizmos.DrawLine(vector, vector + quaternion * Vector3.forward * 0.5f);
	}
}
