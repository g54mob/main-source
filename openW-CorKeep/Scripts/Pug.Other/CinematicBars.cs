using UnityEngine;

public class CinematicBars : MonoBehaviour
{
	public SpriteRenderer topBar;

	public Transform topBarFadeInPosition;

	public Transform topBarFadeOutPosition;

	public SpriteRenderer botBar;

	public Transform botBarFadeInPosition;

	public Transform botBarFadeOutPosition;

	private float fadeInAlpha;

	private void Update()
	{
		if (Manager.sceneHandler.cutsceneIsPlaying)
		{
			fadeInAlpha += Time.deltaTime;
		}
		else
		{
			fadeInAlpha -= Time.deltaTime;
		}
		fadeInAlpha = Mathf.Clamp01(fadeInAlpha);
		topBar.transform.position = Vector3.Lerp(topBarFadeOutPosition.position, topBarFadeInPosition.position, fadeInAlpha);
		botBar.transform.position = Vector3.Lerp(botBarFadeOutPosition.position, botBarFadeInPosition.position, fadeInAlpha);
	}
}
