using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA.Examples
{
	public class UMASimpleLOD : MonoBehaviour
	{
		[Tooltip("The distance to step to another LOD")]
		[Range(0.01f, 100f)]
		public float lodDistance;

		[Tooltip("The LOD distance is cumulatively multiplied by this each level ie - 5 distance and multiplier 2 would give 5/10/20/40/80")]
		[Range(1.5f, 4f)]
		public float distanceMultiplier;

		[Tooltip("Look for LOD slots in the library.")]
		public bool swapSlots;

		[Tooltip("This value is subtracted from the slot LOD counter.")]
		public int lodOffset;

		[Tooltip("This is the max LOD to search for if the current LOD can't be found.")]
		public int maxLOD;

		[Tooltip("The maximum scale reduction (8 means the texture can be reduced in half 8 times)")]
		public int maxReduction;

		[Tooltip("Allow the system to drop slots based on the SlotDataAsset MaxLOD")]
		public bool useSlotDropping;

		[Tooltip("Allow the system to drop slots based on the SlotDataAsset MaxLOD")]
		public bool useTextureResize;

		[Tooltip("Disable the automated processing of LOD changes. This is useful if you want to control when the LOD changes happen, such as in a custom update loop or event system.")]
		public bool disableAutomatedProcessing;

		[Tooltip("How much of a movement buffer before triggering an LOD change again. This is to stop thrashing at edges 4.99->5.0->4.99, etc")]
		public float BufferZone;

		private int _currentLOD;

		private float lastDist;

		private float NextTime;

		[Tooltip("How much time must pass before this is checked again. Default = 0.5 seconds")]
		public float MinCheck;

		[Tooltip("Random Variance in time (added to MinCheck) so that everything doesn't trigger at the same time. Default = 0.25 seconds")]
		public float CheckRange;

		private DynamicCharacterAvatar _avatar;

		private UMAData _umaData;

		private bool initialized;

		private static Dictionary<string, string[]> LODSFound;

		public int CurrentLOD => 0;

		public void SetSwapSlots(bool swapSlots, int lodOffset)
		{
		}

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void OnEnable()
		{
		}

		public void CharacterCreated(UMAData umaData)
		{
		}

		public void CharacterBegun(UMAData umaData)
		{
		}

		private void DoLODCheck(UMAData umaData)
		{
		}

		public void DoManualLODCheck(int lodLevel)
		{
		}

		public void Update()
		{
		}

		public bool PerformLodCheck()
		{
			return false;
		}

		private string GetNextLODName(string currentSlotName, string baseSlotName, int lodLevel)
		{
			return null;
		}

		private bool ProcessRecipe(int currentLevel)
		{
			return false;
		}
	}
}
