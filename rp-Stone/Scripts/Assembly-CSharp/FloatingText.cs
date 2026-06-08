using UnityEngine;

public class FloatingText : MonoBehaviour, IAsciiObject
{
	private enum State
	{
		InitialDelay = 0,
		Traveling = 1,
		FadingOut = 2,
		Done = 3
	}

	public float velocity = 4f;

	public float targetDistance = 4f;

	public float maxTravelTime = 2f;

	public float fadeOutDuration = 1f;

	public int initialDelay;

	[SerializeField]
	private AsciiString message = new AsciiString();

	[SerializeField]
	private int positionX;

	[SerializeField]
	private int positionY;

	private State currentState;

	private float stateElapsedTime;

	private float distanceTraveled;

	public AsciiString Message => message;

	public int PositionX
	{
		get
		{
			return positionX;
		}
		set
		{
			positionX = value;
		}
	}

	public int PositionY
	{
		get
		{
			return positionY;
		}
		set
		{
			positionY = value;
		}
	}

	private void SetState(State newState)
	{
		if (newState == State.Done)
		{
			Cleanup();
		}
		currentState = newState;
		stateElapsedTime = 0f;
	}

	private void Update()
	{
		stateElapsedTime += Utils.deltaTime;
		if (currentState == State.InitialDelay && stateElapsedTime >= (float)initialDelay / 30f)
		{
			SetState(State.Traveling);
		}
		if (currentState == State.Traveling)
		{
			distanceTraveled += velocity * Utils.deltaTime;
			if (distanceTraveled >= targetDistance)
			{
				distanceTraveled = targetDistance;
				SetState(State.FadingOut);
			}
			else if (stateElapsedTime >= maxTravelTime)
			{
				SetState(State.FadingOut);
			}
		}
		if (currentState == State.FadingOut && stateElapsedTime >= fadeOutDuration)
		{
			SetState(State.Done);
		}
	}

	public void UpdateTic()
	{
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		offsetY -= Mathf.FloorToInt(distanceTraveled);
		if (currentState == State.FadingOut)
		{
			float t = stateElapsedTime / fadeOutDuration;
			Color colorOverride = Color.Lerp(message.color, Color.black, t);
			message.Draw(r, offsetX, offsetY, colorOverride);
		}
		else if (currentState == State.Traveling)
		{
			message.Draw(r, offsetX, offsetY);
		}
	}

	public void SetMessage(string msg)
	{
		message.SetValue(msg);
	}

	private void Cleanup()
	{
		GameStates.Singleton.level.RemoveObject(this);
		if (this != null && base.gameObject != null)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
