using Mirror;
using TMPro;
using UnityEngine;

public class VehicleOccupantsUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("4 adet hazır passenger UI objesi (sırasıyla 0-3 koltuk)")]
	public GameObject[] passengerSlots = new GameObject[4];

	[Tooltip("Her slot için oyuncu ismi text'i")]
	public TextMeshProUGUI[] playerNameTexts = new TextMeshProUGUI[4];

	[Header("References")]
	public SCC_Network currentVehicle;

	[Header("Settings")]
	[Tooltip("True ise event'lere abone olmaz, SCC_Network doğrudan RefreshUI çağırır")]
	public bool manualRefreshMode;

	private void OnEnable()
	{
		if (currentVehicle != null && !manualRefreshMode)
		{
			SubscribeToVehicle(currentVehicle);
			RefreshUI();
		}
	}

	private void OnDisable()
	{
		if (currentVehicle != null && !manualRefreshMode)
		{
			UnsubscribeFromVehicle(currentVehicle);
		}
	}

	public void SetVehicle(SCC_Network vehicle)
	{
		if (currentVehicle != null && !manualRefreshMode)
		{
			UnsubscribeFromVehicle(currentVehicle);
		}
		currentVehicle = vehicle;
		if (currentVehicle != null)
		{
			if (!manualRefreshMode)
			{
				SubscribeToVehicle(currentVehicle);
			}
			RefreshUI();
		}
		else
		{
			HideAllSlots();
		}
	}

	private void SubscribeToVehicle(SCC_Network vehicle)
	{
		vehicle.OnPassengerCountChangedAll.AddListener(RefreshUI);
		vehicle.OnOwnerTakenAll.AddListener(RefreshUI);
		vehicle.OnOwnerReleasedAll.AddListener(RefreshUI);
	}

	private void UnsubscribeFromVehicle(SCC_Network vehicle)
	{
		vehicle.OnPassengerCountChangedAll.RemoveListener(RefreshUI);
		vehicle.OnOwnerTakenAll.RemoveListener(RefreshUI);
		vehicle.OnOwnerReleasedAll.RemoveListener(RefreshUI);
	}

	public void RefreshUI()
	{
		if (currentVehicle == null)
		{
			HideAllSlots();
			return;
		}
		if (!currentVehicle.IsLocalOccupant())
		{
			HideAllSlots();
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			uint seatNetId = GetSeatNetId(i);
			if (seatNetId != 0)
			{
				if (passengerSlots[i] != null)
				{
					passengerSlots[i].SetActive(value: true);
				}
				GamePlayer gamePlayer = FindPlayerByNetId(seatNetId);
				if (playerNameTexts[i] != null)
				{
					playerNameTexts[i].text = ((gamePlayer != null) ? gamePlayer.playerName : "???");
				}
			}
			else
			{
				if (passengerSlots[i] != null)
				{
					passengerSlots[i].SetActive(value: false);
				}
				if (playerNameTexts[i] != null)
				{
					playerNameTexts[i].text = "";
				}
			}
		}
	}

	private void HideAllSlots()
	{
		for (int i = 0; i < passengerSlots.Length; i++)
		{
			if (passengerSlots[i] != null)
			{
				passengerSlots[i].SetActive(value: false);
			}
			if (i < playerNameTexts.Length && playerNameTexts[i] != null)
			{
				playerNameTexts[i].text = "";
			}
		}
	}

	private uint GetSeatNetId(int seatIndex)
	{
		if (currentVehicle == null)
		{
			return 0u;
		}
		return currentVehicle.GetSeatNetId(seatIndex);
	}

	private GamePlayer FindPlayerByNetId(uint netId)
	{
		if (netId == 0)
		{
			return null;
		}
		if (NetworkClient.spawned.TryGetValue(netId, out var value))
		{
			return value.GetComponent<GamePlayer>();
		}
		return null;
	}
}
