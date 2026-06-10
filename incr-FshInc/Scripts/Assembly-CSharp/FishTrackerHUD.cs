using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FishTrackerHUD : MonoBehaviour
{
	public enum TrackerTier
	{
		None = 0,
		Tier1_Presence = 1,
		Tier2_Advantage = 2,
		Tier3_Precision = 3
	}

	[Header("Settings")]
	public TrackerTier currentTier;

	public float significanceThreshold = 2f;

	[Header("Sonar Settings")]
	[Tooltip("How many seconds between each scan pulse?")]
	public float pulseInterval = 4f;

	[Header("UI References")]
	public TextMeshProUGUI statusText;

	public Transform listContainer;

	public FishTrackerRow statRowPrefab;

	[Tooltip("Drag your Filled Image here. It will fill continuously.")]
	public Image scanningBarImage;

	private CanvasGroup canvasGroup;

	private FishHabitat[] cachedHabitats;

	private Camera mainCam;

	private float pulseTimer;

	private Tile currentHoverTile;

	private Tile lastHoverTile;

	private string lastTileName;

	private Dictionary<Fish, FishTrackerRow> activeRows = new Dictionary<Fish, FishTrackerRow>();

	private bool isHovering;

	private void Start()
	{
		mainCam = Camera.main;
		cachedHabitats = Object.FindObjectsOfType<FishHabitat>();
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = false;
		canvasGroup.interactable = false;
	}

	private void Update()
	{
		if (PlayerStats.Instance != null)
		{
			TrackerTier trackerTier = (TrackerTier)Mathf.Clamp(PlayerStats.Instance.FishTrackerTier, 0, 3);
			if (trackerTier != currentTier)
			{
				Debug.Log($"[FishTrackerHUD] Tier updated: {currentTier} -> {trackerTier} (Stat: {PlayerStats.Instance.FishTrackerTier})");
				currentTier = trackerTier;
			}
		}
		if (Time.frameCount % 60 == 0)
		{
			cachedHabitats = Object.FindObjectsOfType<FishHabitat>();
		}
		Vector3 hitPoint;
		Tile tileUnderMouse = GetTileUnderMouse(out hitPoint);
		if (tileUnderMouse == null || currentTier == TrackerTier.None || EndOfGamePanel.IsVisible)
		{
			isHovering = false;
			return;
		}
		bool flag = isHovering;
		isHovering = true;
		currentHoverTile = tileUnderMouse;
		ShowPanel();
		if (EndOfDayPanel.IsVisible)
		{
			return;
		}
		if (lastHoverTile != currentHoverTile)
		{
			lastHoverTile = currentHoverTile;
			pulseTimer = 0f;
			if (scanningBarImage != null)
			{
				scanningBarImage.fillAmount = 0f;
			}
			if (statusText != null && lastTileName != currentHoverTile.name)
			{
				lastTileName = currentHoverTile.name;
				statusText.text = lastTileName;
				statusText.transform.DOPunchPosition(Vector3.up * 2f, 0.3f, 1, 0.1f).SetEase(Ease.OutBounce);
			}
		}
		if (!flag || activeRows.Count == 0)
		{
			UpdateTracker(currentHoverTile);
		}
		float num = pulseInterval;
		if (PlayerStats.Instance != null && PlayerStats.Instance.TrackerPulseSpeedBonus > 0f)
		{
			num = pulseInterval / (1f + PlayerStats.Instance.TrackerPulseSpeedBonus);
		}
		pulseTimer += Time.deltaTime;
		if (scanningBarImage != null)
		{
			scanningBarImage.fillAmount = pulseTimer / num;
		}
		if (pulseTimer >= num)
		{
			pulseTimer = 0f;
			UpdateTracker(currentHoverTile);
			if (scanningBarImage != null)
			{
				scanningBarImage.transform.DOPunchScale(Vector3.one * 0.05f, 0.2f);
			}
		}
	}

	private void UpdateTracker(Tile tile)
	{
		Dictionary<Fish, float> source = CalculateOdds(tile.transform.position, useHabitats: true);
		Dictionary<Fish, float> dictionary = null;
		if (currentTier >= TrackerTier.Tier2_Advantage)
		{
			dictionary = CalculateOdds(tile.transform.position, useHabitats: false);
		}
		List<KeyValuePair<Fish, float>> list = (from x in source
			where x.Value > 0f
			orderby x.Value descending, x.Key.speciesName
			select x).ToList();
		HashSet<Fish> newFishSet = new HashSet<Fish>(list.Select((KeyValuePair<Fish, float> x) => x.Key));
		foreach (Fish item in activeRows.Keys.Where((Fish f) => !newFishSet.Contains(f)).ToList())
		{
			FishTrackerRow row = activeRows[item];
			activeRows.Remove(item);
			row.Hide(delegate
			{
				if (row != null)
				{
					Object.Destroy(row.gameObject);
				}
			});
		}
		int num = 0;
		foreach (KeyValuePair<Fish, float> item2 in list)
		{
			Fish key = item2.Key;
			float value = item2.Value;
			if (!activeRows.TryGetValue(key, out var value2))
			{
				value2 = Object.Instantiate(statRowPrefab, listContainer);
				activeRows.Add(key, value2);
				value2.Show();
			}
			else
			{
				value2.PlayUpdateAnimation();
			}
			value2.transform.SetSiblingIndex(num++);
			bool flag = FishLogManager.Instance != null && FishLogManager.Instance.HasCaughtSpecies(key.speciesName);
			Sprite icon = null;
			if (key.availableRarities != null && key.availableRarities.Count > 0)
			{
				icon = key.availableRarities[0].artwork;
			}
			string text = "";
			bool isHotspot = false;
			if (currentTier == TrackerTier.Tier1_Presence)
			{
				text = "<c=#888888>" + key.LocalizedName + "</c>";
			}
			else
			{
				float baseVal = 0f;
				if (dictionary != null && dictionary.ContainsKey(key))
				{
					baseVal = dictionary[key];
				}
				Color color;
				bool significant;
				string advantageSymbol = GetAdvantageSymbol(value, baseVal, out color, out significant);
				if (currentTier >= TrackerTier.Tier3_Precision && significant)
				{
					isHotspot = true;
				}
				text = key.LocalizedName + " <c=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + advantageSymbol + "</c>";
			}
			value2.Setup(icon, text, !flag, isHotspot);
		}
	}

	private void ShowPanel()
	{
		if (canvasGroup.alpha < 1f && !DOTween.IsTweening(canvasGroup))
		{
			canvasGroup.DOFade(1f, 0.5f);
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
		}
	}

	private void HidePanel()
	{
		if (canvasGroup.alpha > 0f && !DOTween.IsTweening(canvasGroup))
		{
			canvasGroup.DOFade(0f, 0.5f);
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
		}
	}

	public void ForceHide()
	{
		canvasGroup.DOKill();
		canvasGroup.DOFade(0f, 0.3f);
		canvasGroup.blocksRaycasts = false;
		canvasGroup.interactable = false;
		isHovering = false;
	}

	private Dictionary<Fish, float> CalculateOdds(Vector3 castPos, bool useHabitats)
	{
		ZoneData currentZone = GameManager.Instance.currentZone;
		Dictionary<Fish, float> dictionary = new Dictionary<Fish, float>();
		Dictionary<Fish, float> dictionary2 = new Dictionary<Fish, float>();
		float num = 0f;
		if (currentZone == null)
		{
			return dictionary;
		}
		foreach (FishEncounterData possibleCatch in currentZone.possibleCatches)
		{
			Fish fishSpecies = possibleCatch.fishSpecies;
			float num2 = 100f;
			float num3 = 0f;
			if (useHabitats && cachedHabitats != null)
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
				dictionary.Add(item.Key, item.Value / num * 100f);
			}
		}
		return dictionary;
	}

	private string GetAdvantageSymbol(float current, float baseVal, out Color color, out bool significant)
	{
		float num = current - baseVal;
		significant = false;
		if (Mathf.Abs(num) < significanceThreshold)
		{
			color = Color.white;
			return "~";
		}
		if (num > 0f)
		{
			if (num > significanceThreshold * 3f)
			{
				significant = true;
				color = Color.cyan;
				if (currentTier < TrackerTier.Tier3_Precision)
				{
					return "+";
				}
				return "+++";
			}
			if (num > significanceThreshold * 2f)
			{
				color = Color.green;
				if (currentTier < TrackerTier.Tier3_Precision)
				{
					return "+";
				}
				return "++";
			}
			color = new Color(0.7f, 1f, 0.7f);
			return "+";
		}
		if (num < (0f - significanceThreshold) * 2f)
		{
			color = Color.red;
			if (currentTier < TrackerTier.Tier3_Precision)
			{
				return "-";
			}
			return "--";
		}
		color = new Color(1f, 0.7f, 0.7f);
		return "-";
	}

	private Tile GetTileUnderMouse(out Vector3 hitPoint)
	{
		hitPoint = Vector3.zero;
		if (mainCam == null)
		{
			return null;
		}
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
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
}
