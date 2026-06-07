using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using DG.Tweening;
using Shapes;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class JFuselageToolBox : IDisposable
	{
		private readonly Designer _designer;

		private float _baseExtent;

		private float3 _center;

		private Color _color = Constants.Colors.PrimaryLight;

		private List<float3> _directions = new List<float3>();

		private float _expand;

		private GameObject _lineContainer;

		private List<Line> _lines = new List<Line>();

		private float _lineWidth = 2.5f;

		private float _opacity = 1f;

		private List<(float3 A, float3 B)> _rawSegments = new List<(float3, float3)>();

		private Tween _tween;

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				if (_color != value)
				{
					_color = value;
					UpdateLineAppearance();
				}
			}
		}

		public float Expand
		{
			get
			{
				return _expand;
			}
			set
			{
				if (_expand != value)
				{
					_expand = value;
					ApplyExpandedSegments();
				}
			}
		}

		public float Opacity
		{
			get
			{
				return _opacity;
			}
			set
			{
				float num = Mathf.Clamp01(value);
				if (_opacity != num)
				{
					_opacity = num;
					UpdateLineAppearance();
				}
			}
		}

		public JFuselageToolBox(Designer designer)
		{
			_designer = designer;
		}

		public void Destroy()
		{
			KillTween();
			if (_lineContainer != null)
			{
				UnityEngine.Object.Destroy(_lineContainer);
				_lineContainer = null;
			}
			_lines.Clear();
			_rawSegments.Clear();
			_directions.Clear();
		}

		public void Dispose()
		{
			Destroy();
		}

		public void Hide()
		{
			KillTween();
			if (_lineContainer != null)
			{
				_lineContainer.SetActive(value: false);
			}
			foreach (Line line in _lines)
			{
				if (line != null)
				{
					line.enabled = false;
				}
			}
		}

		public void Initialize(string name)
		{
			if (_lineContainer == null)
			{
				_lineContainer = new GameObject(name);
				_lineContainer.transform.SetParent(_designer.DesignerScript.transform, worldPositionStays: false);
			}
		}

		public void ShowHover(SelectionTarget target)
		{
			KillTween();
			_color = Constants.Colors.HighlightColor;
			_opacity = 0.75f;
			_expand = 0f;
			UpdateBox(target);
			_tween = DOTween.To(() => _expand, delegate(float x)
			{
				_expand = x;
				ApplyExpandedSegments();
			}, 0.05f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}

		public void ShowSelection(SelectionTarget target)
		{
			KillTween();
			_color = Constants.Colors.PrimaryLight;
			_opacity = 1f;
			_expand = 0.125f;
			UpdateBox(target);
			_tween = DOTween.To(() => _expand, delegate(float x)
			{
				_expand = x;
				ApplyExpandedSegments();
			}, 0f, 0.15f).SetEase(Ease.OutBack);
		}

		public void UpdateBox(SelectionTarget target)
		{
			if (_lineContainer == null)
			{
				return;
			}
			_rawSegments.Clear();
			_directions.Clear();
			_center = float3.zero;
			_baseExtent = 0f;
			int pointCount = 0;
			List<float3> allPoints = new List<float3>();
			JFuselageScript fuselageScript = GetFuselageScript(target.Fuselage);
			if (fuselageScript != null)
			{
				if (target.IsSlice)
				{
					Span<float3> span = stackalloc float3[4];
					fuselageScript.GetSliceOutline(span, target.Index);
					AddShape(span);
				}
				else
				{
					Span<float3> span2 = stackalloc float3[4];
					Span<float3> span3 = stackalloc float3[4];
					fuselageScript.GetSectionOutline(span2, span3, target.Index);
					AddShape(span2);
					AddShape(span3);
					for (int i = 0; i < 4; i++)
					{
						AddSegment(span2[i], span3[i]);
					}
				}
			}
			if (pointCount > 0)
			{
				_center /= (float)pointCount;
				float3 float5 = _center;
				float3 float6 = _center;
				foreach (float3 item in allPoints)
				{
					float5 = math.min(float5, item);
					float6 = math.max(float6, item);
				}
				float3 float7 = (float6 - float5) * 0.5f;
				float num = float.MaxValue;
				for (int j = 0; j < 3; j++)
				{
					if (float7[j] > 0.001f)
					{
						num = math.min(num, float7[j]);
					}
				}
				_baseExtent = ((num < float.MaxValue) ? num : 0.001f);
				foreach (float3 item2 in allPoints)
				{
					float3 float8 = item2 - _center;
					float num2 = math.length(float8);
					_directions.Add((num2 > 0.0001f) ? (float8 / num2) : float3.zero);
				}
			}
			ApplyExpandedSegments();
			void AddSegment(float3 a, float3 b)
			{
				_rawSegments.Add((a, b));
				allPoints.Add(a);
				allPoints.Add(b);
				_center += a + b;
				pointCount += 2;
			}
			void AddShape(Span<float3> points)
			{
				for (int k = 0; k < points.Length; k++)
				{
					AddSegment(points[k], points[(k + 1) % points.Length]);
				}
			}
		}

		public void UpdateBox(JFuselageTool tool)
		{
			SelectionTarget? selectionTarget = null;
			if (tool.Slice != null)
			{
				selectionTarget = SelectionTarget.ForSlice(tool.Slice.PrimaryFuselage, tool.Slice.PrimarySliceIndex);
			}
			else if (tool.Section != null)
			{
				selectionTarget = SelectionTarget.ForSection(tool.Section.PrimaryFuselage, tool.Section.PrimaryFuselageIndex);
			}
			if (selectionTarget.HasValue)
			{
				UpdateBox(selectionTarget.Value);
			}
			else
			{
				Hide();
			}
		}

		private static JFuselageScript GetFuselageScript(JFuselageData data)
		{
			PartScript partScript = data.Part.PartScript;
			if (partScript == null)
			{
				return null;
			}
			return partScript.GetModifier<JFuselageScript>();
		}

		private void ApplyExpandedSegments()
		{
			if (!(_lineContainer == null))
			{
				float num = _baseExtent * _expand;
				int index = 0;
				int num2 = 0;
				for (int i = 0; i < _rawSegments.Count; i++)
				{
					(float3 A, float3 B) tuple = _rawSegments[i];
					float3 item = tuple.A;
					float3 item2 = tuple.B;
					Vector3 a = item + _directions[num2++] * num;
					Vector3 b = item2 + _directions[num2++] * num;
					SetLine(ref index, a, b);
				}
				for (int j = index; j < _lines.Count; j++)
				{
					_lines[j].enabled = false;
				}
				_lineContainer.SetActive(value: true);
			}
		}

		private Color GetColorWithOpacity()
		{
			Color color = _color;
			color.a *= _opacity;
			return color;
		}

		private void KillTween()
		{
			_tween?.Kill();
			_tween = null;
		}

		private void SetLine(ref int index, Vector3 a, Vector3 b)
		{
			int num = index++;
			Line line;
			if (num < _lines.Count)
			{
				line = _lines[num];
				line.enabled = true;
			}
			else
			{
				GameObject gameObject = new GameObject($"Line {num}");
				gameObject.transform.SetParent(_lineContainer.transform, worldPositionStays: false);
				gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				gameObject.AddComponent<MeshFilter>();
				gameObject.AddComponent<MeshRenderer>();
				line = gameObject.AddComponent<Line>();
				line.ThicknessSpace = ThicknessSpace.Pixels;
				line.Thickness = _lineWidth;
				_lines.Add(line);
			}
			line.Color = GetColorWithOpacity();
			line[0] = a;
			line[1] = b;
		}

		private void UpdateLineAppearance()
		{
			Color colorWithOpacity = GetColorWithOpacity();
			foreach (Line line in _lines)
			{
				if (line != null && line.enabled)
				{
					line.Color = colorWithOpacity;
				}
			}
		}
	}
}
