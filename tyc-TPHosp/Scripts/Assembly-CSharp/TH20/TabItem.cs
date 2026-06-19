using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TabItem : MonoBehaviour
	{
		[SerializeField]
		private Image _tabBacking;

		[SerializeField]
		private Sprite _selectedImage;

		[SerializeField]
		private Sprite _unselectedImage;

		[SerializeField]
		private Button _tabButton;

		[SerializeField]
		private GameObject _content;

		[HideInInspector]
		public TabLayoutGroup OwnerTab;

		public bool IsSelected { get; private set; }

		private void Start()
		{
			_tabButton.onClick.AddListener(OnSelected);
		}

		private void OnDestroy()
		{
			_tabButton.onClick.RemoveListener(OnSelected);
		}

		public void Select()
		{
			if (_tabBacking != null)
			{
				_tabBacking.overrideSprite = _selectedImage;
			}
			if (_content != null)
			{
				_content.SetActive(value: true);
			}
			IsSelected = true;
		}

		public void Deselect()
		{
			if (_tabBacking != null)
			{
				_tabBacking.overrideSprite = _unselectedImage;
			}
			if (_content != null)
			{
				_content.SetActive(value: false);
			}
			IsSelected = false;
		}

		public void OnSelected()
		{
			OwnerTab.SelectTab(this);
		}
	}
}
