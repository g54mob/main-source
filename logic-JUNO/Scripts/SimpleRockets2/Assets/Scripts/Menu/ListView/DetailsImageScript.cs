using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsImageScript : DetailsWidgetBaseScript
	{
		private ListViewDetailsScript _details;

		private XmlElement _element;

		private Image _image;

		private string _imagePath;

		public string ImagePath
		{
			get
			{
				return _imagePath;
			}
			set
			{
				if (_imagePath != value)
				{
					_imagePath = value;
					_image.sprite = _details.ListView.LoadSpriteFromFile(_imagePath);
				}
			}
		}

		public override void Initialize(ListViewDetailsScript details)
		{
			_details = details;
			_element = GetComponent<XmlElement>();
			_image = _element.GetComponentInChildren<Image>();
		}

		public void SetSize(int height)
		{
			_element.SetAndApplyAttribute("preferredHeight", height.ToString());
		}
	}
}
