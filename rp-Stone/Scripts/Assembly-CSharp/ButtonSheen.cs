using UnityEngine;

public class ButtonSheen : MonoBehaviour
{
	private float sheenDuration = 1.5f;

	private float sheenElapsedTime = 99f;

	private AsciiObject myButton;

	private bool isPlaying;

	public void Play()
	{
		sheenElapsedTime = 0f;
		isPlaying = true;
	}

	private void Update()
	{
		if (base.enabled)
		{
			sheenElapsedTime += Time.deltaTime;
			if (sheenElapsedTime > sheenDuration)
			{
				isPlaying = false;
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!isPlaying || !base.enabled)
		{
			return;
		}
		float num = 3f;
		float p = 15f;
		float num2 = 1.2f;
		float t = 0.8f;
		float num3 = sheenElapsedTime * num;
		for (int i = 0; i < myButton.Width; i++)
		{
			for (int j = 1; j < myButton.Height - 1; j++)
			{
				int x = offsetX + i;
				int y = offsetY + j;
				AsciiCellProcedural cell = r.GetCell(x, y);
				if (cell != null)
				{
					Color background = cell.GetBackground();
					float num4 = Mathf.Pow(Mathf.Sin(num3 + (float)i / (float)myButton.Width - (float)j / (float)myButton.Height), p);
					if (float.IsNaN(num4))
					{
						num4 = 0f;
					}
					num4 *= num2;
					Color b = Color.Lerp(background * (num4 + 1f), ColorConstants.white, t);
					background = Color.Lerp(background, b, num4);
					cell.SetBackground(background);
				}
			}
		}
	}

	private void Awake()
	{
		myButton = GetComponent<AsciiObject>();
	}
}
