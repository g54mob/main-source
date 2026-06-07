using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class NavigationItemScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _filterCheck;

		[SerializeField]
		private Image _highlight;

		[SerializeField]
		private Color _hoverColor;

		private bool _hovered;

		private Color _invisible = new Color(0f, 0f, 0f, 0f);

		private bool _selected;

		[SerializeField]
		private Color _selectedColor;

		[SerializeField]
		private TextMeshProUGUI _text;

		public bool IncludeInFilterCount { get; set; }

		public bool IsChecked
		{
			get
			{
				return _filterCheck.gameObject.activeSelf;
			}
			set
			{
				_filterCheck.gameObject.SetActive(value);
			}
		}

		public bool IsFilter { get; set; }

		public ListViewScript ListView { get; private set; }

		public string Name
		{
			get
			{
				return _text.text;
			}
			private set
			{
				_text.text = value;
			}
		}

		public NavigationGroupScript NavGroup { get; private set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				UpdateHighlight();
			}
		}

		public object UserData { get; set; }

		private bool Hovered
		{
			get
			{
				return _hovered;
			}
			set
			{
				_hovered = value;
				UpdateHighlight();
			}
		}

		public virtual void Initialize(string name, NavigationGroupScript navGroup, ListViewScript listView)
		{
			Name = name;
			NavGroup = navGroup;
			ListView = listView;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			ListView.OnNavItemClicked(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Hovered = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Hovered = false;
		}

		private void UpdateHighlight()
		{
			if (_selected)
			{
				_highlight.color = _selectedColor;
			}
			else if (_hovered)
			{
				_highlight.color = _hoverColor;
			}
			else
			{
				_highlight.color = _invisible;
			}
		}
	}
}
