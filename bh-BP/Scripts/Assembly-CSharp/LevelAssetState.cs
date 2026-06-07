using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelAssetState
{
	public AssetLoadState LoadState;

	public AsyncOperationHandle<IList<GameObject>> LoadedGridPieceObjs;

	public AsyncOperationHandle<IList<GameObject>> LoadedMeshControllers;

	public AsyncOperationHandle<GameObject> LoadedOuterTiles;

	public AsyncOperationHandle<GameObject>[] LoadedExtraObjs;

	public AsyncOperationHandle<Texture> LoadedEnemyTex;

	public AsyncOperationHandle<GameObject>[] LoadedParticles;
}
