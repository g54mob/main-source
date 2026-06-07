using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.ObjectManagement
{
	public class DisableScript : MonoBehaviour
	{
		protected virtual void Awake()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
