using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Snake
{
	public class SnakeBodyPart : MonoBehaviour
	{
		public ParticleSystem TerrainCollisionEffect;

		public string SoundLoop;

		public string DamageSoundLoop;

		private SnakeMovementController _snake;

		private int _dronePartCounter;

		public void Init(SnakeMovementController snake)
		{
			_snake = snake;
			AudioController.Play(SoundLoop, base.transform);
		}

		public void OnTriggerStay(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				other.gameObject.SendMessage("TakeDamage", new DamageInformation(_snake.DamagePerSecond * Time.deltaTime, EDamageReason.Environment), SendMessageOptions.DontRequireReceiver);
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer && _dronePartCounter == 0)
			{
				if (!AudioController.IsPlaying(DamageSoundLoop))
				{
					AudioController.Play(DamageSoundLoop, base.transform);
				}
				_dronePartCounter++;
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
			{
				_dronePartCounter--;
				if (_dronePartCounter <= 0 && AudioController.IsPlaying(DamageSoundLoop))
				{
					AudioController.Stop(DamageSoundLoop);
				}
			}
		}

		public void Update()
		{
			NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(base.transform.position);
			if (data.HasValue)
			{
				if (data.Value.Volume >= 0.5f)
				{
					ParticleSystem.MainModule main = TerrainCollisionEffect.main;
					Color color = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false).Material.color;
					main.startColor = color;
					if (!TerrainCollisionEffect.isPlaying)
					{
						TerrainCollisionEffect.Play();
					}
				}
				else
				{
					TerrainCollisionEffect.Stop();
				}
			}
			else
			{
				TerrainCollisionEffect.Stop();
			}
		}
	}
}
