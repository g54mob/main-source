using System;
using System.Runtime.CompilerServices;
using Brewery.Minigames;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class SterilizationCandidate3D : MonoBehaviour
	{
		[Serializable]
		public class IconSettings
		{
			public GameObject prefab;

			[Tooltip("World-space size for this icon (ratio to candidateScale).")]
			public float scale;

			[Tooltip("Local rotation offset (Euler angles).")]
			public Vector3 rotation;
		}

		[Header("State Icons (0=Dirty, 1=Soapy, 2=Unsanitized, 3=Wet)")]
		[SerializeField]
		private IconSettings dirtyIcon;

		[SerializeField]
		private IconSettings soapyIcon;

		[SerializeField]
		private IconSettings unsanitizedIcon;

		[SerializeField]
		private IconSettings wetIcon;

		[Header("Icon Layout")]
		[Tooltip("Parent transform for icons. If null, uses this transform.")]
		[SerializeField]
		private Transform iconContainer;

		[Tooltip("Local-space offset from candidate center to the icon row center.")]
		[SerializeField]
		private Vector3 iconOffset;

		[Tooltip("Distance between icons along the spread axis.")]
		[SerializeField]
		private float iconSpacing;

		[Tooltip("Which local axis icons spread along (0=X, 1=Y, 2=Z).")]
		[SerializeField]
		private int spreadAxis;

		[Header("Candidate")]
		[Tooltip("Desired world-space size for the candidate. Divided by parent scale to prevent distortion.")]
		[SerializeField]
		private float candidateScale;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig iconAppearAnimation;

		[SerializeField]
		private TweenConfig iconRemoveAnimation;

		[SerializeField]
		private TweenConfig candidateEnterAnimation;

		[Tooltip("Scale-punch animation on the blocking icon when a tool penalty triggers.")]
		[SerializeField]
		private TweenConfig iconWarnAnimation;

		[Tooltip("How fast icons slide to their new positions after a layout change.")]
		[SerializeField]
		private float repositionSpeed;

		private CandidateStates states;

		private readonly GameObject[] icons;

		private readonly Vector3[] iconTargetPositions;

		private readonly int[] iconTweenIds;

		private readonly bool[] iconRemoving;

		private Collider cachedCollider;

		private int enterTweenId;

		private Transform container;

		private IconSettings[] iconSettings;

		public Collider CandidateCollider => null;

		public bool IsSanitized => false;

		public event Action<SterilizationCandidate3D> OnSanitized
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

		private void Update()
		{
		}

		public void Initialize(bool dirty, bool soapy, bool unsanitized, bool wet)
		{
		}

		public void ApplyBrush()
		{
		}

		public void ApplyRinse()
		{
		}

		public void ApplySanitize()
		{
		}

		public void ApplyDry()
		{
		}

		public void Recycle()
		{
		}

		private void RepositionIcons()
		{
		}

		private void SnapPositions()
		{
		}

		private bool IsIconVisible(int index)
		{
			return false;
		}

		private GameObject CreateIcon(int index)
		{
			return null;
		}

		private void SnapIcon(int index, bool active)
		{
		}

		private void ShowIcon(int index)
		{
		}

		private void RemoveIcon(int index)
		{
		}

		private void WarnIcon(int index)
		{
		}

		private Vector3 CandidateTargetScale()
		{
			return default(Vector3);
		}

		private Vector3 IconTargetScale(int index)
		{
			return default(Vector3);
		}

		private void CheckSanitized()
		{
		}

		private void CancelAllTweens()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
