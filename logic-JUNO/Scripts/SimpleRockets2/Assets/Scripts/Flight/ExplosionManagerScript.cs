using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class ExplosionManagerScript : MonoBehaviour
	{
		private const float MaxExplosionScale = 70f;

		private const ushort MaxExplosionsPerType = 15;

		private const float MinExplosionScale = 0.1f;

		[SerializeField]
		private ushort _countLarges;

		[SerializeField]
		private ushort _countMediums;

		[SerializeField]
		private ushort _countSmalls;

		private List<ExplosionScript> _pool = new List<ExplosionScript>();

		[SerializeField]
		private float _scale = 0.004f;

		[SerializeField]
		private float _scalePower = 0.5f;

		public void CreateExplosion(IEnumerable<PartData> parts, Vector3 position, Vector3 velocity, float magnitude, float magnitudeFromFuel)
		{
			float num = Mathf.Max(0.1f, Mathf.Pow(magnitude, _scalePower) * _scale);
			float num2 = 100f * _scale * Mathf.Pow(magnitude - magnitudeFromFuel, 0.25f);
			float num3 = Mathf.Max(num, num2);
			bool flag = magnitudeFromFuel > 0f;
			if (num2 > num * 3f)
			{
				flag = false;
			}
			ExplosionScript nextExplosionFromPool = GetNextExplosionFromPool((!flag) ? 1 : ((magnitude < 100000f) ? 2 : 3));
			if (nextExplosionFromPool != null)
			{
				float volume = Mathf.Lerp(0.4f, 10f, num3 / 70f);
				nextExplosionFromPool.Play(position, velocity, num3, volume);
			}
			if (parts == null)
			{
				return;
			}
			float num4 = magnitude / 100f;
			foreach (PartData part in parts)
			{
				if (part.PartScript.GameObject.activeInHierarchy && part.Config.CanExplode)
				{
					Vector3 vector = part.PartScript.Transform.position - position;
					float sqrMagnitude = vector.sqrMagnitude;
					if (sqrMagnitude < num4)
					{
						float num5 = ((sqrMagnitude < 1f) ? magnitude : (magnitude / sqrMagnitude)) * part.PartDrag.TotalArea * 0.1f * 0.01f;
						Rigidbody rigidBody = part.PartScript.BodyScript.RigidBody;
						part.PartScript.TakeDamage(400f * num5 / rigidBody.mass, PartDamageType.Explosion);
						rigidBody.AddForceAtPosition(vector.normalized * Mathf.Min(num5, rigidBody.mass * 70f), part.PartScript.Transform.position, ForceMode.Impulse);
					}
				}
			}
		}

		private static GameObject LoadExplosionPrefab(int explosionStrength, int variant)
		{
			string arg = Game.Instance.QualitySettings.VisualEffects.Explosions.Value switch
			{
				VisualEffectsQualitySettings.ExplosionQuality.High => "High", 
				VisualEffectsQualitySettings.ExplosionQuality.Medium => "Medium", 
				_ => "Low", 
			};
			return Game.Instance.ResourceLoader.LoadPrefab(string.Format("Flight/Common/Explosions/Basic/{0}Explosion{1}-{2}", explosionStrength switch
			{
				3 => "Large", 
				2 => "Medium", 
				_ => "Small", 
			}, variant, arg));
		}

		private ExplosionScript GetNextExplosionFromPool(int type)
		{
			int num = (type - 1) * 15;
			ushort num2 = type switch
			{
				1 => _countSmalls, 
				2 => _countMediums, 
				_ => _countLarges, 
			};
			for (int i = num2; i < 15 + num2; i++)
			{
				if (!_pool[num + i % 15].Alive)
				{
					switch (type)
					{
					case 1:
						_countSmalls = (ushort)(i + 1);
						break;
					case 2:
						_countMediums = (ushort)(i + 1);
						break;
					default:
						_countLarges = (ushort)(i + 1);
						break;
					}
					return _pool[num + i % 15];
				}
			}
			return null;
		}

		private void InitializePool()
		{
			foreach (ExplosionScript item in _pool)
			{
				Object.DestroyImmediate(item.gameObject);
			}
			_pool.Clear();
			for (int i = 1; i <= 3; i++)
			{
				GameObject gameObject = LoadExplosionPrefab(i, 1);
				GameObject gameObject2 = LoadExplosionPrefab(i, 2);
				string text = "Explosion" + i switch
				{
					2 => "Medium", 
					1 => "Small", 
					_ => "Large", 
				};
				for (int j = 0; j < 15; j++)
				{
					GameObject obj = Object.Instantiate((j % 2 == 0) ? gameObject : gameObject2);
					obj.transform.SetParent(base.transform, worldPositionStays: false);
					ExplosionScript explosionScript = obj.AddComponent<ExplosionScript>();
					explosionScript.Initialize(Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/" + text + (1 + j % 2)));
					_pool.Add(explosionScript);
					obj.SetActive(value: false);
				}
			}
		}

		private void OnDestroy()
		{
			UpdateEventSubscriptions(subscribe: false);
		}

		private void OnExplosionQualitySettingsChanged(object sender, SettingsChangedEventArgs<VisualEffectsQualitySettings> e)
		{
			InitializePool();
		}

		private void Start()
		{
			InitializePool();
			UpdateEventSubscriptions(subscribe: true);
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			VisualEffectsQualitySettings visualEffects = Game.Instance.QualitySettings.VisualEffects;
			if (subscribe)
			{
				visualEffects.Changed += OnExplosionQualitySettingsChanged;
			}
			else
			{
				visualEffects.Changed -= OnExplosionQualitySettingsChanged;
			}
		}
	}
}
