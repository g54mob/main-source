using System.Collections.Generic;
using UnityEngine;

public static class ObjectUtil
{
	private static float defaultWeight = 12f;

	private static List<string> reusableList = new List<string>();

	public static List<string> GetAllPropertiesForObject(GameObject obj)
	{
		reusableList.Clear();
		if (obj == null)
		{
			return reusableList;
		}
		RegisterTaggedObject component = obj.GetComponent<RegisterTaggedObject>();
		if (component != null)
		{
			reusableList.Add(component.objectType.ToString());
		}
		ObjectID component2 = obj.GetComponent<ObjectID>();
		if (component2 != null)
		{
			if (component.objectType == TagsEnum.DOG)
			{
				reusableList.Add(component2.GetUID().ToString());
			}
			else
			{
				reusableList.Add(component2.item.itemName);
			}
		}
		return reusableList;
	}

	public static Vector3 GetObjCenter(GameObject obj)
	{
		if (obj.GetComponent<Collider>() == null && obj.GetComponentInChildren<Collider>() == null)
		{
			return obj.transform.position;
		}
		BoundingBoxComponent boundingBoxComponent = obj.transform.root.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = obj.transform.root.gameObject.AddComponent<BoundingBoxComponent>();
		}
		return boundingBoxComponent.GetBoxCenter();
	}

	public static Vector3 GetCentroid(List<GameObject> objs)
	{
		Vector3 zero = Vector3.zero;
		if (objs.Count == 0)
		{
			return zero;
		}
		for (int i = 0; i < objs.Count; i++)
		{
			zero += objs[i].transform.position;
		}
		return zero / objs.Count;
	}

	public static bool GetStageHitpoint(Vector3 startPos, ref Vector3 hitPoint)
	{
		if (!RaycastUtil.StageRaycast(startPos + Vector3.up * 0.1f, Vector3.down, out var hitInfo, 100f))
		{
			hitPoint = startPos;
			return false;
		}
		hitPoint = hitInfo.point;
		return true;
	}

	public static void ConvertObjectToFood(GameObject obj, InventoryItem item, Color associatedColor, bool canSaveLoad, InventoryItem bones = null, List<GutFloraResource> additionalFlora = null, List<GutFloraResource> additionalFloraBoosted = null)
	{
		SetAllLayers(obj, 0);
		SetAllTags(obj, Tags.FOOD);
		obj.AddComponent<InteractableBase>();
		RegisterTaggedObject registerTaggedObject = obj.AddComponent<RegisterTaggedObject>();
		registerTaggedObject.objectType = TagsEnum.FOOD;
		registerTaggedObject.canSaveLoad = canSaveLoad;
		registerTaggedObject.SetSafeDestroy();
		if (bones != null)
		{
			registerTaggedObject.spawnOnDestroy = bones;
			registerTaggedObject.saveAsAlternativeItem = bones;
		}
		Eatable eatable = obj.AddComponent<Eatable>();
		Eatable component = item.itemPrefab.GetComponent<Eatable>();
		eatable.bitesTotal = component.bitesTotal;
		eatable.hungerGivenPerBite = component.hungerGivenPerBite;
		eatable.particleObj = component.particleObj;
		eatable.lastBiteParticleObj = component.lastBiteParticleObj;
		eatable.associatedColors.Add(associatedColor);
		eatable.gutFloraTypes.AddRange(component.gutFloraTypes);
		if (additionalFlora != null)
		{
			eatable.gutFloraTypes.AddRange(additionalFlora);
		}
		if (additionalFloraBoosted != null)
		{
			eatable.boostedGutFloraTypes.AddRange(additionalFloraBoosted);
		}
		eatable.ManualAwaken();
		ObjectRegistration.GetRegistrationScript().AssignID(obj, item);
		registerTaggedObject.ManualRegister();
	}

	public static void SetAllMaterials(GameObject obj, Material newMat)
	{
		Renderer component = obj.GetComponent<Renderer>();
		if (component != null)
		{
			component.material = newMat;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			SetAllMaterials(obj.transform.GetChild(i).gameObject, newMat);
		}
	}

	public static void SetAllTags(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			SetAllTags(obj.transform.GetChild(i).gameObject, newTag);
		}
	}

	public static void SetAllLayers(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			SetAllLayers(obj.transform.GetChild(i).gameObject, newLayer);
		}
	}

	public static void SetAllColliders(GameObject obj, bool enabledVal)
	{
		Collider[] components = obj.GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = enabledVal;
		}
		for (int j = 0; j < obj.transform.childCount; j++)
		{
			SetAllColliders(obj.transform.GetChild(j).gameObject, enabledVal);
		}
	}

	public static void RemoveAllComponents<T>(GameObject obj) where T : Component
	{
		T[] components = obj.GetComponents<T>();
		for (int i = 0; i < components.Length; i++)
		{
			Object.Destroy(components[i]);
		}
		for (int j = 0; j < obj.transform.childCount; j++)
		{
			RemoveAllComponents<T>(obj.transform.GetChild(j).gameObject);
		}
	}

	public static void SetAllComponents<T>(GameObject obj, bool enabledVal) where T : MonoBehaviour
	{
		T[] components = obj.GetComponents<T>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = enabledVal;
		}
		for (int j = 0; j < obj.transform.childCount; j++)
		{
			SetAllComponents<T>(obj.transform.GetChild(j).gameObject, enabledVal);
		}
	}

	public static Transform FindNestedTransformByName(GameObject obj, string name)
	{
		Transform transform = obj.transform;
		if (transform.name == name)
		{
			return transform;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			transform = FindNestedTransformByName(obj.transform.GetChild(i).gameObject, name);
			if (transform.name == name)
			{
				return transform;
			}
		}
		return transform;
	}

	public static float GetMassMultiplierForObject(GameObject obj)
	{
		float num = 0f;
		Rigidbody component = obj.GetComponent<Rigidbody>();
		if (component != null)
		{
			num += component.mass;
		}
		Rigidbody[] componentsInChildren = obj.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			num += rigidbody.mass;
		}
		float num2 = num / defaultWeight;
		if (obj.CompareTag(Tags.DOG))
		{
			num2 /= 2f;
		}
		return num2;
	}

	public static void AllowPhysics(GameObject obj, bool val)
	{
		Rigidbody[] componentsInChildren = obj.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			if (!val)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			rigidbody.useGravity = val;
			rigidbody.isKinematic = !val;
			if (val)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
		}
	}
}
