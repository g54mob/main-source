using UnityEngine;

namespace Assets.Scripts
{
	public class DisableScript : MonoBehaviour
	{
		protected virtual void Awake()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
