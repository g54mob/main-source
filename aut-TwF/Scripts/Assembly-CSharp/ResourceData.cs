using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Tower Factory/ResourceData", order = 1)]
public class ResourceData : ScriptableObject, ISavable
{
	[SerializeField]
	[Savable("id", true, false)]
	private string id = "";

	[SerializeField]
	private Resource resource;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private Sprite image;

	[SerializeField]
	private Sprite inventoryImage;

	[SerializeField]
	private bool hideInInventory;

	[SerializeField]
	private float value;

	[SerializeField]
	private float lengthOnConveyorBelt = 1f / 3f;

	public string Id => id;

	public Resource Resource => resource;

	public string DisplayName => displayName.GetLocalizedString();

	public Sprite Image => image;

	public Sprite InventoryImage => inventoryImage;

	public GameObject Prefab => Resource.gameObject;

	public bool HideInInventory => hideInInventory;

	public float Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public float LengthOnConveyorBelt => lengthOnConveyorBelt;

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
