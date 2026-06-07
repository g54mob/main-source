using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class DirtManager : WorldManager
	{
		[SerializeField]
		private DirtSpawner m_spawner;

		private readonly List<Dirt> m_dirt = new List<Dirt>();

		private Dictionary<DirtData.EType, int> m_dirtTypeCount = new Dictionary<DirtData.EType, int>();

		private Dictionary<DirtData.EType, IEnumerator> m_spawnDirtRoutines = new Dictionary<DirtData.EType, IEnumerator>
		{
			{
				DirtData.EType.STAIN,
				null
			},
			{
				DirtData.EType.TRASH,
				null
			}
		};

		public DirtSpawner Spawner => m_spawner;

		public void Register(Dirt dirt)
		{
			if (!m_dirt.Contains(dirt))
			{
				m_dirt.Add(dirt);
				m_dirtTypeCount[dirt.Type]++;
				World.ScoreManager.ComputeFromScore(ScoreSettings.GetDirtScoreMalus(dirt.Type), $"Malus due to client spawning {dirt.Type}");
			}
		}

		public void Unregister(Dirt dirt)
		{
			if (m_dirt.Contains(dirt))
			{
				m_dirt.Remove(dirt);
				if (m_dirtTypeCount.ContainsKey(dirt.Type) && m_dirtTypeCount[dirt.Type] > 0)
				{
					m_dirtTypeCount[dirt.Type]--;
				}
				World.ScoreManager.ComputeFromScore(ScoreSettings.GetDirtScoreMalus(dirt.Type).ReverseOperator(), $"Bonus due to clean {dirt.Type}");
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.OPEN_SHOP:
				SpawnDirt(DirtData.EType.TRASH);
				SpawnDirt(DirtData.EType.STAIN);
				break;
			case EGameEvent.CLOSE_SHOP:
				StopSpawning();
				break;
			}
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.SAVE:
				SaveDirt();
				break;
			case EWorldEvent.LOADING_PHASE2:
				LoadDirt();
				break;
			}
		}

		private void SaveDirt()
		{
			SaveManager.CurrentSave.dirt.dirtDatas = new List<SaveClass_Dirt.SaveDirtData>();
			foreach (Dirt item in m_dirt.Where((Dirt dirt) => !(dirt is Trash trash) || !trash.IsStacked))
			{
				item.Save();
			}
		}

		private void LoadDirt()
		{
			m_dirt.Clear();
			m_dirtTypeCount.Clear();
			foreach (DirtData.EType item in Enum.GetValues(typeof(DirtData.EType)).Cast<DirtData.EType>())
			{
				m_dirtTypeCount.Add(item, 0);
			}
			SaveClass_Dirt dirt = SaveManager.CurrentSave.dirt;
			if (dirt.dirtDatas == null)
			{
				return;
			}
			foreach (SaveClass_Dirt.SaveDirtData dirtData in dirt.dirtDatas)
			{
				Spawner.Spawn(dirtData);
			}
		}

		private IEnumerator StartSpawning(DirtData.EType type, float delay)
		{
			yield return new WaitForSeconds(delay);
			m_spawnDirtRoutines[type] = null;
			SpawnDirt(type);
		}

		private void SpawnDirt(DirtData.EType type)
		{
			if (m_spawner != null)
			{
				IEnumerator enumerator = m_spawnDirtRoutines[type];
				if (enumerator != null)
				{
					StopCoroutine(enumerator);
				}
				enumerator = StartSpawning(type, TrySpawnDirt(type) ? DirtSettings.GetDirtSpawnCooldown(type) : DirtSettings.GetDirtSpawnTimer(type));
				StartCoroutine(enumerator);
				m_spawnDirtRoutines[type] = enumerator;
			}
		}

		private bool TrySpawnDirt(DirtData.EType type)
		{
			if (m_dirtTypeCount[type] >= DirtSettings.GetMaxDirtInShop(type))
			{
				return false;
			}
			if (World.Shop.ClientsInside.Count <= 0)
			{
				return false;
			}
			if (UnityEngine.Random.value > DirtSettings.GetDirtSpawnPercentage(type))
			{
				return false;
			}
			if (new HashSet<AIClientBehaviour>(World.Shop.ClientsInside).ToList().TryGetRandom((AIClientBehaviour client) => CanSpawnHere(client, type), out var value))
			{
				return m_spawner.Spawn(type, value.ClientCharacter.Position) != null;
			}
			return false;
		}

		private bool CanSpawnHere(AIClientBehaviour client, DirtData.EType type)
		{
			Collider[] array = new Collider[5];
			Physics.OverlapSphereNonAlloc(client.ClientCharacter.transform.position, DirtSettings.GetDirtSpawnFromDirtRadius(type), array, DirtSettings.BlockingLayerDirtSpawn);
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (collider == null)
				{
					continue;
				}
				Furniture component2;
				if (collider.TryGetComponent<Dirt>(out var component))
				{
					if (component.Type == type)
					{
						return false;
					}
				}
				else if (collider.attachedRigidbody != null && collider.attachedRigidbody.TryGetComponent<Furniture>(out component2))
				{
					return false;
				}
			}
			return true;
		}

		private void StopSpawning()
		{
			foreach (var (_, routine) in m_spawnDirtRoutines)
			{
				StopCoroutine(routine);
			}
		}
	}
}
