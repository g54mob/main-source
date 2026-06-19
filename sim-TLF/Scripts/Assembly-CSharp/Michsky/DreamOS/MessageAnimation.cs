using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class MessageAnimation : MonoBehaviour
	{
		public Animator animator;

		private float destroyAfter = 0.5f;

		private void Start()
		{
			destroyAfter = DreamOSInternalTools.GetAnimatorClipLength(animator, "MessageTyping_Start") + 0.1f;
			StartCoroutine(DestroyComponents());
		}

		private IEnumerator DestroyComponents()
		{
			yield return new WaitForSeconds(destroyAfter);
			Object.Destroy(animator);
			Object.Destroy(this);
		}
	}
}
