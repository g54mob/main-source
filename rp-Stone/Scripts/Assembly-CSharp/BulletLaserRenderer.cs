using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class BulletLaserRenderer : AsciiLineSprite
{
	public float solidDuration = 0.07f;

	public float dissolveDuration = 0.23f;

	private Bullet myBullet;

	private int elapsedTics;

	private float elapsedTime;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		if (dissolveDuration <= 0f)
		{
			dissolve = 0f;
		}
		else
		{
			dissolve = (elapsedTime - solidDuration) / dissolveDuration;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		Character target = myBullet.target;
		if (target != null)
		{
			int num = target.PositionX + target.HeadPivotX;
			int num2 = target.PositionZ - target.PositionY + target.HeadPivotY * 2 / 3;
			num -= myBullet.PositionX;
			num2 -= myBullet.PositionZ - myBullet.PositionY;
			end.x = num;
			end.y = (float)num2 + 0.5f;
			start.y = 0.5f;
			base.Draw(r, offsetX, offsetY, colorMultiply, tint);
			if (myBullet.impactDeathSprite != null)
			{
				myBullet.impactDeathSprite.Draw(r, num + offsetX, num2 + offsetY);
			}
		}
	}

	private void Awake()
	{
		myBullet = GetComponent<Bullet>();
	}
}
