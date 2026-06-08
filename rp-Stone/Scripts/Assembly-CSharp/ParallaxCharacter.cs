using UnityEngine;

[RequireComponent(typeof(Character))]
public class ParallaxCharacter : MonoBehaviour
{
	public float parallaxScaleX = 1f;

	public float parallaxScaleY;

	private Character myCharacter;

	private AsciiSprite lastSprite;

	private int lastX;

	private int lastY;

	private int lastCamX;

	private int lastCamY;

	private int lastOffsetX;

	private int lastOffsetY;

	private void Update()
	{
		if (GameStates.Singleton == null || GameStates.Singleton.level == null)
		{
			return;
		}
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		if (gameCamera != null && (lastX != myCharacter.PositionX || lastCamX != gameCamera.PositionX || lastSprite != myCharacter.MySprite))
		{
			lastX = myCharacter.PositionX;
			lastCamX = gameCamera.PositionX;
			if (lastSprite != null)
			{
				lastSprite.pivotX -= lastOffsetX;
			}
			lastSprite = myCharacter.MySprite;
			if (lastSprite != null)
			{
				int num = Mathf.FloorToInt((float)(gameCamera.PositionX + 23 - myCharacter.PositionX) * parallaxScaleX);
				lastSprite.pivotX += num;
				lastOffsetX = num;
			}
		}
	}

	private void Awake()
	{
		myCharacter = GetComponent<Character>();
	}
}
