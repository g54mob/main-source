using System.Collections;
using ModApi.Audio;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Paint
{
	public class ColorPickerScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
	{
		public delegate void ColorPickerDelegate(ColorPickerScript colorPickerScript, ColorGradient.Shade shade);

		private RawImage _gradientImage;

		private RectTransform _selectionIndicator;

		private Texture2D _texture;

		private RectTransform _transform;

		public ColorGradient ColorGradient { get; private set; }

		public Color SelectedColor { get; set; }

		public event ColorPickerDelegate UserSelectedColor;

		public void Cleanup()
		{
			if (_texture != null)
			{
				Object.Destroy(_texture);
				_texture = null;
			}
		}

		public void Initialize(XmlElement element)
		{
			_transform = GetComponent<RectTransform>();
			_gradientImage = GetComponentInChildren<RawImage>();
			_selectionIndicator = element.GetChildElementsWithClass("color-picker-selection")[0].GetComponent<RectTransform>();
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			OnDrag(eventData);
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			OnPointerDown(eventData);
		}

		public ColorGradient.Shade SelectClosestShade(Color color)
		{
			ColorGradient.Shade shade = null;
			float num = float.MaxValue;
			Vector3 vector = new Vector3(color.r, color.g, color.b);
			foreach (ColorGradient.Shade shade2 in ColorGradient.Shades)
			{
				if (shade2.ColorGradient != null)
				{
					foreach (ColorGradient.Shade shade3 in shade2.ColorGradient.Shades)
					{
						Vector3 vector2 = new Vector3(shade3.Color.r, shade3.Color.g, shade3.Color.b);
						float sqrMagnitude = (vector - vector2).sqrMagnitude;
						if (sqrMagnitude < num)
						{
							num = sqrMagnitude;
							shade = shade2;
						}
					}
				}
				else
				{
					Vector3 vector3 = new Vector3(shade2.Color.r, shade2.Color.g, shade2.Color.b);
					float sqrMagnitude2 = (vector - vector3).sqrMagnitude;
					if (sqrMagnitude2 < num)
					{
						num = sqrMagnitude2;
						shade = shade2;
					}
				}
			}
			if (shade != null)
			{
				SelectShade(shade);
				SelectedColor = shade.Color;
			}
			return shade;
		}

		public void SetColorGradient(ColorGradient colorGradient)
		{
			if (_texture != null)
			{
				colorGradient.UpdateTexture(_texture);
			}
			else
			{
				_texture = colorGradient.GenerateTexture(colorGradient.Shades.Count, 1);
				_gradientImage.texture = _texture;
			}
			ColorGradient = colorGradient;
		}

		protected virtual void OnDestroy()
		{
			Cleanup();
		}

		protected virtual void OnDrag(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		protected virtual void OnPointerDown(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		private void HandleInput(Vector2 screenPosition)
		{
			Color selectedColor = SelectedColor;
			int count = ColorGradient.Shades.Count;
			float x = _transform.sizeDelta.x;
			int index = Mathf.Clamp((int)((_gradientImage.transform.InverseTransformPoint(screenPosition).x + x / 2f) / (x / (float)count)), 0, count - 1);
			ColorGradient.Shade shade = ColorGradient.Shades[index];
			SelectShade(shade);
			this.UserSelectedColor?.Invoke(this, shade);
			if (SelectedColor != selectedColor)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.ButtonClicked);
			}
		}

		private void SelectShade(ColorGradient.Shade shade)
		{
			SelectedColor = shade.Color;
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(SetSelection(shade.Start));
			}
		}

		private IEnumerator SetSelection(int index)
		{
			yield return new WaitForEndOfFrame();
			float x = _transform.sizeDelta.x;
			float num = x / (float)ColorGradient.Shades.Count;
			float num2 = (float)index * num;
			Vector3 localPosition = _selectionIndicator.transform.localPosition;
			localPosition.x = num2 - x / 2f + num / 2f;
			Vector2 sizeDelta = new Vector2(num + 3f, _selectionIndicator.sizeDelta.y);
			_selectionIndicator.sizeDelta = sizeDelta;
			_selectionIndicator.transform.localPosition = localPosition;
		}
	}
}
