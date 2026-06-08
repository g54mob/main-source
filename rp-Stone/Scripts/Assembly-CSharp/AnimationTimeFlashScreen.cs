using UnityEngine;

public class AnimationTimeFlashScreen : AAnimationTimeEffect, IPostAsciiRendererEffect
{
	public float effectDuration;

	private AsciiRenderProcedural lastRenderer;

	private float timeRemaining;

	public override void ExecuteEffect(AsciiAnimation animation, AsciiSprite sprite, AsciiRenderProcedural r)
	{
		if (AdditionalSettings.isScreenFlash)
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

	private void LateUpdate()
	{
		if (lastRenderer != null && timeRemaining > 0f)
		{
			timeRemaining -= Utils.deltaTime;
			if (timeRemaining <= 0f)
			{
				lastRenderer.RemovePostEffect(this);
			}
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (lastRenderer != null)
		{
			lastRenderer.RemovePostEffect(this);
		}
	}
}
