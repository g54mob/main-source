#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using I2.Loc;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class DynamicPlaylistUIRowSource : MonoBehaviour
	{
		[SerializeField]
		private GameObject _rowPrefabTrack;

		[SerializeField]
		private Toggle _toggleEnabled;

		[SerializeField]
		private DynamicButton _buttonExpand;

		[SerializeField]
		private DynamicButton _buttonCollapse;

		[SerializeField]
		private TMP_Text _textSourceName;

		[SerializeField]
		private DynamicButton _buttonLocalModEdit;

		[SerializeField]
		private DynamicButton _buttonOpenWorkshop;

		private DynamicPlaylistUI _dynamicPlaylistUI;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private GameObject _rowParent;

		private string _sourceItemId;

		private List<DynamicPlaylistUIRowTrack> _trackRows;

		private bool _bInitialising;

		private MessageBox _messageBox;

		public DynamicPlaylistUIRowSource()
		{
			_trackRows = new List<DynamicPlaylistUIRowTrack>();
		}

		public void Init(DynamicPlaylistUI dynamicPlaylistUI, DynamicPlaylistManager dynamicPlaylistManager, GameObject rowParent, string sourceItemId, MessageBox messageBox)
		{
			_bInitialising = true;
			_dynamicPlaylistUI = dynamicPlaylistUI;
			_dynamicPlaylistManager = dynamicPlaylistManager;
			_rowParent = rowParent;
			_sourceItemId = sourceItemId;
			_messageBox = messageBox;
			if (_toggleEnabled != null)
			{
				_toggleEnabled.onValueChanged.AddListener(OnToggleChangeEnabled);
			}
			if (_buttonExpand != null)
			{
				_buttonExpand.onPrimaryDown.AddListener(OnButtonExpand);
			}
			if (_buttonCollapse != null)
			{
				_buttonCollapse.onPrimaryDown.AddListener(OnButtonCollapse);
			}
			if (_buttonLocalModEdit != null)
			{
				_buttonLocalModEdit.onPrimaryDown.AddListener(OnButtonLocalModEdit);
			}
			if (_buttonOpenWorkshop != null)
			{
				_buttonOpenWorkshop.onPrimaryDown.AddListener(OnButtonOpenWorkshop);
			}
			RebuildTrackRows();
			RefreshUI();
			_bInitialising = false;
		}

		public void DeInit()
		{
			if (_toggleEnabled != null)
			{
				_toggleEnabled.onValueChanged.RemoveListener(OnToggleChangeEnabled);
			}
			if (_buttonExpand != null)
			{
				_buttonExpand.onPrimaryDown.RemoveListener(OnButtonExpand);
			}
			if (_buttonCollapse != null)
			{
				_buttonCollapse.onPrimaryDown.RemoveListener(OnButtonCollapse);
			}
			if (_buttonLocalModEdit != null)
			{
				_buttonLocalModEdit.onPrimaryDown.RemoveListener(OnButtonLocalModEdit);
			}
			if (_buttonOpenWorkshop != null)
			{
				_buttonOpenWorkshop.onPrimaryDown.RemoveListener(OnButtonOpenWorkshop);
			}
			DestroyTrackRows();
		}

		public void RefreshUI()
		{
			RefreshUISourceNameText();
			RefreshUIButtonExtContentButtons();
			RefreshUIToggleEnabledState();
			RefreshUIButtonsExpandCollapse();
		}

		public void OnTrackPreviewStatusChanged()
		{
			foreach (DynamicPlaylistUIRowTrack trackRow in _trackRows)
			{
				trackRow.OnTrackPreviewStatusChanged();
			}
		}

		public void SetExpanded(bool BExpanded)
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				sourceItem._bExpandedUI = BExpanded;
				UpdateTrackRowsExpandedStatus();
				_dynamicPlaylistUI.OnPlaylistChangesMade();
			}
		}

		public void FrameUpdate()
		{
			foreach (DynamicPlaylistUIRowTrack trackRow in _trackRows)
			{
				trackRow.FrameUpdate();
			}
		}

		private void DestroyTrackRows()
		{
			int i = 0;
			for (int count = _trackRows.Count; i < count; i++)
			{
				_trackRows[i].DeInit();
				Object.Destroy(_trackRows[i].gameObject);
				_trackRows[i] = null;
			}
			_trackRows.Clear();
		}

		private DynPlaylistSourceItem GetSourceItem()
		{
			return _dynamicPlaylistManager.FindSourceItemById(_sourceItemId);
		}

		private void RebuildTrackRows()
		{
			_trackRows.Clear();
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				int i = 0;
				for (int count = sourceItem._trackItems.Count; i < count; i++)
				{
					DynPlaylistTrackItem dynPlaylistTrackItem = sourceItem._trackItems[i];
					GameObject gameObject = Object.Instantiate(_rowPrefabTrack, _rowParent.transform);
					if (gameObject != null)
					{
						DynamicPlaylistUIRowTrack component = gameObject.GetComponent<DynamicPlaylistUIRowTrack>();
						if (component != null)
						{
							component.Init(_dynamicPlaylistUI, _dynamicPlaylistManager, _rowParent, _sourceItemId, dynPlaylistTrackItem._itemId);
							_trackRows.Add(component);
						}
					}
				}
			}
			UpdateTrackRowsExpandedStatus();
		}

		private void RefreshUISourceNameText()
		{
			if (_textSourceName != null)
			{
				DynPlaylistSourceItem sourceItem = GetSourceItem();
				if (sourceItem != null)
				{
					_textSourceName.text = sourceItem._sourceName;
					_textSourceName.color = (sourceItem._bEnabled ? _dynamicPlaylistUI.ColorTextSource : _dynamicPlaylistUI.ColorTextDisabled);
				}
			}
		}

		private void RefreshUIButtonExtContentButtons()
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (_buttonLocalModEdit != null)
			{
				_buttonLocalModEdit.gameObject.SetActive(sourceItem != null && sourceItem._type == DynPlaylistSource.LocalMod);
			}
			if (_buttonOpenWorkshop != null)
			{
				_buttonOpenWorkshop.gameObject.SetActive(sourceItem != null && sourceItem._type == DynPlaylistSource.Workshop);
			}
		}

		private void RefreshUIToggleEnabledState()
		{
			if (_toggleEnabled != null)
			{
				DynPlaylistSourceItem sourceItem = GetSourceItem();
				if (sourceItem != null)
				{
					_toggleEnabled.isOn = sourceItem._bEnabled;
				}
			}
		}

		private void RefreshUIButtonsExpandCollapse()
		{
			if (_buttonExpand != null && _buttonCollapse != null)
			{
				bool flag = false;
				DynPlaylistSourceItem sourceItem = GetSourceItem();
				if (sourceItem != null)
				{
					flag = !sourceItem._bExpandedUI;
				}
				_buttonExpand.gameObject.SetActive(flag);
				_buttonCollapse.gameObject.SetActive(!flag);
			}
		}

		private void OnToggleChangeEnabled(bool bStatus)
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem == null)
			{
				return;
			}
			bool flag = true;
			if (!_bInitialising && !bStatus)
			{
				sourceItem._bEnabled = false;
				if (_dynamicPlaylistManager.GetNumEnabledTracks() < 1)
				{
					flag = false;
				}
				sourceItem._bEnabled = true;
			}
			if (flag)
			{
				sourceItem._bEnabled = bStatus;
				RefreshUISourceNameText();
				foreach (DynamicPlaylistUIRowTrack trackRow in _trackRows)
				{
					trackRow.RefreshUI();
				}
				RefreshUIToggleEnabledState();
				_dynamicPlaylistUI.OnPlaylistChangesMade();
				return;
			}
			RefreshUIToggleEnabledState();
			if (!(_messageBox == null))
			{
				_messageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				string messageString = ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageTitle);
				string messageString2 = ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageBody);
				Logging.Info(string.Format("Opened message box: Title: '{0}', Body: '{1}'", messageString, messageString2.Replace("\n", "")));
				_messageBox.Show(messageString, messageString2, ScriptLocalization.Menu_Messages.OK_Button_CS);
			}
		}

		private void OnButtonExpand()
		{
			OnButtonExpandCollapse();
		}

		private void OnButtonCollapse()
		{
			OnButtonExpandCollapse();
		}

		private void OnButtonExpandCollapse()
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					_dynamicPlaylistUI.ExpandAll(!sourceItem._bExpandedUI);
				}
				else
				{
					SetExpanded(!sourceItem._bExpandedUI);
				}
			}
			RefreshUIButtonsExpandCollapse();
		}

		private void OnButtonLocalModEdit()
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				_dynamicPlaylistUI.OpenGameItemUIScreen(ExtContentUtils.ExtContentManager.ContentSourceLocalMods.FindGameItemByID(sourceItem._itemId));
			}
		}

		private void OnButtonOpenWorkshop()
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				_dynamicPlaylistUI.OpenGameItemUIScreen(ExtContentUtils.ExtContentManager.ContentSourceWorkshop.FindGameItemByID(sourceItem._itemId));
			}
		}

		private void UpdateTrackRowsExpandedStatus()
		{
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem == null)
			{
				return;
			}
			foreach (DynamicPlaylistUIRowTrack trackRow in _trackRows)
			{
				trackRow.OnParentExpanded(sourceItem._bExpandedUI);
			}
		}
	}
}
