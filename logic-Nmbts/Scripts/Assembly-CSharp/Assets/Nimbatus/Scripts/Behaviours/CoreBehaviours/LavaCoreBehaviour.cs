using System.Collections;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class LavaCoreBehaviour : CoreBehaviour
	{
		public float TemperatureChangePerSecond;

		public GameObject PlanetCore;

		public float MinScale = 50f;

		private float _maxScale = 100f;

		public float PauseTime = 5f;

		public AnimationCurve AnimC;

		private bool _stopCoroutine;

		protected override void OnInit()
		{
			_stopCoroutine = false;
			OwnWorldObject.StartCoroutine(ScaleCoroutine());
			WorldController.HasExpandingPlanetCore = true;
			_maxScale = (float)WorldController.TerrainSettings.PlanetSize * 2f;
		}

		private IEnumerator ScaleCoroutine()
		{
			float startTime = Time.time;
			float duration = 30f;
			float animTime = 0f;
			while (!_stopCoroutine)
			{
				animTime += Time.deltaTime;
				float num = AnimC.Evaluate(animTime);
				PlanetCore.transform.localScale = new Vector3(_maxScale * num, _maxScale * num, 1f);
				WorldController.PlanetCoreRadius = _maxScale * num / 2f;
				WorldController.PlanetCoreTemperature = TemperatureChangePerSecond;
				if (startTime + duration < Time.time)
				{
					yield return new WaitForSeconds(PauseTime);
					startTime = Time.time;
				}
				yield return null;
			}
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnRelease()
		{
			_stopCoroutine = false;
			WorldController.HasExpandingPlanetCore = false;
		}
	}
}
