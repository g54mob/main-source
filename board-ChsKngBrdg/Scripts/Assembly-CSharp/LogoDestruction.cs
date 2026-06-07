using System.Collections;
using UnityEngine;

public class LogoDestruction : MonoBehaviour
{
	private SoundManager soundManager;

	public ObjectShake shakeScript;

	public AnimationCurve logoFallCurveY;

	public Transform logoParent;

	public int destructionThreshold;

	private int destructionClickCount;

	private float shakeTime = 0.1f;

	private float shakeAmount = 0.05f;

	private bool isDestructing;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void OnMouseDown()
	{
		if (!isDestructing)
		{
			StartCoroutine(DestructClick());
		}
	}

	public IEnumerator DestructClick()
	{
		isDestructing = true;
		shakeScript.StartCoroutine(shakeScript.Shake(shakeTime, shakeAmount));
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_capture);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z + Random.Range(-3f, 3f));
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - 0.05f, base.transform.position.z);
		destructionClickCount++;
		shakeTime += 0.025f;
		shakeAmount += 0.035f;
		if (destructionClickCount >= destructionThreshold)
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_slip);
			Keyframe[] keys = logoFallCurveY.keys;
			keys[0].value = logoParent.position.y;
			keys[^1].value = logoParent.position.y - 15f;
			logoFallCurveY.keys = keys;
			float moveSeconds = 0f;
			while (moveSeconds < logoFallCurveY[logoFallCurveY.length - 1].time)
			{
				logoParent.position = new Vector3(logoParent.position.x, logoFallCurveY.Evaluate(moveSeconds), logoParent.position.z);
				moveSeconds += Time.deltaTime;
				yield return null;
			}
			SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_manhole_blast);
			SoundManager.LoadSoundEffect(logoParent, soundManager.titel_impact);
			yield return new WaitForSeconds(1f);
			SteamAchievements.UnlockAchievement("DROP_MENULOGO");
		}
		yield return new WaitForSeconds(0.25f);
		isDestructing = false;
	}
}
