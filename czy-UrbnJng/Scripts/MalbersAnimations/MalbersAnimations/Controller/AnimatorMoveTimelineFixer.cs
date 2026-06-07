using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Timeline/Animator Move Timeline Fixer")]
	[ExecuteInEditMode]
	public class AnimatorMoveTimelineFixer : MonoBehaviour
	{
		public Animator anim;

		private void Start()
		{
			if (Application.isPlaying)
			{
				Object.Destroy(this);
			}
			anim = GetComponent<Animator>();
		}
	}
}
