using ModApi.Craft.Parts;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Paint
{
	public class ColorButtonScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		public delegate void SelectedDelegate(ColorButtonScript colorButton);

		private XmlElement _glossOverlay;

		private Image _image;

		private bool _isSelected;

		private PartMaterial _partMaterial;

		public Color Color => _partMaterial.Color;

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (IsSelected != value)
				{
					_isSelected = value;
					XmlElement component = GetComponent<XmlElement>();
					if (value)
					{
						component.AddClass("color-button-selected");
					}
					else
					{
						component.RemoveClass("color-button-selected");
					}
				}
			}
		}

		public PartMaterial PartMaterial
		{
			get
			{
				return _partMaterial;
			}
			set
			{
				_partMaterial = value;
				Refresh();
			}
		}

		public event SelectedDelegate Selected;

		public void Initialize(XmlElement element)
		{
			_image = element.GetElementByInternalId<Image>("color");
			_glossOverlay = element.GetElementByInternalId("gloss-overlay");
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			OnPointerDown(eventData);
		}

		public void Refresh()
		{
			Color color = _partMaterial.Color;
			color.a = 1f - _partMaterial.TransparencyStrength;
			_image.color = color;
			float num = Mathf.Clamp01((_partMaterial.Metallic + _partMaterial.Smoothness - 0.2f) / 2f);
			_glossOverlay.SetAndApplyAttribute("opacity", num.ToString());
		}

		protected virtual void OnPointerDown(PointerEventData eventData)
		{
			this.Selected?.Invoke(this);
		}
	}
}
