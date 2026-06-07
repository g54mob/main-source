using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.ObjectManagement
{
	public class EnableOnAwake : MonoBehaviour
	{
		public GameObject ObjectToEnable;

		protected virtual void Awake()
		{
			ObjectToEnable.SetActive(value: true);
		}
	}
}
