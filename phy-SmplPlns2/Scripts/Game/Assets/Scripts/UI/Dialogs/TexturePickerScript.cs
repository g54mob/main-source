using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Dialogs
{
	public class TexturePickerScript : WidgetScript
	{
		public delegate void TexturePickerDelegate(TexturePickerScript texturePicker);

		public class TextureSelectedEventArgs : EventArgs
		{
			public TexturePickerItem TextureItem { get; private set; }

			public TextureSelectedEventArgs(TexturePickerItem textureItem)
			{
				TextureItem = textureItem;
			}
		}

		private List<TextureButtonScript> _buttons = new List<TextureButtonScript>();

		private Widget _categoriesParent;

		private string _initiallySelectedId;

		private bool _largePreviews;

		private ScrollViewWidget _scrollView;

		private string _selectedCategory;

		private TextureButtonScript _selectedTextureButton;

		private IEnumerable<TexturePickerItem> _textureItems;

		private GridLayoutWidget _texturesParent;

		public IFlyout Flyout { get; private set; }

		public bool LargePreviews
		{
			get
			{
				return _largePreviews;
			}
			set
			{
				if (_largePreviews != value)
				{
					_largePreviews = value;
					_scrollView.EnableClass("texture-picker-big", value);
				}
			}
		}

		public Action<TextureButtonScript> OnTextureButtonCreated { get; set; }

		public TextureButtonScript SelectedTextureButton
		{
			get
			{
				return _selectedTextureButton;
			}
			private set
			{
				if (_selectedTextureButton != value)
				{
					_selectedTextureButton?.SetSelected(selected: false);
					_selectedTextureButton = value;
					_selectedTextureButton?.SetSelected(selected: true);
				}
			}
		}

		public event EventHandler<TextureSelectedEventArgs> TextureSelected;

		public void Initialize(IEnumerable<TexturePickerItem> textures, string initiallySelectedId = null)
		{
			_initiallySelectedId = initiallySelectedId;
			Flyout = GetComponentInParent<IFlyout>(includeInactive: true);
			_scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_textureItems = textures;
			_categoriesParent = base.Widget.FindWidget("categories");
			_texturesParent = base.Widget.FindWidget<GridLayoutWidget>("textures");
			List<string> categoryNames = (from x in _textureItems.Select((TexturePickerItem x) => x.Category).Distinct()
				orderby x
				select x).ToList();
			BuildCategories(categoryNames);
			Flyout.HeaderClicked += OnFlyoutHeaderClicked;
		}

		public void OnTextureButtonClicked(TextureButtonScript textureButton)
		{
			if (SelectedTextureButton != textureButton)
			{
				SelectedTextureButton = textureButton;
				this.TextureSelected?.Invoke(this, new TextureSelectedEventArgs(textureButton.TextureItem));
			}
			else
			{
				Close();
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
		}

		protected async void Start()
		{
			TexturePickerItem texturePickerItem = _textureItems.FirstOrDefault((TexturePickerItem x) => x.Id == _initiallySelectedId);
			if (!string.IsNullOrWhiteSpace(texturePickerItem?.Category))
			{
				SelectCategory(texturePickerItem.Category);
			}
			else
			{
				_categoriesParent.Show(force: true);
				_texturesParent.Hide(null, force: true);
			}
			await Task.Yield();
			await Task.Yield();
			await Task.Yield();
			await Task.Yield();
			_scrollView.ScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
			TextureButtonScript textureButtonScript = _buttons.FirstOrDefault((TextureButtonScript x) => x.TextureItem.Id == _initiallySelectedId);
			if (textureButtonScript != null)
			{
				_scrollView.ScrollToWidget(textureButtonScript.Widget, -15f);
				SelectedTextureButton = textureButtonScript;
			}
		}

		private void BuildCategories(List<string> categoryNames)
		{
			foreach (string categoryName in categoryNames)
			{
				if (!string.IsNullOrEmpty(categoryName))
				{
					base.Widget.Context.CreateWidgetFromTemplate("category", _categoriesParent, new XAttribute[1]
					{
						new XAttribute("text", categoryName)
					});
				}
			}
		}

		private void Close()
		{
			Flyout.Close();
		}

		private void OnCategoryClicked(Widget widget)
		{
			TextWidget textWidget = widget.FindWidget<TextWidget>("name");
			SelectCategory(textWidget.Text);
		}

		private void OnFlyoutHeaderClicked(IFlyout flyout)
		{
			if (_selectedCategory != null)
			{
				_selectedCategory = null;
				Flyout.Title = "TEXTURES";
				_categoriesParent.Show(force: true);
				_texturesParent.Hide(null, force: true);
			}
			else
			{
				flyout.Close();
			}
		}

		private void SelectCategory(string categoryName)
		{
			_categoriesParent.Hide(null, force: true);
			_texturesParent.Show(force: true);
			_selectedCategory = categoryName;
			Flyout.Title = categoryName;
			foreach (TextureButtonScript button in _buttons)
			{
				button.Widget.Destroy();
			}
			_buttons.Clear();
			foreach (TexturePickerItem textureItem in _textureItems)
			{
				if (textureItem.Category == categoryName)
				{
					TextureButtonScript component = base.Widget.Context.CreateWidgetFromTemplate("texture-button", _texturesParent).GetComponent<TextureButtonScript>();
					component.InitializeTextureButton(this, textureItem, (int)_texturesParent.GridLayout.cellSize.x);
					OnTextureButtonCreated?.Invoke(component);
					_buttons.Add(component);
				}
			}
		}
	}
}
