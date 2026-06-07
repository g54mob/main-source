using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.MainMenu.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Nimbatus.GUI.EndOfGame
{
	public class EndOfGameUi : MonoBehaviour
	{
		[Serializable]
		public class NestedList
		{
			public List<GameObject> Objects = new List<GameObject>();
		}

		public VideoPlayer Video;

		public GameObject VideoPanel;

		public List<NestedList> SlideObjects = new List<NestedList>();

		private int _index;

		public void Start()
		{
			_index = 0;
			SlideObjects.ForEach(delegate(NestedList s)
			{
				s.Objects.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
			});
			StartCoroutine(PlayVideo());
		}

		private IEnumerator PlayVideo()
		{
			AudioController.EnableMusic(false);
			VideoPanel.SetActive(true);
			Video.SetDirectAudioVolume(0, RuntimeGlobals.Settings.MusicVolume);
			bool flag = false;
			try
			{
				Video.Play();
			}
			catch (Exception)
			{
				flag = true;
			}
			if (!flag)
			{
				while (!Video.isPlaying)
				{
					yield return null;
				}
				while (Video.isPlaying && !Input.GetKeyDown(KeyCode.Escape))
				{
					yield return null;
				}
				Video.Stop();
			}
			AudioController.EnableMusic(true);
			VideoPanel.SetActive(false);
			Toggle();
		}

		private void Toggle()
		{
			if (_index > SlideObjects.Count)
			{
				return;
			}
			if (_index > 0)
			{
				SlideObjects[_index - 1].Objects.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
			}
			SlideObjects[_index].Objects.ForEach(delegate(GameObject o)
			{
				o.SetActive(true);
			});
		}

		public void Continue()
		{
			_index++;
			Toggle();
		}

		public void ToMainMenu()
		{
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			SaveManager.StoreSaveGame(false, true);
			MainMenuNavigator.PageToLoad = EMainMenuPage.Main;
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}

		public void ToEndOfGalaxy()
		{
			NimbatusSceneManager.LoadScene("EndOfGalaxyScene");
		}
	}
}
