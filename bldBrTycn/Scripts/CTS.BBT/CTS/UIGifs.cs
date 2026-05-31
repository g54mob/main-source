using System;
using System.Collections;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using UnityEngine.Video;

namespace CTS
{
	public class UIGifs : CTSSingleton<UIGifs>
	{
		[SerializeField]
		private CanvasGroupController _controller;

		[SerializeField]
		private RawImage _image;

		[SerializeField]
		private LocalizeStringEvent _name;

		[SerializeField]
		private LocalizeStringEvent _description;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private UIGifsListSO _listClipTest;

		[SerializeField]
		private RenderTexture _renderTexture;

		[Foldout("Button")]
		[SerializeField]
		private Button _previousButton;

		[Foldout("Button")]
		[SerializeField]
		private Button _nextButton;

		[Foldout("Button")]
		[SerializeField]
		private Button _closeButton;

		[Foldout("Button")]
		[SerializeField]
		private Button _nextButton2;

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

		private LockToggle _time;

		private UIGifsListSO _currentGifsList;

		private int _indexGifs;

		private UIGifsHideButton _nextButtonHide;

		private UIGifsHideButton _previousButtonHide;

		public static event Action GifsOn;

		public static event Action GifValidated;

		protected override void OnDisabled()
		{
		}

		protected override void OnEnabled()
		{
			if (_time == null)
			{
				_time = new LockToggle(MonoSingleton<TimeController>.Instance);
			}
		}

		protected override void SingletonAwake()
		{
			_previousButtonHide = _previousButton.GetComponent<UIGifsHideButton>();
			_nextButtonHide = _nextButton.GetComponent<UIGifsHideButton>();
		}

		protected override void OnSingletonDestroy()
		{
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
			_controller.ShowCanvasGroup(show: false, 1f);
			_time.Unlock();
			UIGifs.GifValidated?.Invoke();
		}

		public void ShowGifs(UIGifsListSO ListSO)
		{
			_currentGifsList = ListSO;
			_indexGifs = 0;
			DisplayCurrentGif();
			SetupLoadingBar(ListSO.ListOfHelp.Count);
			_previousButton.interactable = false;
			_previousButtonHide.HideImages();
			if (ListSO.ListOfHelp.Count > 1)
			{
				_nextButton.interactable = true;
				_nextButtonHide.ShowImages();
			}
			else
			{
				_nextButton.interactable = false;
				_nextButtonHide.HideImages();
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
			if (_indexGifs == _currentGifsList.ListOfHelp.Count - 1)
			{
				_nextButton2.gameObject.SetActive(value: false);
				_closeButton.gameObject.SetActive(value: true);
			}
			if (_indexGifs >= _currentGifsList.ListOfHelp.Count)
			{
				_indexGifs = 0;
			}
			if (_indexGifs > 0)
			{
				_previousButton.interactable = true;
				_previousButtonHide.ShowImages();
			}
			else
			{
				_previousButton.interactable = false;
				_previousButtonHide.HideImages();
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
				_previousButton.interactable = false;
				_previousButtonHide.HideImages();
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
			_controller.ShowCanvasGroup(show: true, 1f);
			UIGifs.GifsOn?.Invoke();
		}

		public void sLaunchVideo(UIGifsListSO listGifs)
		{
			if ((bool)listGifs & (listGifs.ListOfHelp.Count > 0))
			{
				_indexGifs = 0;
				if (listGifs.ListOfHelp.Count == 1)
				{
					_nextButton2.gameObject.SetActive(value: false);
					_closeButton.gameObject.SetActive(value: true);
				}
				else
				{
					_nextButton2.gameObject.SetActive(value: true);
					_closeButton.gameObject.SetActive(value: false);
				}
				DeleteOldBar();
				_time.Lock();
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
					_nextButton2.gameObject.SetActive(value: false);
					_closeButton.gameObject.SetActive(value: true);
				}
				else
				{
					_nextButton2.gameObject.SetActive(value: true);
					_closeButton.gameObject.SetActive(value: false);
				}
				DeleteOldBar();
				_time.Lock();
				StartCoroutine(WaitBeforeGifs(_listClipTest));
			}
		}
	}
}
