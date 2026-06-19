using System.Collections.Generic;
using PugTilemap;
using UnityEngine;

[DisallowMultipleComponent]
public class EnsureSameGroundTileBeneathEntityAuthoring : MonoBehaviour
{
	[Tooltip("If left empty then any tileset is fine, otherwise it will use fallbackTileset")]
	public TileType tileType = TileType.ground;

	public List<Tileset> onlySupportsTilesets;

	public Tileset fallbackTileset;

	public bool continouslyCheck;

	public bool ignoreCheckingWhileInState;

	public StateID stateToIgnore;
}
