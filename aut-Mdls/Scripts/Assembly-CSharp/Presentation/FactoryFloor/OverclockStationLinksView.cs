using System.Collections;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using NaughtyAttributes;
using Shapes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class OverclockStationLinksView : FactoryBehaviorView<OverclockStationBehaviour>
	{
		[SerializeField]
		private Vector3 _startOffset;

		[SerializeField]
		private Vector3 _endOffset;

		[SerializeField]
		[Layer]
		private int _layer;

		[Header("Line settings")]
		[SerializeField]
		private bool _alsoSelectLinkedObjects;

		[SerializeField]
		private Color _startColor;

		[SerializeField]
		private Color _endColor;

		[SerializeField]
		private float _thickness = 0.1f;

		[SerializeField]
		private Vector3 _archOffset;

		[SerializeField]
		[Range(2f, 64f)]
		private int _segments = 8;

		[SerializeField]
		private bool _useThicknessCurve;

		[SerializeField]
		[ShowIf("_useThicknessCurve")]
		private AnimationCurve _thicknessCurve;

		private readonly List<FactoryObject> _factoryObjectsLines = new List<FactoryObject>();

		private FactoryObject _factoryObject;

		private readonly List<Polyline> _softLinkPolyLines = new List<Polyline>();

		private bool _isShowingLinks;

		private List<FactoryObjectView> _linkedSelectedViews = new List<FactoryObjectView>();

		private bool _isAnimatingOut;

		private Coroutine _hideAnimationCoroutine;

		private const float ANIM_OUT_TIME = 0.075f;

		protected override void Init()
		{
			base.Init();
			DestroyLinks();
		}

		protected override void OnDestroy()
		{
			_objectView.ObjectSelected -= ShowLinks;
			_objectView.ObjectDeSelected -= HideLinks;
			base.OnDestroy();
		}

		public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading = false)
		{
			base.SetFactoryObject(factoryObject, isGameLoading);
			_factoryObject = factoryObject;
			_objectView.ObjectSelected += ShowLinks;
			_objectView.ObjectDeSelected += HideLinks;
			DestroyLinks();
		}

		protected override void ResetFactoryObject()
		{
			_objectView.ObjectSelected -= ShowLinks;
			_objectView.ObjectDeSelected -= HideLinks;
			_factoryObject = null;
			DestroyLinks();
			base.ResetFactoryObject();
		}

		public void ShowLinks()
		{
			if (_isShowingLinks || _behaviour.OverclockedBuildings.Count == 0)
			{
				return;
			}
			foreach (BuildingBehaviour overclockedBuilding in _behaviour.OverclockedBuildings)
			{
				CreateSoftLinkLine(overclockedBuilding.FactoryObject);
			}
			SelectLinkedObjects();
			_isShowingLinks = true;
		}

		private void SelectLinkedObjects()
		{
			if (!_alsoSelectLinkedObjects || _behaviour.OverclockedBuildings.Count == 0)
			{
				return;
			}
			foreach (BuildingBehaviour overclockedBuilding in _behaviour.OverclockedBuildings)
			{
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(overclockedBuilding.FactoryObject.CreatedId, out var view) && !view.IsSelected)
				{
					view.Select();
					_linkedSelectedViews.Add(view);
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

		public virtual void HideLinks()
		{
			if (_isShowingLinks && !_isAnimatingOut)
			{
				_isAnimatingOut = true;
				_isShowingLinks = false;
				_hideAnimationCoroutine = StartCoroutine(IHideLinksAnimation(0.075f));
			}
		}

		private IEnumerator IHideLinksAnimation(float time)
		{
			_factoryObjectsLines.Clear();
			for (float i = 0f; i < time; i += Time.deltaTime)
			{
				float num = 1f - Mathf.Clamp01(i / time);
				foreach (Polyline softLinkPolyLine in _softLinkPolyLines)
				{
					softLinkPolyLine.Thickness = _thickness * num;
				}
				yield return null;
			}
			DestroyLinks();
		}

		private void DestroyLinks()
		{
			if (_hideAnimationCoroutine != null)
			{
				StopCoroutine(_hideAnimationCoroutine);
				_hideAnimationCoroutine = null;
			}
			for (int num = _softLinkPolyLines.Count - 1; num >= 0; num--)
			{
				Object.Destroy(_softLinkPolyLines[num].gameObject);
			}
			_softLinkPolyLines.Clear();
			_factoryObjectsLines.Clear();
			DeselectLinkedViews();
			_isShowingLinks = false;
			_isAnimatingOut = false;
		}

		protected virtual void ShowPreviewLine(Vector3 position, FactoryObject linkObject)
		{
			if (!_factoryObjectsLines.Contains(linkObject))
			{
				CreateSoftLinkLine(position + new Vector3(0.5f, 0f, 0.5f), linkObject.Position + new Vector3(0.5f, 0f, 0.5f));
				_factoryObjectsLines.Add(linkObject);
			}
		}

		protected virtual Polyline CreateSoftLinkLine(FactoryObject linkObject)
		{
			if (_factoryObjectsLines.Contains(linkObject))
			{
				return null;
			}
			Polyline result = CreateSoftLinkLine(_factoryObject.Position + new Vector3(0.5f, 0f, 0.5f), linkObject.Position + new Vector3(0.5f, 0f, 0.5f));
			_factoryObjectsLines.Add(linkObject);
			return result;
		}

		protected Polyline CreateSoftLinkLine(Vector3 startPos, Vector3 endPos)
		{
			if (_isAnimatingOut)
			{
				DestroyLinks();
			}
			GameObject obj = new GameObject("LinkLine");
			obj.transform.SetParent(base.transform);
			obj.layer = _layer;
			obj.transform.localPosition = Vector3.zero;
			Vector3 vector = startPos + _startOffset;
			Vector3 vector2 = endPos + _endOffset;
			Polyline polyline = obj.AddComponent<Polyline>();
			polyline.points.Clear();
			polyline.Closed = false;
			polyline.Geometry = PolylineGeometry.Billboard;
			polyline.Thickness = _thickness;
			Vector3 vector3 = vector2 - vector;
			Vector3 vector4 = vector + vector3 / 2f + _archOffset;
			for (int i = 0; i <= _segments; i++)
			{
				float num = (float)i / (float)_segments;
				Vector3 a = Vector3.Lerp(vector, vector4, num);
				Vector3 b = Vector3.Lerp(vector4, vector2, num);
				Vector3 position = Vector3.Lerp(a, b, num);
				Color color = Color.Lerp(_startColor, _endColor, num);
				position -= base.transform.position;
				polyline.AddPoint(position, color);
				if (_useThicknessCurve)
				{
					polyline.SetPointThickness(i, _thicknessCurve.Evaluate(num));
				}
			}
			_softLinkPolyLines.Add(polyline);
			_isShowingLinks = true;
			return polyline;
		}
	}
}
