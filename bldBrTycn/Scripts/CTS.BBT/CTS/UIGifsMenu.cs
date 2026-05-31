using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using UnityEngine.Video;

namespace CTS
{
	public class UIGifsMenu : CTSSingleton<UIGifsMenu>
	{
		[SerializeField]
		private RawImage _image;

		[SerializeField]
		private LocalizeStringEvent _name;

		[SerializeField]
		private LocalizeStringEvent _description;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		[BoxGroup("Test")]
		private UIGifsListSO _listClipTest;

		[SerializeField]
		private RenderTexture _renderTexture;

		[Foldout("Button")]
		[SerializeField]
		private Button _previousButton;

		[Foldout("Button")]
		[SerializeField]
		private Button _nextButton;

		[Foldout("Loading Bar")]
		[SerializeField]
		private GameObject _prefabLoadingBar;

		[SerializeField]
		private GameObject _parentForPrefabBar;

		[SerializeField]
		private Color _onColorBar;

		[SerializeField]
		private Color _offColorBar;

		private List<GameObject> _listLoadingBar;

		private UIGifsListSO _currentGifsList;

		private int _indexGifs;

		private UIGifsHideButton _nextButtonHide;

		private UIGifsHideButton _previousButtonHide;

		public static event Action GifsOn;

		public static event Action GifValidated;

		protected override void SingletonAwake()
		{
			_previousButtonHide = _previousButton.GetComponent<UIGifsHideButton>();
			_nextButtonHide = _nextButton.GetComponent<UIGifsHideButton>();
			UIHelpListToggle.OnHelpGiftChanged += UIHelpListToggle_OnHelpGiftChanged;
		}

		protected override void OnSingletonDestroy()
		{
			UIHelpListToggle.OnHelpGiftChanged -= UIHelpListToggle_OnHelpGiftChanged;
		}

		private void UIHelpListToggle_OnHelpGiftChanged(UIGifsListSO obj)
		{
			LaunchVideo(obj);
		}

		public void ShowGifs(string nameEntryName, string descriptionEntryName, VideoClip videoClip)
		{
			string table = GUIDHelper.FindTableID(nameEntryName);
			_name.SetTable(table);
			_description.SetTable(table);
			_name.SetEntry(nameEntryName);
			_description.SetEntry(descriptionEntryName);
			_videoPlayer.clip = videoClip;
			_videoPlayer.Play();
		}

		public void ShowMessage(LocalizedString name, LocalizedString description, Sprite sprite = null)
		{
			_image.texture = sprite.texture;
			_name.StringReference = name;
			_description.StringReference = description;
		}

		public void ShowGifs(LocalizedString name, LocalizedString description, VideoClip videoClip)
		{
			_videoPlayer.clip = videoClip;
			_name.StringReference = name;
			_description.StringReference = description;
			_videoPlayer.Play();
		}

		public void MessageValidation()
		{
			_videoPlayer.Stop();
			UIGifsMenu.GifValidated?.Invoke();
		}

		public void ShowGifs(UIGifsListSO ListSO)
		{
			_currentGifsList = ListSO;
			_indexGifs = 0;
			DisplayCurrentGif();
			SetupLoadingBar(ListSO.ListOfHelp.Count);
			_previousButtonHide.NotInteractableButton();
			_previousButton.interactable = false;
			if (ListSO.ListOfHelp.Count > 1)
			{
				_nextButtonHide.ShowImages();
				_nextButton.interactable = true;
			}
			else
			{
				_nextButtonHide.NotInteractableButton();
				_nextButton.interactable = false;
			}
		}

		private void SetupLoadingBar(int clipCount)
		{
			_parentForPrefabBar.gameObject.SetActive(clipCount > 1);
			_listLoadingBar = new List<GameObject>();
			for (int i = 0; i < clipCount; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_prefabLoadingBar, _parentForPrefabBar.transform);
				_listLoadingBar.Add(gameObject);
				gameObject.GetComponent<Image>().color = ((i == 0) ? _onColorBar : _offColorBar);
			}
		}

