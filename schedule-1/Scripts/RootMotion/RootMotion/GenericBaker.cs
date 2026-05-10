using UnityEngine;

namespace RootMotion
{
	public class GenericBaker : Baker
	{
		[Tooltip("If true, produced AnimationClips will be marked as Legacy and usable with the Legacy animation system.")]
		public bool markAsLegacy;

		[Tooltip("Root Transform of the hierarchy to bake.")]
		public Transform root;

		[Tooltip("Root Node used for root motion.")]
		public Transform rootNode;

		[Tooltip("List of Transforms to ignore, rotation curves will not be baked for these Transforms.")]
		public Transform[] ignoreList;

		[Tooltip("LocalPosition curves will be baked for these Transforms only. If you are baking a character, the pelvis bone should be added to this array.")]
		public Transform[] bakePositionList;

		private BakerTransform[] children;

		private BakerTransform rootChild;

		private int rootChildIndex;

		private void Awake()
		{
		}

		protected override Transform GetCharacterRoot()
		{
			return null;
		}

		protected override void OnStartBaking()
		{
		}

		protected override void OnSetLoopFrame(float time)
		{
		}

		protected override void OnSetCurves(ref AnimationClip clip)
		{
		}

		protected override void OnSetKeyframes(float time, bool lastFrame)
		{
		}

		private bool IsIgnored(Transform t)
		{
			return false;
		}

		private bool BakePosition(Transform t)
		{
			return false;
		}
	}
}
