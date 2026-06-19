using System;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugProjectInfoItem : MonoBehaviour
	{
		public Action OnProjectSelected;

		[SerializeField]
		private GameObject _parentPanel;

		[SerializeField]
		private TMP_Text _projectNameLabel;

		[SerializeField]
		private TMP_Text _leaderNameLabel;

		[SerializeField]
		private ButtonAnimator _button;

		[SerializeField]
		private Image _buttonImage;

		[SerializeField]
		private GameObject _completedBanner;

		[SerializeField]
		private GameObject _alertIcon;

		[SerializeField]
		private Sprite _selectableBacking;

		[SerializeField]
		private Sprite _selectedBacking;

		private SuperBugProjectManager _superBugManager;

		private bool _isSelected;

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				_buttonImage.overrideSprite = (value ? _selectedBacking : _selectableBacking);
			}
		}

		public void Setup(SuperBugProjectManager superBugManager)
		{
			_superBugManager = superBugManager;
			Refresh();
		}

		private void OnEnable()
		{
			_button.Button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		private void OnDisable()
		{
			_button.Button.onPrimaryDown.RemoveListener(OnButtonPressed);
		}

		public void Refresh()
		{
			SuperBugDefinition superBugDefinition = _superBugManager?.DownloadedProjectDefinition;
			GameObjectUtils.SetActive(_parentPanel.gameObject, superBugDefinition != null);
			if (superBugDefinition != null)
			{
				_completedBanner.SetActive(value: false);
				_projectNameLabel.text = superBugDefinition.Name.Translation;
				_leaderNameLabel.text = superBugDefinition.LeaderName.Translation;
			}
		}

		private void OnButtonPressed()
		{
			OnProjectSelected.InvokeSafe();
		}
	}
}
