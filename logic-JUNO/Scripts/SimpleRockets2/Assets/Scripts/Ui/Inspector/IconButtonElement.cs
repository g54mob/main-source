using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class IconButtonElement : ButtonElement
	{
		private Button _button;

		private Image _image;

		private IconButtonModel _model;

		private string _sprite;

		public override XmlElement Button => base.XmlElement;

		public IconButtonElement(XmlElement xmlElement, IconButtonModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_image = xmlElement.GetElementByInternalId<Image>("image");
			_button = xmlElement.GetComponent<Button>();
			_button.onClick.AddListener(delegate
			{
				model.OnClicked();
			});
			Update();
		}

		public override void Update()
		{
			base.Update();
			if (_sprite != _model.Sprite)
			{
				_sprite = _model.Sprite;
				_image.sprite = Game.Instance.ResourceLoader.Load<Sprite>(_sprite);
			}
			if (_button.interactable != _model.Enabled)
			{
				_button.interactable = _model.Enabled;
			}
		}
	}
}
