using UnityEngine;

public class ExperiencePotionActivationState : BasePotionActivationState, IPostAsciiRendererEffect
{
	public DebuffStatMod experienceBuff;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_experience");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != PotionState.BottleMorphing)
		{
			return;
		}
		if (stateElapsedTics == 12)
		{
			if (AdditionalSettings.isScreenFlash)
			{
				GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			}
		}
		else if (stateElapsedTics == 15)
		{
			AddBuff(experienceBuff);
			if (AdditionalSettings.isScreenFlash)
			{
				GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			}
		}
		else if (stateElapsedTics == 25)
		{
			SetState(State.Done);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		r.RemovePostEffect(this);
		Color white = ColorConstants.white;
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				cell.SetForeground(white);
				cell.SetBackground(white);
			}
		}
	}
}
