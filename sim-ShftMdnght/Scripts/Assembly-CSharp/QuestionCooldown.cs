using UnityEngine;
using UnityEngine.UI;

public class QuestionCooldown : MonoBehaviour
{
	public GameObject questionCooldownHolder;

	public Image questionCooldownBar;

	public StoreManager storeMan;

	private bool justTurnedOff = true;

	private void Start()
	{
		storeMan = StoreManager.Instance;
	}

	private void FixedUpdate()
	{
		if (storeMan.questionCooldown > 0f)
		{
			justTurnedOff = true;
			questionCooldownBar.fillAmount = storeMan.questionCooldown / storeMan.maxQuestionCooldown;
		}
		else if (justTurnedOff)
		{
			justTurnedOff = false;
			questionCooldownHolder.SetActive(value: false);
		}
	}
}
