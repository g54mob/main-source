using System;
using System.Collections;
using UnityEngine;

public class CouplingScanner : MonoBehaviour
{
	private const float RAYCAST_RANGE = 1.5f;

	private const float CONNECTED_RANGE_SQR = 4f;

	private const float SCAN_INTERVAL = 0.1f;

	[HideInInspector]
	public CouplingScanner nearbyScanner;

	private Coroutine scanCoro;

	private Coroutine masterCoro;

	private LayerMask trainsLayerMask;

	private Ray ray;

	public event Action<CouplingScanner> ScanStateChanged;

	private void Start()
	{
		trainsLayerMask = LayerMask.GetMask("Train_Big_Collider");
		CouplingScannerReferences couplingScannerReferences = GetComponentInParent<CouplingScannerReferences>();
		if ((object)couplingScannerReferences == null)
		{
			TrainCarInteriorObject componentInParent = GetComponentInParent<TrainCarInteriorObject>();
			if ((object)componentInParent == null)
			{
				Debug.LogError("CouplingScanner couldn't find CouplingScannerReferences", this);
				return;
			}
			couplingScannerReferences = componentInParent.actualTrainCar.GetComponent<CouplingScannerReferences>();
		}
		couplingScannerReferences.scanners.Add(this);
	}

	private void OnEnable()
	{
		if (nearbyScanner == null)
		{
			StartScanning();
		}
	}

	private void OnDisable()
	{
		if ((bool)nearbyScanner)
		{
			Unpair(startScanning: false);
		}
		KillCoroutines();
	}

	private void KillCoroutines()
	{
		if (scanCoro != null)
		{
			StopCoroutine(scanCoro);
		}
		if (masterCoro != null)
		{
			StopCoroutine(masterCoro);
		}
		scanCoro = null;
		masterCoro = null;
	}

	private void StartScanning()
	{
		KillCoroutines();
		if (base.gameObject.activeInHierarchy)
		{
			scanCoro = StartCoroutine(ScanCoro());
		}
	}

	private void Pair(CouplingScanner other)
	{
		if (other == this)
		{
			Debug.LogError("CouplingScanner trying to assign itself", base.gameObject);
			return;
		}
		if (other == null)
		{
			Debug.LogError("CouplingScanner trying to pair with null", base.gameObject);
			return;
		}
		if (other == nearbyScanner)
		{
			Debug.LogWarning("CouplingScanner assigning same other scanner '" + other.transform.root.name + "', this shouldn't be possible", base.gameObject);
			return;
		}
		if (other.nearbyScanner != null)
		{
			Debug.LogError("CouplingScanner tried to pair with already paired '" + other.transform.root.name + "'", base.gameObject);
			return;
		}
		if (nearbyScanner != null)
		{
			Debug.LogWarning("CouplingScanner assigning different scanner '" + other.transform.root.name + "' while there's already '" + nearbyScanner.transform.root.name + "' assigned, this shouldn't be possible", base.gameObject);
		}
		if (other.GetInstanceID() < GetInstanceID())
		{
			other.Pair(this);
			return;
		}
		nearbyScanner = other;
		other.nearbyScanner = this;
		this.ScanStateChanged?.Invoke(nearbyScanner);
		nearbyScanner.ScanStateChanged?.Invoke(this);
		KillCoroutines();
		masterCoro = StartCoroutine(MasterCoro());
	}

	private void Unpair(bool startScanning)
	{
		if (nearbyScanner.GetInstanceID() < GetInstanceID())
		{
			nearbyScanner.Unpair(startScanning);
			return;
		}
		CouplingScanner couplingScanner = nearbyScanner;
		nearbyScanner = null;
		couplingScanner.nearbyScanner = null;
		this.ScanStateChanged?.Invoke(null);
		couplingScanner.ScanStateChanged?.Invoke(null);
		StartScanning();
		couplingScanner.StartScanning();
	}

	private IEnumerator ScanCoro()
	{
		int initialWaitFrames = Mathf.Abs(GetInstanceID() % 20);
		for (int i = 0; i < initialWaitFrames; i++)
		{
			yield return null;
		}
		WaitForSeconds wait = WaitFor.Seconds(0.1f);
		while (true)
		{
			yield return wait;
			if ((bool)nearbyScanner)
			{
				break;
			}
			DoScan();
		}
		scanCoro = null;
	}

	private IEnumerator MasterCoro()
	{
		WaitForSeconds wait = WaitFor.Seconds(0.1f);
		do
		{
			yield return wait;
		}
		while (!(Vector3.SqrMagnitude(base.transform.position - nearbyScanner.transform.position) > 4f));
		Unpair(startScanning: true);
	}

	private CouplingScanner RaycastScanner()
	{
		ray = new Ray(base.transform.position, base.transform.forward);
		if (!Physics.Raycast(ray, out var hitInfo, 1.5f, trainsLayerMask, QueryTriggerInteraction.Ignore))
		{
			return null;
		}
		CouplingScannerReferences component = hitInfo.transform.GetComponent<CouplingScannerReferences>();
		if (!component)
		{
			return null;
		}
		CouplingScanner result = null;
		foreach (CouplingScanner scanner in component.scanners)
		{
			if (scanner != null && scanner != this && Vector3.Dot(base.transform.forward, scanner.transform.forward) < 0f)
			{
				result = scanner;
				break;
			}
		}
		return result;
	}

	private void DoScan()
	{
		CouplingScanner couplingScanner = RaycastScanner();
		Debug.DrawRay(ray.origin, ray.direction * 1.5f, (couplingScanner != null) ? Color.green : Color.red, 0.05f);
		if ((bool)couplingScanner && couplingScanner.nearbyScanner == null)
		{
			Pair(couplingScanner);
		}
	}
}
