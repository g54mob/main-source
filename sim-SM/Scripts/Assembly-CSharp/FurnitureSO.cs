using MyBox;
using NaisuPorter.CommonScripts;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Furniture", menuName = "Scriptable Objects/Furniture/Furniture")]
public class FurnitureSO : ScriptableObject
{
	public int ID;

	[Separator("General Setup", false)]
	public LocalizedString LocalizedName;

	public BoxSize BoxSize;

	public Sprite FurnitureIcon;

	public int AtlasIndex;

	public SerializableVector2Int AtlasPosition;

	public GameObject FurniturePrefab;

	public Color FurnitureColor;

	public DisplaySubType DisplaySubType;

	public bool IsMainFurniture;

	[Separator("Purchase Info", false)]
	public float Cost;

	public string FurnitureName => null;
}
