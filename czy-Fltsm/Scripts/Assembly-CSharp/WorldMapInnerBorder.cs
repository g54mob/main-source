using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldMapInnerBorder : MonoBehaviour
{
	public enum Axis
	{
		X = 0,
		Z = 1
	}

	[SerializeField]
	private Axis _axis;

	[SerializeField]
	private Transform[] _visualtransforms;

	[SerializeField]
	private float _distanceMarkerInterval = 500f;

	[SerializeField]
	private TextMeshPro _distanceMarkerPrefab;

	private List<TextMeshPro> _distanceMarkers;

	public void UpdateWorldBounds(Rect worldBounds, WorldMapBorder.Sides side, float markerLabelOffsetX = 0f)
	{
		int i = 0;
		switch (_axis)
		{
		case Axis.X:
		{
			Vector3 position = base.transform.position;
			position.x = worldBounds.xMin;
			switch (side)
			{
			case WorldMapBorder.Sides.North:
				position.z = worldBounds.yMax;
				break;
			case WorldMapBorder.Sides.South:
				position.z = worldBounds.yMin;
				break;
			default:
				throw new NotImplementedException();
			}
			base.transform.position = position;
			Transform[] visualtransforms = _visualtransforms;
			foreach (Transform obj2 in visualtransforms)
			{
				Vector3 localPosition = obj2.localPosition;
				Vector3 localScale = obj2.localScale;
				localPosition.x = worldBounds.size.x / 2f;
				localScale.x = worldBounds.size.x;
				obj2.localPosition = localPosition;
				obj2.localScale = localScale;
			}
			if (_distanceMarkers == null)
			{
				_distanceMarkers = new List<TextMeshPro>(Mathf.CeilToInt(worldBounds.size.x / _distanceMarkerInterval));
			}
			float num2 = (float)Mathf.CeilToInt(worldBounds.xMin / _distanceMarkerInterval) * _distanceMarkerInterval;
			if (Mathf.Approximately(num2, worldBounds.xMin))
			{
				num2 += _distanceMarkerInterval;
			}
			for (; num2 < worldBounds.xMax; num2 += _distanceMarkerInterval)
			{
				TextMeshPro textMeshPro2 = ReturnDistanceMarker(i++);
				Vector3 position2 = textMeshPro2.transform.position;
				position2.x = num2;
				textMeshPro2.transform.position = position2;
				float num3 = (float)Mathf.CeilToInt((num2 + markerLabelOffsetX) / _distanceMarkerInterval) * _distanceMarkerInterval;
				textMeshPro2.name = $"Marker ({num3})";
				textMeshPro2.text = Mathf.RoundToInt(num3).ToString();
			}
			break;
		}
		case Axis.Z:
		{
			Vector3 position = base.transform.position;
			switch (side)
			{
			case WorldMapBorder.Sides.East:
				position.x = worldBounds.xMax;
				break;
			case WorldMapBorder.Sides.West:
				position.x = worldBounds.xMin;
				break;
			default:
				throw new NotImplementedException();
			}
			base.transform.position = position;
			Transform[] visualtransforms = _visualtransforms;
			foreach (Transform obj in visualtransforms)
			{
				Vector3 localScale = obj.localScale;
				localScale.x = worldBounds.size.y;
				obj.localScale = localScale;
			}
			if (_distanceMarkers == null)
			{
				_distanceMarkers = new List<TextMeshPro>(Mathf.CeilToInt(worldBounds.size.x / _distanceMarkerInterval));
			}
			float num = (float)Mathf.CeilToInt(worldBounds.yMin / _distanceMarkerInterval) * _distanceMarkerInterval;
			if (Mathf.Approximately(num, worldBounds.yMin))
			{
				num += _distanceMarkerInterval;
			}
			for (; num < worldBounds.yMax; num += _distanceMarkerInterval)
			{
				TextMeshPro textMeshPro = ReturnDistanceMarker(i++);
				Vector3 position2 = textMeshPro.transform.position;
				position2.z = num;
				textMeshPro.transform.position = position2;
				textMeshPro.name = $"Marker ({num})";
				textMeshPro.text = Mathf.RoundToInt(num).ToString();
			}
			break;
		}
		}
		if (!_distanceMarkers.IsNullOrEmpty())
		{
			for (; i < _distanceMarkers.Count; i++)
			{
				_distanceMarkers[i].gameObject.SetActive(value: false);
			}
		}
	}

	private TextMeshPro ReturnDistanceMarker(int index)
	{
		TextMeshPro textMeshPro;
		if (index < _distanceMarkers.Count)
		{
			textMeshPro = _distanceMarkers[index];
		}
		else
		{
			textMeshPro = UnityEngine.Object.Instantiate(_distanceMarkerPrefab, base.transform);
			_distanceMarkers.Add(textMeshPro);
		}
		textMeshPro.gameObject.SetActive(value: true);
		return textMeshPro;
	}
}
