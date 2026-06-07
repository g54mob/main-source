using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMap : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private GameplaySettings gameplaySettings;

	[Header("References")]
	[SerializeField]
	private RectTransform _ocean;

	[SerializeField]
	private DebugMapNode _nodePrefab;

	[SerializeField]
	private DebugMapConnection _connectionPrefab;

	[Header("Zoom")]
	[SerializeField]
	private float _zoomMax = 1f;

	[SerializeField]
	private float _zoomMin = 0.1f;

	[SerializeField]
	private float _zoomInterval = 0.1f;

	[SerializeField]
	private float _mouseScrollMultiplier = 0.01f;

	[Header("Info")]
	[SerializeField]
	private TMP_InputField _widthField;

	[SerializeField]
	private TMP_InputField _heightField;

	private List<IDebugMapDataProvider> _dataProviders;

	private List<GameObject> _debugBehaviours;

	private float _zoom = 1f;

	public RectTransform Ocean => _ocean;

	public DebugMapNode NodePrefab => _nodePrefab;

	public DebugMapConnection ConnectionPrefab => _connectionPrefab;

	private void OnEnable()
	{
		if (_dataProviders == null)
		{
			_dataProviders = new List<IDebugMapDataProvider>();
		}
	}

	public void Initialize(TileGenerator tileGenerator)
	{
		if (_dataProviders == null)
		{
			_dataProviders = new List<IDebugMapDataProvider>();
		}
		if (tileGenerator.TryPopulateDebugNodeDataProvider(_dataProviders))
		{
			InitializeNodes(_dataProviders);
		}
	}

	public void InitializeNodes(List<IDebugMapDataProvider> providers)
	{
		Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
		Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
		ClearDebugBehaviours();
		foreach (IDebugMapDataProvider provider in providers)
		{
			if (provider == null)
			{
				continue;
			}
			_debugBehaviours.Add(provider.ReturnDebugVisual(this));
			if (provider.Type == DebugMapDataProviderType.Node)
			{
				Vector3 vector3 = provider.Position;
				if (vector3.x < vector.x)
				{
					vector.x = vector3.x;
				}
				if (vector2.x < vector3.x)
				{
					vector2.x = vector3.x;
				}
				if (vector3.y < vector.y)
				{
					vector.y = vector3.y;
				}
				if (vector2.y < vector3.y)
				{
					vector2.y = vector3.y;
				}
			}
		}
		float num = (Mathf.Max(Mathf.Max(Mathf.Abs(vector2.x), Mathf.Abs(vector.x)), Mathf.Max(Mathf.Abs(vector2.y), Mathf.Abs(vector.y))) + 128f) * 2f;
		if (float.IsInfinity(num))
		{
			Debug.Log("Huh?");
		}
		if (_ocean.sizeDelta.x < num)
		{
			_ocean.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
		}
		if (_ocean.sizeDelta.y < num)
		{
			_ocean.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
		}
		UpdateInfo(num);
	}

	private void Update()
	{
		Zoom(Input.mouseScrollDelta.y * _mouseScrollMultiplier);
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			Zoom(_zoomInterval);
		}
		if (Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			Zoom(0f - _zoomInterval);
		}
		_ocean.localScale = new Vector3(_zoom, _zoom, 1f);
	}

	public void ClearDebugBehaviours()
	{
		if (_debugBehaviours == null)
		{
			_debugBehaviours = new List<GameObject>();
			return;
		}
		foreach (GameObject debugBehaviour in _debugBehaviours)
		{
			Object.Destroy(debugBehaviour);
		}
		_debugBehaviours.Clear();
	}

	private void Zoom(float zoomChange)
	{
		float num = Mathf.Max(_zoomMin, Mathf.Min(_zoomMax, _zoom + zoomChange));
		if (_zoom != num)
		{
			_zoom = num;
			_ocean.localScale = new Vector3(_zoom, _zoom, 1f);
		}
	}

	public void Recenter()
	{
		_ocean.anchoredPosition = Vector2.zero;
	}

	private void UpdateInfo(float oceanSize)
	{
		string text = Mathf.Floor(oceanSize).ToString();
		if ((bool)_widthField)
		{
			_widthField.text = text;
		}
		if ((bool)_heightField)
		{
			_heightField.text = text;
		}
	}
}
