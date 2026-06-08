using System.Collections.Generic;
using UnityEngine;

public class Faerie : MonoBehaviour, IAsciiObject
{
	public enum State
	{
		Inactive = 0,
		ApproachPlayer = 1,
		Stationary = 2,
		Moving = 3
	}

	public float lerpSpeed = 0.4f;

	public int scale = 2;

	public int stationaryTics = 18;

	public int movementTics = 8;

	private int baseOffsetX = -4;

	private int baseOffsetY = 3;

	private int[] topLeft = new int[2] { -2, 1 };

	private int[] topRight = new int[2] { 0, 1 };

	private int[] botLeft = new int[2] { -2, 0 };

	private int[] botRight = new int[2];

	private AsciiSprite mySprite;

	private State currentState;

	private int stateElapsedTics;

	private int sequenceIndex;

	private List<List<int[]>> sequences = new List<List<int[]>>();

	private List<int[]> currentSequence;

	private int[] currentPos;

	private int targetPosX;

	private int targetPosY;

	private int targetPosZ;

	private float _x;

	private float _y;

	private float _z;

	public Weapon weapon { get; set; }

	public void StartQuest()
	{
	}

	private void SetState(State newState)
	{
		if (newState == State.ApproachPlayer)
		{
			currentPos = botRight;
			ComputeTargetPos();
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void ResetPos()
	{
		targetPosX = -50;
		targetPosY = baseOffsetY;
		targetPosZ = 15;
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (questData != null)
		{
			targetPosZ = questData.walkLimitTop;
		}
		_x = targetPosX;
		_y = targetPosY;
		_z = targetPosZ;
	}

	private void ComputeTargetPos()
	{
		targetPosX = GameStates.Singleton.hero.PositionX + currentPos[0] * scale + baseOffsetX;
		targetPosY = GameStates.Singleton.hero.PositionY + currentPos[1] * scale + baseOffsetY;
		targetPosZ = GameStates.Singleton.hero.PositionZ;
	}

	private void UpdatePosition()
	{
		_x = Lerp(_x, targetPosX);
		_y = Lerp(_y, targetPosY);
		_z = Lerp(_z, targetPosZ);
	}

	private float Lerp(float current, int target)
	{
		float num = ((currentState == State.ApproachPlayer) ? 0.2f : lerpSpeed);
		float num2 = (float)target - current;
		if (Mathf.Abs(num2) <= 1f)
		{
			return target;
		}
		num2 *= num;
		return current + num2;
	}

	public void UpdateTic()
	{
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
	}

	private void NextStep()
	{
		sequenceIndex++;
		if (currentSequence == null || sequenceIndex >= currentSequence.Count)
		{
			NextSequence();
		}
		currentPos = currentSequence[sequenceIndex];
		ComputeTargetPos();
	}

	private void NextSequence()
	{
		int index = Random.Range(0, sequences.Count);
		currentSequence = sequences[index];
		sequenceIndex = 0;
	}

	private void Start()
	{
	}

	private void AddSequence(int[] first, int[] second, int[] third, int[] fourth)
	{
		List<int[]> list = new List<int[]>();
		sequences.Add(list);
		list.Add(first);
		list.Add(second);
		list.Add(third);
		list.Add(fourth);
	}
}
