using System.Collections.Generic;
using Restory.Data.PC;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Screens
{
	public class GUI_HackingEffectsScreen : MonoBehaviour
	{
		[SerializeField]
		private List<GUI_HackingEffect> effects;

		private HackingEffectsSettings settings;

		private float effectTimer;

		private bool activated;

		private void Update()
		{
			if (activated)
			{
				if (effectTimer > 0f)
				{
					effectTimer -= Time.deltaTime;
					return;
				}
				PlayRandomPermanentEffect();
				effectTimer = settings.EffectFrequencyInSeconds;
			}
		}

		private void OnDisable()
		{
			activated = false;
		}

		public void Init(HackingEffectsSettings settings)
		{
			this.settings = settings;
			effectTimer = settings.EffectFrequencyInSeconds;
		}

		public void Activate()
		{
			if (!activated)
			{
				activated = true;
			}
		}

		private void PlayRandomPermanentEffect()
		{
			if (effects.Count != 0)
			{
				int index = Random.Range(0, effects.Count);
				effects[index].Play();
				effects.RemoveAt(index);
			}
		}
	}
}
