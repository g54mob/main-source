using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SummonArea : EntityMonoBehaviour
{
	public SpriteRenderer runeSR;

	[ColorUsage(true, true)]
	public Color glowColor;

	private static readonly int Emissive = Shader.PropertyToID("_EmissiveColor");

	private float glowAlpha;

	public AnimationCurve glowCurve;

	public float animatedSRGlowAlpha;

	public Color animatedGlowColor;

	public List<SpriteRenderer> sRGlows;

	public List<SpriteRenderer> glows;

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -360926955)
		{
			AudioManager.Sfx(SfxID.Bell, base.transform.position);
		}
		if (animID == -1878077465)
		{
			SpawnEffect freeComponent = Manager.memory.GetFreeComponent<SpawnEffect>(deferOnOccupied: true);
			if (freeComponent != null)
			{
				freeComponent.transform.position = base.transform.position + new Vector3(0f, 5f, -5f);
				freeComponent.OnOccupied();
			}
			else
			{
				Debug.LogError("failed to instantiate boss spawn effect");
			}
			AudioManager.Sfx(SfxID.darkgleam, base.transform.position);
		}
		base.HandleAnimationTrigger(animID);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		runeSR.material.SetColor(Emissive, glowColor);
		int index = base.variation;
		sRGlows[index].material.SetColor(Emissive, glowColor);
		sRGlows[index].SetAlpha(animatedSRGlowAlpha);
		glows[index].color = animatedGlowColor;
	}

	public void AE_BuildUpSoundEffect()
	{
		AudioManager.SfxFollowTransform(SfxID.MagicBuildup, base.transform, 0.4f);
	}
}
