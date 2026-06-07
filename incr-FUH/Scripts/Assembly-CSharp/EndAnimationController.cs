using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndAnimationController : MonoBehaviour
{
	public GameObject MainCamera;

	public GameObject MainCamera2;

	public GameObject MainCamera3;

	public GameObject MainCamera4;

	public Canvas MainCanvas;

	public List<EndPop> EndPop;

	public EndingStatue EndStatue;

	public EndingRay TempleLazer;

	public EndingRay Lazer2;

	public EndingRay Lazer3;

	public List<ParticleSystem> MoneyPS;

	public PlayableDirector MainTimeline;

	private void Start()
	{
		foreach (EndPop item in EndPop)
		{
			item.Disapear();
		}
		Lazer2.StartRay();
		Lazer3.StartRay();
		GoToPart1();
	}

	public void ChangeScene()
	{
		if (EndOfGameController.IsBadEnding || !CharDisplay.HasHat)
		{
			SceneManager.LoadScene("EndOfGameScene");
		}
	}

	public void ReallyChangeScene()
	{
		SceneManager.LoadScene("EndOfGameScene");
	}

	public void PlayMoneyParticle()
	{
		foreach (ParticleSystem moneyP in MoneyPS)
		{
			moneyP.Play();
		}
	}

	public void PlayTempleLazer()
	{
		TempleLazer.StartRay();
		MainCamera2.transform.DOShakePosition(2f);
	}

	public void GoToPart1()
	{
	}

	public void GoToPart2()
	{
	}

	public void GoToPart3()
	{
		MainCanvas.worldCamera = MainCamera3.GetComponent<Camera>();
		MainCamera3.transform.DOShakePosition(10f);
	}

	public void GoToPart4()
	{
		MainCanvas.worldCamera = MainCamera4.GetComponent<Camera>();
	}
}
