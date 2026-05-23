using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphDrawer : MonoBehaviour
{
	public enum Type
	{
		Networth = 0,
		Score = 1
	}

	public Type type;

	private List<int> current;

	private List<int> oldBest;

	[SerializeField]
	private Color colorCurrent;

	[SerializeField]
	private Color colorOldBest;

	[SerializeField]
	private GameObject graphMarkersPrefab;

	[SerializeField]
	private GameObject graphSclaeMarkerPrefab;

	[SerializeField]
	private RectTransform graphSurface;

	private int xMaxScale;

	private int yMaxScale;

	private float width;

	private float height;

	private float wspacing;

	public void Generate(string _comingFromScene)
	{
		LevelData levelDataForScene = LevelProgressManager.instance.GetLevelDataForScene(_comingFromScene);
		if (type == Type.Networth)
		{
			current = levelDataForScene.dayToDayNetworth;
			oldBest = levelDataForScene.dayToDayNetworthBest;
		}
		else if (type == Type.Score)
		{
			current = levelDataForScene.dayToDayScore;
			oldBest = levelDataForScene.dayToDayScoreBest;
		}
		xMaxScale = Mathf.Max(oldBest.Count, current.Count);
		width = graphSurface.rect.width;
		height = graphSurface.rect.height;
		if (xMaxScale > 1)
		{
			wspacing = width / (float)(xMaxScale - 1);
		}
		else
		{
			wspacing = 0f;
		}
		yMaxScale = 1;
		for (int i = 0; i < oldBest.Count; i++)
		{
			yMaxScale = Mathf.Max(yMaxScale, oldBest[i]);
		}
		for (int j = 0; j < current.Count; j++)
		{
			yMaxScale = Mathf.Max(yMaxScale, current[j]);
		}
		GameObject gameObject = Object.Instantiate(graphSclaeMarkerPrefab, graphSurface);
		gameObject.transform.localPosition = new Vector3((0f - width) / 2f, (0f - height) / 2f);
		gameObject.GetComponentInChildren<TMP_Text>().text = "0";
		gameObject = Object.Instantiate(graphSclaeMarkerPrefab, graphSurface);
		gameObject.transform.localPosition = new Vector3((0f - width) / 2f, height / 2f);
		if (yMaxScale < 1000)
		{
			gameObject.GetComponentInChildren<TMP_Text>().text = yMaxScale.ToString();
		}
		else
		{
			int num = Mathf.FloorToInt((float)yMaxScale / 1000f);
			int num2 = Mathf.FloorToInt((float)yMaxScale / 100f) - num * 10;
			gameObject.GetComponentInChildren<TMP_Text>().text = num + "." + num2 + "K";
		}
		PlotList(oldBest, colorOldBest);
		PlotList(current, colorCurrent);
	}

	private void PlotList(List<int> _list, Color _color)
	{
		if (_list.Count <= 0)
		{
			return;
		}
		Vector3 vector = Vector3.zero;
		for (int i = 0; i < _list.Count; i++)
		{
			float x = (float)i * wspacing - width / 2f;
			float y = (float)_list[i] / (float)yMaxScale * height - height / 2f;
			Vector3 vector2 = new Vector3(x, y, 0f);
			if (i > 0 || _list.Count <= 1)
			{
				GameObject obj = Object.Instantiate(graphMarkersPrefab, graphSurface);
				RectTransform component = obj.GetComponent<RectTransform>();
				component.localPosition = vector2;
				obj.GetComponent<Image>().color = _color;
				if (i > 0)
				{
					component.localPosition = (vector + vector2) / 2f;
					component.localScale = new Vector3((vector - vector2).magnitude / component.rect.width, component.localScale.y, component.localScale.z);
					component.localRotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, vector - vector2));
				}
			}
			vector = vector2;
		}
	}
}
