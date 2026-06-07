using System;
using System.Collections.Generic;
using UMA.CharacterSystem;
using Unity.Collections;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAUVAttachedItem
	{
		public enum PrefabStatus
		{
			ShouldBeActivated = 0,
			ShouldBeDeactivated = 1,
			ShouldBeDeleted = 2
		}

		private struct BonesAndWeights
		{
			public Transform Bone;

			public float Weight;

			public Vector3 Normal;
		}

		private struct UVVerts
		{
			public int positionVertex;

			public int upVertex;

			public Vector3 InitialPosition;
		}

		public Vector2 uVLocation;

		public Vector2 uvUp;

		public Vector2 uvInAtlas;

		public Rect uvArea;

		public string slotName;

		public Quaternion rotation;

		public Vector3 normalAdjust;

		public Vector3 translation;

		public GameObject prefab;

		public string boneName;

		public string sourceSlotName;

		public bool useMostestBone;

		public GameObject prefabInstance;

		public int subMeshNumber;

		public List<int> triangle;

		public SkinnedMeshRenderer skin;

		private Mesh tempMesh;

		private UMAData umaData;

		private Transform mostestBone;

		public Vector3 originalPosition;

		public Vector3 normal;

		public Vector3 normalMult;

		public List<UMAUVAttachedItemBlendshapeAdjuster> blendshapeAdjusters;

		public bool InitialFound;

		public float DistanceFromBone;

		public float InitialDistanceFromBone;

		[Tooltip("The UV set to use for the attached item")]
		[Range(0f, 3f)]
		public int UVSet;

		public PrefabStatus prefabStatus;

		private List<BonesAndWeights> weights;

		public bool worldTransform;

		private UVVerts uvVerts;

		public void CleanUp()
		{
		}

		public void Setup(UMAData umaData, UMAUVAttachedItemLauncher bootstrap, bool Activate)
		{
		}

		public void ProcessSlot(UMAData umaData, SlotData slotData, DynamicCharacterAvatar avatar)
		{
		}

		private List<int> FindTriangle(int vert, Mesh.MeshData dat, Mesh mesh)
		{
			return null;
		}

		private Transform GetMostestBone(int vertexNumber, Mesh mesh, SkinnedMeshRenderer smr)
		{
			return null;
		}

		private List<BonesAndWeights> GetBoneWeights(int vertexNumber, Mesh mesh, SkinnedMeshRenderer smr)
		{
			return null;
		}

		private UVVerts FindVert(SlotData slotData, int maxVert, Vector2 UV, Vector2 UvUp, NativeArray<Vector2> allUVS)
		{
			return default(UVVerts);
		}

		public Vector3 GetOffset(Vector3 position, Vector3 initialposition, DynamicCharacterAvatar avatar)
		{
			return default(Vector3);
		}

		private Vector3 LerpVector(Vector3 a, Vector3 b, float t)
		{
			return default(Vector3);
		}

		private Vector3 LerpAngle(Vector3 a, Vector3 b, float t)
		{
			return default(Vector3);
		}

		public void DoLateUpdate(SkinnedMeshRenderer skin, Transform transform, DynamicCharacterAvatar avatar)
		{
		}
	}
}
