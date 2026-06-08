using UnityEngine;

namespace Dorfromantik
{
	public class TileSlotHighlighter : MonoBehaviour
	{
		private Animator animator;

		[SerializeField]
		private GameObject regularVersion;

		[SerializeField]
		private GameObject mirroredVersion;

		[SerializeField]
		private bool rotationTween;

		private void Awake()
		{
			animator = GetComponentInChildren<Animator>();
		}

		public void Show(bool show)
		{
			animator.SetBool("Visible", show);
		}

		public void SetMirrored(bool mirrored)
		{
			Debug.Log($"Set Mirrored {mirrored}");
			animator.SetBool("Mirrored", mirrored);
		}
	}
}
