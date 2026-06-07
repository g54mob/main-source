using TMPro;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsHeaderScript : DetailsWidgetBaseScript
	{
		private TextMeshProUGUI _text;

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			_text = GetComponent<TextMeshProUGUI>();
		}
	}
}
