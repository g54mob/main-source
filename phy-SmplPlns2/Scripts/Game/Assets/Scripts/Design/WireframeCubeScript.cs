using System.Collections.Generic;
using Shapes;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class WireframeCubeScript : MonoBehaviour
	{
		[Header("Cube Definition")]
		[SerializeField]
		private Vector3 _cornerPoint1 = new Vector3(-0.5f, -0.5f, -0.5f);

		[SerializeField]
		private Vector3 _cornerPoint2 = new Vector3(0.5f, 0.5f, 0.5f);

		private List<Vector3> _cubePoints;

		[SerializeField]
		private Vector3 _cubeScale = Vector3.one;

		private bool _isVisible;

		[Header("Appearance")]
		[SerializeField]
		private Color _lineColor = Color.white;

		private List<GameObject> _lineGameObjects = new List<GameObject>();

		private bool _linesNeedRecreation = true;

		[SerializeField]
		private float _lineWidth = 2f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _opacity = 1f;

		[Header("Visibility")]
		[SerializeField]
		private bool _showConnectingEdges = true;

		[SerializeField]
		private bool _showZMinusFace = true;

		[SerializeField]
		private bool _showZPlusFace = true;

		[SerializeField]
		private bool _startVisible = true;

		public Color Color
		{
			get
			{
				return _lineColor;
			}
			set
			{
				if (_lineColor != value)
				{
					_lineColor = value;
					UpdateLineProperties();
				}
			}
		}

		public bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				if (_isVisible != value)
				{
					_isVisible = value;
					SetLinesActive(_isVisible);
				}
			}
		}

		public float LineWidth
		{
			get
			{
				return _lineWidth;
			}
			set
			{
				if (_lineWidth != value)
				{
					_lineWidth = value;
					UpdateLineProperties();
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
					UpdateLineProperties();
				}
			}
		}

		public Vector3 Scale
		{
			get
			{
				return _cubeScale;
			}
			set
			{
				if (_cubeScale != value)
				{
					_cubeScale = value;
					_linesNeedRecreation = true;
					CreateOrUpdateWireframeCube();
				}
			}
		}

		public void SetCornerPoints(Vector3 point1, Vector3 point2)
		{
			if (_cornerPoint1 != point1 || _cornerPoint2 != point2)
			{
				_cornerPoint1 = point1;
				_cornerPoint2 = point2;
				_linesNeedRecreation = true;
				CreateOrUpdateWireframeCube();
			}
		}

		public void ToggleFaceVisibility(bool zPlus, bool zMinus, bool connectingEdges)
		{
			if (_showZPlusFace != zPlus || _showZMinusFace != zMinus || _showConnectingEdges != connectingEdges)
			{
				_showZPlusFace = zPlus;
				_showZMinusFace = zMinus;
				_showConnectingEdges = connectingEdges;
				_linesNeedRecreation = true;
				CreateOrUpdateWireframeCube();
			}
		}

		protected void Awake()
		{
			_isVisible = _startVisible;
			_linesNeedRecreation = true;
		}

		protected void OnDestroy()
		{
			ClearLines();
		}

		protected void OnDisable()
		{
			SetLinesActive(active: false);
		}

		protected void OnEnable()
		{
			CreateOrUpdateWireframeCube();
			SetLinesActive(_isVisible);
		}

		protected void Start()
		{
			CreateOrUpdateWireframeCube();
		}

		private void AddLine(Vector3 start, Vector3 end)
		{
			GameObject gameObject = new GameObject($"WireframeEdge_{GetInstanceID()}");
			gameObject.layer = 10;
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			Line line = gameObject.AddComponent<Line>();
			line.Geometry = LineGeometry.Billboard;
			line.Start = start;
			line.End = end;
			line.ThicknessSpace = ThicknessSpace.Pixels;
			_lineGameObjects.Add(gameObject);
		}

		private void ClearLines()
		{
			foreach (GameObject lineGameObject in _lineGameObjects)
			{
				if (lineGameObject != null)
				{
					Object.Destroy(lineGameObject);
				}
			}
			_lineGameObjects.Clear();
			_linesNeedRecreation = true;
		}

		private void CreateOrUpdateWireframeCube()
		{
			if (!base.enabled || !base.gameObject.activeInHierarchy)
			{
				return;
			}
			bool flag = _lineGameObjects.Count > 0 && _lineGameObjects[0] != null;
			if (!_linesNeedRecreation && flag)
			{
				UpdateLineProperties();
				SetLinesActive(_isVisible);
				return;
			}
			ClearLines();
			Vector3 vector = Vector3.Scale(_cornerPoint2 - _cornerPoint1, _cubeScale);
			Vector3 vector2 = (_cornerPoint1 + _cornerPoint2) / 2f;
			Vector3 vector3 = vector / 2f;
			_cubePoints = new List<Vector3>
			{
				vector2 + new Vector3(0f - vector3.x, 0f - vector3.y, 0f - vector3.z),
				vector2 + new Vector3(vector3.x, 0f - vector3.y, 0f - vector3.z),
				vector2 + new Vector3(vector3.x, vector3.y, 0f - vector3.z),
				vector2 + new Vector3(0f - vector3.x, vector3.y, 0f - vector3.z),
				vector2 + new Vector3(0f - vector3.x, 0f - vector3.y, vector3.z),
				vector2 + new Vector3(vector3.x, 0f - vector3.y, vector3.z),
				vector2 + new Vector3(vector3.x, vector3.y, vector3.z),
				vector2 + new Vector3(0f - vector3.x, vector3.y, vector3.z)
			};
			if (_showZMinusFace)
			{
				AddLine(_cubePoints[0], _cubePoints[1]);
				AddLine(_cubePoints[1], _cubePoints[2]);
				AddLine(_cubePoints[2], _cubePoints[3]);
				AddLine(_cubePoints[3], _cubePoints[0]);
			}
			if (_showZPlusFace)
			{
				AddLine(_cubePoints[4], _cubePoints[5]);
				AddLine(_cubePoints[5], _cubePoints[6]);
				AddLine(_cubePoints[6], _cubePoints[7]);
				AddLine(_cubePoints[7], _cubePoints[4]);
			}
			if (_showConnectingEdges)
			{
				AddLine(_cubePoints[0], _cubePoints[4]);
				AddLine(_cubePoints[1], _cubePoints[5]);
				AddLine(_cubePoints[2], _cubePoints[6]);
				AddLine(_cubePoints[3], _cubePoints[7]);
			}
			UpdateLineProperties();
			SetLinesActive(_isVisible);
			_linesNeedRecreation = false;
		}

		private Color GetCurrentColorWithOpacity()
		{
			Color lineColor = _lineColor;
			lineColor.a *= _opacity;
			return lineColor;
		}

		private void SetLinesActive(bool active)
		{
			if (_lineGameObjects == null)
			{
				return;
			}
			bool flag = false;
			foreach (GameObject lineGameObject in _lineGameObjects)
			{
				if (lineGameObject != null && lineGameObject.TryGetComponent<Line>(out var component))
				{
					if (component.enabled != active)
					{
						component.enabled = active;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				Debug.LogWarning($"[{base.name}_{GetInstanceID()}] Found missing line GameObject during visibility update. Forcing recreation.", this);
				_linesNeedRecreation = true;
				_lineGameObjects.RemoveAll((GameObject item) => item == null);
			}
		}

		private void UpdateLineProperties()
		{
			if (_lineGameObjects == null)
			{
				return;
			}
			Color currentColorWithOpacity = GetCurrentColorWithOpacity();
			bool flag = false;
			float num = Mathf.Max(base.transform.lossyScale.x, base.transform.lossyScale.y, base.transform.lossyScale.z, 0.01f);
			if (base.transform.lossyScale.sqrMagnitude == 0f)
			{
				num = 1f;
			}
			foreach (GameObject lineGameObject in _lineGameObjects)
			{
				if (lineGameObject != null && lineGameObject.TryGetComponent<Line>(out var component))
				{
					component.Color = currentColorWithOpacity;
					component.Thickness = _lineWidth / num;
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				Debug.LogWarning($"[{base.name}_{GetInstanceID()}] Found missing line GameObject during property update. Forcing recreation.", this);
				_linesNeedRecreation = true;
				_lineGameObjects.RemoveAll((GameObject item) => item == null);
			}
		}
	}
}
