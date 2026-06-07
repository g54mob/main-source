using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class DeactivateGameObjectOnClick : MonoBehaviour
	{
		public GameObject Target;

		public void OnClick()
		{
			Target.SetActive(false);
		}
	}
}
