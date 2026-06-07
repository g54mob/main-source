using System.Collections.Generic;
using Data.ResourceTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.WorldMap
{
	public class ArcRenderer : MonoBehaviour
	{
		[SerializeField]
		private Transform _point1;

		[SerializeField]
		private Transform _point2;

		[SerializeField]
		private Transform _point3;

		[SerializeField]
		private LineRenderer _lineRenderer;

		[SerializeField]
		private Transform _iconTransform;

		[SerializeField]
		private GameObject _icon;

		[SerializeField]
		private GameObject _panel;

		[Range(1f, 20f)]
		[SerializeField]
		private uint _vertexCount = 12u;

		public float CurveHeight;

		public float Point2Offset;

		private List<ResourceType> _resourceTypes = new List<ResourceType>();

		private Coroutine _animationCoroutine;

		private LineRenderAnimator _lineRenderAnimator = new LineRenderAnimator();

		private void Update()
		{
			_point2.transform.position = new Vector3(_point1.transform.position.x + _point3.transform.position.x, CurveHeight, (_point1.transform.position.z + _point3.transform.position.z) / 2f);
			_iconTransform.position = _point2.position;
			_point2.transform.position += CalculatePerpendicularDirection(_point1.position, _point3.position) * Point2Offset;
			List<Vector3> list = new List<Vector3>();
			int num = 0;
			for (float num2 = 0f; num2 <= 1f; num2 += 1f / (float)_vertexCount)
			{
				Vector3 a = Vector3.Lerp(_point1.position, _point2.position, num2);
				Vector3 b = Vector3.Lerp(_point2.position, _point3.position, num2);
				Vector3 item = Vector3.Lerp(a, b, num2);
				list.Add(item);
				num++;
			}
			_iconTransform.position = list[num / 2];
			_lineRenderer.positionCount = list.Count;
			_lineRenderer.SetPositions(list.ToArray());
		}

		public void SetStartPoint(Transform trans)
		{
			_point1.position = trans.position;
			_point1.parent = trans;
		}

		public void SetEndPoint(Transform trans)
		{
			_point3.position = trans.position;
			_point3.parent = trans;
		}

		public void SetEndPointPosition(Vector3 pos)
		{
			_point3.position = pos;
		}

		private Vector3 CalculatePerpendicularDirection(Vector3 point1, Vector3 point2)
		{
			Vector3 vector = point2 - point1;
			Vector3 result = new Vector3(0f - vector.z, 0f, vector.x);
			result.Normalize();
			return result;
		}

		public void CreateIcon(ResourceType type)
		{
			GameObject obj = Object.Instantiate(_icon);
			obj.transform.SetParent(_panel.transform, worldPositionStays: false);
			obj.GetComponent<Image>().sprite = type.Icon;
			_resourceTypes.Add(type);
		}

		public void RemoveIcon(ResourceType type)
		{
			for (int i = 0; i < _resourceTypes.Count; i++)
			{
				if (_resourceTypes[i] == type)
				{
					Object.Destroy(_panel.transform.GetChild(i).gameObject);
					_resourceTypes.RemoveAt(i);
				}
			}
		}

		public void StartAnimation()
		{
			if (_animationCoroutine == null)
			{
				_animationCoroutine = StartCoroutine(_lineRenderAnimator.AnimateLoop(_lineRenderer));
			}
		}

		public void StopAnimation()
		{
			if (_animationCoroutine != null)
			{
				StopCoroutine(_animationCoroutine);
				_animationCoroutine = null;
			}
		}

		private void Start()
		{
			_lineRenderer.colorGradient = _lineRenderAnimator.AddInitialCopy(_lineRenderer.colorGradient);
		}
	}
}
