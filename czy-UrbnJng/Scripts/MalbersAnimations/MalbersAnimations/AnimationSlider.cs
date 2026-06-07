using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Transform/Animation Slider Preview")]
	public class AnimationSlider : MonoBehaviour
	{
		public Animator animator;

		public AnimationClip clip;

		public GameObject target;

		[Range(0f, 1f)]
		public float time;

		[MButton("RebindAnimator", false)]
		public bool rebind;

		private void Reset()
		{
			animator = GetComponent<Animator>();
			target = base.gameObject;
		}

		[ContextMenu("Rebind Animator")]
		public void RebindAnimator()
		{
			if (TryGetComponent<Animator>(out var component))
			{
				component.Rebind();
				MTools.SetDirty(this);
			}
		}

		private void OnValidate()
		{
			if ((bool)target && (bool)clip)
			{
				Vector3 position = target.transform.position;
				Quaternion rotation = target.transform.rotation;
				float num = Mathf.Lerp(0f, clip.length, time);
				clip.SampleAnimation(target, num);
				target.transform.SetPositionAndRotation(position, rotation);
			}
		}
	}
}
