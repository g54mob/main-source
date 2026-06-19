using System.Collections.Generic;
using TH20.ExtContent;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class DynamicPlaylistUI : MonoBehaviour
	{
		private const bool cHideExtContentUIParents = true;

		[SerializeField]
		private GameObject _scrollAreaContent;

		[SerializeField]
		private GameObject _rowPrefabSource;

		[SerializeField]
		private ScrollRect _scrollRectContents;

		[SerializeField]
		private Color _colorTextSource;

		[SerializeField]
		private Color _colorTextArtist;

		[SerializeField]
		private Color _colorTextTrack;

		[SerializeField]
		private Color _colorTextDisabled;

		[SerializeField]
		private Color _colorTextError;

		[SerializeField]
		private DynamicButton _buttonNewItem;

		[SerializeField]
		private GameObject _gameObjectTrackProgressPanelParent;

		[SerializeField]
		private GameObject _prefabTrackProgressPanel;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private GameObject _parentUIScreen;

		private List<DynamicPlaylistUIRowSource> _sourceRows;

		private DynamicPlaylistUITrackProgressPanel _trackProgressPanel;

		private string _clrMarkupStrArtist;

		private string _clrMarkupStrTrack;

		private string _clrMarkupStrDisabled;

		private string _clrMarkupStrError;

		private bool _bPlaylistChangesMade;

		private MessageBox _messageBox;

		private AudioClipStreamingTest _audioClipStreamingTest;

		public Color ColorTextSource => _colorTextSource;

		public Color ColorTextArtist => _colorTextArtist;

		public Color ColorTextTrack => _colorTextTrack;

		public Color ColorTextDisabled => _colorTextDisabled;

		public Color ColorTextError => _colorTextError;

		public DynamicPlaylistUI()
		{
			_sourceRows = new List<DynamicPlaylistUIRowSource>();
		}

		public void Init(DynamicPlaylistManager dynamicPlaylistManager, GameObject parentUIScreen, MessageBox messageBox)
		{
			_dynamicPlaylistManager = dynamicPlaylistManager;
			_parentUIScreen = parentUIScreen;
			_messageBox = messageBox;
			_clrMarkupStrArtist = ColorToColorMarkup(_colorTextArtist);
			_clrMarkupStrTrack = ColorToColorMarkup(_colorTextTrack);
			_clrMarkupStrDisabled = ColorToColorMarkup(_colorTextDisabled);
			_clrMarkupStrError = ColorToColorMarkup(_colorTextError);
			if (_buttonNewItem != null && ShouldAllowAddLocalModItems())
			{
				_buttonNewItem.onPrimaryDown.AddListener(OnButtonNewLocalModItem);
			}
			_dynamicPlaylistManager.OnDynamicPlaylistChanged += OnDynamicPlaylistChanged;
			ExtContentUtils.ExtContentManager.ExtContentUIManager.OnAllExtContentUIScreensClosed += OnAllExtContentUIScreensClosed;
			RebuildSourceRows();
			RefreshUISetNewItemButtonEnabledStatus();
			CreateTrackProgressPanel();
		}

		public void DeInit()
		{
			if (_buttonNewItem != null && ShouldAllowAddLocalModItems())
			{
				_buttonNewItem.onPrimaryDown.RemoveListener(OnButtonNewLocalModItem);
			}
			_dynamicPlaylistManager.OnDynamicPlaylistChanged -= OnDynamicPlaylistChanged;
			ExtContentUtils.ExtContentManager.ExtContentUIManager.OnAllExtContentUIScreensClosed -= OnAllExtContentUIScreensClosed;
			DestroySourceRows();
			DestroyTrackProgressPanel();
		}

		public void SetVisible(bool bVisible)
		{
			base.gameObject.SetActive(bVisible);
			OnUIPanelVisiblilityChanged(bVisible);
		}

		public void OnTrackPreviewStatusChanged()
		{
			foreach (DynamicPlaylistUIRowSource sourceRow in _sourceRows)
			{
				sourceRow.OnTrackPreviewStatusChanged();
			}
		}

		public void OnPlaylistChangesMade()
		{
			_bPlaylistChangesMade = true;
			_dynamicPlaylistManager.BuildEnabledItemsList();
		}

		public void StopPreview()
		{
			_dynamicPlaylistManager.StopPreview();
			OnTrackPreviewStatusChanged();
		}

		public void Update()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			ProcessInputs();
			if (_trackProgressPanel != null)
			{
				_trackProgressPanel.RefreshUI();
			}
			foreach (DynamicPlaylistUIRowSource sourceRow in _sourceRows)
			{
				sourceRow.FrameUpdate();
			}
		}

		public string GetMarkedUpStringArtistName(bool bEnabled, bool bError, string artistName)
		{
			return GetColourMarkupString(artistName, bError ? _clrMarkupStrError : (bEnabled ? _clrMarkupStrArtist : _clrMarkupStrDisabled));
		}

		public string GetMarkedUpStringTrackName(bool bEnabled, bool bError, string trackName)
		{
			return GetColourMarkupString(trackName, bError ? _clrMarkupStrError : (bEnabled ? _clrMarkupStrTrack : _clrMarkupStrDisabled));
		}

		public void OpenGameItemUIScreen(GameItemBase gameItem)
		{
			OpenGameItemUIScreenImpl(gameItem);
		}

		public void ExpandAll(bool bExpand)
		{
			int i = 0;
			for (int count = _sourceRows.Count; i < count; i++)
			{
				_sourceRows[i].SetExpanded(bExpand);
			}
		}

		private bool ShouldAllowAddLocalModItems()
		{
			return _dynamicPlaylistManager.Config._allowLocalModCreationPC;
		}

		private void ProcessInputs()
		{
			ProcessAudioClipStreamingTestInputs();
		}

		private void RefreshUISetNewItemButtonEnabledStatus()
		{
			if (!(_buttonNewItem != null))
			{
				return;
			}
			bool bAllowAddItem = ShouldAllowAddLocalModItems();
			ExtContentUIUtils.SetSelectableInteractable(_buttonNewItem, bAllowAddItem);
			CanvasGroup componentInChildren = _buttonNewItem.gameObject.transform.GetComponentInChildren<CanvasGroup>();
			if (componentInChildren != null)
			{
				componentInChildren.alpha = (bAllowAddItem ? 1f : 0.1f);
			}
			TooltipSpawner componentInChildren2 = _buttonNewItem.gameObject.transform.GetComponentInChildren<TooltipSpawner>();
			if (componentInChildren2 != null)
			{
				componentInChildren2.SetShouldShowFunc(() => bAllowAddItem);
			}
		}

		private void CreateTrackProgressPanel()
		{
			if (!(_gameObjectTrackProgressPanelParent != null) || !(_prefabTrackProgressPanel != null))
			{
				return;
			}
			GameObject gameObject = Object.Instantiate(_prefabTrackProgressPanel, _gameObjectTrackProgressPanelParent.transform);
			if (gameObject != null)
			{
				_trackProgressPanel = gameObject.GetComponent<DynamicPlaylistUITrackProgressPanel>();
				if (_trackProgressPanel != null)
				{
					_trackProgressPanel.Init(_dynamicPlaylistManager);
				}
			}
		}

		private void DestroyTrackProgressPanel()
		{
			if (_trackProgressPanel != null)
			{
				_trackProgressPanel.DeInit();
				_trackProgressPanel = null;
			}
		}

		private void OnUIPanelVisiblilityChanged(bool bVisible)
		{
			if (!bVisible)
			{
				StopPreview();
				if (_bPlaylistChangesMade)
				{
					_bPlaylistChangesMade = false;
					_dynamicPlaylistManager.BuildEnabledItemsList();
					_dynamicPlaylistManager.SetSaveToFilePending();
				}
			}
			else
			{
				OnTrackPreviewStatusChanged();
			}
		}

		public static string GetColourMarkupString(string text, string markupStr)
		{
			return markupStr + text + ColorMarkupOff();
		}

		public static string ColorMarkupOff()
		{
			return "</color>";
		}

		public static string ColorToColorMarkup(Color clr)
		{
			string text = $"{(int)(clr.r * 255f):X}";
			string text2 = $"{(int)(clr.g * 255f):X}";
			string text3 = $"{(int)(clr.b * 255f):X}";
			string text4 = $"{(int)(clr.a * 255f):X}";
			if (text.Length < 2)
			{
				text = "0" + text;
			}
			if (text2.Length < 2)
			{
				text2 = "0" + text2;
			}
			if (text3.Length < 2)
			{
				text3 = "0" + text3;
			}
			if (text4.Length < 2)
			{
				text4 = "0" + text4;
			}
			return $"<color=#{text}{text2}{text3}{text4}>";
		}

		private void DestroySourceRows()
		{
			int i = 0;
			for (int count = _sourceRows.Count; i < count; i++)
			{
				_sourceRows[i].DeInit();
				Object.Destroy(_sourceRows[i].gameObject);
				_sourceRows[i] = null;
			}
			_sourceRows.Clear();
		}

		private void RebuildSourceRows()
		{
			DestroySourceRows();
			int i = 0;
			for (int count = _dynamicPlaylistManager.SourcesList.Count; i < count; i++)
			{
				DynPlaylistSourceItem dynPlaylistSourceItem = _dynamicPlaylistManager.SourcesList[i];
				if (!dynPlaylistSourceItem._bContentValid)
				{
					continue;
				}
				GameObject gameObject = Object.Instantiate(_rowPrefabSource, _scrollAreaContent.transform);
				if (gameObject != null)
				{
					DynamicPlaylistUIRowSource component = gameObject.GetComponent<DynamicPlaylistUIRowSource>();
					if (component != null)
					{
						component.Init(this, _dynamicPlaylistManager, _scrollAreaContent, dynPlaylistSourceItem._itemId, _messageBox);
						_sourceRows.Add(component);
					}
				}
			}
			if (_scrollRectContents != null)
			{
				_scrollRectContents.normalizedPosition = new Vector2(0f, 1f);
			}
		}

		private void OnButtonNewLocalModItem()
		{
			ExtContentGameItemUIScreen gameItemUIScreen = ExtContentUtils.ExtContentManager.ExtContentUIManager.GameItemUIScreen;
			if (gameItemUIScreen != null)
			{
				StopPreview();
				gameItemUIScreen.Configure(bCreateNewItem: true, bAllowAmendContentType: false, EContentType.MusicPack, null, null);
				gameItemUIScreen.Show(_parentUIScreen.transform, bHideInvokingSiblingUI: true);
			}
		}

		public void OpenGameItemUIScreenImpl(GameItemBase gameItem)
		{
			StopPreview();
			ExtContentUIUtils.OpenGameItemUIOrWorkshopUIScreen(gameItem, _parentUIScreen.transform, bHideInvokingSiblingUI: true);
		}

		private void OnDynamicPlaylistChanged()
		{
			RebuildSourceRows();
		}

		private void OnAllExtContentUIScreensClosed()
		{
		}

		private void ProcessAudioClipStreamingTestInputs()
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T) && _audioClipStreamingTest == null)
			{
				GameObject gameObject = new GameObject();
				_audioClipStreamingTest = gameObject.AddComponent<AudioClipStreamingTest>();
			}
		}
	}
}
