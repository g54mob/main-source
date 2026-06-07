using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiceButton : MenuButton
{
	public int diceIndex;

	public Image faceImage;

	public Image lockImage;

	private float changeProgress;

	private float rollProgress;

	private float rollSpeed;

	[NonSerialized]
	public bool isRolling;

	[NonSerialized]
	public bool isMinigameOver;

	[NonSerialized]
	public bool hasRolledAtLeastOnce;

	[NonSerialized]
	public bool isLocked;

	[NonSerialized]
	public bool isTempLocked;

	[NonSerialized]
	public int rollResult;

	[NonSerialized]
	public UnityAction<DiceButton> finalizeDelegate;

	[NonSerialized]
	public UnityAction lockStateChangeDelegate;

	private int debugPredictedResult;

	private Tweener shakeTween;

	private Tweener rotationTween;

	private float changeCountdownSpeed;

	protected override void Awake()
	{
		base.Awake();
		AddPointerClickTrigger(OnClickedSingleDie);
	}

	private void CalcChangeCountdownSpeed()
	{
		changeCountdownSpeed = Mathf.Lerp(6f, 1f, rollProgress);
	}

	protected override void Update()
	{
		base.Update();
		if (!isRolling)
		{
			return;
		}
		rollProgress += TimeManager.MinigameDelta * rollSpeed;
		if (rollProgress >= 1f)
		{
			FinalizeRoll();
			return;
		}
		changeProgress += TimeManager.MinigameDelta * changeCountdownSpeed;
		if (changeProgress >= 1f)
		{
			changeProgress -= 1f;
			float num = (1f - rollProgress) / rollSpeed;
			CalcChangeCountdownSpeed();
			float num2 = (1f - changeProgress) / changeCountdownSpeed;
			if (num < num2)
			{
				debugPredictedResult = rollResult;
				faceImage.sprite = IconManager.SpriteForDiceFace(rollResult);
			}
			else
			{
				RandomizeFace();
			}
		}
	}

	public void ResetState()
	{
		rollResult = 0;
		isLocked = false;
		isTempLocked = false;
		isMinigameOver = false;
		isRolling = false;
		faceImage.enabled = false;
		lockImage.enabled = false;
		hasRolledAtLeastOnce = false;
		UpdateIconState();
	}

	private void FinalizeRoll()
	{
		isRolling = false;
		finalizeDelegate(this);
		base.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.2f, 0, 0f);
		if (rollResult == 6)
		{
			MenuManager.Instance.PlayStarParticles(base.transform.position);
		}
		if (debugPredictedResult != rollResult)
		{
			Debug.LogError("Index " + diceIndex + " PREDICTION ERROR");
		}
		UpdateFaceState();
		UpdateIconState();
	}

	public void ToggleTempLock()
	{
		SetTempLock(!isTempLocked);
		lockStateChangeDelegate?.Invoke();
	}

	public void SetTempLock(bool next)
	{
		lockImage.enabled = true;
		isTempLocked = next;
		UpdateIconState();
	}

	public void Roll()
	{
		faceImage.enabled = true;
		float num = UnityEngine.Random.Range(1f, 2f);
		hasRolledAtLeastOnce = true;
		rollResult = GetRandomFace();
		rollSpeed = 1f / num;
		debugPredictedResult = 0;
		isRolling = true;
		rollProgress = 0f;
		CalcChangeCountdownSpeed();
		shakeTween?.Kill(complete: true);
		rotationTween?.Kill(complete: true);
		shakeTween = faceImage.transform.DOShakePosition(num, 20f);
		rotationTween = faceImage.transform.DOShakeRotation(num, new Vector3(0f, 0f, 90f));
		isRolling = true;
		changeProgress = 0f;
		RandomizeFace();
		UpdateIconState();
	}

	private void OnClickedSingleDie()
	{
		if (!isLocked)
		{
			ToggleTempLock();
		}
	}

	private int GetRandomFace()
	{
		return UnityEngine.Random.Range(1, 7);
	}

	private void RandomizeFace()
	{
		faceImage.sprite = IconManager.SpriteForDiceFace(GetRandomFace());
	}

	public void UpdateFaceState()
	{
		faceImage.sprite = IconManager.SpriteForDiceFace(rollResult);
	}

	public void UpdateIconState()
	{
		lockImage.sprite = IconManager.SpriteForDiceLockState(isTempLocked);
		lockImage.enabled = !isRolling && hasRolledAtLeastOnce && !isMinigameOver && !isLocked && !isTempLocked;
		if (null != stateImage)
		{
			base.interactable = !isRolling && hasRolledAtLeastOnce && !isLocked;
		}
		if (!hasRolledAtLeastOnce && !isRolling)
		{
			base.buttonState = CustomButtonState.Hidden;
		}
		else if (isMinigameOver)
		{
			base.buttonState = CustomButtonState.Hidden;
		}
		else if (isLocked)
		{
			base.buttonState = CustomButtonState.Hidden;
		}
		else if (isRolling)
		{
			base.buttonState = CustomButtonState.Background;
		}
		else
		{
			base.buttonState = CustomButtonState.Default;
		}
	}
}
