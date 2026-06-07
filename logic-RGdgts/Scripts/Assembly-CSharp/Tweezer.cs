using UnityEngine;

public class Tweezer : MonoBehaviour
{
	public TweezerSprite tableSprite;

	public TweezerSprite[] mainTweezerSprites;

	public TweezerSprite[] externalTweezerSprites;

	private bool interpolate;

	private int spriteI;

	private PixelCameraManager pixelCamera;

	private bool showTableSprite;

	private Sticker overingSticker;

	private Vector3 positionVel;

	private void Awake()
	{
	}

	public Vector2 GetCenter()
	{
		return default(Vector2);
	}

	public Vector2 GetInvalidPositionMarkerPoint()
	{
		return default(Vector2);
	}

	public void UpdatePosition()
	{
	}

	private Vector3 GetFinalPosition()
	{
		return default(Vector3);
	}

	public void UpdateInteraction()
	{
	}

	public void Enable(Vector3 position, Vector3 initialVelocity)
	{
	}

	public void Disable()
	{
	}

	public void SetSpriteI(int spriteI)
	{
	}

	public void ShowTableSprite(bool showTableSprite)
	{
	}
}
