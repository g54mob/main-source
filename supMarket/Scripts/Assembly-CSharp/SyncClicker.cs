using MyBox;
using UnityEngine;

public class SyncClicker : MonoBehaviour
{
	[SerializeField]
	private PlayerInteraction m_PlayerInteraction;

	public bool isClicked;

	public bool isHoldClicked;

	public PlayerInteraction PlayerInteraction => null;

	private void Update()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void Click()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void HoldClick()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void ResetClick()
	{
	}
}