		private void DisplayCurrentGif()
		{
			UIGifsSO uIGifsSO = _currentGifsList.ListOfHelp[_indexGifs];
			switch (uIGifsSO.SelectedMediaType)
			{
			case UIGifsSO.EHelpingMediaType.Image:
				ShowMessage(uIGifsSO.VideoTitle, uIGifsSO.VideoBody, uIGifsSO.Image);
				break;
			case UIGifsSO.EHelpingMediaType.VideoClip:
				_image.texture = _renderTexture;
				ShowGifs(uIGifsSO.VideoTitle, uIGifsSO.VideoBody, uIGifsSO.VideoClip);
				break;
			case UIGifsSO.EHelpingMediaType.none:
				break;
			}
		}

		public void NextVideo()
		{
			UpdateLoadingBarColor(_offColorBar);
			_indexGifs++;
			if (_indexGifs >= _currentGifsList.ListOfHelp.Count - 1)
			{
				_indexGifs = _currentGifsList.ListOfHelp.Count - 1;
				_nextButtonHide.NotInteractableButton();
				_nextButton.interactable = false;
			}
			if (_indexGifs > 0)
			{
				_previousButtonHide.ShowImages();
				_previousButton.interactable = true;
			}
			UpdateLoadingBarColor(_onColorBar);
			DisplayCurrentGif();
		}

		public void PreviousVideo()
		{
			UpdateLoadingBarColor(_offColorBar);
			_indexGifs--;
			if (_indexGifs <= 0)
			{
				_indexGifs = 0;
				_previousButtonHide.NotInteractableButton();
				_previousButton.interactable = false;
			}
			if (_indexGifs < _currentGifsList.ListOfHelp.Count)
			{
				_nextButtonHide.ShowImages();
				_nextButton.interactable = true;
			}
			UpdateLoadingBarColor(_onColorBar);
			DisplayCurrentGif();
		}

		private void UpdateLoadingBarColor(Color color)
		{
			_listLoadingBar[_indexGifs].GetComponent<Image>().color = color;
		}

		private IEnumerator WaitBeforeGifs(UIGifsListSO listGifs)
		{
			ShowGifs(listGifs);
			yield return new WaitForSecondsRealtime(0.25f);
			UIGifsMenu.GifsOn?.Invoke();
		}

		public void LaunchVideo(UIGifsListSO listGifs)
		{
			if ((bool)listGifs & (listGifs.ListOfHelp.Count > 0))
			{
				_indexGifs = 0;
				DeleteOldBar();
				if (_listClipTest.ListOfHelp.Count == 1)
				{
					_previousButtonHide.NotInteractableButton();
					_previousButton.interactable = false;
					_nextButtonHide.NotInteractableButton();
					_nextButton.interactable = false;
				}
				else
				{
					_previousButtonHide.NotInteractableButton();
					_previousButton.interactable = false;
					_nextButtonHide.ShowImages();
					_nextButton.interactable = true;
				}
				StartCoroutine(WaitBeforeGifs(listGifs));
			}
		}

		private void DeleteOldBar()
		{
			if (_listLoadingBar == null || _listLoadingBar.Count <= 0)
			{
				return;
			}
			foreach (GameObject item in _listLoadingBar)
			{
				UnityEngine.Object.Destroy(item);
			}
			_listLoadingBar.Clear();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void TestLaunchVideo()
		{
			if ((bool)_listClipTest & (_listClipTest.ListOfHelp.Count > 0))
			{
				_indexGifs = 0;
				if (_listClipTest.ListOfHelp.Count == 1)
				{
					_previousButtonHide.NotInteractableButton();
					_nextButtonHide.NotInteractableButton();
					_previousButton.interactable = false;
					_nextButton.interactable = false;
				}
				else
				{
					_previousButtonHide.NotInteractableButton();
					_nextButtonHide.ShowImages();
					_previousButton.interactable = false;
					_nextButton.interactable = true;
				}
				DeleteOldBar();
				StartCoroutine(WaitBeforeGifs(_listClipTest));
			}
		}
	}
}
