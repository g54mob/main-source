using UnityEngine;

namespace OneUseScripts
{
	public class DisableOnNotEditor : MonoBehaviour
	{
		private void Start()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
