using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class BlendingCandidate3D : MonoBehaviour
	{
		[Header("Requirement Slots")]
		[Tooltip("Visual containers for each requirement slot.")]
		[SerializeField]
		private Transform slot1Container;

		[SerializeField]
		private Transform slot2Container;

		[Header("Slot Icons - AB (BoostFerment)")]
		[SerializeField]
		private GameObject slot1_AB;

		[SerializeField]
		private GameObject slot2_AB;

		[Header("Slot Icons - AC (HealthyYeast)")]
		[SerializeField]
		private GameObject slot1_AC;

		[SerializeField]
		private GameObject slot2_AC;

		[Header("Slot Icons - AD (StructuredFerment)")]
		[SerializeField]
		private GameObject slot1_AD;

		[SerializeField]
		private GameObject slot2_AD;

		[Header("Slot Icons - BC (FastStart)")]
		[SerializeField]
		private GameObject slot1_BC;

		[SerializeField]
		private GameObject slot2_BC;

		[Header("Slot Icons - BD (BodyBuilder)")]
		[SerializeField]
		private GameObject slot1_BD;

		[SerializeField]
		private GameObject slot2_BD;

		[Header("Slot Icons - CD (BalancePack)")]
		[SerializeField]
		private GameObject slot1_CD;

		[SerializeField]
		private GameObject slot2_CD;

		[Header("Slot Icons - AA (DoubleYeast)")]
		[SerializeField]
		private GameObject slot1_AA;

		[SerializeField]
		private GameObject slot2_AA;

		[Header("Slot Icons - BB (DoubleSugar)")]
		[SerializeField]
		private GameObject slot1_BB;

		[SerializeField]
		private GameObject slot2_BB;

		[Header("Slot Icons - CC (DoubleNutrients)")]
		[SerializeField]
		private GameObject slot1_CC;

		[SerializeField]
		private GameObject slot2_CC;

		[Header("Slot Icons - DD (DoubleTannin)")]
		[SerializeField]
		private GameObject slot1_DD;

		[SerializeField]
		private GameObject slot2_DD;

		[Header("Matched Indicators")]
		[Tooltip("Shown when slot 1 requirement is matched.")]
		[SerializeField]
		private GameObject slot1MatchedIndicator;

		[Tooltip("Shown when slot 2 requirement is matched.")]
		[SerializeField]
		private GameObject slot2MatchedIndicator;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig enterAnimation;

		[SerializeField]
		private TweenConfig matchAnimation;

		[SerializeField]
		private TweenConfig completeAnimation;

		[Header("Candidate Scale")]
		[Tooltip("Desired world-space size for the candidate.")]
		[SerializeField]
		private float candidateScale;

		private BlendPairType requirement1;

		private BlendPairType requirement2;

		private bool slot1Matched;

		private bool slot2Matched;

		private Collider cachedCollider;

		private int enterTweenId;

		private int completeTweenId;

		public Collider CandidateCollider => null;

		public BlendPairType Requirement1 => default(BlendPairType);

		public BlendPairType Requirement2 => default(BlendPairType);

		public bool IsComplete => false;

		public event Action<BlendingCandidate3D> OnComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void ValidateIconReferences()
		{
		}

		public void Initialize(BlendPairType req1, BlendPairType req2)
		{
		}

		public bool TryMatch(BlendPairType pair)
		{
			return false;
		}

		public bool CanMatch(BlendPairType pair)
		{
			return false;
		}

		public Vector3 GetMatchSlotPosition(BlendPairType pair)
		{
			return default(Vector3);
		}

		public void Recycle()
		{
		}

		private void OnSlotMatched(int slotIndex)
		{
		}

		private void CheckComplete()
		{
		}

		private void HideAllSlotIcons()
		{
		}

		private void ShowSlotIcon(int slot, BlendPairType pair, bool show)
		{
		}

		private GameObject GetSlotIcon(int slot, BlendPairType pair)
		{
			return null;
		}

		private Vector3 CandidateTargetScale()
		{
			return default(Vector3);
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
