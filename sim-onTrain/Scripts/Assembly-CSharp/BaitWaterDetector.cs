using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BaitWaterDetector : MonoBehaviour
{
	[SerializeField]
	private FishingRodController rod;

	[SerializeField]
	[Tooltip("Aynı atışta birden fazla splash önler.")]
	private bool oneShotPerThrow = true;

	[SerializeField]
	private bool debugLog = true;

	private bool splashedThisThrow;

	private void Awake()
	{
		if (rod == null)
		{
			rod = GetComponentInParent<FishingRodController>();
		}
		Collider component = GetComponent<Collider>();
		if (!component.isTrigger)
		{
			component.isTrigger = true;
			if (debugLog)
			{
				Debug.Log("[BaitWaterDetector] Collider auto-set to trigger on " + base.name + ".", this);
			}
		}
		if (GetComponent<Rigidbody>() == null)
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			if (debugLog)
			{
				Debug.Log("[BaitWaterDetector] Kinematic Rigidbody auto-added on " + base.name + ".", this);
			}
		}
	}

	public void ResetSplash()
	{
		splashedThisThrow = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (debugLog)
		{
			Debug.Log("[BaitWaterDetector] OnTriggerEnter with " + other.name + " (layer " + LayerMask.LayerToName(other.gameObject.layer) + ")", this);
		}
		if (oneShotPerThrow && splashedThisThrow)
		{
			return;
		}
		if (rod == null)
		{
			Debug.LogWarning("[BaitWaterDetector] rod reference null", this);
			return;
		}
		if (other.GetComponentInParent<WaterInteractable>() == null)
		{
			if (debugLog)
			{
				Debug.Log("[BaitWaterDetector] -> not WaterInteractable, ignoring");
			}
			return;
		}
		Vector3 vector = other.ClosestPoint(base.transform.position);
		splashedThisThrow = true;
		if (debugLog)
		{
			Debug.Log($"[BaitWaterDetector] Water hit, splash at {vector}");
		}
		rod.PlayWaterSplashAt(vector);
	}
}
