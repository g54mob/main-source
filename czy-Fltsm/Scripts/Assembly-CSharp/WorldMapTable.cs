using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class WorldMapTable : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer _tilePrefab;

	[SerializeField]
	private float _minimumWorldMargin = 4000f;

	[SerializeField]
	private Collider _mapPlane;

	private List<MeshRenderer> _tiles;

	public void UpdateWorldBounds(Rect worldBounds)
	{
		Vector3 size = _tilePrefab.bounds.size;
		Vector3 vector = size / 2f;
		int num = Mathf.FloorToInt((worldBounds.xMin - _minimumWorldMargin) / size.x);
		int num2 = Mathf.CeilToInt((worldBounds.xMax + _minimumWorldMargin) / size.x) - num;
		int num3 = Mathf.FloorToInt((worldBounds.yMin - _minimumWorldMargin) / size.z);
		int num4 = Mathf.CeilToInt((worldBounds.yMax + _minimumWorldMargin) / size.z) - num3;
		float num5 = (float)num * size.x + vector.x;
		float num6 = (float)num3 * size.z + vector.z;
		if (_tiles == null)
		{
			_tiles = new List<MeshRenderer>();
		}
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num4; j++)
			{
				MeshRenderer meshRenderer = ReturnTile(i * num4 + j);
				Vector3 position = meshRenderer.transform.position;
				position.x = num5 + size.x * (float)i;
				position.z = num6 + size.z * (float)j;
				meshRenderer.transform.position = position;
			}
		}
		Rect rect = new Rect((float)num * size.x, (float)num3 * size.z, (float)num2 * size.x, (float)num4 * size.z);
		_mapPlane.transform.localScale = rect.size.Vector3TopDown(_mapPlane.transform.localScale.y);
		_mapPlane.transform.position = rect.center.Vector3TopDown();
	}

	private MeshRenderer ReturnTile(int index)
	{
		if (index < _tiles.Count)
		{
			return _tiles[index];
		}
		MeshRenderer meshRenderer = Object.Instantiate(_tilePrefab, base.transform);
		meshRenderer.gameObject.SetActive(value: true);
		_tiles.Add(meshRenderer);
		return meshRenderer;
	}
}
