using Assets.Scripts.Ui.GradientEditor;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public class GradientElement : ItemElement
	{
		private TextMeshProUGUI _labelText;

		private GradientModel _model;

		private GradientViewer _viewer;

		public GradientElement(XmlElement xmlElement, GradientModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("image");
			elementByInternalId.AddOnClickEvent(delegate
			{
				OnClicked();
			});
			_viewer = elementByInternalId.gameObject.AddComponent<GradientViewer>();
			_viewer.material = Game.Instance.ResourceLoader.LoadMaterial("Ui/Materials/GradientMaterial");
			_viewer.raycastTarget = true;
			Update();
			UpdatePreview(_model.Value ?? new Gradient());
		}

		public override void Update()
		{
			base.Update();
			_viewer.AlphaHeight = (_model.HasAlpha ? 0.25f : 0f);
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
			if (_model.UpdatePreview)
			{
				_model.UpdatePreview = false;
				UpdatePreview(_model.Value ?? new Gradient());
			}
		}

		public void UpdatePreview(Gradient gradient)
		{
			_viewer.Gradient = gradient;
		}

		private void OnClicked()
		{
			Game.Instance.UserInterface.CreateGradientEditor(_model.Value ?? new Gradient(), delegate(Gradient gradient)
			{
				UpdatePreview(gradient);
				_model.ValueChanged?.Invoke(gradient);
			}, _model.HasAlpha, _model.AllowHDR);
		}
	}
}
