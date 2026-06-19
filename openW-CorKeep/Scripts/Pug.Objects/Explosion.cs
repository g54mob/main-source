#define PUG_RGB_ENABLED
using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

public class Explosion : EntityMonoBehaviour
{
	[Serializable]
	public class ExplosionProperty
	{
		[HideInInspector]
		public string name;

		public ObjectID explosionID;

		[Header("Properties")]
		public Color lightColor = Color.white;

		public SFXTableIDField explosionSound;

		public PuffID explosionPuffID = PuffID.WhiteSmoke;

		public ParticleSystem circleEffect;
	}

	private ParticleSystem circleParticleSystem;

	public Light pointLight;

	public float fadeOutTime = 0.5f;

	[Tooltip("Sfx, vfx, light color for each Explosion ID")]
	public List<ExplosionProperty> explosionProperties;

	private bool hasExploded;

	protected virtual bool doRgbEffect => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		hasExploded = false;
		circleParticleSystem = null;
		CheckForExplosion();
	}

	private void Explode()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			float magnitude = (base.transform.position - player.transform.position).magnitude;
			if (doRgbEffect && magnitude < 9f)
			{
				Manager.camera.ShakeCameraNow();
				Manager.rgb.TriggerEvent(RGBManager.Event.Bomb);
			}
		}
		ObjectID objectID = EntityUtility.GetObjectID(base.entity, base.world);
		foreach (ExplosionProperty explosionProperty in explosionProperties)
		{
			if (explosionProperty.explosionID == objectID)
			{
				pointLight.color = explosionProperty.lightColor;
				AudioManager.SfxFollowTransform(explosionProperty.explosionSound.value, base.transform);
				PlayEffectForExplosion(explosionProperty.explosionPuffID);
				float3 float5 = base.WorldPosition;
				TileInfo topTile = Manager.multiMap.GetTileLayerLookup().GetTopTile(float5.RoundToInt2());
				if (topTile.tileType == TileType.water)
				{
					float3 float6 = Manager.camera.RenderOrigo.ToFloat3();
					EffectEventExtensions.PlayDynamicBubbleExplosion(float5 - float6, topTile);
				}
				circleParticleSystem = explosionProperty.circleEffect;
				break;
			}
		}
		if (circleParticleSystem != null)
		{
			circleParticleSystem.Play();
		}
		WaterSim.AddImpulse(base.transform.position, 2f, 10f);
		if (pointLight != null)
		{
			pointLight.gameObject.SetActive(value: false);
			SpawnFadeOutLight(pointLight, fadeOutTime);
		}
	}

	protected virtual void PlayEffectForExplosion(PuffID puffID)
	{
		Manager.effects.PlayPuff(puffID, base.transform.position, 1);
	}

	private void CheckForExplosion()
	{
		if (!hasExploded)
		{
			float fraction;
			NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(base.entity, base.world, out fraction);
			ExplosionCD componentData = EntityUtility.GetComponentData<ExplosionCD>(base.entity, base.world);
			if (!componentData.delayTimer.isRunning || componentData.delayTimer.IsTimerElapsed(currentTickOnClient))
			{
				Explode();
				hasExploded = true;
			}
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		CheckForExplosion();
		if (!(circleParticleSystem == null))
		{
			ExplosionCD componentData = EntityUtility.GetComponentData<ExplosionCD>(base.entity, base.world);
			ParticleSystem.MainModule main = circleParticleSystem.main;
			main.startSize = 45f * (componentData.radius / 2f);
		}
	}

	private void OnValidate()
	{
		for (int i = 0; i < explosionProperties.Count; i++)
		{
			explosionProperties[i].name = explosionProperties[i].explosionID.ToString();
		}
	}
}
