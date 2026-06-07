using TMPro;
using UnityEngine;

public class DebugCoinDisplay : MonoBehaviour
{
	public TextMeshProUGUI target;

	private PlayerInteraction player;

	private void Start()
	{
		player = Object.FindObjectOfType<PlayerInteraction>();
	}

	private void Update()
	{
		target.text = player.Balance.ToString();
	}
}
