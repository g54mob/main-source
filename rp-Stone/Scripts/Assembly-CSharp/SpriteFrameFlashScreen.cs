using UnityEngine;

public class SpriteFrameFlashScreen : ASpriteFrameEffect, IPostAsciiRendererEffect
{
	public float effectDuration;

	private AsciiRenderProcedural lastRenderer;

	private float timeRemaining;

	public override void ExecuteEffect(AsciiSprite sprite, AsciiRenderProcedural r)
	{
		if (AdditionalSettings.isScreenFlash && base.enabled)
		{
			lastRenderer = r;
			r.AddPostEffect(this);
			timeRemaining = effectDuration;
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color background = cell.GetBackground();
				cell.SetBackground(Color.white);
				cell.SetForeground(background);
			}
		}
	}

	private void RemoveEffect()
	{
		if (lastRenderer != null)
		{
			lastRenderer.RemovePostEffect(this);
		}
	}

	private void LateUpdate()
	{
		if (lastRenderer != null && timeRemaining > 0f)
		{
			timeRemaining -= Utils.deltaTime;
			if (timeRemaining <= 0f)
			{
				RemoveEffect();
			}
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		RemoveEffect();
	}

	private void OnDisable()
	{
		RemoveEffect();
	}
}
