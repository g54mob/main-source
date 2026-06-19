using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ProgressBar : Graphic
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _progress = 0.5f;

		[SerializeField]
		private float _visibleUpdateSpeed = 1f;

		[SerializeField]
		private Color _barColor = Color.white;

		[SerializeField]
		private Color _backColor = Color.gray;

		[SerializeField]
		private Texture _texture;

		[SerializeField]
		private TMP_Text _label;

		[SerializeField]
		private ProgressBarChevron _chevron;

		[SerializeField]
		private bool _useInterpolation = true;

		private float _progressVisible = 0.5f;

		private bool _barInitialised;

		public new bool enabled
		{
			set
			{
				base.enabled = value;
				if (_label != null)
				{
					_label.enabled = value;
				}
			}
		}

		public float Progress
		{
			set
			{
				_progress = Mathf.Clamp01(value);
				SetVerticesDirty();
			}
		}

		public Color BarColor
		{
			set
			{
				_barColor = value;
				SetVerticesDirty();
			}
		}

		public Color BackColor
		{
			set
			{
				_backColor = value;
				SetVerticesDirty();
			}
		}

		public string LabelText
		{
			set
			{
				_label.text = value;
			}
		}

		public TMP_Text Label
		{
			set
			{
				_label = value;
			}
		}

		public override Texture mainTexture => _texture ?? base.mainTexture;

		public ProgressBarChevron Chevron
		{
			set
			{
				_chevron = value;
			}
		}

		private void Update()
		{
			if (!_barInitialised)
			{
				_progressVisible = _progress;
				SetVerticesDirty();
				_barInitialised = true;
			}
			float num = Mathf.Clamp(_progress - _progressVisible, (0f - _visibleUpdateSpeed) * Time.deltaTime, _visibleUpdateSpeed * Time.deltaTime);
			_progressVisible += num;
			if (!MathUtils.ApproximatelyZero(num))
			{
				SetVerticesDirty();
			}
			else
			{
				num = 0f;
			}
			if (_chevron != null)
			{
				_chevron.Delta = num;
			}
		}

		public void SetColorFromGradient(Color colorMin, Color colorMid, Color colorMax)
		{
			BarColor = ((_progress <= 0.5f) ? ((colorMid - colorMin) * (_progress * 2f) + colorMin) : ((colorMax - colorMid) * ((_progress - 0.5f) * 2f) + colorMid));
		}

		public void SetColorFromGradient(Color colorMin, Color colorMax)
		{
			BarColor = (colorMax - colorMin) * _progress + colorMin;
		}

		public void SetBackColorFromBarColor(float multiplier)
		{
			BackColor = new Color(_barColor.r * multiplier, _barColor.g * multiplier, _barColor.b * multiplier, _barColor.a);
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			float x = (_useInterpolation ? _progressVisible : _progress);
			vh.Clear();
			vh.AddUIVertexQuad(BuildQuad(_backColor, new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f),
				new Vector2(1f, 0f)
			}));
			vh.AddUIVertexQuad(BuildQuad(_barColor, new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(x, 1f),
				new Vector2(x, 0f)
			}));
		}

		private UIVertex[] BuildQuad(Color quadColor, IList<Vector2> vertices)
		{
			UIVertex[] array = new UIVertex[4];
			float width = base.rectTransform.rect.width;
			float height = base.rectTransform.rect.height;
			float num = (0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width;
			float num2 = (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height;
			for (int i = 0; i < vertices.Count; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				Vector2 vector = new Vector2(vertices[i].x * width + num, vertices[i].y * height + num2);
				simpleVert.color = quadColor;
				simpleVert.position = vector;
				simpleVert.uv0 = vertices[i];
				array[i] = simpleVert;
			}
			return array;
		}
	}
}
