using UnityEngine;

public class EnchantmentProgressBar : FilledProgressBar
{
	private bool _isMax;

	private bool forceRefresh;

	private float lastPercent = -1f;

	private int initialX;

	public bool maxEnchantment
	{
		get
		{
			return _isMax;
		}
		set
		{
			_isMax = value;
			forceRefresh = true;
		}
	}

	public void Setup(float targetP, Color targetC)
	{
		base.targetPercent = targetP;
		targetFillColor = targetC;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (lastPercent != percent || forceRefresh)
		{
			lastPercent = percent;
			forceRefresh = false;
			if (maxEnchantment && percent > 0.99f)
			{
				label.SetValue(Te.xt("MAX") + " ");
			}
			else
			{
				int num = Mathf.FloorToInt(percent * 100f);
				label.SetValue(num + "%");
			}
		}
		if (percent >= 10f && !maxEnchantment)
		{
			label.PositionX = initialX - 1;
		}
		else
		{
			label.PositionX = initialX;
		}
		base.Draw(r, offsetX, offsetY);
	}

	private void Start()
	{
		initialX = label.PositionX;
	}
}
