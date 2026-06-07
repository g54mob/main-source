using UnityEngine;

public class SideWalkGroup
{
	private MeshCombiner _meshCombiner;

	private Mesh _mesh;

	private GameObject _go;

	private int _xFrom;

	private int _xTo;

	private int _yFrom;

	private int _yTo;

	private int _floor;

	public bool Dirty = true;

	public SideWalkGroup(int x1, int y1, int w, int h, int floor, Transform parent)
	{
		_xFrom = x1;
		_xTo = x1 + w;
		_yFrom = y1;
		_yTo = y1 + h;
		_floor = floor;
		_meshCombiner = new MeshCombiner("Sidewalk", true, false);
		_mesh = new Mesh();
		_go = new GameObject(string.Format("Sidewalk({0}, {1}, {2})", _xFrom, _yFrom, floor));
		_go.transform.SetParent(parent);
		_go.AddComponent<MeshFilter>().sharedMesh = _mesh;
		_go.AddComponent<MeshRenderer>().sharedMaterial = TimeOfDay.Instance.SideWalkMat;
	}

	public void Update(int floor)
	{
		if (Dirty)
		{
			_meshCombiner.Clear("Sidewalk");
			for (int i = _xFrom; i < _xTo; i++)
			{
				for (int j = _yFrom; j < _yTo; j++)
				{
					RoadSegment segment = RoadManager.Instance.GetSegment(i, j, _floor, false);
					if (segment != null)
					{
						segment.GenerateSidewalk(_meshCombiner);
					}
				}
			}
			_meshCombiner.CreateMesh(_mesh);
			Dirty = false;
		}
		bool flag = floor >= 0 && floor / 2 >= _floor;
		if (flag != _go.activeSelf)
		{
			_go.SetActive(flag);
		}
	}

	public void Destroy()
	{
		Object.Destroy(_go);
		Object.Destroy(_mesh);
	}
}
