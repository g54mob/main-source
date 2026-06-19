using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

public class Firework : EntityMonoBehaviour
{
	public GameObject wiresContainer;

	public SpriteRenderer middleWire;

	public SpriteRenderer forwardWire;

	public SpriteRenderer backWire;

	public SpriteRenderer leftWire;

	public SpriteRenderer rightWire;

	public ParticleSystem fire;

	public ParticleSystem sparks;

	public ParticleSystem smoke;

	public Transform ExplosionPosition;

	private int prevVariation;

	public override void OnOccupied()
	{
		base.OnOccupied();
		prevVariation = 0;
		CheckIfShouldBeFired();
		UpdateElectricityVisuals();
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		CheckIfShouldBeFired();
		UpdateElectricityVisuals();
	}

	private void UpdateElectricityVisuals()
	{
		int2 obj = base.WorldPosition.RoundToInt2();
		if (!wiresContainer.activeSelf)
		{
			wiresContainer.SetActive(value: true);
		}
		int2 worldPosition = obj + new int2(0, 1);
		int2 worldPosition2 = obj + new int2(0, -1);
		int2 worldPosition3 = obj + new int2(-1, 0);
		int2 worldPosition4 = obj + new int2(1, 0);
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		bool flag = Manager.multiMap.HasHiddenTile(worldPosition, 4, TileType.circuitPlate) || tileLayerLookup.HasTile(worldPosition, TileType.circuitPlate);
		if (flag != forwardWire.gameObject.activeSelf)
		{
			forwardWire.gameObject.SetActive(flag);
		}
		bool flag2 = Manager.multiMap.HasHiddenTile(worldPosition2, 4, TileType.circuitPlate) || tileLayerLookup.HasTile(worldPosition2, TileType.circuitPlate);
		if (flag2 != backWire.gameObject.activeSelf)
		{
			backWire.gameObject.SetActive(flag2);
		}
		bool flag3 = Manager.multiMap.HasHiddenTile(worldPosition3, 4, TileType.circuitPlate) || tileLayerLookup.HasTile(worldPosition3, TileType.circuitPlate);
		if (flag3 != leftWire.gameObject.activeSelf)
		{
			leftWire.gameObject.SetActive(flag3);
		}
		bool flag4 = Manager.multiMap.HasHiddenTile(worldPosition4, 4, TileType.circuitPlate) || tileLayerLookup.HasTile(worldPosition4, TileType.circuitPlate);
		if (flag4 != rightWire.gameObject.activeSelf)
		{
			rightWire.gameObject.SetActive(flag4);
		}
		bool flag5 = flag || flag2 || flag3 || flag4;
		if (flag5 != middleWire.gameObject.activeSelf)
		{
			middleWire.gameObject.SetActive(flag5);
		}
	}

	private void CheckIfShouldBeFired()
	{
		if (base.variation == 1 && prevVariation != base.variation)
		{
			if ((bool)fire)
			{
				fire.Play();
			}
			if ((bool)smoke)
			{
				smoke.Stop();
			}
			if ((bool)sparks)
			{
				sparks.Play();
				AudioManager.SfxFollowTransform(SfxID.bombFuse, base.transform, 0.5f, 0.9f, 0.15f);
			}
			HandleAnimationTrigger(199885753);
			prevVariation = base.variation;
		}
	}

	public virtual void AE_bounceAudio()
	{
		AudioManager.SfxFollowTransform(SfxID.bubble, base.transform, 0.4f, 1f, 0.1f);
	}

	public virtual void AE_disableParticlesystems()
	{
		if ((bool)fire)
		{
			fire.Stop();
		}
		if ((bool)sparks)
		{
			sparks.Stop();
		}
	}

	public virtual void AE_takeOff()
	{
		if ((bool)sparks)
		{
			sparks.Stop();
		}
		if ((bool)smoke)
		{
			smoke.Play();
		}
		AudioManager.Sfx(SfxTableID.fireworkTakeOff, ExplosionPosition.position);
	}

	public virtual void AE_Explosion()
	{
		FireworkExplosion freeComponent = Manager.memory.GetFreeComponent<FireworkExplosion>(deferOnOccupied: true);
		if (!(freeComponent == null))
		{
			freeComponent.transform.position = ExplosionPosition.position;
			Color color = new Color(0f, 0.2f, 1f);
			Color color2 = new Color(1f, 0.5f, 0f);
			switch (base.objectData.objectID)
			{
			default:
				freeComponent.Play(Color.red, Color.white, Color.clear, Color.white, 0.5f);
				AudioManager.Sfx(SfxTableID.fireworkExplode, ExplosionPosition.position);
				break;
			case ObjectID.FireworkGreen:
				freeComponent.Play(Color.green, Color.white, Color.clear, Color.white, 0.5f);
				AudioManager.Sfx(SfxTableID.fireworkExplode, ExplosionPosition.position);
				break;
			case ObjectID.FireworkBlue:
				freeComponent.Play(color, Color.white, Color.clear, Color.white, 0.5f);
				AudioManager.Sfx(SfxTableID.fireworkExplode, ExplosionPosition.position);
				break;
			case ObjectID.FireworkYellow:
				freeComponent.Play(color2, color, Color.white, Color.clear, 0.1f);
				AudioManager.Sfx(SfxTableID.fireworkExplodeSparkles, ExplosionPosition.position);
				break;
			case ObjectID.FireworkPurple:
				freeComponent.Play(new Color(1f, 0f, 1f), color2, Color.white, Color.clear, 0.1f);
				AudioManager.Sfx(SfxTableID.fireworkExplodeSparkles, ExplosionPosition.position);
				break;
			}
			HandleAnimationTrigger(-414722770);
		}
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (animID == -601574123)
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	protected override void OnDeath()
	{
	}
}
