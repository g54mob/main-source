using UnityEngine.UIElements;

namespace Restory.UI.Views
{
	public class TitleAndDescTooltip<TPresenter> : View
	{
		private const string TITLE_NAME = "title";

		private const string DESC_NAME = "desc";

		private TextElement titleText;

		private TextElement descText;

		public string Title
		{
			get
			{
				return titleText.text;
			}
			set
			{
				titleText.text = value;
			}
		}

		public string Desc
		{
			get
			{
				return descText.text;
			}
			set
			{
				descText.text = value;
			}
		}

		public void Init(VisualElement root)
		{
			base.root = root;
			titleText = root.Q<TextElement>("title");
			descText = root.Q<TextElement>("desc");
		}

		public void Clear()
		{
			descText = null;
			titleText = null;
			root = null;
		}
	}
}
