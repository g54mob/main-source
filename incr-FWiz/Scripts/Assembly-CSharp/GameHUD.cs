using UnityEngine;

public class GameHUD : MonoBehaviour
{
	[SerializeField]
	private GameHUDNotificationHandler _notificationHandler;

	[SerializeField]
	private GameHUDNotificationListener _notificationListener;

	[SerializeField]
	private GameHUDSprintSymbol _sprintSymbol;

	[SerializeField]
	private ButtonGuide _buttonGuide;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}
}
