using UnityEngine;

public class VampiricPotionActivationState : BasePotionActivationState, IPostAsciiRendererEffect
{
	public DebuffStatMod vampiricBuff;

	private int orangeCount;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_vampiric");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState != PotionState.BottleMorphing)
		{
			return;
		}
		if (stateElapsedTics == 29)
		{
			AddBuff(vampiricBuff);
			if (AdditionalSettings.isScreenFlash)
			{
				GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			}
			orangeCount = 0;
		}
		else if (stateElapsedTics >= 30 && stateElapsedTics < 35)
		{
			orangeCount++;
		}
		else if (stateElapsedTics == 35)
		{
			orangeCount = 99;
			SetState(State.Done);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (orangeCount >= 0 && orangeCount <= 3)
		{
			Color color = new Color(1f, 0.5f, 0f);
			for (int i = 0; i < r.width; i++)
			{
				for (int j = 0; j < r.height; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					cell.SetForeground(color);
					if (orangeCount <= 2)
					{
						cell.SetBackground(color);
					}
				}
			}
		}
		else
		{
			r.RemovePostEffect(this);
		}
	}
}
