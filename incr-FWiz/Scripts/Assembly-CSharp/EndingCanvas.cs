using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

public class EndingCanvas : MonoBehaviour
{
	[SerializeField]
	public ClickListener _returnButton;

	[SerializeField]
	public ClickListener _restartButton;

	public EventReference OpenSound;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Return()
	{
	}

	public void LeaveGame()
	{
	}
}
