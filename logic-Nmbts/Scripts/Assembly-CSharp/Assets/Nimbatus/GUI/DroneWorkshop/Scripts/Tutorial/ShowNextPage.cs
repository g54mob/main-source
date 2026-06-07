using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class ShowNextPage : MonoBehaviour
	{
		public UITexture Texture;

		public ShowTutorial Tutorial;

		public void Update()
		{
			if (Tutorial.HasNextPage())
			{
				Texture.enabled = true;
			}
			else
			{
				Texture.enabled = false;
			}
		}

		public void OnClick()
		{
			if (Tutorial.HasNextPage())
			{
				Tutorial.ShowNextPage();
			}
		}
	}
}
