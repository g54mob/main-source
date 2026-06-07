using System.Collections;
using SteamIntegrations;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts.BibiteScripts
{
	public class InternalClock : MonoBehaviour
	{
		private BibiteGenes gene;

		private NEATBrain brain;

		public UnityEvent OnAging;

		[SerializeField]
		internal int tic;

		[SerializeField]
		private float ticProgress;

		[SerializeField]
		internal float timeAlive;

		[SerializeField]
		internal float chronoTime;

		private float agingProgress;

		private float period;

		private bool isReady;

		private bool triggered1Day;

		private float resetDesire => brain.Output(NEATBrain.Outputs.ClkReset);

		private void InitClock()
		{
			gene = GetComponent<BibiteGenes>();
			brain = GetComponent<NEATBrain>();
		}

		public void StartClock()
		{
			InitClock();
			tic = 0;
			ticProgress = 0f;
			timeAlive = 0f;
			chronoTime = 0f;
			StartCoroutine("waitReady");
		}

		public void ResumeClock()
		{
			InitClock();
			StartCoroutine("waitReady");
		}

		private void FixedUpdate()
		{
			if (isReady && !(Time.timeScale <= 0f))
			{
				float fixedDeltaTime = Time.fixedDeltaTime;
				ticProgress += fixedDeltaTime;
				if (ticProgress >= period)
				{
					ticProgress -= period;
					tic = 1 - tic;
				}
				if (resetDesire > 0.75f)
				{
					chronoTime = 0f;
				}
				else
				{
					chronoTime += fixedDeltaTime;
				}
				agingProgress += fixedDeltaTime;
				if (agingProgress > 120f)
				{
					agingProgress = 0f;
					OnAging.Invoke();
				}
				timeAlive += fixedDeltaTime;
				if (!triggered1Day && !(timeAlive < 86400f))
				{
					AchievementManager.Trigger("ACH_BIBITE_1DAY", base.gameObject);
					triggered1Day = true;
				}
			}
		}

		private IEnumerator waitReady()
		{
			while (!brain.isReady)
			{
				yield return null;
			}
			period = gene.genes[14];
			isReady = true;
		}
	}
}
