using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ActivateGameObjectOnHover : MonoBehaviour
	{
		public GameObject Target;

		public void OnHover(bool isOver)
		{
			Target.SetActive(isOver);
		}
	}
}
