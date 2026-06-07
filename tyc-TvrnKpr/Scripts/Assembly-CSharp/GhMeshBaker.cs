using System;
using System.Collections.Generic;
using DigitalOpus.MB.Core;
using Gh;
using Gh.Tk;
using UnityEngine;

public class GhMeshBaker : SingletonMonoBehaviour<GhMeshBaker>
{
	private class MeshData
	{
		public Mesh BaseMesh;

		public List<(int startIndex, int endIndex)> ObjectVertexIndices;
	}

	[SerializeField]
	private MB3_MeshBaker _meshbaker;

	private MB3_MeshCombinerSingle _meshCombiner;

	private readonly Dictionary<int, MeshData> _meshCache;

	public const int BAKER_HASH_BASE_ID = 3011;

	public const int BAKER_HASH_BASE_MULTIPLIER = 5987;

	public override void Awake()
	{
	}

	private void OnPreLoad(object sender, EventArgs e)
	{
	}

	public static int CalculateMeshHash(GameObject root, BakeMeshRendererData[] currentMeshObjs)
	{
		return 0;
	}

	private Mesh GetMeshFromCache(int id)
	{
		return null;
	}

	private GameObject BakeMeshObject(GameObject root, BakeMeshRendererData[] currentMeshObjs)
	{
		return null;
	}

	public GameObject BakeMeshes(GameObject root, BakeMeshRendererData[] mergeObjects, bool includeVertexStreams)
	{
		return null;
	}

	private static Mesh CreateVertexMesh(MeshData data, BakeMeshRendererData[] currentMeshObjs)
	{
		return null;
	}
}
