using SettingScripts;
using SimulationScripts.Events;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class Pherosense : MonoBehaviour
	{
		public LayerMask pheroMask;

		public Collider2D[] elementsInSenseRadius;

		private float pheroDist;

		private static float SensePeriod = 0.5f;

		private float progress;

		public float pheroSum1;

		public float pheroSum2;

		public float pheroSum3;

		public float angleToPhero1;

		public float angleToPhero2;

		public float angleToPhero3;

		public float angleToPhero1Heading;

		public float angleToPhero2Heading;

		public float angleToPhero3Heading;

		private Vector2 headingConcentrationR;

		public bool usePheroSense;

		private BibiteGenes gene;

		private NEATBrain brain;

		private PheromoneSpot pheros;

		private static readonly BoolSetting EnableRedDeath = ScenarioSettings.Instance.enableRedDeath;

		private static bool enableRedDeath = EnableRedDeath.SubscribeTo<BoolSetting, bool>(UpdateEnableRedDeath);

		private static void UpdateEnableRedDeath(bool val)
		{
			enableRedDeath = val;
		}

		public void StartPherosensing()
		{
			if (!usePheroSense)
			{
				usePheroSense = true;
				gene = GetComponent<BibiteGenes>();
				brain = GetComponent<NEATBrain>();
				elementsInSenseRadius = new Collider2D[128];
				pheroDist = gene.genes[15];
				progress = SensePeriod * Random.Range(-0.5f, 0.5f);
			}
		}

		private void FixedUpdate()
		{
			if (usePheroSense && !(Time.timeScale <= 0f))
			{
				progress += Time.fixedDeltaTime;
				if (!(progress < SensePeriod))
				{
					progress -= SensePeriod;
					PherosenseAround();
				}
			}
		}

		private void PherosenseAround()
		{
			pheroSum1 = 0f;
			pheroSum2 = 0f;
			pheroSum3 = 0f;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			headingConcentrationR = Vector2.zero;
			Vector2 zero4 = Vector2.zero;
			Vector2 zero5 = Vector2.zero;
			int num = Physics2D.OverlapCircleNonAlloc(base.transform.position, pheroDist, elementsInSenseRadius, pheroMask);
			for (int i = 0; i < num && !(elementsInSenseRadius[i] == null); i++)
			{
				pheros = elementsInSenseRadius[i].gameObject.GetComponent<PheromoneSpot>();
				Vector3 vector = pheros.transform.position - base.transform.position;
				if (!(vector.sqrMagnitude <= 0f))
				{
					if (pheros.Rstrength > 0f)
					{
						float num2 = pheros.Rstrength / vector.magnitude;
						pheroSum1 += num2;
						zero += vector * num2;
						headingConcentrationR += pheros.heading * num2;
					}
					if (pheros.Gstrength > 0f)
					{
						float num3 = pheros.Gstrength / vector.magnitude;
						pheroSum2 += num3;
						zero2 += vector * num3;
						zero4 += pheros.heading * num3;
					}
					if (pheros.Bstrength > 0f)
					{
						float num4 = pheros.Bstrength / vector.magnitude;
						pheroSum3 += num4;
						zero3 += vector * num4;
						zero5 += pheros.heading * num4;
					}
				}
			}
			if (enableRedDeath)
			{
				Vector3 position = base.transform.position;
				float num5 = RedDeathBloomManager.safeRadius - position.magnitude;
				if (pheroDist > num5)
				{
					float num6 = 100f / Mathf.Max(1f, num5);
					pheroSum1 += num6;
					zero += position.normalized * (num5 * num6);
					headingConcentrationR += (Vector2)(-position.normalized) * num6;
				}
			}
			Vector2 vector2 = base.transform.up;
			angleToPhero1 = Vector2.SignedAngle(vector2, zero) / 180f;
			angleToPhero2 = Vector2.SignedAngle(vector2, zero2) / 180f;
			angleToPhero3 = Vector2.SignedAngle(vector2, zero3) / 180f;
			angleToPhero1Heading = Vector2.SignedAngle(vector2, headingConcentrationR) / 180f;
			angleToPhero2Heading = Vector2.SignedAngle(vector2, zero4) / 180f;
			angleToPhero3Heading = Vector2.SignedAngle(vector2, zero5) / 180f;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawLine(base.transform.position, base.transform.position + (Vector3)headingConcentrationR.normalized * 20f);
		}
	}
}
