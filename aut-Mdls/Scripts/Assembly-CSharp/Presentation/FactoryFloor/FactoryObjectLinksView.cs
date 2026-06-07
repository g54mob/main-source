using System.Collections.Generic;
using Data.FactoryFloor;
using NaughtyAttributes;
using Shapes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Presentation.FactoryFloor
{
	public class FactoryObjectLinksView : MonoBehaviour
	{
		[SerializeField]
		protected FactoryObjectView _objectView;

		[SerializeField]
		protected Vector3 _startOffset;

		[SerializeField]
		protected Vector3 _endOffset;

		[SerializeField]
		[Layer]
		protected int _layer;

		[Header("Links")]
		[SerializeField]
		private bool _showSoftLinks;

		[SerializeField]
		private bool _showHardLinks;

		[SerializeField]
		private bool _alsoSelectLinkedObjects;

		[Header("Line settings")]
		[SerializeField]
		protected Color _startColor;

		[SerializeField]
		protected Color _endColor;

		[SerializeField]
		protected float _lineOffsetSpeed = 1f;

		[SerializeField]
		protected bool _reversed;

		[SerializeField]
		protected bool _dashed = true;

		[SerializeField]
		protected float _thickness = 0.1f;

		[SerializeField]
		protected bool _arch;

		[FormerlySerializedAs("_offset")]
		[SerializeField]
		[EnableIf("_arch")]
		protected Vector3 _archOffset;

		[SerializeField]
		[EnableIf("_arch")]
		[Range(2f, 64f)]
		protected int _segments = 8;

		protected List<Line> _softLinkLines = new List<Line>();

		protected List<Line> _hardLinkLines = new List<Line>();

		protected List<Polyline> _softLinkPolyLines = new List<Polyline>();

		protected List<Polyline> _hardLinkPolyLines = new List<Polyline>();

		protected FactoryObject _factoryObject;

		private bool _isShowingLinks;

		private readonly List<FactoryObjectView> _linkedSelectedViews = new List<FactoryObjectView>();

		private void Awake()
		{
			_objectView.FactoryObjectSet += FactoryObjectSet;
			_objectView.FactoryObjectReset += FactoryObjectReset;
		}

		private void OnDestroy()
		{
			_objectView.FactoryObjectSet -= FactoryObjectSet;
			_objectView.FactoryObjectReset -= FactoryObjectReset;
		}

		protected virtual void FactoryObjectSet(FactoryObject factoryObject, bool isGameLoading = false)
		{
			_factoryObject = factoryObject;
			_objectView.ObjectSelected += ShowLinks;
			_objectView.ObjectDeSelected += HideLinks;
		}

		private void FactoryObjectReset(FactoryObjectView _)
		{
			_objectView.ObjectSelected -= ShowLinks;
			_objectView.ObjectDeSelected -= HideLinks;
		}

		private void Update()
		{
			if (_isShowingLinks)
			{
				UpdateLineOffsets();
			}
		}

		private void ShowLinks()
		{
			if (_isShowingLinks)
			{
				return;
			}
			if (_showSoftLinks && _factoryObject.IsSoftLinked)
			{
				foreach (FactoryObject softLinkedObject in _factoryObject.SoftLinkedObjects)
				{
					CreateSoftLinkLine(softLinkedObject);
				}
			}
			if (_showHardLinks && _factoryObject.IsHardLinked)
			{
				foreach (FactoryObject hardLinkedObject in _factoryObject.HardLinkedObjects)
				{
					CreateHardLinkLine(hardLinkedObject);
				}
			}
			SelectLinkedObjects();
			_isShowingLinks = true;
		}

		private void SelectLinkedObjects()
		{
			if (!_alsoSelectLinkedObjects)
			{
				return;
			}
			if (_showSoftLinks && _factoryObject.IsSoftLinked)
			{
				foreach (FactoryObject softLinkedObject in _factoryObject.SoftLinkedObjects)
				{
					if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(softLinkedObject.CreatedId, out var view) && !view.IsSelected)
					{
						view.Select();
						_linkedSelectedViews.Add(view);
					}
				}
			}
			if (!_showHardLinks || !_factoryObject.IsHardLinked)
			{
				return;
			}
			foreach (FactoryObject hardLinkedObject in _factoryObject.HardLinkedObjects)
			{
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(hardLinkedObject.CreatedId, out var view2) && !view2.IsSelected)
				{
					view2.Select();
					_linkedSelectedViews.Add(view2);
				}
			}
		}

		private void DeselectLinkedViews()
		{
			for (int num = _linkedSelectedViews.Count - 1; num >= 0; num--)
			{
				if (_linkedSelectedViews[num].IsSelected)
				{
					_linkedSelectedViews[num].DeSelect();
				}
				_linkedSelectedViews.RemoveAt(num);
			}
		}

		public void HideLinks()
		{
			if (_isShowingLinks)
			{
				for (int num = _softLinkLines.Count - 1; num >= 0; num--)
				{
					Object.Destroy(_softLinkLines[num].gameObject);
				}
				_softLinkLines.Clear();
				for (int num2 = _hardLinkLines.Count - 1; num2 >= 0; num2--)
				{
					Object.Destroy(_hardLinkLines[num2].gameObject);
				}
				_hardLinkLines.Clear();
				for (int num3 = _softLinkPolyLines.Count - 1; num3 >= 0; num3--)
				{
					Object.Destroy(_softLinkPolyLines[num3].gameObject);
				}
				_softLinkPolyLines.Clear();
				for (int num4 = _hardLinkPolyLines.Count - 1; num4 >= 0; num4--)
				{
					Object.Destroy(_hardLinkPolyLines[num4].gameObject);
				}
				_hardLinkPolyLines.Clear();
				DeselectLinkedViews();
				_isShowingLinks = false;
			}
		}

		protected virtual void CreateSoftLinkLine(FactoryObject linkObject)
		{
			CreateSoftLinkLine(_factoryObject.Position + new Vector3(0.5f, 0f, 0.5f), linkObject.Position + new Vector3(0.5f, 0f, 0.5f));
		}

		protected void CreateSoftLinkLine(Vector3 startPos, Vector3 endPos)
		{
			GameObject gameObject = new GameObject("LinkLine");
			gameObject.transform.SetParent(base.transform);
			gameObject.layer = _layer;
			gameObject.transform.localPosition = Vector3.zero;
			Vector3 vector = startPos + _startOffset;
			Vector3 vector2 = endPos + _endOffset;
			if (_arch)
			{
				Polyline polyline = gameObject.AddComponent<Polyline>();
				polyline.points.Clear();
				polyline.Closed = false;
				polyline.Geometry = PolylineGeometry.Billboard;
				polyline.Thickness = _thickness;
				Vector3 vector3 = vector2 - vector;
				Vector3 vector4 = vector + vector3 / 2f + _archOffset;
				for (int i = 0; i <= _segments; i++)
				{
					float t = (float)i / (float)_segments;
					Vector3 a = Vector3.Lerp(vector, vector4, t);
					Vector3 b = Vector3.Lerp(vector4, vector2, t);
					Vector3 position = Vector3.Lerp(a, b, t);
					Color color = Color.Lerp(_startColor, _endColor, t);
					position -= base.transform.position;
					polyline.AddPoint(position, color);
				}
				_softLinkPolyLines.Add(polyline);
			}
			else
			{
				Line line = gameObject.AddComponent<Line>();
				line.Start = vector - base.transform.position;
				line.End = vector2 - base.transform.position;
				line.DashType = DashType.Chevron;
				line.Dashed = _dashed;
				line.Thickness = _thickness;
				line.ColorMode = Line.LineColorMode.Double;
				line.ColorStart = _startColor;
				line.ColorEnd = _endColor;
				line.DashShapeModifier = ((!_reversed) ? 1 : (-1));
				_softLinkLines.Add(line);
			}
			_isShowingLinks = true;
		}

		private void CreateHardLinkLine(FactoryObject linkObject)
		{
			GameObject obj = new GameObject("LinkLine");
			obj.transform.SetParent(base.transform);
			obj.transform.localPosition = Vector3.zero;
			obj.layer = _layer;
			Line line = obj.AddComponent<Line>();
			line.Start = _startOffset;
			line.End = linkObject.Position - _factoryObject.Position + _endOffset;
			line.DashType = DashType.Chevron;
			line.Dashed = _dashed;
			line.Thickness = _thickness;
			line.ColorMode = Line.LineColorMode.Double;
			line.ColorStart = _startColor;
			line.ColorEnd = _endColor;
			line.DashShapeModifier = ((!_reversed) ? 1 : (-1));
			_hardLinkLines.Add(line);
			_isShowingLinks = true;
		}

		private void UpdateLineOffsets()
		{
			if (!_dashed)
			{
				return;
			}
			foreach (Line softLinkLine in _softLinkLines)
			{
				softLinkLine.DashOffset += Time.deltaTime * _lineOffsetSpeed;
			}
			foreach (Line hardLinkLine in _hardLinkLines)
			{
				hardLinkLine.DashOffset += Time.deltaTime * _lineOffsetSpeed;
			}
		}
	}
}
