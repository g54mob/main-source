using ModApi.Audio;
using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftAudio
	{
		private int _collisionSoundCooldown;

		private Vector3? _collisionSoundPosition;

		private ICraftScript _craftScript;

		private int _disconnectSoundCooldown;

		private Vector3? _disconnectSoundPosition;

		private AudioSource _windNoise;

		public CraftAudio(ICraftScript craftScript)
		{
			_craftScript = craftScript;
		}

		public void PlayCollisionSound(Vector3 position)
		{
			_collisionSoundPosition = position;
		}

		public void PlayDisconnectSound(Vector3 position)
		{
			_disconnectSoundPosition = position;
		}

		public void Update()
		{
			UpdateWindNoise();
			if (_collisionSoundCooldown > 0)
			{
				_collisionSoundCooldown--;
			}
			if (_collisionSoundPosition.HasValue)
			{
				if (_collisionSoundCooldown <= 0)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.PartCollisionGround, _collisionSoundPosition.Value, 0.05f, 0f, userInterfaceSound: false);
					_collisionSoundCooldown = 10;
				}
				_collisionSoundPosition = null;
			}
			if (_disconnectSoundCooldown > 0)
			{
				_disconnectSoundCooldown--;
			}
			if (_disconnectSoundPosition.HasValue)
			{
				if (_disconnectSoundCooldown <= 0)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.DisconnectPart, _disconnectSoundPosition.Value, 0.05f, 0f, userInterfaceSound: false);
					_disconnectSoundCooldown = 10;
				}
				_disconnectSoundPosition = null;
			}
		}

		private void CreateWindNoise(GameObject target)
		{
			_windNoise = target.gameObject.GetComponent<AudioSource>();
			if (_windNoise == null)
			{
				_windNoise = target.gameObject.AddComponent<AudioSource>();
			}
			_windNoise.dopplerLevel = 0f;
			_windNoise.spatialBlend = 1f;
			_windNoise.minDistance = 50f;
			_windNoise.maxDistance = 1000f;
			_windNoise.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetGameMixerGroup();
			_windNoise.clip = Resources.Load("Audio/Sounds/WindNoise") as AudioClip;
			_windNoise.loop = true;
			_windNoise.volume = 0f;
			_windNoise.Play();
		}

		private void UpdateWindNoise()
		{
			ICraftNode craftNode = _craftScript.CraftNode;
			if (craftNode != null && craftNode.IsPlayer)
			{
				if (_craftScript.CenterOfMass.gameObject.activeInHierarchy)
				{
					if (_windNoise == null)
					{
						CreateWindNoise(_craftScript.CenterOfMass.gameObject);
					}
					float value = (float)_craftScript.FlightData.SurfaceVelocityMagnitude / 200f * _craftScript.AtmosphereSample.AirDensity;
					_windNoise.volume = Mathf.Clamp01(value) * 0.2f;
				}
			}
			else if (_windNoise != null)
			{
				_windNoise.volume = 0f;
			}
		}
	}
}
