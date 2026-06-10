using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	public class DemoGhost : MonoBehaviour
	{
		public virtual void OnAnimationEnd()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
