using System.Collections.Generic;
using UnityEngine;

public class FishingOddsDisplay : MonoBehaviour
{
	[Header("Settings")]
	public bool showOnGUI = true;

	public bool rightClickToLog = true;

	private FishHabitat[] cachedHabitats;

	private void Start()
	{
		cachedHabitats = Object.FindObjectsOfType<FishHabitat>();
	}

	private void Update()
	{
		if (Time.frameCount % 60 == 0)
		{
			cachedHabitats = Object.FindObjectsOfType<FishHabitat>();
		}
		if (rightClickToLog && Input.GetMouseButtonDown(1))
		{
			LogOddsToConsole();
		}
	}

	private void OnGUI()
	{
		if (!showOnGUI)
		{
			return;
		}
		if (GameManager.Instance == null || GameManager.Instance.currentZone == null)
		{
			GUI.Label(new Rect(10f, 10f, 300f, 20f), "Waiting for Game Manager...");
			return;
		}
		string text = "Hovering: Nothing";
		Dictionary<string, float> dictionary = null;
		Vector3 hitPoint;
		Tile tileUnderMouse = GetTileUnderMouse(out hitPoint);
		if (tileUnderMouse != null)
		{
			text = "Hovering: " + tileUnderMouse.name;
			dictionary = CalculateOddsAtPosition(tileUnderMouse.transform.position);
		}
		else if (hitPoint != Vector3.zero)
		{
			text = "Hovering: Non-Tile Object";
		}
		float num = 100 + ((dictionary != null) ? (dictionary.Count * 20) : 0);
		GUI.Box(new Rect(10f, 10f, 250f, num), "Live Catch Odds");
		GUILayout.BeginArea(new Rect(20f, 35f, 230f, num - 10f));
		GUILayout.Label(text);
		if (dictionary != null)
		{
			GUILayout.Space(5f);
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			foreach (KeyValuePair<string, float> item in dictionary)
			{
				gUIStyle.normal.textColor = ((item.Value > 0f) ? Color.green : Color.white);
				GUILayout.Label($"{item.Key}: {item.Value:F1}%", gUIStyle);
			}
			GUILayout.Space(5f);
			GUILayout.Label("(Right-Click to Log)");
		}
		GUILayout.EndArea();
	}

	private void LogOddsToConsole()
	{
		Vector3 hitPoint;
		Tile tileUnderMouse = GetTileUnderMouse(out hitPoint);
		if (tileUnderMouse != null)
		{
			Debug.Log($"--- DETAILED ODDS FOR TILE AT {tileUnderMouse.transform.position} ---");
			{
				foreach (string item in CalculateOddsDetailed(tileUnderMouse.transform.position))
				{
					Debug.Log(item);
				}
				return;
			}
		}
		Debug.Log("Not hovering over a Tile.");
	}

	private Tile GetTileUnderMouse(out Vector3 hitPoint)
	{
		hitPoint = Vector3.zero;
		if (Camera.main == null)
		{
			return null;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out var hitInfo, 1000f))
		{
			hitPoint = hitInfo.point;
			Tile tile = hitInfo.collider.GetComponentInParent<Tile>();
			if (tile == null)
			{
				tile = hitInfo.collider.GetComponentInChildren<Tile>();
			}
			return tile;
		}
		RaycastHit2D rayIntersection = Physics2D.GetRayIntersection(ray, 1000f);
		if (rayIntersection.collider != null)
		{
			hitPoint = rayIntersection.point;
			Tile tile2 = rayIntersection.collider.GetComponentInParent<Tile>();
			if (tile2 == null)
			{
				tile2 = rayIntersection.collider.GetComponentInChildren<Tile>();
			}
			return tile2;
		}
		return null;
	}

	private Dictionary<string, float> CalculateOddsAtPosition(Vector3 castPos)
	{
		ZoneData currentZone = GameManager.Instance.currentZone;
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<Fish, float> dictionary2 = new Dictionary<Fish, float>();
		float num = 0f;
		foreach (FishEncounterData possibleCatch in currentZone.possibleCatches)
		{
			Fish fishSpecies = possibleCatch.fishSpecies;
			float num2 = 100f;
			float num3 = 0f;
			if (cachedHabitats != null)
			{
				FishHabitat[] array = cachedHabitats;
				foreach (FishHabitat fishHabitat in array)
				{
					if (fishHabitat != null)
					{
						num3 += fishHabitat.GetBoostPercentage(fishSpecies, castPos);
					}
				}
			}
			float num4 = num2 * (1f + num3);
			dictionary2.Add(fishSpecies, num4);
			num += num4;
		}
		if (num > 0f)
		{
			foreach (KeyValuePair<Fish, float> item in dictionary2)
			{
				float value = item.Value / num * 100f;
				dictionary.Add(item.Key.speciesName, value);
			}
		}
		return dictionary;
	}

	private List<string> CalculateOddsDetailed(Vector3 castPos)
	{
		ZoneData currentZone = GameManager.Instance.currentZone;
		List<string> list = new List<string>();
		foreach (FishEncounterData possibleCatch in currentZone.possibleCatches)
		{
			Fish fishSpecies = possibleCatch.fishSpecies;
			float num = 100f;
			float num2 = 0f;
			string text = "";
			if (cachedHabitats != null)
			{
				FishHabitat[] array = cachedHabitats;
				foreach (FishHabitat fishHabitat in array)
				{
					if (fishHabitat != null)
					{
						float boostPercentage = fishHabitat.GetBoostPercentage(fishSpecies, castPos);
						if (boostPercentage > 0f)
						{
							num2 += boostPercentage;
							text += $"[{fishHabitat.gameObject.name}: +{boostPercentage * 100f:F1}%] ";
						}
					}
				}
			}
			float num3 = num * (1f + num2);
			list.Add($"FISH: {fishSpecies.speciesName.PadRight(10)} | Base: {num} | Boost: +{num2 * 100f:F1}% {text}| Final W: {num3:F1}");
		}
		return list;
	}
}
