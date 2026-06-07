using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class TutorialIndicator : MonoBehaviour
	{
		public UITexture DotTexture;

		public Color SelectedColor;

		public Color NotSelectedColor;

		private FillupTutorial _tutorialList;

		private int _index;

		public void Init(FillupTutorial t, int index)
		{
			_tutorialList = t;
			_index = index;
		}

		public void Update()
		{
			if (_index == _tutorialList.SelectedIndex)
			{
				DotTexture.color = SelectedColor;
			}
			else
			{
				DotTexture.color = NotSelectedColor;
			}
		}

		public void OnClick()
		{
			_tutorialList.ChangeIndexTo(_index);
		}
	}
}
