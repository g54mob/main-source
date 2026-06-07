using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class FillupTutorial : MonoBehaviour
	{
		public GameObject TutorialButtonPrefab;

		public UIGrid TutorialGrid;

		public UILabel TitleLabel;

		public UILabel DescriptionLabel;

		public TutorialIndicator IndicatorPrefab;

		public UIGrid IndicatorGrid;

		[HideInInspector]
		public int SelectedIndex;

		public void Start()
		{
			IndicatorGrid.gameObject.SetActive(true);
			IndicatorGrid.enabled = true;
			IndicatorGrid.transform.DestroyChildren();
			for (int i = 0; i < EnumHelper.GetValues<ETutorialDifficulty>().Count(); i++)
			{
				TutorialIndicator tutorialIndicator = Object.Instantiate(IndicatorPrefab);
				tutorialIndicator.Init(this, i);
				tutorialIndicator.transform.position = IndicatorGrid.transform.position;
				tutorialIndicator.transform.parent = IndicatorGrid.transform;
				tutorialIndicator.transform.localScale = IndicatorGrid.transform.localScale;
				IndicatorGrid.repositionNow = true;
				IndicatorGrid.Reposition();
			}
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.LastTutorialDifficulty == ETutorialDifficulty.Advanced)
			{
				SelectedIndex = 1;
			}
			else
			{
				SelectedIndex = 0;
			}
			Fill();
		}

		public void Fill()
		{
			TutorialGrid.gameObject.SetActive(true);
			TutorialGrid.enabled = true;
			TutorialGrid.transform.DestroyChildren();
			foreach (Tutorial item in GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Tutorials.Where((Tutorial t) => t.Difficulty == (ETutorialDifficulty)SelectedIndex))
			{
				GameObject obj = Object.Instantiate(TutorialButtonPrefab);
				obj.GetComponentInChildren<InitTutorial>().TutorialType = item.TutorialType;
				obj.GetComponentInChildren<InitTutorial>().Init();
				obj.transform.position = TutorialGrid.transform.position;
				obj.transform.parent = TutorialGrid.transform;
				obj.transform.localScale = TutorialGrid.transform.localScale;
				TutorialGrid.repositionNow = true;
				TutorialGrid.Reposition();
			}
			TitleLabel.text = LocalizationManager.GetTranslation("MainMenu/TutorialTitle" + (ETutorialDifficulty)SelectedIndex);
			DescriptionLabel.text = LocalizationManager.GetTranslation("MainMenu/TutorialDescription" + (ETutorialDifficulty)SelectedIndex);
		}

		private void ChangeIndex(bool up)
		{
			if (up)
			{
				if (SelectedIndex + 1 < EnumHelper.GetValues<ETutorialDifficulty>().Count())
				{
					SelectedIndex++;
				}
				else
				{
					SelectedIndex = 0;
				}
			}
			else if (SelectedIndex - 1 >= 0)
			{
				SelectedIndex--;
			}
			else
			{
				SelectedIndex = EnumHelper.GetValues<ETutorialDifficulty>().Count() - 1;
			}
			Fill();
		}

		public void ChangeUp()
		{
			ChangeIndex(true);
		}

		public void ChangeDown()
		{
			ChangeIndex(false);
		}

		public void ChangeIndexTo(int index)
		{
			SelectedIndex = index;
			Fill();
		}

		public void Update()
		{
			TutorialGrid.repositionNow = true;
			TutorialGrid.Reposition();
			IndicatorGrid.repositionNow = true;
			IndicatorGrid.Reposition();
		}
	}
}
