using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class WaveSimulation
	{
		[SerializeField]
		[HideInInspector]
		private GameObject WaterGO;

		[SerializeField]
		[HideInInspector]
		private SpriteRenderer WaterSr;

		[SerializeField]
		[HideInInspector]
		private BoxCollider2D collider;

		[SerializeField]
		[HideInInspector]
		private BuoyancyEffector2D buoyancy;

		[SerializeField]
		[HideInInspector]
		private WaveSimulationSettings settings;

		[SerializeField]
		[HideInInspector]
		private Texture2D heights;

		[SerializeField]
		[HideInInspector]
		private WaveSimNode[] nodes;

		private float[] ld;

		private float[] rd;

		private int res => 0;

		private void CreateT()
		{
		}

		private void SetNodes()
		{
		}

		private void SetTextureData()
		{
		}

		private void CreateColliders()
		{
		}

		public void SetSettings(GameObject go, SpriteRenderer water, WaveSimulationSettings settings)
		{
		}

		public void Setup()
		{
		}

		private void AutoWaves()
		{
		}

		private void SimulateSingle()
		{
		}

		private void SimulateTogether()
		{
		}

		private void SetTexture()
		{
		}

		private void SetLevel(float l)
		{
		}

		public void Start()
		{
		}

		public void Update(float buy_lev)
		{
		}

		public void Collision(Collider2D c, float t)
		{
		}
	}
}
