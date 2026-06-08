using UnityEngine;

public class TestDrawSprite : MonoBehaviour
{
	public enum OffsetMode
	{
		TopLeft = 0,
		Center = 1
	}

	public OffsetMode offsetMode;

	public int offsetX;

	public int offsetY;

	public AsciiSprite[] spritesToDraw;

	public bool reloadSprites;

	private const float timePerTic = 0.03333333f;

	private float accumulatedTicTime;

	private void LateUpdate()
	{
		AsciiRenderProcedural asciiRenderProcedural = Object.FindObjectOfType<AsciiRenderProcedural>();
		asciiRenderProcedural.Clear();
		int num = 0;
		int num2 = 0;
		if (offsetMode == OffsetMode.Center)
		{
			num = asciiRenderProcedural.width >> 1;
			num2 = asciiRenderProcedural.height >> 1;
		}
		num += offsetX;
		num2 += offsetY;
		if (asciiRenderProcedural != null)
		{
			for (int i = 0; i < spritesToDraw.Length; i++)
			{
				AsciiSprite asciiSprite = spritesToDraw[i];
				if (!(asciiSprite == null))
				{
					if (reloadSprites)
					{
						asciiSprite.Reload();
					}
					reloadSprites = false;
					if (!asciiSprite.gameObject.activeSelf)
					{
						asciiSprite.gameObject.SetActive(value: true);
					}
					asciiSprite.Draw(asciiRenderProcedural, num, num2);
				}
			}
		}
		AsciiParticleLayer asciiParticleLayer = Object.FindObjectOfType<AsciiParticleLayer>();
		if (asciiParticleLayer != null)
		{
			accumulatedTicTime += Utils.deltaTime;
			while (accumulatedTicTime >= 0.03333333f)
			{
				accumulatedTicTime -= 0.03333333f;
				asciiParticleLayer.UpdateTic();
			}
			asciiParticleLayer.Draw(asciiRenderProcedural, 0, 0);
		}
		asciiRenderProcedural.Push();
	}
}
