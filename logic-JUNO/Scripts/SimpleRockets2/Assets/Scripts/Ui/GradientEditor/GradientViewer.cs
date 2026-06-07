using System.Linq;
using ModApi.Common.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.GradientEditor
{
	[ExecuteInEditMode]
	public class GradientViewer : MaskableGraphic
	{
		[SerializeField]
		private float _alphaHeight = 0.25f;

		[SerializeField]
		private Gradient _gradient;

		public float AlphaHeight
		{
			get
			{
				return _alphaHeight;
			}
			set
			{
				if (_alphaHeight != value)
				{
					_alphaHeight = value;
					SetVerticesDirty();
				}
			}
		}

		public Gradient Gradient
		{
			get
			{
				return _gradient;
			}
			set
			{
				_gradient = value;
				Refresh();
			}
		}

		public void Refresh()
		{
			SetVerticesDirty();
		}

		protected override void Awake()
		{
			base.Awake();
			base.gameObject.AddMissingComponent<CanvasRenderer>().cullTransparentMesh = false;
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			Vector2 min = base.rectTransform.rect.min;
			Vector2 max = base.rectTransform.rect.max;
			float y = Mathf.Lerp(min.y, max.y, 1f - _alphaHeight);
			if (_gradient == null)
			{
				return;
			}
			_gradient.colorKeys.Select((GradientColorKey gradientColorKey2) => (time: gradientColorKey2.time, color: gradientColorKey2.color));
			bool flag = _gradient.mode == GradientMode.Blend;
			if (_gradient.colorKeys.Length != 0 && _gradient.colorKeys[0].time != 0f)
			{
				Color color = _gradient.colorKeys[0].color;
				float x = Mathf.Lerp(min.x, max.x, _gradient.colorKeys[0].time);
				vh.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector2(min.x, y),
						tangent = color.linear
					},
					new UIVertex
					{
						position = new Vector2(min.x, min.y),
						tangent = color.linear
					},
					new UIVertex
					{
						position = new Vector2(x, min.y),
						tangent = color.linear
					},
					new UIVertex
					{
						position = new Vector2(x, y),
						tangent = color.linear
					}
				});
			}
			GradientColorKey? gradientColorKey = null;
			GradientColorKey[] colorKeys = _gradient.colorKeys;
			for (int num = 0; num < colorKeys.Length; num++)
			{
				GradientColorKey value = colorKeys[num];
				if (gradientColorKey.HasValue)
				{
					float x2 = Mathf.Lerp(min.x, max.x, gradientColorKey.Value.time);
					float x3 = Mathf.Lerp(min.x, max.x, value.time);
					Color color2 = value.color;
					Color color3 = (flag ? gradientColorKey.Value.color : color2);
					vh.AddUIVertexQuad(new UIVertex[4]
					{
						new UIVertex
						{
							position = new Vector2(x2, y),
							tangent = color3.linear
						},
						new UIVertex
						{
							position = new Vector2(x2, min.y),
							tangent = color3.linear
						},
						new UIVertex
						{
							position = new Vector2(x3, min.y),
							tangent = color2.linear
						},
						new UIVertex
						{
							position = new Vector2(x3, y),
							tangent = color2.linear
						}
					});
				}
				gradientColorKey = value;
			}
			if (gradientColorKey.HasValue && gradientColorKey.Value.time != 1f)
			{
				Color color4 = gradientColorKey.Value.color;
				float x4 = Mathf.Lerp(min.x, max.x, gradientColorKey.Value.time);
				vh.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector2(x4, y),
						tangent = color4.linear
					},
					new UIVertex
					{
						position = new Vector2(x4, min.y),
						tangent = color4.linear
					},
					new UIVertex
					{
						position = new Vector2(max.x, min.y),
						tangent = color4.linear
					},
					new UIVertex
					{
						position = new Vector2(max.x, y),
						tangent = color4.linear
					}
				});
			}
			if (!(_alphaHeight > 0f))
			{
				return;
			}
			if (_gradient.alphaKeys.Length != 0 && _gradient.alphaKeys[0].time != 0f)
			{
				Color color5 = Color.white * _gradient.alphaKeys[0].alpha;
				float x5 = Mathf.Lerp(min.x, max.x, _gradient.alphaKeys[0].time);
				vh.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector2(min.x, max.y),
						tangent = color5.linear
					},
					new UIVertex
					{
						position = new Vector2(min.x, y),
						tangent = color5.linear
					},
					new UIVertex
					{
						position = new Vector2(x5, y),
						tangent = color5.linear
					},
					new UIVertex
					{
						position = new Vector2(x5, max.y),
						tangent = color5.linear
					}
				});
			}
			GradientAlphaKey? gradientAlphaKey = null;
			GradientAlphaKey[] alphaKeys = _gradient.alphaKeys;
			for (int num = 0; num < alphaKeys.Length; num++)
			{
				GradientAlphaKey value2 = alphaKeys[num];
				if (gradientAlphaKey.HasValue)
				{
					float x6 = Mathf.Lerp(min.x, max.x, gradientAlphaKey.Value.time);
					float x7 = Mathf.Lerp(min.x, max.x, value2.time);
					Color color6 = Color.white * value2.alpha;
					color6.a = 1f;
					Color color7 = (flag ? (Color.white * gradientAlphaKey.Value.alpha) : color6);
					color7.a = 1f;
					vh.AddUIVertexQuad(new UIVertex[4]
					{
						new UIVertex
						{
							position = new Vector2(x6, max.y),
							tangent = color7.linear
						},
						new UIVertex
						{
							position = new Vector2(x6, y),
							tangent = color7.linear
						},
						new UIVertex
						{
							position = new Vector2(x7, y),
							tangent = color6.linear
						},
						new UIVertex
						{
							position = new Vector2(x7, max.y),
							tangent = color6.linear
						}
					});
				}
				gradientAlphaKey = value2;
			}
			if (gradientAlphaKey.HasValue && gradientAlphaKey.Value.time != 1f)
			{
				Color color8 = Color.white * gradientAlphaKey.Value.alpha;
				color8.a = 1f;
				float x8 = Mathf.Lerp(min.x, max.x, gradientAlphaKey.Value.time);
				vh.AddUIVertexQuad(new UIVertex[4]
				{
					new UIVertex
					{
						position = new Vector2(x8, max.y),
						tangent = color8.linear
					},
					new UIVertex
					{
						position = new Vector2(x8, y),
						tangent = color8.linear
					},
					new UIVertex
					{
						position = new Vector2(max.x, y),
						tangent = color8.linear
					},
					new UIVertex
					{
						position = new Vector2(max.x, max.y),
						tangent = color8.linear
					}
				});
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			SetVerticesDirty();
		}
	}
}
