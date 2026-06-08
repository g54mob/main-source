using UnityEngine;

public class BerserkPotionActivationState : BasePotionActivationState, IPostAsciiRendererEffect
{
	public DebuffStatMod berserkBuff;

	private float redPercent;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_berserk");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != PotionState.BottleMorphing)
		{
			return;
		}
		if (stateElapsedTics == 15)
		{
			AddBuff(berserkBuff);
			redPercent = 1.02f;
			if (AdditionalSettings.isScreenFlash)
			{
				GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			}
		}
		else if (stateElapsedTics == 22)
		{
			CameraShake.singleton.ShakeCamera(3f, 0.15f);
		}
		else if (stateElapsedTics == 45)
		{
			redPercent = -1f;
			SetState(State.Done);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (redPercent <= 0f || GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			r.RemovePostEffect(this);
			return;
		}
		Color red = ColorConstants.red;
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetForeground();
				cell.SetForeground(Color.Lerp(foreground, red, redPercent));
				Color background = cell.GetBackground();
				cell.SetBackground(Color.Lerp(background, red, redPercent));
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		redPercent -= Time.deltaTime * 2.5f;
	}
}
