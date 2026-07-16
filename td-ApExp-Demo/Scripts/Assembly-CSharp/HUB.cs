using AYellowpaper.SerializedCollections;
using UnityEngine;

public class HUB : MonoBehaviour
{
	public static HUB Instance;

	private HUBLayoutSO currentLayout;

	[SerializeField]
	private SpriteRenderer floorSr;

	[SerializeField]
	private SpriteRenderer mountainExitSr;

	[SerializeField]
	private SpriteRenderer archwaysSr;

	[SerializeField]
	private SpriteRenderer craneSr;

	[field: SerializeField]
	public SerializedDictionary<string, GameObject> hubElements { get; private set; }

	[field: SerializeField]
	public SerializedDictionary<int, HUBLayoutSO> HUBLayouts { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		ZoneManager.Instance.OnZoneLoaded += OnZoneLoaded;
	}

	public void OnZoneLoaded(int i)
	{
		base.gameObject.SetActive(value: true);
		if (HUBLayouts.TryGetValue(i, out var value))
		{
			currentLayout = value;
			floorSr.sprite = value.FloorArt;
			if (value.showArchways)
			{
				archwaysSr.gameObject.SetActive(value: true);
				archwaysSr.sprite = value.ArchwaysArt;
			}
			else
			{
				archwaysSr.gameObject.SetActive(value: false);
			}
			if (value.showMountains)
			{
				mountainExitSr.gameObject.SetActive(value: true);
				mountainExitSr.sprite = value.MountainExitArt;
			}
			else
			{
				mountainExitSr.gameObject.SetActive(value: false);
			}
			craneSr.sprite = value.CraneArt;
			foreach (string key in hubElements.Keys)
			{
				if (currentLayout.elements.TryGetValue(key, out var value2))
				{
					hubElements[key].SetActive(value2);
				}
			}
			foreach (PlayerController player in PlayerManager.Instance.Players)
			{
				SetInteractablesForPlayer(player, value, i > 0);
			}
		}
		else
		{
			Debug.LogError($"Cant find HUB layout for world index: {i}.");
			foreach (PlayerController player2 in PlayerManager.Instance.Players)
			{
				player2.interactor.RefreshInteractablesArray();
			}
		}
		TutorialManager.Instance.MapLocked = false;
	}

	public void SetInteractablesForPlayer(PlayerController player, HUBLayoutSO currentZoneLayout, bool fullTrain)
	{
		player.interactor.ClearInteractables();
		player.interactor.AddInteractableToArray(Train.Instance.GetFurnaceModuleSlot().Module.GetComponent<Interactable>());
		if (fullTrain)
		{
			player.interactor.AddInteractableToArray(Train.Instance.GetLeverModuleSlot().Module.GetComponent<Interactable>());
			player.interactor.AddInteractableToArray(Train.Instance.GetCannonModuleSlot().Module.GetComponent<Interactable>());
			player.interactor.AddInteractableToArray(Train.Instance.GetClawModuleSlot().Module.GetComponent<Interactable>());
		}
		foreach (string key in currentZoneLayout.elements.Keys)
		{
			if (currentZoneLayout.elements[key] && hubElements.TryGetValue(key, out var value))
			{
				player.interactor.AddInteractableToArray(value.GetComponent<Interactable>());
			}
		}
	}

	private void OnDestroy()
	{
		ZoneManager.Instance.OnZoneLoaded -= OnZoneLoaded;
	}
}
