using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate.Examples
{
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(AudioSource))]
	public class ItemSpawner : MonoBehaviour
	{
		[Serializable]
		private struct ItemToSpawn
		{
			public ItemPickup ItemPickup;

			public int Amount;
		}

		public enum ItemSpawnSuccesion
		{
			InOrder = 0,
			Random = 1
		}

		[BHeader("General", true)]
		[SerializeField]
		private bool OneTimeSpawn;

		[SerializeField]
		private ItemSpawnSuccesion m_SpawnType;

		[SerializeField]
		private ItemToSpawn[] m_ItemsToSpawn;

		[SerializeField]
		private Vector3 m_RandomRotation = Vector3.zero;

		[SerializeField]
		private ParticleSystem m_ParticleEffects;

		[BHeader("Delays")]
		[SerializeField]
		private float m_CanSpawnDelay = 10f;

		[SerializeField]
		private float m_InitialItemSpawnDelay = 0.5f;

		[SerializeField]
		private float m_DelayBetweenItemSpawns = 0.1f;

		[SerializeField]
		private float m_ItemDestroyDelay = 15f;

		[BHeader("Audio")]
		[SerializeField]
		private SoundPlayer m_StartSpawnAudio;

		[SerializeField]
		private SoundPlayer m_EndSpawnAudio;

		private BoxCollider m_Collider;

		private AudioSource m_AudioSource;

		private int m_ItemsToSpawnCount;

		private float m_NextTimeCanSpawn;

		private bool m_CanSpawn = true;

		private WaitForSeconds m_TimeBetweenSpawns;

		private WaitForSeconds m_ItemDestroyWait;

		public void SpawnItems(int maxSpawnCount)
		{
			if (!(Time.time > m_NextTimeCanSpawn) || !m_CanSpawn)
			{
				return;
			}
			maxSpawnCount = Mathf.Clamp(maxSpawnCount, 0, m_ItemsToSpawn.Length);
			m_NextTimeCanSpawn = Time.time + m_CanSpawnDelay;
			List<ItemPickup> list = new List<ItemPickup>();
			if (m_SpawnType == ItemSpawnSuccesion.InOrder)
			{
				for (int i = 0; i < m_ItemsToSpawn.Length; i++)
				{
					if (m_ItemsToSpawnCount >= maxSpawnCount)
					{
						break;
					}
					for (int j = 0; j < m_ItemsToSpawn[i].Amount; j++)
					{
						if (m_ItemsToSpawnCount >= maxSpawnCount)
						{
							break;
						}
						list.Add(m_ItemsToSpawn[i].ItemPickup);
						m_ItemsToSpawnCount++;
					}
				}
			}
			else if (m_SpawnType == ItemSpawnSuccesion.Random)
			{
				for (int k = 0; k < maxSpawnCount; k++)
				{
					int num = UnityEngine.Random.Range(k, m_ItemsToSpawn.Length);
					ItemToSpawn itemToSpawn = m_ItemsToSpawn[num];
					if (m_ItemsToSpawn[k].ItemPickup != itemToSpawn.ItemPickup)
					{
						ItemToSpawn itemToSpawn2 = m_ItemsToSpawn[k];
						m_ItemsToSpawn[k] = itemToSpawn;
						m_ItemsToSpawn[num] = itemToSpawn2;
					}
					list.Add(itemToSpawn.ItemPickup);
				}
			}
			StartCoroutine(C_SpawnItems(list));
		}

		private Vector3 RandomPointInBounds(Bounds bounds)
		{
			return new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
		}

		private void Start()
		{
			m_Collider = GetComponent<BoxCollider>();
			m_AudioSource = GetComponent<AudioSource>();
			m_TimeBetweenSpawns = new WaitForSeconds(m_DelayBetweenItemSpawns);
			m_ItemDestroyWait = new WaitForSeconds(m_ItemDestroyDelay);
		}

		private IEnumerator C_SpawnItems(List<ItemPickup> itemsToSpawn)
		{
			yield return new WaitForSeconds(m_InitialItemSpawnDelay);
			m_StartSpawnAudio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource);
			for (int i = 0; i < itemsToSpawn.Count; i++)
			{
				if (itemsToSpawn[i] != null)
				{
					Quaternion rotation = Quaternion.Euler(UnityEngine.Random.Range(0f - Mathf.Abs(m_RandomRotation.x), Mathf.Abs(m_RandomRotation.x)), UnityEngine.Random.Range(0f - Mathf.Abs(m_RandomRotation.y), Mathf.Abs(m_RandomRotation.y)), UnityEngine.Random.Range(0f - Mathf.Abs(m_RandomRotation.z), Mathf.Abs(m_RandomRotation.z)));
					ItemPickup itemPickup = UnityEngine.Object.Instantiate(itemsToSpawn[i], RandomPointInBounds(m_Collider.bounds), rotation);
					StartCoroutine(C_DelayedItemDestroy(itemPickup));
					if (m_ParticleEffects != null)
					{
						UnityEngine.Object.Instantiate(m_ParticleEffects, itemPickup.transform.position, rotation);
					}
					yield return m_TimeBetweenSpawns;
				}
			}
			if (OneTimeSpawn)
			{
				m_CanSpawn = false;
			}
			m_ItemsToSpawnCount = 0;
			m_EndSpawnAudio.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource);
		}

		private IEnumerator C_DelayedItemDestroy(ItemPickup item)
		{
			yield return m_ItemDestroyWait;
			if (item != null)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
	}
}
