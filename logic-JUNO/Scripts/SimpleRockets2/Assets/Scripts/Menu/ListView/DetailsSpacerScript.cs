using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsSpacerScript : DetailsWidgetBaseScript
	{
		private LayoutElement _layout;

		public float Height
		{
			get
			{
				return _layout.preferredHeight;
			}
			set
			{
				_layout.preferredHeight = value;
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			_layout = GetComponent<LayoutElement>();
		}
	}
}
