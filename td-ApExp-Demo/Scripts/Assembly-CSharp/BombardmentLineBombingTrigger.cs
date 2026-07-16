using UnityEngine;

public class BombardmentLineBombingTrigger : BombardmentEventTrigger
{
	[SerializeField]
	private BombardmentLeverResetTrigger trigger;

	[SerializeField]
	private GameObject fakePlaneGo;

	protected override void OnTrigger()
	{
		base.OnTrigger();
		Object.Instantiate(fakePlaneGo);
		switch (trigger.currentSafeLine)
		{
		case 1:
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(2));
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(3));
			break;
		case 2:
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(1));
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(3));
			break;
		case 3:
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(1));
			StartCoroutine(GameManager.Instance.ringMinigame.gameObject.GetComponent<Bombardment>().LineBombing(2));
			break;
		}
		Debug.Log("ringggg LINE");
	}
}
