using UnityEngine;

public class Feedback : MonoBehaviour
{
	[Header("Audio")]
	public AudioSource uiClickAudio;

	private static Feedback inst { get; set; }

	private void Awake()
	{
	}

	private void ConnectAllButtons()
	{
	}

	public static void UITouchStart()
	{
	}

	public static void UIClicked()
	{
	}
}
