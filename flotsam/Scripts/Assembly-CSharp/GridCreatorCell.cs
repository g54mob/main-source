using PajamaLlama.Enums;
using TMPro;
using UnityEngine;

public class GridCreatorCell : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer _renderer;

	[SerializeField]
	private Material _emptyMaterial;

	[SerializeField]
	private Material _roadMaterial;

	[SerializeField]
	private Material _buildingMaterial;

	[SerializeField]
	private Material _foliageMaterial;

	[SerializeField]
	private Material _entranceMaterial;

	[SerializeField]
	private TextMeshPro _textMeshPro;

	[SerializeField]
	[HideInInspector]
	private LandmarkCellData _data;

	[SerializeField]
	[HideInInspector]
	private int _index;

	private LandmarkCell _landmarkCell;

	public LandmarkCellData Data => _data;

	public int Index => _index;

	public void Initialize(LandmarkCellData data, int index)
	{
		_data = data;
		SetType(data.Type);
		_index = index;
	}

	public void Initialize(LandmarkCell landmarkCell)
	{
		_landmarkCell = landmarkCell;
		if (landmarkCell.EntranceDirection != CardinalDirectionFlags.None)
		{
			SetType(LandmarkCellType.Entrance);
			_textMeshPro.text = landmarkCell.EntranceClearance.ToString();
			return;
		}
		SetType(landmarkCell.CellType);
		switch (landmarkCell.RoadOrientation)
		{
		case HorizontalVerticalFlags.Horizontal:
			_textMeshPro.text = "H";
			break;
		case HorizontalVerticalFlags.Vertical:
			_textMeshPro.text = "V";
			break;
		case HorizontalVerticalFlags.Horizontal | HorizontalVerticalFlags.Vertical:
			_textMeshPro.text = "HV";
			break;
		}
	}

	public void SetType(LandmarkCellType type)
	{
		_data.Type = type;
		switch (type)
		{
		case LandmarkCellType.Road:
			_renderer.material = _roadMaterial;
			break;
		case LandmarkCellType.Building:
			_renderer.material = _buildingMaterial;
			break;
		case LandmarkCellType.Foliage:
			_renderer.material = _foliageMaterial;
			break;
		case LandmarkCellType.Entrance:
			_renderer.material = _entranceMaterial;
			break;
		default:
			_renderer.material = _emptyMaterial;
			break;
		}
	}

	public void SetEmptyCellActive(bool value)
	{
		if (_data.Type == LandmarkCellType.Empty)
		{
			base.gameObject.SetActive(value);
		}
	}

	public Rect ReturnRect(float cellSize = 1f)
	{
		Vector3 position = base.transform.position;
		float num = cellSize / 2f;
		return new Rect
		{
			xMin = position.x - num,
			xMax = position.x + num,
			yMin = position.z - num,
			yMax = position.z + num
		};
	}
}
