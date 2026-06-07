using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.ObjectManagement
{
	public class DisableOnMobile : MonoBehaviour
	{
		protected virtual void Awake()
		{
			if (Game.Instance.Device.IsMobileBuild)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
