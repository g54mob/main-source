using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UMA
{
	public class SimpleDecal : MonoBehaviour, IUMAEventHookup
	{
		public int[] boneHashes;

		public string[] boneNames;

		public byte[] bonesPerVertex;

		public BoneWeight1[] capturedBoneWeights;

		public BoneWeight1[] finalBoneWeights;

		private Dictionary<int, int> NameToBone;

		private Vector3[] translated;

		public UMAMeshData meshData;

		public Vector3 Offset;

		public Vector3 Rotation;

		private GameObject vmarker;

		private GameObject sceneRoot;

		private Scene editorScene;

		private Vector3 InitialSpot;

		public bool invert;

		public bool root;

		public bool global;

		public bool position;

		public void Configure(string[] _boneNames, int[] _boneHashes, byte[] _bonesPerVertex, BoneWeight1[] _boneWeights)
		{
		}

		public void UpdateBones(UMAData umaData)
		{
		}

		private Matrix4x4 GetBoneTransform(UMAData umaData)
		{
			return default(Matrix4x4);
		}

		private Vector3[] TranslateVertices(Vector3[] verts, UMAData umaData)
		{
			return null;
		}

		private void ApplyToMesh(Mesh mesh, UMAData umaData)
		{
		}

		public GameObject ApplyTo(UMAData umaData, SkinnedMeshRenderer baseRenderer, GameObject slotObject)
		{
			return null;
		}

		public void Begun(UMAData umaData)
		{
		}

		public void Completed(UMAData umaData, GameObject slotObject)
		{
		}

		public void HookupEvents(SlotDataAsset slot)
		{
		}
	}
}
