using ModApi.Common.Collections;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class OcclusionSampler
	{
		private float _cellSize;

		private Vector2i _currentCell;

		private GameObject[] _debugObjects;

		private Vector3 _localCenter;

		private Vector3 _localDirection;

		private int _numOccluded;

		private int _numSampled;

		private int _numSamplesPerDimension;

		private Collider[] _overlapSphereTestResults = new Collider[1];

		private float _spacingX;

		private float _spacingY;

		private Transform _transform;

		public bool DebugModeEnabled { get; set; }

		public GameObjectCollection IgnoreList { get; private set; } = new GameObjectCollection();

		public float MaxDistance { get; set; }

		public float Occlusion { get; set; }

		public bool Ready { get; private set; }

		public bool SkipCorners { get; set; }

		public OcclusionSampler(Vector2 scale, int numSamplesPerDimension, Transform transform, Vector3 localCenter, Vector3 localDirection)
		{
			float x = scale.x;
			float y = scale.y;
			_numSamplesPerDimension = numSamplesPerDimension;
			_cellSize = Mathf.Min(x, y) / (float)numSamplesPerDimension;
			_spacingX = x / (float)numSamplesPerDimension;
			_spacingY = y / (float)numSamplesPerDimension;
			_transform = transform;
			_localDirection = localDirection;
			_localCenter = localCenter;
			MaxDistance = Mathf.Max(x, y) * 2f;
		}

		public void Update()
		{
			if (!SkipCorners || !IsCornerCell())
			{
				SampleCell(_currentCell);
			}
			_currentCell.x++;
			if (_currentCell.x >= _numSamplesPerDimension)
			{
				_currentCell.x = 0;
				_currentCell.y++;
				if (_currentCell.y >= _numSamplesPerDimension)
				{
					Occlusion = (float)_numOccluded / (float)_numSampled;
					_currentCell = new Vector2i(0, 0);
					_numSampled = 0;
					_numOccluded = 0;
					Ready = true;
				}
			}
		}

		private Vector3 CalculateCellPosition(Vector2i currentCell)
		{
			float x = (float)(-(_numSamplesPerDimension - 1) / 2 + currentCell.x) * _spacingX;
			float z = (float)(-(_numSamplesPerDimension - 1) / 2 + currentCell.y) * _spacingY;
			return _localCenter + new Vector3(x, 0f, z);
		}

		private void CreateDebugSphere(Vector3 startPosition, float diameter, bool occluded)
		{
			if (_debugObjects == null)
			{
				_debugObjects = new GameObject[_numSamplesPerDimension * _numSamplesPerDimension];
			}
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.GetComponent<Collider>().enabled = false;
			gameObject.transform.SetParent(_transform, worldPositionStays: false);
			gameObject.transform.localScale = new Vector3(_spacingX, 0.05f, _spacingY);
			gameObject.transform.localPosition = startPosition;
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			Material material = Object.Instantiate(component.material);
			if (occluded)
			{
				material.SetColor("_Color", new Color(1f, 0f, 0f));
			}
			else
			{
				material.SetColor("_Color", new Color(1f, 1f, 1f));
			}
			component.material = material;
			if (_debugObjects[_numSampled] != null)
			{
				Object.Destroy(_debugObjects[_numSampled]);
			}
			_debugObjects[_numSampled] = gameObject;
		}

		private bool IsCornerCell()
		{
			int num = _numSamplesPerDimension - 1;
			if ((_currentCell.x != 0 || _currentCell.y != 0) && (_currentCell.x != num || _currentCell.y != 0) && (_currentCell.x != 0 || _currentCell.y != num))
			{
				if (_currentCell.x == num)
				{
					return _currentCell.y == num;
				}
				return false;
			}
			return true;
		}

		private void SampleCell(Vector2i currentCell)
		{
			try
			{
				IgnoreList.SetTemporaryLayer(2);
				Vector3 vector = CalculateCellPosition(currentCell);
				Ray ray = new Ray(_transform.TransformPoint(vector), _transform.TransformDirection(_localDirection));
				float num = _cellSize * 0.5f;
				int layerMask = -1073741824;
				bool flag = false;
				flag = Physics.OverlapSphereNonAlloc(ray.origin, _cellSize / 4f, _overlapSphereTestResults, layerMask, QueryTriggerInteraction.Ignore) > 0 || Physics.Raycast(ray, MaxDistance, layerMask, QueryTriggerInteraction.Ignore);
				if (flag)
				{
					_numOccluded++;
				}
				if (DebugModeEnabled)
				{
					CreateDebugSphere(vector, num * 2f, flag);
				}
			}
			finally
			{
				IgnoreList.RestoreLayers();
			}
			_numSampled++;
		}
	}
}
