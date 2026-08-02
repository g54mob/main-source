using System;
using UnityEngine;

public class PropBase : MonoBehaviour
{
	public CollectableItemData data;

	public int assignedWagonID;

	public float maxHealth = 100f;

	public float health = 100f;

	public string uniqueID;

	public PropType propType = PropType.Prop;

	public bool IsDamaged => health < maxHealth;

	public void SetID()
	{
		if (data == null)
		{
			Debug.LogWarning(string.Format("[PropBase:SetID] data NULL! GameObject: '{0}', Position: {1}, WagonID: {2}, Parent: '{3}'", base.gameObject.name, base.transform.localPosition, assignedWagonID, (base.transform.parent != null) ? base.transform.parent.name : "none"));
			uniqueID = Guid.NewGuid().ToString() + base.gameObject.name + base.transform.localPosition.normalized.ToString("0.00") + assignedWagonID;
		}
		else
		{
			uniqueID = Guid.NewGuid().ToString() + data.name + base.transform.localPosition.normalized.ToString("0.00") + assignedWagonID;
		}
	}

	public string GetDisplayName()
	{
		if (!(data != null))
		{
			return base.gameObject.name;
		}
		return data.GetLocalizedDisplayName();
	}

	public void TakeDamage(float damage, Vector3 hitPoint, Quaternion hitRotation)
	{
		if (propType == PropType.Ground)
		{
			return;
		}
		health = Mathf.Clamp(health - damage, 0f, maxHealth);
		Debug.Log($"[PropBase] Yeni can: {health}");
		if (health <= 0f)
		{
			Debug.Log("[PropBase] Obje öldü: " + base.gameObject.name);
			if (TrainBuildManager.Instance != null && data != null)
			{
				TrainBuildManager.Instance.CmdDestroyBuildObject(base.transform.localPosition, data.itemName, assignedWagonID);
			}
		}
	}

	public void Heal(float healAmount)
	{
		health = Mathf.Clamp(health + healAmount, 0f, maxHealth);
	}

	public float GetHealthPercentage()
	{
		if (!(maxHealth > 0f))
		{
			return 1f;
		}
		return health / maxHealth;
	}

	public void DestroyObjectOnServer()
	{
		if (TrainBuildManager.Instance != null)
		{
			TrainBuildManager.Instance.CmdDestroyBuildObject(base.transform.localPosition, data.itemName, assignedWagonID);
		}
	}
}
