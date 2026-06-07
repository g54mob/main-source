using Data.Buildings;
using Presentation.FactoryFloor;
using UnityEngine;

public class ActiveBuildingVFX : FactoryBehaviorView<BuildingBehaviour>
{
	[SerializeField]
	private GameObject _selectedBuildingVFX;

	private Vector2Int _defaultBuildingSize = new Vector2Int(6, 6);

	private Vector3 _defaultScale;

	private void Start()
	{
		_defaultBuildingSize = new Vector2Int(6, 6);
		_defaultScale = _selectedBuildingVFX.transform.localScale;
		_selectedBuildingVFX.SetActive(value: false);
	}

	public void Show()
	{
		_selectedBuildingVFX.SetActive(value: true);
		_selectedBuildingVFX.transform.localPosition = new Vector3((_behaviour.BuildingObjectData.BuildingSize.x % 2 == 0) ? (-0.5f) : 0f, -0.5f, (_behaviour.BuildingObjectData.BuildingSize.y % 2 == 0) ? (-0.5f) : 0f);
		_selectedBuildingVFX.transform.localScale = new Vector3(_defaultScale.x * ((float)_behaviour.BuildingObjectData.BuildingSize.x / (float)_defaultBuildingSize.x), _defaultScale.y, _defaultScale.z * ((float)_behaviour.BuildingObjectData.BuildingSize.y / (float)_defaultBuildingSize.y));
	}

	public void Hide()
	{
		_selectedBuildingVFX.SetActive(value: false);
	}
}
