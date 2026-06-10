using UnityEngine;

namespace NSMedieval.Construction
{
	public class DisableAnimatorOnAnimationEnd : MonoBehaviour
	{
		public void Disable()
		{
			base.gameObject.GetComponent<Animator>().enabled = false;
		}
	}
}
