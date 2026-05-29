using System.Collections;
using TMPro;
using UnityEngine;

public class ReaperAI : MonoBehaviour
{
	public enum StartingPosition
	{
		Left = 0,
		Right = 1,
		Top = 2,
		Bottom = 3
	}

	[SerializeField]
	private StartingPosition startingState;

	[SerializeField]
	private Transform reaperShopTransform;

	[SerializeField]
	private float speed;

	private Vector2 startingPosition;

	private float distance = 30f;

	[SerializeField]
	private TMP_Text clockCountdown;

	private float waitTime = 750f;

	private bool triggerArrival;

	public bool canOpenShop;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Animator leftLegAnimator;

	[SerializeField]
	private Animator rightLegAnimator;

	private const string WALKRIGHT = "WalkRight";

	private const string WALKLEFT = "WalkLeft";

	private const string WALKUP = "WalkUp";

	private const string WALKDOWN = "WalkDown";

	private const string SIT = "Sit";

	private const string IDLE = "Idle";

	private const string STAND = "Stand";

	private void Start()
	{
		PickNewStartingPosition();
		reaperShopTransform.gameObject.SetActive(value: false);
		if (GameManager.ins.reaperTimer <= distance)
		{
			GameManager.ins.reaperTimer = 0f;
			clockCountdown.text = TimeFormatter(GameManager.ins.reaperTimer);
			reaperShopTransform.position = base.transform.position;
			reaperShopTransform.gameObject.SetActive(value: true);
			triggerArrival = true;
			canOpenShop = true;
		}
	}

	private void Update()
	{
		Countdown();
		CheckTheTimerForArrival();
	}

	private void PickNewStartingPosition()
	{
		if (!SaveData.ins.verticalMode)
		{
			if (Random.value < 0.5f)
			{
				startingPosition = new Vector2(-82f, base.transform.position.y);
				startingState = StartingPosition.Left;
			}
			else
			{
				startingPosition = new Vector2(82f, base.transform.position.y);
				startingState = StartingPosition.Right;
			}
		}
		else if (Random.value < 0.5f)
		{
			startingPosition = new Vector2(base.transform.position.x, -46f);
			startingState = StartingPosition.Bottom;
		}
		else
		{
			startingPosition = new Vector2(base.transform.position.x, 46f);
			startingState = StartingPosition.Top;
		}
		distance = Vector2.Distance(base.transform.position, startingPosition) / speed;
	}

	private void Countdown()
	{
		if (GameManager.ins.reaperTimer > 0f)
		{
			float num = Time.deltaTime;
			if (SaveData.ins.focusMode)
			{
				num *= 0.5f;
			}
			GameManager.ins.reaperTimer -= num;
			if (SaveData.ins.focusMode)
			{
				clockCountdown.text = TimeFormatter(GameManager.ins.reaperTimer * 2f);
			}
			else
			{
				clockCountdown.text = TimeFormatter(GameManager.ins.reaperTimer);
			}
		}
		else
		{
			GameManager.ins.reaperTimer = 0f;
			clockCountdown.text = TimeFormatter(0f);
		}
	}

	private void CheckTheTimerForArrival()
	{
		float num = GameManager.ins.reaperTimer;
		if (SaveData.ins.focusMode)
		{
			num *= 2f;
		}
		if (!triggerArrival && num <= distance + 1f)
		{
			triggerArrival = true;
			StartCoroutine(ReaperArrival());
		}
	}

	private IEnumerator ReaperArrival()
	{
		reaperShopTransform.position = startingPosition;
		reaperShopTransform.gameObject.SetActive(value: true);
		PlayWalkAnimation(coming: true);
		yield return new WaitForPositionReached(reaperShopTransform, base.transform.position, speed);
		PlayAnimation("Sit");
		yield return new WaitForSeconds(1f);
		canOpenShop = true;
	}

	public void StartDeparture()
	{
		StartCoroutine(ReaperDeparture());
	}

	private IEnumerator ReaperDeparture()
	{
		PickNewStartingPosition();
		GameManager.ins.reaperTimer = waitTime;
		triggerArrival = false;
		canOpenShop = false;
		PlayAnimation("Stand");
		yield return new WaitForSeconds(1f);
		PlayWalkAnimation(coming: false);
		Vector3 vector = (startingPosition - (Vector2)reaperShopTransform.position).normalized;
		Debug.Log("Slower speed: " + speed * 0.7f);
		yield return new WaitForPositionReached(reaperShopTransform, reaperShopTransform.position + vector, speed * 0.75f);
		Debug.Log("Faster speed: " + speed);
		yield return new WaitForPositionReached(reaperShopTransform, startingPosition, speed);
		reaperShopTransform.gameObject.SetActive(value: false);
	}

	public void OpenReaperUI()
	{
		GameManager.ins.reaperShopPanel.SetReaperAI(this);
		if (SaveData.ins.verticalMode)
		{
			GameManager.ins.reaperShopPanel.transform.position = new Vector3(0f, reaperShopTransform.position.y, 90f);
		}
		else
		{
			GameManager.ins.reaperShopPanel.transform.position = new Vector3(reaperShopTransform.position.x, 0f, 90f);
		}
		if (!GameManager.ins.reaperShopPanel.gameObject.activeInHierarchy)
		{
			GameManager.ins.reaperShopPanel.gameObject.SetActive(value: true);
		}
	}

	private string TimeFormatter(float seconds)
	{
		int num = Mathf.FloorToInt(seconds);
		int num2 = num / 60;
		int num3 = num % 60;
		return $"{num2:0}m:{num3:00}s";
	}

	private void PlayWalkAnimation(bool coming)
	{
		if (coming)
		{
			switch (startingState)
			{
			case StartingPosition.Left:
				PlayAnimation("WalkRight");
				break;
			case StartingPosition.Right:
				PlayAnimation("WalkLeft");
				break;
			case StartingPosition.Top:
				PlayAnimation("WalkDown");
				break;
			case StartingPosition.Bottom:
				PlayAnimation("WalkUp");
				break;
			}
		}
		else
		{
			switch (startingState)
			{
			case StartingPosition.Left:
				PlayAnimation("WalkLeft");
				break;
			case StartingPosition.Right:
				PlayAnimation("WalkRight");
				break;
			case StartingPosition.Top:
				PlayAnimation("WalkUp");
				break;
			case StartingPosition.Bottom:
				PlayAnimation("WalkDown");
				break;
			}
		}
	}

	private void PlayAnimation(string state)
	{
		animator.Play(state);
		if ((bool)leftLegAnimator)
		{
			leftLegAnimator.Play(state);
		}
		if ((bool)rightLegAnimator)
		{
			rightLegAnimator.Play(state);
		}
	}
}
