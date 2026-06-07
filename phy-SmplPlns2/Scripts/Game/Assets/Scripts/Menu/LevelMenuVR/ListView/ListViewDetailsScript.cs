using System.Collections.Generic;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class ListViewDetailsScript : MonoBehaviour
	{
		public enum PerformanceLoad
		{
			Normal = 0,
			Moderate = 1,
			Heavy = 2,
			Unknown = 3
		}

		[SerializeField]
		private AuthorUIScript _authorUI;

		[SerializeField]
		private TextMeshProUGUI _bodyText;

		[SerializeField]
		private GameObject _buttonPanel;

		[SerializeField]
		private ToggleButtonScript _curateApproveButton;

		[SerializeField]
		private ToggleButtonScript _curateRejectButton;

		[SerializeField]
		private ToggleButtonScript _curateResetButton;

		[SerializeField]
		private GameObject _curationPanel;

		private List<GameObject> _detailRows = new List<GameObject>();

		[SerializeField]
		private GameObject _detailsButtonPrefab;

		[SerializeField]
		private GameObject _detailsLabelPrefab;

		[SerializeField]
		private TextMeshProUGUI _downloadCountText;

		[SerializeField]
		private ToggleButtonScript _favoriteButton;

		[SerializeField]
		private TextMeshProUGUI _headerText;

		[SerializeField]
		private Image _imagePreview;

		private ListViewScript _listView;

		[SerializeField]
		private Image _lock;

		[SerializeField]
		private TextMeshProUGUI _partCountText;

		[SerializeField]
		private TextMeshProUGUI _performanceCostText;

		[SerializeField]
		private GameObject _performancePanel;

		[SerializeField]
		private Image _performancePanelBackground;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private Button _selectButton;

		[SerializeField]
		private TextMeshProUGUI _selectButtonText;

		[SerializeField]
		private ToggleButtonScript _starButton;

		[SerializeField]
		private TagsUIScript _tagsUI;

		[SerializeField]
		private ToggleButtonScript _upvoteButton;

		[SerializeField]
		private TextMeshProUGUI _upvoteCountText;

		public AuthorUIScript AuthorUI => _authorUI;

		public ToggleButtonScript CurateApproveButton => _curateApproveButton;

		public ToggleButtonScript CurateRejectButton => _curateRejectButton;

		public ToggleButtonScript CurateResetButton => _curateResetButton;

		public ToggleButtonScript FavoriteButton => _favoriteButton;

		public bool LockVisible
		{
			get
			{
				return _lock.gameObject.activeSelf;
			}
			set
			{
				_lock.gameObject.SetActive(value);
				_imagePreview.color = (value ? new Color(0.5f, 0.5f, 0.5f, 1f) : Color.white);
			}
		}

		public ToggleButtonScript StarButton => _starButton;

		public TagsUIScript TagsUI => _tagsUI;

		public ToggleButtonScript UpvoteButton => _upvoteButton;

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public void ClearDetailRows()
		{
			foreach (GameObject detailRow in _detailRows)
			{
				Object.Destroy(detailRow);
			}
			_detailRows.Clear();
		}

		public DetailButtonRowScript CreateDetailsButtonRow()
		{
			GameObject gameObject = Object.Instantiate(_detailsButtonPrefab);
			gameObject.transform.SetParent(_detailsButtonPrefab.transform.parent, worldPositionStays: false);
			gameObject.SetActive(value: true);
			DetailButtonRowScript component = gameObject.GetComponent<DetailButtonRowScript>();
			_detailRows.Add(gameObject);
			return component;
		}

		public DetailLabelRowScript CreateDetailsLabelRow()
		{
			GameObject gameObject = Object.Instantiate(_detailsLabelPrefab);
			gameObject.transform.SetParent(_detailsLabelPrefab.transform.parent, worldPositionStays: false);
			gameObject.SetActive(value: true);
			DetailLabelRowScript component = gameObject.GetComponent<DetailLabelRowScript>();
			_detailRows.Add(gameObject);
			return component;
		}

		public void Initialize(ListViewScript listView)
		{
			_listView = listView;
		}

		public void SetBodyText(string text)
		{
			_bodyText.text = text;
			_scrollRect.verticalNormalizedPosition = 1f;
		}

		public void SetHeaderText(string text)
		{
			_headerText.text = text;
		}

		public void SetPerformanceInfo(bool visible, int parts, float performanceCost, PerformanceLoad load, int downloadCount, int upvoteCount)
		{
			_performancePanel.SetActive(visible);
			if (visible)
			{
				string tooltipText = "This craft should run well on most devices.";
				Color color = new Color32(38, 38, 38, byte.MaxValue);
				switch (load)
				{
				case PerformanceLoad.Heavy:
					color = new Color32(byte.MaxValue, 0, 33, byte.MaxValue);
					tooltipText = "This craft is very complex and may not run well on your device.";
					break;
				case PerformanceLoad.Moderate:
					color = new Color32(byte.MaxValue, 148, 0, byte.MaxValue);
					tooltipText = "This craft is moderately complex and may not run well on your device.";
					break;
				case PerformanceLoad.Unknown:
					tooltipText = "The complexity of this craft is not known.";
					break;
				}
				_upvoteCountText.text = Utilities.FriendlyLargeNumber(upvoteCount);
				_downloadCountText.text = Utilities.FriendlyLargeNumber(downloadCount);
				_partCountText.text = $"{parts:n0} parts";
				_performanceCostText.text = $"{performanceCost:n0}";
				_performancePanelBackground.color = color;
				_performancePanel.GetComponentInChildren<ShowTooltipScript>().TooltipText = tooltipText;
			}
		}

		public void SetPreviewSprite(Sprite sprite)
		{
			_imagePreview.sprite = sprite;
			_imagePreview.gameObject.SetActive(sprite != null);
		}

		public void SetSelectButtonText(string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				_selectButton.gameObject.SetActive(value: true);
				_selectButtonText.text = text;
			}
			else
			{
				_selectButton.gameObject.SetActive(value: false);
			}
		}

		public void ShowButtonPanel(bool show)
		{
			_buttonPanel.SetActive(show);
		}

		public void ShowCurationPanel(bool show)
		{
			_curationPanel.SetActive(show);
		}

		protected virtual void Awake()
		{
			_selectButton.onClick.AddListener(delegate
			{
				_listView.OnSelectButtonClicked();
			});
		}

		protected virtual void Start()
		{
		}
	}
}
