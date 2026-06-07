using UnityEngine;
using UnityEngine.UI;

public class CommandBaseControls : MonoBehaviour
{
	public GameObject burstButton;

	public Text countText;

	public Toggle buildPacketToggle;

	public Toggle ammoPacketToggle;

	public Toggle priorityTowerToggle;

	public Toggle priorityMinerToggle;

	private int lastEggCount;

	public void OnEnable()
	{
	}

	public void OnBuildPacketsToggled(bool val)
	{
	}

	public void OnAmmoPacketsToggled(bool val)
	{
	}

	public void OnPriorityTowerToggled(bool val)
	{
	}

	public void OnPriorityMinerToggled(bool val)
	{
	}
}
