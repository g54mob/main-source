using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("UI/Bar Graph", 101)]
	[ExecuteInEditMode]
	public class BarGraph : ElementLayoutController, ILayoutGroup, ILayoutController
	{
		public class Entry
		{
			public string Name = string.Empty;

			public float Value;

			public Color BarColor = Color.white;

			public Sprite LabelSprite;

			public Color LabelSpriteColor;

			public TMP_Text LabelText;
		}

		[Serializable]
		private class InternalEntry
		{
			public string Name = string.Empty;

			public float Value;

			public RectTransform Bar;

			public RectTransform Label;

			public Color BarColor = Color.white;

			public Sprite LabelSprite;

			public Color LabelSpriteColor;

			public TMP_Text LabelText;

			public InternalEntry(Entry entry)
			{
				Name = entry.Name;
				Value = entry.Value;
				BarColor = entry.BarColor;
				LabelSprite = entry.LabelSprite;
				LabelSpriteColor = entry.LabelSpriteColor;
				LabelText = entry.LabelText;
			}
		}

		private DrivenRectTransformTracker _drivenRectTransformTracker;

		[SerializeField]
		private float _labelsSize = 10f;

		[SerializeField]
		private RectOffset _labelsPadding = new RectOffset();

		[SerializeField]
		private RectOffset _textLabelsPadding = new RectOffset();

		[SerializeField]
		private float _barSpacing;

		[SerializeField]
		private float _maxValue = 10f;

		[SerializeField]
		private Sprite _barSprite;

		[SerializeField]
		private RectTransform _bars;

		[SerializeField]
		private RectTransform _labels;

		[SerializeField]
		private RectTransform _textLabels;

		[SerializeField]
		private List<InternalEntry> _entries = new List<InternalEntry>();

		public RectTransform BarsParentTransform
		{
			get
			{
				return _bars;
			}
			set
			{
				if (!(_bars == value))
				{
					_bars = value;
					SetDirty();
				}
			}
		}

		public Sprite BarSprite
		{
			get
			{
				return _barSprite;
			}
			set
			{
				if (!(_barSprite == value))
				{
					_barSprite = value;
					UpdateProperties();
				}
			}
		}

		public int BarCount => _entries.Count;

		public float MaxValue
		{
			get
			{
				return _maxValue;
			}
			set
			{
				if (!Mathf.Approximately(_maxValue, value))
				{
					_maxValue = value;
					SetDirty();
				}
			}
		}

		public float BarSpacing
		{
			get
			{
				return _barSpacing;
			}
			set
			{
				if (!Mathf.Approximately(_barSpacing, value))
				{
					_barSpacing = value;
					SetDirty();
				}
			}
		}

		public void SetLayoutHorizontal()
		{
			SetLayout(RectTransform.Axis.Horizontal);
		}

		public void SetLayoutVertical()
		{
			SetLayout(RectTransform.Axis.Vertical);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			UpdateProperties();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_drivenRectTransformTracker.Clear();
		}

		public void SetBarValue(int index, float value)
		{
			InternalEntry internalEntry = _entries[index];
			if (!Mathf.Approximately(internalEntry.Value, value))
			{
				internalEntry.Value = value;
				UpdateTextLabels();
				SetDirty();
			}
		}

		public int AddBar(Entry entry)
		{
			_entries.Add(new InternalEntry(entry));
			SetDirty();
			UpdateProperties();
			return _entries.Count - 1;
		}

		private void UpdateTextLabels()
		{
			float num = 0f;
			foreach (InternalEntry entry in _entries)
			{
				num += entry.Value;
			}
			foreach (InternalEntry entry2 in _entries)
			{
				int num2 = ((num > 0f) ? ((int)(entry2.Value * 100f / num)) : 0);
				if ((bool)entry2.LabelText)
				{
					entry2.LabelText.text = num2 + "%";
				}
			}
		}

		private void SetLayout(RectTransform.Axis axis)
		{
			_drivenRectTransformTracker.Clear();
			if (_bars != null)
			{
				_drivenRectTransformTracker.Add(this, _bars, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
				_bars.anchorMin = new Vector2(0f, 0f);
				_bars.anchorMax = new Vector2(1f, 1f);
				if (_labels != null)
				{
					_bars.offsetMin = new Vector2(0f, _labelsSize);
				}
				else
				{
					_bars.offsetMin = new Vector2(0f, 0f);
				}
				_bars.offsetMax = new Vector2(0f, 0f);
				for (int i = 0; i < _entries.Count; i++)
				{
					InternalEntry internalEntry = _entries[i];
					if (internalEntry.Bar == null)
					{
						GameObject gameObject = new GameObject(internalEntry.Name);
						internalEntry.Bar = gameObject.AddComponent<RectTransform>();
						internalEntry.Bar.SetParent(_bars, worldPositionStays: false);
						gameObject.AddComponent<Image>();
					}
					_drivenRectTransformTracker.Add(this, internalEntry.Bar, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
					internalEntry.Bar.anchorMin = new Vector2((float)i / (float)_entries.Count, 0f);
					internalEntry.Bar.anchorMax = new Vector2((float)(i + 1) / (float)_entries.Count, Mathf.Clamp01(internalEntry.Value / _maxValue));
					float x = _barSpacing * 0.5f;
					float num = _barSpacing * 0.5f;
					internalEntry.Bar.offsetMin = new Vector2(x, 0f);
					internalEntry.Bar.offsetMax = new Vector2(0f - num, 0f);
				}
			}
			if (_labels != null)
			{
				_drivenRectTransformTracker.Add(this, _labels, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
				_labels.anchorMin = new Vector2(0f, 0f);
				_labels.anchorMax = new Vector2(1f, 0f);
				_labels.offsetMin = new Vector2(0f, _labelsPadding.bottom);
				_labels.offsetMax = new Vector2(0f, _labelsSize - (float)_labelsPadding.top);
				for (int j = 0; j < _entries.Count; j++)
				{
					InternalEntry internalEntry2 = _entries[j];
					if (internalEntry2.Label == null)
					{
						GameObject gameObject2 = new GameObject(internalEntry2.Name);
						internalEntry2.Label = gameObject2.AddComponent<RectTransform>();
						internalEntry2.Label.SetParent(_labels, worldPositionStays: false);
						gameObject2.AddComponent<Image>();
					}
					_drivenRectTransformTracker.Add(this, internalEntry2.Label, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
					internalEntry2.Label.anchorMin = new Vector2((float)j / (float)_entries.Count, 0f);
					internalEntry2.Label.anchorMax = new Vector2((float)(j + 1) / (float)_entries.Count, 1f);
					float x2 = _labelsPadding.left;
					float num2 = _labelsPadding.right;
					internalEntry2.Label.offsetMin = new Vector2(x2, 0f);
					internalEntry2.Label.offsetMax = new Vector2(0f - num2, 0f);
				}
			}
			if (!(_textLabels != null))
			{
				return;
			}
			_drivenRectTransformTracker.Add(this, _textLabels, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
			_textLabels.anchorMin = new Vector2(0f, 0f);
			_textLabels.anchorMax = new Vector2(1f, 0f);
			_textLabels.offsetMin = new Vector2(0f, _textLabelsPadding.bottom);
			_textLabels.offsetMax = new Vector2(0f, _textLabelsPadding.top);
			for (int k = 0; k < _entries.Count; k++)
			{
				InternalEntry internalEntry3 = _entries[k];
				if (internalEntry3.LabelText != null)
				{
					internalEntry3.Label = internalEntry3.LabelText.GetComponent<RectTransform>();
				}
				if (internalEntry3.LabelText != null)
				{
					_drivenRectTransformTracker.Add(this, internalEntry3.Label, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
					internalEntry3.Label.anchorMin = new Vector2((float)k / (float)_entries.Count, 0f);
					internalEntry3.Label.anchorMax = new Vector2((float)(k + 1) / (float)_entries.Count, 1f);
					float x3 = _labelsPadding.left;
					float num3 = _labelsPadding.right;
					internalEntry3.Label.offsetMin = new Vector2(x3, 0f);
					internalEntry3.Label.offsetMax = new Vector2(0f - num3, 0f);
				}
			}
		}

		private void UpdateProperties()
		{
			if (_bars != null)
			{
				for (int i = 0; i < _entries.Count; i++)
				{
					InternalEntry internalEntry = _entries[i];
					if (internalEntry.Bar != null)
					{
						Image component = internalEntry.Bar.GetComponent<Image>();
						component.sprite = _barSprite;
						component.color = internalEntry.BarColor;
						component.type = Image.Type.Sliced;
					}
				}
			}
			if (!(_labels != null))
			{
				return;
			}
			for (int j = 0; j < _entries.Count; j++)
			{
				InternalEntry internalEntry2 = _entries[j];
				if (internalEntry2.Label != null)
				{
					Image component2 = internalEntry2.Label.GetComponent<Image>();
					component2.enabled = internalEntry2.LabelSprite != null;
					component2.sprite = internalEntry2.LabelSprite;
					component2.color = internalEntry2.LabelSpriteColor;
					component2.type = Image.Type.Simple;
					component2.preserveAspect = true;
				}
			}
		}
	}
}
