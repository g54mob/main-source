using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class HideWhileTween : MonoBehaviour
	{
		public TweenPosition Tween;

		public GameObject GameObjectToHide;

		public void Update()
		{
			GameObjectToHide.SetActive(Tween.value != Tween.from);
		}
	}
}
