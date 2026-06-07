using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class ShowPrevPage : MonoBehaviour
	{
		public UITexture Texture;

		public ShowTutorial Tutorial;

		public void Update()
		{
			if (Tutorial.HasPrevPage())
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
			if (Tutorial.HasPrevPage())
			{
				Tutorial.ShowPrevPage();
			}
		}
	}
}
