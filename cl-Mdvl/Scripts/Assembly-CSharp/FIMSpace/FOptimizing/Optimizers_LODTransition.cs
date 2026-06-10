using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_LODTransition
	{
		public bool done;

		public ILODInstance From;

		public ILODInstance To;

		private readonly ILODInstance tempLOD;

		private ILODInstance breakLOD;

		private Component sceneComponent;

		private ILODInstance initialLODSettings;

		public Optimizers_LODTransition(Component sceneComp, ILODInstance from, ILODInstance to, ILODInstance initialLODSettingsRef)
		{
			if (!initialLODSettingsRef.SupportingTransitions || OptimizersManager.InstantTransition > 0)
			{
				to.ApplySettingsToTheComponent(sceneComp, initialLODSettingsRef);
				To = null;
				done = true;
			}
			if (from == null || to == null || initialLODSettingsRef == null)
			{
				Debug.Log("[Optimizers Transitions] Uknown transition data! [" + from?.ToString() + "," + to?.ToString() + "," + initialLODSettingsRef?.ToString() + "]");
				to.ApplySettingsToTheComponent(sceneComp, initialLODSettingsRef);
				To = null;
				done = true;
			}
			else
			{
				From = from;
				tempLOD = from.GetCopy();
				To = to;
				sceneComponent = sceneComp;
				initialLODSettings = initialLODSettingsRef;
			}
		}

		public void BreakCurrentTransition(ILODInstance to)
		{
			done = false;
			if (tempLOD != null)
			{
				if (breakLOD == null)
				{
					breakLOD = tempLOD.GetCopy();
				}
				else
				{
					breakLOD.InterpolateBetween(breakLOD, tempLOD, 1f);
				}
			}
			else if (From != null)
			{
				if (breakLOD == null)
				{
					breakLOD = From.GetCopy();
				}
				else
				{
					breakLOD.InterpolateBetween(breakLOD, From, 1f);
				}
			}
			From = breakLOD;
			To = to;
		}

		public void Update(float progress, float secondsAfter = 0f)
		{
			if (To == null)
			{
				return;
			}
			tempLOD.InterpolateBetween(From, To, progress);
			tempLOD.ApplySettingsToTheComponent(sceneComponent, initialLODSettings);
			if (!(progress >= 1f))
			{
				return;
			}
			if (To.Disable)
			{
				if (To.ToCullDelay <= 0f)
				{
					done = true;
				}
				else if (secondsAfter >= To.ToCullDelay)
				{
					done = true;
				}
			}
			else
			{
				done = true;
			}
		}

		public void Finish()
		{
			if (To != null)
			{
				done = true;
				if (sceneComponent != null)
				{
					To.ApplySettingsToTheComponent(sceneComponent, initialLODSettings);
				}
			}
		}
	}
}
