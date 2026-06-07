using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class ShowCurrentPageIndex : MonoBehaviour
	{
		public UILabel Label;

		public ShowTutorial Tutorial;

		private void Update()
		{
			if (Tutorial.HasMoreThanOnePage())
			{
				Label.enabled = true;
			}
			else
			{
				Label.enabled = false;
			}
			Label.text = Tutorial.CurrentIndex + 1 + "/" + Tutorial.Pages.Count;
		}
	}
}
