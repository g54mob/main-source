using System.Collections.Generic;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_Transitioning
	{
		public Optimizer_Base Optimizer;

		public int Index = -1;

		private float elapsed;

		private float transitionDuration;

		private int targetLODLevel;

		private bool allDone;

		private List<Optimizers_LODTransition> lodTypes;

		public int Id { get; private set; }

		public bool Finished { get; private set; }

		public Optimizers_Transitioning(int optimizerId, Optimizer_Base optimizer, int targetLODLevel, float duration, int index = -1)
		{
			lodTypes = new List<Optimizers_LODTransition>();
			Reset(optimizerId, optimizer, targetLODLevel, duration, index);
		}

		public void Reset(int optimizerId, Optimizer_Base optimizer, int targetLODLevel, float duration, int index = -1)
		{
			Id = optimizerId;
			Finished = false;
			allDone = false;
			Optimizer = optimizer;
			this.targetLODLevel = targetLODLevel;
			transitionDuration = duration;
			elapsed = 0f;
			Index = index;
			InitTransitioning();
		}

		private void InitTransitioning()
		{
			lodTypes.Clear();
			for (int i = 0; i < Optimizer.GetToOptimizeCount(); i++)
			{
				lodTypes.Add(Optimizer.GetLodTransitionFor(i, targetLODLevel));
			}
			Optimizer.TransitionNextLOD = targetLODLevel;
			Optimizer.TransitionPercent = 0f;
		}

		internal void BreakCurrentTransition(float newDuration, int targetLODLevel)
		{
			transitionDuration = newDuration;
			this.targetLODLevel = targetLODLevel;
			elapsed = 0f;
			if (Optimizer != null)
			{
				BreakTransitioning();
			}
		}

		private void BreakTransitioning()
		{
			for (int i = 0; i < lodTypes.Count; i++)
			{
				lodTypes[i].BreakCurrentTransition(Optimizer.GetLODInstance(i, targetLODLevel));
			}
			Optimizer.TransitionNextLOD = targetLODLevel;
			Optimizer.TransitionPercent = -1f;
		}

		public void Finish()
		{
			Optimizer.SetLODLevel(targetLODLevel);
			for (int i = 0; i < lodTypes.Count; i++)
			{
				lodTypes[i].Finish();
			}
			Finished = true;
			Optimizer.TransitionNextLOD = 0;
			Optimizer.TransitionPercent = -1f;
		}

		public void Update(float deltaTime)
		{
			elapsed += deltaTime;
			if (allDone)
			{
				Finish();
				return;
			}
			if (Optimizer == null)
			{
				Finished = true;
				return;
			}
			float num = elapsed / transitionDuration;
			Optimizer.TransitionPercent = num;
			float secondsAfter = 0f;
			if (elapsed > transitionDuration)
			{
				secondsAfter = elapsed - transitionDuration;
			}
			if (!Optimizer.gameObject.activeInHierarchy)
			{
				Optimizer.gameObject.SetActive(value: true);
			}
			bool flag = true;
			for (int i = 0; i < lodTypes.Count; i++)
			{
				if (!lodTypes[i].done)
				{
					lodTypes[i].Update(num, secondsAfter);
					flag = false;
				}
			}
			if (num >= 1f)
			{
				allDone = flag;
			}
			else
			{
				allDone = false;
			}
		}
	}
}
