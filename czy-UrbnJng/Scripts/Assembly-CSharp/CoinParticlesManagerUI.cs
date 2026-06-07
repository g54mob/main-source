using System;
using System.Collections;
using Coffee.UIExtensions;
using UnityEngine;

public class CoinParticlesManagerUI : MonoBehaviour
{
	[SerializeField]
	private UIParticleAttractor scoreAttractor;

	[SerializeField]
	private ParticleSystem coinParticleSystemTemplate;

	[SerializeField]
	private UIParticleAttractor coinAttractor;

	[SerializeField]
	private Transform coinAtProgressBar;

	public static CoinParticlesManagerUI Instance { get; private set; }

	public event EventHandler OnCoinHitCounter;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		NewScoreUI instance = NewScoreUI.Instance;
		instance.OnMaxScoreReached = (Action<bool>)Delegate.Combine(instance.OnMaxScoreReached, new Action<bool>(NewScoreUI_OnMaxScoreReached));
	}

	private void OnDestroy()
	{
		NewScoreUI instance = NewScoreUI.Instance;
		instance.OnMaxScoreReached = (Action<bool>)Delegate.Remove(instance.OnMaxScoreReached, new Action<bool>(NewScoreUI_OnMaxScoreReached));
	}

	private void NewScoreUI_OnMaxScoreReached(bool coinInfoActive)
	{
		if (coinInfoActive)
		{
			SpawnCoinsAtProgressBar(1);
		}
	}

	private void SpawnCoinsAtProgressBar(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			ParticleSystem particleSystem = UnityEngine.Object.Instantiate(coinParticleSystemTemplate, coinParticleSystemTemplate.transform.parent);
			particleSystem.transform.position = coinAtProgressBar.position;
			coinAttractor.AddParticleSystem(particleSystem);
			StartCoroutine(EmitParticlesOneByOne(particleSystem, amount, coinAttractor, null));
		}
	}

	private IEnumerator EmitParticlesOneByOne(ParticleSystem particleSystem, int count, UIParticleAttractor attractor, UIParticleAttractor spawnedAttractor)
	{
		float delay = 0.05f;
		if (count > 20)
		{
			delay = 0.03f;
		}
		if (count > 40)
		{
			delay = 0.015f;
		}
		for (int i = 0; i < count; i++)
		{
			if (particleSystem != null)
			{
				particleSystem.Emit(1);
			}
			yield return new WaitForSeconds(delay);
		}
		yield return new WaitForSeconds(3f);
		attractor.RemoveParticleSystem(particleSystem);
		UnityEngine.Object.Destroy(particleSystem.gameObject);
		if (spawnedAttractor != null)
		{
			UnityEngine.Object.Destroy(spawnedAttractor.gameObject);
		}
	}

	public void OnCoinsHitCounter()
	{
		this.OnCoinHitCounter?.Invoke(this, EventArgs.Empty);
	}
}
