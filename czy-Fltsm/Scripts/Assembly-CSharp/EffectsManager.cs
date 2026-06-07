using UnityEngine;

public class EffectsManager : MonoBehaviour
{
	public void Initialize()
	{
		ParticleEffect[] particleEffects = GameManager.Settings.FXSettings.ParticleEffects;
		for (int i = 0; i < particleEffects.Length; i++)
		{
			particleEffects[i].Initialize();
		}
	}

	public static bool ActivateEffect(EffectTrigger trigger, Transform parent, Vector3 localPosition)
	{
		ParticleEffect[] particleEffects = GameManager.Settings.FXSettings.ParticleEffects;
		for (int i = 0; i < particleEffects.Length; i++)
		{
			if (particleEffects[i].Activate(trigger, parent, localPosition))
			{
				return true;
			}
		}
		return false;
	}
}
