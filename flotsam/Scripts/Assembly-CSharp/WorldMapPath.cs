using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WorldMapPath : MonoBehaviour
{
	[SerializeField]
	private LineRenderer _lineRenderer;

	[SerializeField]
	private LineRendererFollower _lineRendererFollower;

	[SerializeField]
	private Color _pathHasFuelColor = Color.white;

	[SerializeField]
	private Color _pathHasNoFuelColor = Color.white;

	[SerializeField]
	private GameObject _endLocationMarkerPrefab;

	private GameObject _endLocationMarker;

	private Engine _engine;

	private int _rangePropertyId;

	public bool IsEnabled => _lineRenderer.gameObject.activeInHierarchy;

	private void Awake()
	{
		_engine = Community.PlayerCommunity.Engine;
		_rangePropertyId = Shader.PropertyToID("_Range");
	}

	public void Enable()
	{
		_lineRenderer.gameObject.SetActive(value: true);
	}

	public void Disable()
	{
		_lineRenderer.gameObject.SetActive(value: false);
		DisableEndPositionMarker();
	}

	public void UpdatePath(MapPath path)
	{
		if (path.EvaluatedState == MapPath.State.Ok)
		{
			SetCanReach();
		}
		else
		{
			SetCannotReach(path);
		}
		SetPathPositions(path, 0f);
	}

	public void SetCanReach()
	{
		_lineRenderer.material.SetFloat(_rangePropertyId, 1f);
		_lineRendererFollower.SetColor(_pathHasFuelColor);
	}

	public void SetCannotReach(MapPath mapPath)
	{
		float value = _engine.ReturnEnergyRange() / mapPath.Length;
		_lineRenderer.material.SetFloat(_rangePropertyId, value);
		_lineRendererFollower.SetColor(_pathHasNoFuelColor);
	}

	public void SetPathPositions(MapPath path, float progress)
	{
		path.SetLineRendererPositions(_lineRenderer, progress);
	}

	public void EnableEndPositionMarker(Vector3 endPosition)
	{
		if (_endLocationMarker == null)
		{
			_endLocationMarker = Object.Instantiate(_endLocationMarkerPrefab, endPosition, Quaternion.identity, base.transform);
			return;
		}
		_endLocationMarker.transform.position = endPosition;
		_endLocationMarker.SetActive(value: true);
	}

	public void DisableEndPositionMarker()
	{
		if (!(_endLocationMarker == null))
		{
			_endLocationMarker.SetActive(value: false);
		}
	}
}
