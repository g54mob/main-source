using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ActivateGameObjectOnClick : MonoBehaviour
	{
		public GameObject Target;

		public void OnClick()
		{
			Target.SetActive(true);
		}
	}
}
