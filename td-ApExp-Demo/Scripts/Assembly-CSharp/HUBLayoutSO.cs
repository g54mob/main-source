using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "HUBLayoutSO", menuName = "HUB Layout SO")]
public class HUBLayoutSO : ScriptableObject
{
	public Sprite FloorArt;

	public Sprite MountainExitArt;

	public Sprite ArchwaysArt;

	public Sprite CraneArt;

	public bool showArchways;

	public bool showMountains;

	[field: SerializeField]
	public SerializedDictionary<string, bool> elements { get; private set; }
}
