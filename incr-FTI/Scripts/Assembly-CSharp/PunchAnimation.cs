using DG.Tweening;

public class PunchAnimation : CustomAnimation
{
	public PunchAnimation()
	{
		base.from = 1f;
		base.to = 1.25f;
		speed = 2f;
	}

	public override float EasedValue()
	{
		float num = 0.4f;
		float num2 = 0.6f;
		if (progress < num)
		{
			float lifetimePercentage = progress / num;
			return DOVirtual.EasedValue(base.from, base.to, lifetimePercentage, Ease.OutQuint);
		}
		if (progress <= num2)
		{
			return base.to;
		}
		float lifetimePercentage2 = (progress - num2) / (1f - num2);
		return DOVirtual.EasedValue(base.to, base.from, lifetimePercentage2, Ease.InQuad);
	}
}
