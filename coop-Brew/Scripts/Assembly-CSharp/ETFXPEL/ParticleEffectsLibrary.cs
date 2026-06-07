using System.Collections.Generic;
using UnityEngine;

namespace ETFXPEL
{
	public class ParticleEffectsLibrary : MonoBehaviour
	{
		public static ParticleEffectsLibrary GlobalAccess;

		public int TotalEffects;

		public int CurrentParticleEffectIndex;

		public int CurrentParticleEffectNum;

		public Vector3[] ParticleEffectSpawnOffsets;

		public float[] ParticleEffectLifetimes;

		public GameObject[] ParticleEffectPrefabs;

		private string effectNameString;

		private List<Transform> currentActivePEList;

		private Vector3 spawnPosition;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public string GetCurrentPENameString()
		{
			return null;
		}

		public void PreviousParticleEffect()
		{
		}

		public void NextParticleEffect()
		{
		}

		public void SpawnParticleEffect(Vector3 positionInWorldToSpawn)
		{
		}
	}
}
