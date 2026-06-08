using System.Collections;
using UnityEngine;

public class LogoLogic : AsciiSprite
{
	public enum State
	{
		SmallPause = 0,
		Drawing = 1,
		DrawnPause = 2,
		WaitingForPress = 3,
		PreBurning = 4,
		Burning = 5,
		BurntPause = 6,
		Done = 7
	}

	public AsciiAnimation drawAnimation;

	public AsciiAnimation burnAnimation;

	public AsciiString subtitle;

	private float smallPauseDuration = 1f;

	private float drawnPauseDuration = 1.1f;

	private float subtitleDelay = 0.55f;

	private float preBurningDuration = 0.65f;

	private float burntPauseDuration = 2f;

	private float stateElapsedTime;

	private float burnElapsedTime;

	private AsciiAnimation currentAnimation;

	private bool waitingToPlaySfx;

	private Sfx logoSfx;

	private float logoSfxVolume;

	public float diagonalSlope = 1f;

	public float timePower = 1f;

	public float timeMultiplier = 1f;

	public float diagonalMultiplier = 4f;

	public float percentMultiplier = 1f;

	public float gradientThreshold = 0.4f;

	public float backToWhiteThreshold = 0.9f;

	public State currentState { get; private set; }

	private void Start()
	{
		drawAnimation.Sprite.Load();
		Reset();
		subtitle.SetValue("RPG");
	}

	public void Reset()
	{
		SetState(State.SmallPause);
	}

	public void Skip()
	{
		if (currentState != State.WaitingForPress && currentState != State.PreBurning)
		{
			SetState(State.Done);
		}
	}

	public bool IsDone()
	{
		return currentState == State.Done;
	}

	private void SetState(State newState)
	{
		if (newState == State.Done && GetComponent<AsciiAnimation>().looping)
		{
			newState = State.Drawing;
		}
		if (newState == State.SmallPause)
		{
			PlayLogoSfx();
		}
		if (newState == State.Done)
		{
			StopLogoSfx();
		}
		if (newState == State.PreBurning)
		{
			burnElapsedTime = 0f;
		}
		AsciiAnimation asciiAnimation;
		switch (newState)
		{
		case State.SmallPause:
		case State.Done:
			asciiAnimation = null;
			break;
		case State.Drawing:
		case State.DrawnPause:
			asciiAnimation = drawAnimation;
			break;
		case State.WaitingForPress:
			asciiAnimation = drawAnimation;
			break;
		case State.PreBurning:
			asciiAnimation = drawAnimation;
			if (logoSfx != null)
			{
				logoSfx.UnPause();
			}
			break;
		default:
			asciiAnimation = burnAnimation;
			break;
		}
		if (currentAnimation != asciiAnimation)
		{
			if (currentAnimation != null)
			{
				currentAnimation.gameObject.SetActive(value: false);
			}
			if (asciiAnimation != null)
			{
				asciiAnimation.gameObject.SetActive(value: true);
				asciiAnimation.Stop();
				asciiAnimation.Sprite.SetFrameIndex(0);
				asciiAnimation.Play();
			}
			currentAnimation = asciiAnimation;
		}
		currentState = newState;
		stateElapsedTime = 0f;
	}

	private void Update()
	{
		stateElapsedTime += Utils.deltaTime;
		burnElapsedTime += Utils.deltaTime;
		if (currentState == State.SmallPause && stateElapsedTime >= smallPauseDuration)
		{
			SetState(State.Drawing);
		}
		else if (currentState == State.Drawing && !drawAnimation.Playing)
		{
			SetState(State.DrawnPause);
		}
		else if (currentState == State.DrawnPause && stateElapsedTime >= drawnPauseDuration)
		{
			SetState(State.PreBurning);
		}
		else if (currentState == State.WaitingForPress && stateElapsedTime > 30f)
		{
			SetState(State.SmallPause);
		}
		else if (currentState == State.PreBurning && stateElapsedTime >= preBurningDuration)
		{
			SetState(State.Burning);
		}
		else if (currentState == State.Burning && !burnAnimation.Playing)
		{
			SetState(State.BurntPause);
		}
		else if (currentState == State.BurntPause && stateElapsedTime >= burntPauseDuration)
		{
			SetState(State.Done);
		}
	}

	public override void UpdateTic()
	{
		if (currentState != State.WaitingForPress)
		{
			return;
		}
		if (AsciiMouse.singleton.down0 || Input.GetKeyDown(KeyCode.Return))
		{
			SetState(State.PreBurning);
		}
		else if (logoSfx != null && logoSfx.currentSfx.volume > 0f)
		{
			logoSfx.currentSfx.volume -= 0.05f;
			if (logoSfx.currentSfx.volume <= 0f)
			{
				logoSfx.Pause();
			}
		}
	}

	private void PlayLogoSfx()
	{
		waitingToPlaySfx = true;
		StartCoroutine(PlayWithDelay());
	}

	private IEnumerator PlayWithDelay()
	{
		yield return new WaitForSeconds(1.25f);
		if (waitingToPlaySfx)
		{
			waitingToPlaySfx = false;
			logoSfx = SfxController.singleton.Play("logo_full");
			if (logoSfx != null)
			{
				logoSfxVolume = logoSfx.currentSfx.volume;
			}
		}
	}

	private void StopLogoSfx()
	{
		waitingToPlaySfx = false;
		if (logoSfx != null)
		{
			logoSfx.Stop();
			logoSfx = null;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentAnimation != null)
		{
			offsetX = (r.width >> 1) - pivotX;
			offsetY = (r.height >> 1) - pivotY;
			currentAnimation.Sprite.Draw(r, offsetX, offsetY);
		}
		if (currentState == State.PreBurning || currentState == State.Burning)
		{
			int num = offsetX - 15;
			int num2 = offsetY - 8;
			for (int i = 0; i < 30; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					int x = i + num;
					int y = j + num2;
					float num3 = (float)(30 - i - 1) + (float)j * diagonalSlope;
					float num4 = (Mathf.Pow(burnElapsedTime, timePower) * timeMultiplier - num3 / 44f * diagonalMultiplier) * percentMultiplier;
					Color foreground = ColorConstants.white;
					if (num4 < gradientThreshold)
					{
						foreground = Color.Lerp(ColorConstants.white, ColorConstants.darkGrey, num4 / gradientThreshold);
					}
					else if (num4 < backToWhiteThreshold)
					{
						foreground = ColorConstants.darkGrey;
					}
					r.GetCell(x, y).SetForeground(foreground);
				}
			}
		}
		if ((currentState == State.DrawnPause && stateElapsedTime >= subtitleDelay) || currentState == State.WaitingForPress || currentState == State.PreBurning)
		{
			subtitle.Draw(r, offsetX, offsetY);
		}
	}
}
