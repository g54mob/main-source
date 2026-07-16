using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MilestoneCoresAwardMenu : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI amount;

	private float coresToGain;

	private float timer = 0.1f;

	private int coreAmount = 1;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private UnitAudioController unitAudioController;

	private bool hasEnded;

	[SerializeField]
	private List<ParticleSystem> ps;

	private void OnEnable()
	{
		coresToGain = MilestoneManager.Instance.coresToGain;
	}

	private void Update()
	{
		if ((float)coreAmount < coresToGain)
		{
			timer -= Time.unscaledDeltaTime;
			if (timer < 0f)
			{
				coreAmount++;
				amount.text = coreAmount.ToString();
				unitAudioController.PlayChannel0();
				timer = 0.1f;
			}
		}
		else if (!hasEnded)
		{
			anim.enabled = false;
			unitAudioController.PlayOnMain();
			hasEnded = true;
			amount.gameObject.GetComponent<RectTransform>().localRotation = new Quaternion(0f, 0f, 0f, 0f);
			EffectsUtils.PlayMultipleParticles(ps, play: true);
		}
	}
}
