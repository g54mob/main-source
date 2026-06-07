using DV.HUD;
using DV.Simulation.Cars;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoFuseStep : ALocoControlStep
	{
		private SimController sim;

		private Fuse fuse;

		public string FuseID { get; private set; }

		public bool TargetValue { get; private set; }

		public LocoFuseStep(string fuseID, bool targetValue, TrainCar loco, InteriorControlsManager.ControlType controlType, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			FuseID = fuseID;
			TargetValue = targetValue;
			sim = loco.GetComponentInChildren<SimController>();
			if (!sim.simFlow.TryGetFuse(fuseID, out fuse, canBeNull: true))
			{
				fuse = null;
			}
		}

		protected override bool InternalCheck()
		{
			if (fuse == null)
			{
				return true;
			}
			return fuse.State == TargetValue;
		}
	}
}
