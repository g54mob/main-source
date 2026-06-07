using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	public class MMF_PlayerEnabler : MonoBehaviour
	{
		public MMF_Player TargetMmfPlayer { get; set; }

		protected virtual void OnEnable()
		{
		}
	}
}
