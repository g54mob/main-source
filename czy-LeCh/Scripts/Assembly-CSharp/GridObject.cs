using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class GridObject : MonoBehaviour
{
	private float startScale = 0.5f;

	private float currentScale;

	private float targetScale = 1f;

	private float scaleSpeed = 25f;

	private float divisionValue = 1f;

	[Header("Distinct variables")]
	[SerializeField]
	private string objectName;

	[SerializeField]
	private string objectNameLabel;

	[SerializeField]
	private string objectDescription;

	[SerializeField]
	private string objectDescriptionLabel;

	[SerializeField]
	private List<ObjectType> objectTypes;

	[SerializeField]
	private int objectId;

	[SerializeField]
	private bool unlocked;

	[SerializeField]
	private bool unlockedFromStart;

	[SerializeField]
	private bool unlockedInDemo;

	[SerializeField]
	private bool canBeUnlockedInDemo;

	[Header("Visual variables")]
	[SerializeField]
	private List<Renderer> renderers;

	[SerializeField]
	private List<Material> roofMaterials;

	[SerializeField]
	private List<Material> materials;

	[SerializeField]
	private List<Material> transparentMaterials;

	private bool canBeTransparent;

	[SerializeField]
	private bool allowedToBeTransparent;

	[Header("Other variables")]
	[SerializeField]
	private List<ParticleSystem> particleSystems;

	[SerializeField]
	private bool isWaterObject;

	[SerializeField]
	private AudioClip spawnSound;

	[SerializeField]
	private List<PointsPerAdjacentObjectType> pointsPerAdjacentObjectTypes;

	[SerializeField]
	private List<SymmetryPoints> symmetryPoints;

	[SerializeField]
	private int humanCount;

	[SerializeField]
	private int foodCount;

	public bool CanBeTransparent => canBeTransparent;

	public string GetName()
	{
		return objectName;
	}

	public string GetNameLabel()
	{
		return objectNameLabel;
	}

	public string GetDescription()
	{
		return objectDescription;
	}

	public string GetDescriptionLabel()
	{
		return objectDescriptionLabel;
	}

	public List<ObjectType> GetObjectTypes()
	{
		return objectTypes;
	}

	public int GetObjectID()
	{
		return objectId;
	}

	public bool IsUnlockedFromStart()
	{
		return unlockedFromStart;
	}

	public bool IsUnlockedInDemo()
	{
		return unlockedInDemo;
	}

	public bool CanBeUnlockedInDemo()
	{
		return canBeUnlockedInDemo;
	}

	public bool IsUnlocked()
	{
		return unlocked;
	}

	public void SetUnlocked()
	{
		unlocked = true;
	}

	public void SetLocked()
	{
		if (!unlockedFromStart)
		{
			unlocked = false;
		}
	}

	public bool GetIsWaterObject()
	{
		return isWaterObject;
	}

	private void Start()
	{
		base.transform.localScale = new Vector3(startScale, startScale, startScale);
		base.transform.DOScale(1f, 0.1f).SetEase(Ease.InBounce);
		FindRenderers(base.transform);
		CreateCustomMaterials();
		CreateTransparentMaterials();
		UpdateRoofColor();
		ChangeMaterialToDefault();
	}

	private void Update()
	{
		if (SettingsManager.Instance.IsSettingsOpen())
		{
			ChangeMaterialToDefault();
		}
	}

	public void UpdateRoofColor()
	{
		foreach (Material roofMaterial in roofMaterials)
		{
			roofMaterial.color = GridController.Instance.GetRoofColor();
		}
		foreach (Material material in materials)
		{
			if (material.name.Contains("roof"))
			{
				material.color = GridController.Instance.GetRoofColor();
			}
		}
	}

	public void ChangeMaterialToTransparent()
	{
		int num = 0;
		try
		{
			foreach (Renderer renderer in renderers)
			{
				int num2 = renderer.materials.Count();
				renderer.materials.ToList().Clear();
				Material[] array = new Material[0];
				List<Material> list = new List<Material>();
				for (int i = 0; i < num2; i++)
				{
					list.Add(transparentMaterials[num]);
					num++;
				}
				array = list.ToArray();
				renderer.materials = array;
			}
			UpdateRoofColor();
		}
		catch
		{
		}
	}

	public void ChangeMaterialToDefault()
	{
		int num = 0;
		canBeTransparent = true;
		try
		{
			foreach (Renderer renderer in renderers)
			{
				int num2 = renderer.materials.Count();
				renderer.materials.ToList().Clear();
				Material[] array = new Material[0];
				List<Material> list = new List<Material>();
				for (int i = 0; i < num2; i++)
				{
					list.Add(materials[num]);
					num++;
				}
				array = list.ToArray();
				renderer.materials = array;
			}
			UpdateRoofColor();
		}
		catch
		{
		}
	}

	private void FindRenderers(Transform parent)
	{
		if (parent.GetComponent<Renderer>() != null && !renderers.Contains(parent.GetComponent<Renderer>()))
		{
			renderers.Add(parent.GetComponent<Renderer>());
		}
		foreach (Transform item in parent)
		{
			if (item.GetComponent<Renderer>() != null)
			{
				renderers.Add(item.GetComponent<Renderer>());
				Material[] array = item.GetComponent<Renderer>().materials;
				foreach (Material material in array)
				{
					if (material.name.Contains("roof"))
					{
						roofMaterials.Add(material);
					}
				}
			}
			if (item.childCount > 0)
			{
				FindRenderers(item);
			}
		}
	}

	private void CreateCustomMaterials()
	{
		try
		{
			if (objectTypes.Contains(ObjectType.water))
			{
				return;
			}
			foreach (Renderer renderer in renderers)
			{
				Material[] array = renderer.materials;
				foreach (Material source in array)
				{
					materials.Add(new Material(source));
				}
			}
		}
		catch
		{
		}
	}

	private void CreateTransparentMaterials()
	{
		try
		{
			if (objectTypes.Contains(ObjectType.water) || objectTypes.Contains(ObjectType.trees) || !allowedToBeTransparent)
			{
				return;
			}
			foreach (Material material2 in materials)
			{
				try
				{
					Material material = new Material(GridController.Instance.GetTransparentMaterial());
					material.color = new Color(material2.color.r, material2.color.g, material2.color.b, 0.15f);
					transparentMaterials.Add(material);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	public void PlaceObject()
	{
		foreach (ParticleSystem particleSystem in particleSystems)
		{
			if (particleSystem != null)
			{
				particleSystem.Play();
			}
		}
	}

	public AudioClip GetSpawnSound()
	{
		return spawnSound;
	}

	public int GetSymmetryPoints(int objectId)
	{
		if (symmetryPoints.Exists((SymmetryPoints x) => x.objectId == objectId))
		{
			return symmetryPoints.Find((SymmetryPoints x) => x.objectId == objectId).points;
		}
		return 0;
	}

	public int GetHumanCount()
	{
		return humanCount;
	}

	public int GetFoodCount()
	{
		return foodCount;
	}

	public int GetHappinessScore()
	{
		if (pointsPerAdjacentObjectTypes.Count == 0)
		{
			return 0;
		}
		int num = 0;
		if (GridController.Instance.ExistsOnGrid(new Vector3(base.transform.parent.position.x + 15f, base.transform.parent.position.y, base.transform.parent.position.z)) && pointsPerAdjacentObjectTypes.Exists((PointsPerAdjacentObjectType x) => GetXPlusObjectTypes().Contains(x.objectType)))
		{
			num += pointsPerAdjacentObjectTypes.Find((PointsPerAdjacentObjectType x) => GetXPlusObjectTypes().Contains(x.objectType)).points;
		}
		if (GridController.Instance.ExistsOnGrid(new Vector3(base.transform.parent.position.x - 15f, base.transform.parent.position.y, base.transform.parent.position.z)) && pointsPerAdjacentObjectTypes.Exists((PointsPerAdjacentObjectType x) => GetXMinObjectTypes().Contains(x.objectType)))
		{
			num += pointsPerAdjacentObjectTypes.Find((PointsPerAdjacentObjectType x) => GetXMinObjectTypes().Contains(x.objectType)).points;
		}
		if (GridController.Instance.ExistsOnGrid(new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, base.transform.parent.position.z + 15f)) && pointsPerAdjacentObjectTypes.Exists((PointsPerAdjacentObjectType x) => GetZPlusObjectTypes().Contains(x.objectType)))
		{
			num += pointsPerAdjacentObjectTypes.Find((PointsPerAdjacentObjectType x) => GetZPlusObjectTypes().Contains(x.objectType)).points;
		}
		if (GridController.Instance.ExistsOnGrid(new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, base.transform.parent.position.z - 15f)) && pointsPerAdjacentObjectTypes.Exists((PointsPerAdjacentObjectType x) => GetZMinObjectTypes().Contains(x.objectType)))
		{
			num += pointsPerAdjacentObjectTypes.Find((PointsPerAdjacentObjectType x) => GetZMinObjectTypes().Contains(x.objectType)).points;
		}
		return num;
	}

	private List<ObjectType> GetXPlusObjectTypes()
	{
		return GridController.Instance.GetGridObjectInstance(new Vector3(base.transform.parent.position.x + 15f, base.transform.parent.position.y, base.transform.parent.position.z)).gridGameObject.GetComponent<GridObject>().GetObjectTypes();
	}

	private List<ObjectType> GetXMinObjectTypes()
	{
		return GridController.Instance.GetGridObjectInstance(new Vector3(base.transform.parent.position.x - 15f, base.transform.parent.position.y, base.transform.parent.position.z)).gridGameObject.GetComponent<GridObject>().GetObjectTypes();
	}

	private List<ObjectType> GetZPlusObjectTypes()
	{
		return GridController.Instance.GetGridObjectInstance(new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, base.transform.parent.position.z + 15f)).gridGameObject.GetComponent<GridObject>().GetObjectTypes();
	}

	private List<ObjectType> GetZMinObjectTypes()
	{
		return GridController.Instance.GetGridObjectInstance(new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, base.transform.parent.position.z - 15f)).gridGameObject.GetComponent<GridObject>().GetObjectTypes();
	}
}
