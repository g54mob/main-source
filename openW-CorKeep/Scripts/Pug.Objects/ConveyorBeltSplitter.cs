using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltSplitter : EntityMonoBehaviour
{
	private int prevVariation;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	public override void OnOccupied()
	{
		base.OnOccupied();
		prevVariation = -1;
		UpdateVisuals();
		AudioManager.Sfx(SfxTableID.conveyorBeltSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		int num = base.variation;
		if (num != prevVariation)
		{
			XScaler.localScale = new Vector3((num != 3) ? 1 : (-1), 1f, 1f);
			switch (num)
			{
			case 0:
				SetOrientation(Vector3.forward);
				break;
			case 1:
				SetOrientation(Vector3.right);
				break;
			case 2:
				SetOrientation(Vector3.back);
				break;
			case 3:
				SetOrientation(Vector3.left);
				break;
			}
			prevVariation = num;
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}
}
