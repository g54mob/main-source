using UnityEngine;

public class ArchingBullet : Bullet
{
	public int travelTics = 20;

	public float arcHeight = 6f;

	public float homingSpeed = 0.35f;

	private int elapsedTics;

	private bool missedTarget;

	private bool firstTime = true;

	private float targetX;

	public override void UpdateTic()
	{
		if (!Alive)
		{
			base.UpdateTic();
			return;
		}
		elapsedTics++;
		if (base.target == null)
		{
			missedTarget = true;
		}
		if (missedTarget)
		{
			base.PositionY -= 2;
			if (base.PositionY <= 0)
			{
				base.PositionY = 0;
				Die(DeathReason.LifetimeEnded);
			}
			return;
		}
		base.PositionZ = base.target.PositionZ;
		float num = base.target.PositionX;
		if (firstTime)
		{
			firstTime = false;
			targetX = num;
		}
		else if (targetX < num)
		{
			targetX += homingSpeed;
			if (targetX > num)
			{
				targetX = num;
			}
		}
		else if (targetX > num)
		{
			targetX -= homingSpeed;
			if (targetX < num)
			{
				targetX = num;
			}
		}
		if (elapsedTics > travelTics)
		{
			base.PositionX = Mathf.RoundToInt(targetX);
			base.PositionY = base.target.PositionY - base.target.HeadPivotY;
			if (tags.Contains("enemy"))
			{
				TestCollisionWithHero();
			}
			else
			{
				TestCollisionWithEnemies();
			}
			if (Alive)
			{
				missedTarget = true;
			}
		}
		else
		{
			float num2 = (float)elapsedTics / (float)travelTics;
			base.PositionX = Mathf.RoundToInt(Mathf.Lerp(startX, targetX, num2));
			int num3 = base.target.PositionY - base.target.HeadPivotY;
			float num4 = Mathf.Lerp(startY, num3, num2);
			float num5 = (num2 - num2 * num2) * arcHeight * 4f;
			int b = Mathf.RoundToInt(num4 + num5);
			base.PositionY = Mathf.Max(num3, b);
		}
	}
}
