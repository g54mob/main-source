using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowItemList : MonoBehaviour
	{
		private TweenPosition _tween;

		public void Start()
		{
			_tween = GetComponent<TweenPosition>();
		}

		public void OnClick()
		{
			_tween.Toggle();
		}
	}
}
