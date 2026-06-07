using ManagementScripts;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts
{
	public class PheromoneSpot : MonoBehaviour
	{
		[SerializeField]
		public Vector2 heading;

		[SerializeField]
		public float Rstrength;

		[SerializeField]
		public float Gstrength;

		[SerializeField]
		public float Bstrength;

		[SerializeField]
		public float nR;

		[SerializeField]
		public float nG;

		[SerializeField]
		public float nB;

		private const float RateOfEmission = 5f;

		private const float RateOfDissipation = 0.25f;

		private const float DissipationPeriod = 0.25f;

		private float dissipationProgress;

		private static readonly FloatUserSetting PheromonesStrength = UserSettings.pheromonesStrength;

		private static float pheromonesStrength;

		private static void UpdatePheromonesStrength(float val)
		{
			pheromonesStrength = val;
		}

		private void Awake()
		{
			pheromonesStrength = PheromonesStrength.SubscribeTo<FloatUserSetting, float>(UpdatePheromonesStrength);
		}

		public void InitPheromones(float _r, float _g, float _b, Vector2 _heading)
		{
			Rstrength = _r;
			Gstrength = _g;
			Bstrength = _b;
			nR = ((pheromonesStrength > 0.01f) ? (Mathf.Sqrt(pheromonesStrength) * Random.Range(0.5f, 1.5f)) : 0f);
			nG = ((pheromonesStrength > 0.01f) ? (Mathf.Sqrt(pheromonesStrength) * Random.Range(0.5f, 1.5f)) : 0f);
			nB = ((pheromonesStrength > 0.01f) ? (Mathf.Sqrt(pheromonesStrength) * Random.Range(0.5f, 1.5f)) : 0f);
			base.transform.rotation.SetLookRotation(_heading);
			heading = _heading;
		}

		private void FixedUpdate()
		{
			if (Time.timeScale <= 0f)
			{
				return;
			}
			dissipationProgress += Time.fixedDeltaTime;
			if (Rstrength <= 0f && Gstrength <= 0f && Bstrength <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
			else if (!(dissipationProgress < 0.25f))
			{
				float num = (float)(int)(dissipationProgress / 0.25f) * 0.25f;
				dissipationProgress -= num;
				if (Rstrength > 0f)
				{
					Rstrength -= num * 0.25f;
					nR += 1.25f * pheromonesStrength;
				}
				if (Gstrength > 0f)
				{
					Gstrength -= num * 0.25f;
					nG += 1.25f * pheromonesStrength;
				}
				if (Bstrength > 0f)
				{
					Bstrength -= num * 0.25f;
					nB += 1.25f * pheromonesStrength;
				}
				ParticlesMaster.Instance.EmitPheromonesAtPosition(base.transform.position, nR, nG, nB);
				nR %= 1f;
				nG %= 1f;
				nB %= 1f;
			}
		}

		private void OnDestroy()
		{
			PheromonesStrength.UnSubscribeTo<FloatUserSetting, float>(UpdatePheromonesStrength);
		}
	}
}
