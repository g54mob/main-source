using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class CargoLeakGas : CargoLeakBase
{
	public SphereCollider volumeCollider;

	private const float MAX_GAS_RADIUS = 25f;

	private const float MIN_DISSIPATION_RATE = 0.05f;

	private const float GAS_BUILDUP_THRESHOLD = 12.5f;

	private Vector3 DEFAULT_LEAK_COLLIDER_SIZE = new Vector3(1f, 1f, 0f);

	private Vector3 DEFAULT_LEAK_COLLIDER_CENTER = Vector3.zero;

	private bool hasFumes;

	private bool hadFumes;

	private float volatility;

	protected override void SetupLeakColliders(GameObject colliderGO)
	{
		leakCollider = colliderGO.AddComponent<BoxCollider>();
		leakCollider.isTrigger = true;
		volumeCollider = colliderGO.AddComponent<SphereCollider>();
		volumeCollider.radius = 0f;
		volumeCollider.isTrigger = true;
		maxLeakColliderSize = 8f;
		ResetLeakColliders();
	}

	protected override void InitializeCargoSpecificValues(CargoType cargoType)
	{
		base.InitializeCargoSpecificValues(cargoType);
		volatility = cargoLeakProperties.volatility;
	}

	protected override void ManageColliders()
	{
		if (isLeaking)
		{
			float num = leakFlow / maxLeakFlow;
			leakColliderSize.z = maxLeakColliderSize * num;
			leakColliderCenter.z = maxLeakColliderSize * 0.5f * num;
			leakCollider.center = leakColliderCenter;
			leakCollider.size = leakColliderSize;
			if (!leakCollider.enabled)
			{
				leakCollider.enabled = true;
			}
		}
		else if (leakCollider.enabled)
		{
			leakCollider.enabled = false;
		}
		if (hasFumes)
		{
			volumeCollider.radius = vaporRadius;
			if (!volumeCollider.enabled)
			{
				volumeCollider.enabled = true;
			}
		}
		else if (volumeCollider.enabled)
		{
			volumeCollider.enabled = false;
		}
	}

	private void UpdateFumes()
	{
		if (!isRuptured || (!isLeaking && !hasFumes))
		{
			return;
		}
		if (cargoMassLeaked <= float.Epsilon)
		{
			hasFumes = false;
			cargoMassLeaked = 0f;
		}
		else
		{
			hasFumes = true;
		}
		cargoVolumeLeaked = 4.1887903f * cargoMassLeaked * volatility * inverseDensity;
		vaporRadius = Mathf.Clamp(Mathf.Pow(cargoVolumeLeaked / 4.1887903f, 0.33f), 0f, 25f);
		base.HasGasBuildup = vaporRadius >= 12.5f;
		if (cargoVolumeLeaked <= float.Epsilon)
		{
			cargoVolumeLeaked = 0f;
		}
		if (!hadFumes && hasFumes)
		{
			hadFumes = true;
			if ((bool)SingletonBehaviour<HazmatTileManager>.Instance)
			{
				SingletonBehaviour<HazmatTileManager>.Instance.AddGasSource(this);
			}
		}
		else if (hadFumes && !hasFumes)
		{
			hadFumes = false;
			if ((bool)SingletonBehaviour<HazmatTileManager>.Instance)
			{
				SingletonBehaviour<HazmatTileManager>.Instance.RemoveGasSource(this);
			}
		}
	}

	protected override void Update()
	{
		UpdateFumes();
		base.Update();
	}

	public override void ResetAndDisable()
	{
		base.ResetAndDisable();
		float num = (volumeCollider.radius = 0f);
		vaporRadius = num;
		hasFumes = (hadFumes = false);
		if ((bool)SingletonBehaviour<HazmatTileManager>.Instance)
		{
			SingletonBehaviour<HazmatTileManager>.Instance.RemoveGasSource(this);
		}
	}

	protected override void ResetLeakColliders()
	{
		volumeCollider.enabled = false;
		leakCollider.enabled = false;
		leakColliderSize = DEFAULT_LEAK_COLLIDER_SIZE;
		leakColliderCenter = DEFAULT_LEAK_COLLIDER_CENTER;
	}

	protected override void CalculateLeakedMass()
	{
		float num = cargoLeakProperties.dissipationRate * Mathf.Max(0.05f, vaporRadius / 25f);
		cargoMassLeaked += (leakFlow - num) * Time.deltaTime;
	}
}
