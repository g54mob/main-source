using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMAUVAttachedItemLauncher : MonoBehaviour
	{
		public DynamicCharacterAvatar avatar;

		public Vector2 uVLocation;

		public Vector2 uVUp;

		public string slotName;

		public Quaternion rotation;

		public Vector3 normalAdjust;

		public Vector3 translation;

		public GameObject prefab;

		public string boneName;

		public SlotData sourceSlot;

		public bool useMostestBone;

		[Tooltip("The UV set to use for the attached item")]
		[Range(0f, 3f)]
		public int UVSet;

		private GameObject prefabInstance;

		public int VertexNumber;

		public int subMeshNumber;

		public List<int> triangle;

		public SkinnedMeshRenderer skin;

		private Mesh tempMesh;

		private UMAUVAttachedItem bootStrapper;

		private UMAData umaData;

		private Transform mostestBone;

		public List<UMAUVAttachedItemBlendshapeAdjuster> blendshapeAdjusters;

		public bool worldTransform;

		public void Start()
		{
		}

		public void OnSlotProcessed(UMAData umaData, SlotData slotData)
		{
		}

		public void Setup(UMAData umaData, bool Activate)
		{
		}

		public void OnDnaAppliedBootstrapper(UMAData umaData)
		{
		}
	}
}
