using Assets.Nimbatus.Scripts.Animations;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

public class TutorialBattleTarget : MonoBehaviour
{
	public HealthPool HealthPool;

	public string ActivateSound;

	public Color ColorActivatedA;

	public Color ColorActivatedB;

	public Color ColorDeactivatedA;

	public Color ColorDeactivatedB;

	public SpriteSinusColorFader Fader;

	private void Update()
	{
		if (HealthPool != null && Fader != null)
		{
			if (HealthPool.IsInvincible)
			{
				Fader.colorA = ColorDeactivatedA;
				Fader.colorB = ColorDeactivatedB;
			}
			else
			{
				Fader.colorA = ColorActivatedA;
				Fader.colorB = ColorActivatedB;
			}
		}
	}

	public void DeactivateTarget()
	{
		if (HealthPool != null)
		{
			HealthPool.IsInvincible = true;
		}
	}

	public void ActivateTarget()
	{
		if (HealthPool != null)
		{
			HealthPool.IsInvincible = false;
			if (ActivateSound != "")
			{
				AudioController.Play(ActivateSound);
			}
		}
	}
}
