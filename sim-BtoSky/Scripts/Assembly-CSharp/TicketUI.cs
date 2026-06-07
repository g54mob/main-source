using TMPro;
using UnityEngine;

public class TicketUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI ticketText;

	private void Start()
	{
		ticketText.text = FirstPersonController.S.ticket.ToString();
		GameManager.S.OnTicketUpdated += S_OnTicketUpdated;
	}

	private void OnDestroy()
	{
		GameManager.S.OnTicketUpdated -= S_OnTicketUpdated;
	}

	private void S_OnTicketUpdated()
	{
		ticketText.text = FirstPersonController.S.ticket.ToString();
	}
}
