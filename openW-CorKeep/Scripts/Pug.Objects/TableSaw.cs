using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class TableSaw : CraftingBuilding
{
	private PoolableAudioSource _sawAudio;

	private static int m_activeAnimation = SpriteAsset.StringToHash("active");

	private static int m_woodAnimation = SpriteAsset.StringToHash("default");

	private static int m_coralHash = SpriteAsset.StringToHash("tableSawWood_coral");

	private static int m_gleamHash = SpriteAsset.StringToHash("tableSawWood_gleam");

	public ParticleSystem particlesChips;

	public ParticleSystem particlesSmoke;

	private static int m_particleStartWoodCutting = SpriteAsset.StringToHash("StartWoodCutting");

	private static int m_particleEndWoodCutting = SpriteAsset.StringToHash("EndWoodCutting");

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[2].onAnimationEvent += HandleWoodAnimationEvent;
	}

	protected override void OnShow()
	{
		base.OnShow();
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		if ((bool)_sawAudio)
		{
			_sawAudio.FadeOutAndStop();
			_sawAudio = null;
		}
		base.OnHide();
	}

	private void HandleWoodAnimationEvent(int hash)
	{
		if (hash == m_particleStartWoodCutting)
		{
			_sawAudio = AudioManager.Sfx(SfxID.tableSaw, base.transform.position, 0.9f, 1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 4f, 4f);
			StartWoodCuttingParticles();
		}
		else if (hash == m_particleEndWoodCutting)
		{
			EndWoodCuttingParticles();
		}
	}

	protected override void OnActive()
	{
		base.OnActive();
		spriteObjects[0].PlayAnimation(m_activeAnimation);
		ObjectID? outputObjectIDatIndex = getOutputObjectIDatIndex(0);
		if (outputObjectIDatIndex == ObjectID.CoralWood)
		{
			spriteObjects[2].PlayAnimation(m_woodAnimation, m_coralHash);
		}
		else if (outputObjectIDatIndex == ObjectID.GleamWood)
		{
			spriteObjects[2].PlayAnimation(m_woodAnimation, m_gleamHash);
		}
		else
		{
			spriteObjects[2].PlayAnimation(m_woodAnimation);
		}
	}

	protected override void OnInactive()
	{
		base.OnInactive();
		if ((bool)_sawAudio)
		{
			_sawAudio.FadeOutAndStop();
			_sawAudio = null;
		}
		spriteObjects[0].StopAnimation();
		spriteObjects[2].StopAnimation();
		EndWoodCuttingParticles();
	}

	private void StartWoodCuttingParticles()
	{
		ParticleSystem.EmissionModule emission = particlesChips.emission;
		emission.rateOverTime = 100f;
		particlesChips.Play();
		ParticleSystem.EmissionModule emission2 = particlesSmoke.emission;
		emission2.rateOverTime = 30f;
		particlesSmoke.Play();
	}

	private void EndWoodCuttingParticles()
	{
		ParticleSystem.EmissionModule emission = particlesChips.emission;
		emission.rateOverTime = 0f;
		particlesChips.Stop();
		ParticleSystem.EmissionModule emission2 = particlesSmoke.emission;
		emission2.rateOverTime = 0f;
		particlesSmoke.Stop();
	}
}
