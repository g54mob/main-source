using UnityEngine;

public class CloudSprite : TilingAsciiSprite
{
	public float speedX = 1f;

	public bool moveWithFrameIndex;

	private float fScrollX;

	private int lastFrameIndex;

	private void Start()
	{
		scrollX = Random.Range(0, width);
		fScrollX = scrollX;
	}

	private void Update()
	{
		if (AsciiAnimation.allAnimationsEnabled && !moveWithFrameIndex)
		{
			fScrollX += Utils.deltaTime * speedX;
			scrollX = Mathf.RoundToInt(fScrollX);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = GetFrameIndex();
		if (moveWithFrameIndex && lastFrameIndex != num)
		{
			int num2 = num - lastFrameIndex;
			if (num == 0 && num2 < 0)
			{
				num2 += base.FrameCount;
			}
			lastFrameIndex = num;
			if (speedX > 0f)
			{
				scrollX += num2;
			}
			else
			{
				scrollX -= num2;
			}
			fScrollX = scrollX;
		}
		base.Draw(r, offsetX, offsetY);
	}
}
