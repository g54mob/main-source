using UnityEngine;

[CreateAssetMenu(fileName = "StorableData", menuName = "GameKit/StorableData", order = 1)]
public class StorableData : ScriptableObject
{
	[SerializeField]
	private string id = "";

	[SerializeField]
	private GameObject prefab;

	[SerializeField]
	private string displayName = "";

	[SerializeField]
	private Sprite image;

	public string Id => id;

	public GameObject Prefab => prefab;

	public string DisplayName => displayName;

	public Sprite Image => image;
}
