using System;
using System.Collections;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.A
{
	[Serializable]
	public class TimeToLive : MonoBehaviour
	{
		public MeshRenderer MeshRenderer;

		public ParticleSystem ParticleSystem;

		[SerializeField]
		public float TimeToLiveInSeconds = 10f;

		private void Awake()
		{
			StartCoroutine(DestroyAfterTime());
		}

		private IEnumerator DestroyAfterTime()
		{
			yield return new WaitForSeconds(TimeToLiveInSeconds);
			if (MeshRenderer != null && ParticleSystem != null)
			{
				MeshRenderer.enabled = false;
				ParticleSystem.MainModule main = ParticleSystem.main;
				main.startColor = MeshRenderer.material.color;
				ParticleSystem.Play();
			}
			yield return new WaitForSeconds(5f);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
