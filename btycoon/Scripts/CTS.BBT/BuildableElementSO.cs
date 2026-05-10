using UnityEngine;

[CreateAssetMenu(fileName = "BuildableElementSO", menuName = "Construction/BuildableElementSO")]
public class BuildableElementSO : AbsInfluentBuyableItemSO
{
	public enum EBuildableType
	{
		None = 0,
		Door = 1,
		Window = 2,
		Arch = 3,
		Room = 4
	}

	[field: SerializeField]
	public BuildableElement Prefab { get; private set; }

	public EBuildableType BuildableType => Prefab.BuildableType;
}
