using System.Collections.Generic;
using UnityEngine;

public class ShinyIcon : AsciiSprite
{
	public List<AsciiAnimation> shinyPool;

	private List<AsciiAnimation> shinyPlaying = new List<AsciiAnimation>();

	public float minCooldown = 0.4f;

	public float maxCooldown = 1f;

	private float playNextCooldown;

	private int lastX = -99;

	private int lastY;

	private void Update()
	{
		playNextCooldown -= Time.deltaTime;
		if (shinyPool.Count > 0 && playNextCooldown <= 0f)
		{
			playNextCooldown = Random.Range(minCooldown, maxCooldown);
			PlayNext();
		}
		for (int num = shinyPlaying.Count - 1; num >= 0; num--)
		{
			AsciiAnimation asciiAnimation = shinyPlaying[num];
			if (!asciiAnimation.Playing)
			{
				shinyPlaying.Remove(asciiAnimation);
				shinyPool.Add(asciiAnimation);
			}
		}
	}

	private void PlayNext()
	{
		AsciiAnimation asciiAnimation = shinyPool[0];
		shinyPool.RemoveAt(0);
		shinyPlaying.Add(asciiAnimation);
		int num;
		int num2;
		do
		{
			num = Random.Range(-1, 2);
			num2 = ((num != 0) ? Random.Range(-1, 2) : Random.Range(-2, 3));
		}
		while (num2 == lastX && num == lastY);
		lastX = num2;
		lastY = num;
		asciiAnimation.Sprite.pivotX = num2;
		asciiAnimation.Sprite.pivotY = num;
		asciiAnimation.Play();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX -= pivotX;
		offsetY -= pivotY;
		for (int i = 0; i < shinyPlaying.Count; i++)
		{
			shinyPlaying[i].Sprite.Draw(r, offsetX, offsetY);
		}
	}

	public override void DrawColorAdd(AsciiRenderProcedural r, int offsetX, int offsetY, Color colorAdd)
	{
		base.DrawColorAdd(r, offsetX, offsetY, colorAdd);
		offsetX -= pivotX;
		offsetY -= pivotY;
		for (int i = 0; i < shinyPlaying.Count; i++)
		{
			shinyPlaying[i].Sprite.DrawColorAdd(r, offsetX, offsetY, colorAdd);
		}
	}
}
