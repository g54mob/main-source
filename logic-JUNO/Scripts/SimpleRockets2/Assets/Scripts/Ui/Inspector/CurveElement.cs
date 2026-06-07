using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class CurveElement : ItemElement
	{
		private readonly Color _backgroundColor = new Color(0.1137255f, 0.1294118f, 0.1529412f);

		private readonly Color _foregroundColor = new Color(0f, 61f / 85f, 0.9294118f);

		private RawImage _image;

		private TextMeshProUGUI _labelText;

		private CurveModel _model;

		private Texture2D _texture;

		public CurveElement(XmlElement xmlElement, CurveModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_labelText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("image");
			elementByInternalId.AddOnClickEvent(delegate
			{
				OnCurveClicked();
			});
			_image = elementByInternalId.GetComponent<RawImage>();
			Update();
			UpdatePreviewCurve(model.Value);
		}

		public override void Update()
		{
			base.Update();
			if (_labelText.text != _model.Label)
			{
				_labelText.text = _model.Label;
			}
		}

		public void UpdatePreviewCurve(AnimationCurve curve)
		{
			if (_texture == null)
			{
				Vector2 vector = _image.rectTransform.rect.size;
				if (vector == Vector2.zero)
				{
					vector = new Vector2(212f, 30f);
				}
				_texture = new Texture2D((int)vector.x, (int)vector.y);
				_image.texture = _texture;
			}
			Texture2D texture = _texture;
			Color[] array = new Color[texture.width * texture.height];
			if (curve == null || curve.length < 2)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _backgroundColor;
				}
			}
			else
			{
				Vector2 vector2 = new Vector2(curve.keys[0].time, curve.keys[0].value);
				Vector2 vector3 = new Vector2(curve.keys[curve.length - 1].time, curve.keys[curve.length - 1].value);
				float[] array2 = new float[texture.width];
				for (int j = 0; j < texture.width; j++)
				{
					float num = curve.Evaluate(Mathf.Lerp(vector2.x, vector3.x, (float)j / (float)texture.width));
					vector2.y = Mathf.Min(vector2.y, num);
					vector3.y = Mathf.Max(vector3.y, num);
					array2[j] = num;
				}
				float num2 = (vector3.y - vector2.y) * 0.05f;
				vector2.y -= num2;
				vector3.y += num2;
				for (int k = 0; k < texture.width; k++)
				{
					float num3 = Mathf.InverseLerp(vector2.y, vector3.y, array2[k]) * (float)texture.height;
					for (int l = 0; l < texture.height; l++)
					{
						float num4 = Mathf.Abs(num3 - (float)l);
						Color color = _backgroundColor;
						if (num4 < 1f)
						{
							color = Color.Lerp(_foregroundColor, color, num4);
						}
						array[l * texture.width + k] = color;
					}
				}
			}
			_texture.SetPixels(array);
			_texture.Apply();
		}

		private void OnCurveClicked()
		{
			Game.Instance.UserInterface.CreateCurveEditor(_model.Value ?? new AnimationCurve(), delegate(AnimationCurve curve)
			{
				_model.SetValueFromUserInput(curve, _model.Label, finished: true, ignoreIfEqual: false);
				UpdatePreviewCurve(curve);
			});
		}
	}
}
