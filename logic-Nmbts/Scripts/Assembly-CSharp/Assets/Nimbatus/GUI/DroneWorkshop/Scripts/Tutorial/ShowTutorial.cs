using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Tutorial
{
	public class ShowTutorial : MonoBehaviour
	{
		public UITexture Image;

		public VideoPlayer VideoPlayer;

		public UILabel TextLabel;

		public TweenPosition Tween;

		public TweenTutorial CloseButton;

		[HideInInspector]
		public List<TutorialPage> Pages = new List<TutorialPage>();

		[HideInInspector]
		public int CurrentIndex;

		public void Start()
		{
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null)
			{
				return;
			}
			Pages.Clear();
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.TutorialSlides.Count == 0)
			{
				return;
			}
			foreach (TutorialSlide tutorialSlide in GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.TutorialSlides)
			{
				TutorialPage tutorialPage = new TutorialPage();
				if (tutorialSlide.Image != null)
				{
					tutorialPage.Image = tutorialSlide.Image;
					Image.gameObject.SetActive(true);
					VideoPlayer.gameObject.SetActive(false);
				}
				if (tutorialSlide.VideoClip != null)
				{
					tutorialPage.Clip = tutorialSlide.VideoClip;
					VideoPlayer.gameObject.SetActive(true);
					Image.gameObject.SetActive(false);
				}
				tutorialPage.Text = tutorialSlide.Description.GetTranslation();
				Pages.Add(tutorialPage);
			}
			CurrentIndex = 0;
			ShowPage(Pages[CurrentIndex]);
			CloseButton.gameObject.SetActive(!HasMoreThanOnePage());
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				if (HasNextPage())
				{
					ShowNextPage();
				}
				else
				{
					CloseButton.OnClick();
				}
			}
		}

		public void Show(bool show)
		{
			Tween.Play(show);
			try
			{
				if (show && VideoPlayer.enabled)
				{
					VideoPlayer.Stop();
					VideoPlayer.Play();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			RuntimeGlobals.BlockUInteraction = show;
		}

		public bool HasNextPage()
		{
			return Pages.Count > CurrentIndex + 1;
		}

		public bool HasPrevPage()
		{
			return CurrentIndex - 1 >= 0;
		}

		public bool HasMoreThanOnePage()
		{
			return Pages.Count > 1;
		}

		public void ShowNextPage()
		{
			CurrentIndex++;
			ShowPage(Pages[CurrentIndex]);
			CloseButton.gameObject.SetActive(!HasNextPage());
		}

		public void ShowPrevPage()
		{
			CurrentIndex--;
			ShowPage(Pages[CurrentIndex]);
			CloseButton.gameObject.SetActive(!HasNextPage());
		}

		private void ShowPage(TutorialPage page)
		{
			Image.mainTexture = page.Image;
			VideoPlayer.Stop();
			VideoPlayer.Play();
			VideoPlayer.clip = page.Clip;
			TextLabel.text = page.Text;
		}
	}
}
