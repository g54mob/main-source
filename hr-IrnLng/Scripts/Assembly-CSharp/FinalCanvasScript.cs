using TMPro;
using UnityEngine;

public class FinalCanvasScript : MonoBehaviour
{
	public TextMeshProUGUI MiddleTextText;

	public CanvasGroup[] Groups;

	public float[] Times;

	public float[] FadeTimes;

	private float MyTimer;

	private int CurrentGroup;

	public CanvasGroup EndCanvas;

	private SteamScript SScript;

	private void Start()
	{
		SScript = GameObject.Find("SteamObject").GetComponent<SteamScript>();
	}

	private void Update()
	{
		if (EndCanvas.alpha != 1f)
		{
			return;
		}
		if (Groups[CurrentGroup].alpha >= 1f)
		{
			MyTimer += Time.deltaTime;
		}
		else if (MyTimer < Times[CurrentGroup])
		{
			Groups[CurrentGroup].alpha += Time.deltaTime * FadeTimes[CurrentGroup];
		}
		if (!(MyTimer >= Times[CurrentGroup]))
		{
			return;
		}
		MyTimer = Times[CurrentGroup];
		Groups[CurrentGroup].alpha -= Time.deltaTime * FadeTimes[CurrentGroup];
		if (Groups[CurrentGroup].alpha <= 0f)
		{
			CurrentGroup++;
			MyTimer = 0f;
			if (CurrentGroup == Groups.Length - 1)
			{
				SScript.UnlockCheevo("finish_game");
			}
			if (CurrentGroup >= Groups.Length)
			{
				Application.LoadLevel("Menu");
			}
		}
	}
}
