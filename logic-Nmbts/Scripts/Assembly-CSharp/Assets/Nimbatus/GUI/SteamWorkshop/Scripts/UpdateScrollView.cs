using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class UpdateScrollView : MonoBehaviour
	{
		public UIScrollView ScrollView;

		public void Start()
		{
			ScrollView.ResetPosition();
		}

		public void ResetPosition()
		{
			ScrollView.ResetPosition();
		}

		public void UpdatePosition()
		{
			ScrollView.transform.position = ScrollView.transform.position + new Vector3(0f, -0.0001f, 0f);
			ScrollView.UpdateScrollbars(true);
		}

		public void OnScroll(float delta)
		{
			if ((bool)ScrollView && NGUITools.GetActive(this))
			{
				ScrollView.Scroll(delta);
			}
		}
	}
}
