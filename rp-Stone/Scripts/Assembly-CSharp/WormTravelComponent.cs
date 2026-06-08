using UnityEngine;

public class WormTravelComponent : MonoBehaviour
{
	public int awakeDistance = 70;

	private Decoration myDecoration;

	private Enemy myEnemy;

	private Character myCharacter;

	private int lastFrame;

	private bool awake;

	private void Update()
	{
		if (myEnemy != null)
		{
			if (myEnemy.CurrentState != Enemy.State.Engaging)
			{
				return;
			}
		}
		else if (!awake)
		{
			int positionX = GameStates.Singleton.hero.PositionX;
			if (myCharacter.PositionX - positionX <= awakeDistance)
			{
				awake = true;
			}
			return;
		}
		int frameIndex = myCharacter.MySprite.GetFrameIndex();
		if (lastFrame != frameIndex)
		{
			lastFrame = frameIndex;
			if ((frameIndex <= 1 || frameIndex >= 10) && frameIndex % 2 == 0)
			{
				myCharacter.PositionX--;
			}
		}
	}

	private void Awake()
	{
		myDecoration = GetComponent<Decoration>();
		myEnemy = GetComponent<Enemy>();
		if (myDecoration != null)
		{
			myCharacter = myDecoration;
		}
		else
		{
			myCharacter = myEnemy;
		}
	}
}
