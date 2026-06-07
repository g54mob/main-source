using UnityEngine;

namespace CTS
{
	public class DisableGameObjectInPlay : MonoBehaviour
	{
		[SerializeField]
		private bool stillEnabledInPlayMode;

		private void Awake()
		{
			base.gameObject.SetActive(stillEnabledInPlayMode);
		}
	}
}
