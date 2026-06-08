using UnityEngine;

public class ConeMovement : MonoBehaviour
{
	public bool useStartPosition = true;

	public IntPosition startPosition;

	public IntPosition startOffset;

	public IntPosition endOffset;

	public IntPosition randomStartRegion;

	public IntPosition randomEndRegion;

	public int ticDuration = 10;

	private float fPosX;

	private float fPosY;

	private float fPosZ;

	private float fMovX;

	private float fMovY;

	private float fMovZ;

	private int elapsedTics;

	private void HandleOnUpdateTic(Character character)
	{
		elapsedTics++;
		if (elapsedTics <= ticDuration)
		{
			fPosX += fMovX;
			fPosY += fMovY;
			fPosZ += fMovZ;
			character.PositionX = (int)fPosX;
			character.PositionY = (int)fPosY;
			character.PositionZ = (int)fPosZ;
		}
	}

	private void HandleOnAddedToLevel(Character character)
	{
		if (useStartPosition)
		{
			character.PositionX = startPosition.x;
			character.PositionY = startPosition.y;
			character.PositionZ = startPosition.z;
		}
		character.PositionX += startOffset.x;
		character.PositionY += startOffset.y;
		character.PositionZ += startOffset.z;
		character.PositionX += Random.Range(-(randomStartRegion.x >> 1), randomStartRegion.x >> 1);
		character.PositionY += Random.Range(-(randomStartRegion.y >> 1), randomStartRegion.y >> 1);
		character.PositionZ += Random.Range(-(randomStartRegion.z >> 1), randomStartRegion.z >> 1);
		fPosX = character.PositionX;
		fPosY = character.PositionY;
		fPosZ = character.PositionZ;
		int num = Random.Range(-(randomEndRegion.x >> 1), randomEndRegion.x >> 1);
		int num2 = Random.Range(-(randomEndRegion.y >> 1), randomEndRegion.y >> 1);
		int num3 = Random.Range(-(randomEndRegion.z >> 1), randomEndRegion.z >> 1);
		fMovX = (float)(endOffset.x + num) / (float)ticDuration;
		fMovY = (float)(endOffset.y + num2) / (float)ticDuration;
		fMovZ = (float)(endOffset.z + num3) / (float)ticDuration;
	}

	private void Awake()
	{
		if (ticDuration <= 0)
		{
			Utils.LogError("Tic Duration must be positive.", base.gameObject);
			return;
		}
		Character component = GetComponent<Character>();
		if (component != null)
		{
			component.OnAddedToLevel += HandleOnAddedToLevel;
			component.OnUpdateTic += HandleOnUpdateTic;
		}
	}

	private void OnDestroy()
	{
		Character component = GetComponent<Character>();
		if (component != null)
		{
			component.OnAddedToLevel -= HandleOnAddedToLevel;
			component.OnUpdateTic -= HandleOnUpdateTic;
		}
	}
}
