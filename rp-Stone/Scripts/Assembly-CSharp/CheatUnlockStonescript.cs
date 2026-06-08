using System;
using UnityEngine;

public class CheatUnlockStonescript : MonoBehaviour
{
	private char[] keySequence = new char[6] { 'i', 'm', 'p', 'o', 'r', 't' };

	private char[] KEYSEQUENCE = new char[6] { 'I', 'M', 'P', 'O', 'R', 'T' };

	private int sequenceIndex;

	private int lastTouches;

	public event Action OnCheat;

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			for (int i = 0; i < Input.inputString.Length; i++)
			{
				char c = Input.inputString[i];
				if (c == keySequence[sequenceIndex] || c == KEYSEQUENCE[sequenceIndex])
				{
					if (sequenceIndex == keySequence.Length - 1)
					{
						sequenceIndex = 0;
						FireCheatCompleted();
					}
					else
					{
						sequenceIndex++;
					}
				}
				else if (c >= 'a' && c <= 'z')
				{
					sequenceIndex = 0;
				}
			}
		}
		else if (lastTouches == 4 && Input.touches.Length == 5)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < Input.touches.Length; j++)
			{
				Vector2 position = Input.touches[j].position;
				float num4 = 3f * position.x / (float)Screen.width;
				float num5 = 3f * position.y / (float)Screen.height;
				if (num5 < 1f)
				{
					if (num4 < 1f)
					{
						num2++;
					}
					else if (num4 > 2f)
					{
						num++;
					}
				}
				else if (num5 > 2f && num4 > 1f && num4 < 2f)
				{
					num3++;
				}
			}
			if (num == 3 && num2 == 1 && num3 == 1)
			{
				FireCheatCompleted();
			}
		}
		lastTouches = Input.touches.Length;
	}

	private void FireCheatCompleted()
	{
		if (this.OnCheat != null)
		{
			this.OnCheat();
		}
	}
}
