using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stinger : MonoBehaviour
{
	[Min(0f)]
	public float stingerDuration = 3.3f;

	public Animator anim;

	public float extraConsoleTime = 2f;

	private void Start()
	{
		anim.Play("ConsoleStinger", 0, 0f);
		StartCoroutine(StingerCo());
	}

	private IEnumerator StingerCo()
	{
		FadeManager.SetUnfaded();
		float num = stingerDuration;
		num += extraConsoleTime;
		yield return new WaitForSeconds(num);
		yield return FadeManager.FadeInCo();
		SceneManager.LoadSceneAsync("scene-title");
	}
}
