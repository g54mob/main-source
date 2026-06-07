using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions.Helper
{
	public class TerrainRebuilder : MonoBehaviour
	{
		private float _radius;

		private float _strength;

		public void Init(float radius, float strength)
		{
			_radius = radius;
			_strength = strength;
			StartCoroutine(RebuildTerrain());
		}

		private IEnumerator RebuildTerrain()
		{
			float progress = 0f;
			while (progress <= 1f)
			{
				TerrainModificationHelper.LerpRebuildTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, base.transform.position, _radius, _strength * Time.deltaTime);
				progress += _strength * Time.deltaTime;
				yield return true;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
