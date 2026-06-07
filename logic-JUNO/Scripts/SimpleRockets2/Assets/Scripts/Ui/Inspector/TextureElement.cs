using System.IO;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class TextureElement : ItemElement
	{
		private TextMeshProUGUI _labelText;

		private TextureModel _model;

		private string _path;

		private RawImage _texture;

		public TextureElement(XmlElement xmlElement, TextureModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("texture");
			elementByInternalId.AddOnClickEvent(delegate
			{
				OnClicked();
			});
			_texture = elementByInternalId.GetComponent<RawImage>();
			Update();
			if (string.IsNullOrWhiteSpace(_path))
			{
				_model.Label = "Select Texture";
				_texture.texture = Texture2D.whiteTexture;
			}
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			if (_path != _model.Value)
			{
				_path = _model.Value;
				_texture.texture = LoadTexture(_path);
			}
		}

		private Texture2D LoadTexture(string path)
		{
			Texture2D texture2D = null;
			if (File.Exists(path))
			{
				texture2D = new Texture2D(1, 1, TextureFormat.RGB24, mipChain: false, linear: false);
				texture2D.LoadImage(File.ReadAllBytes(path), markNonReadable: true);
				texture2D.wrapMode = TextureWrapMode.Clamp;
			}
			return texture2D;
		}

		private void OnClicked()
		{
			_model.TextureSelector.SelectTexture(_model, delegate(string path)
			{
				_model.SetValueFromUserInput(path, _model.Label);
			});
		}
	}
}
