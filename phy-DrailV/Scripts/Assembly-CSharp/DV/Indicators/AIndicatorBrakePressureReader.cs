using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Indicators
{
	public abstract class AIndicatorBrakePressureReader : MonoBehaviour
	{
		[FuseId]
		public string fuseId;

		protected TrainCar train;

		protected Fuse fuse;

		protected Indicator indicator;

		public abstract float GetPressureValue { get; }

		private void Awake()
		{
			train = TrainCar.Resolve(base.gameObject);
			indicator = GetComponent<Indicator>();
			if (indicator == null)
			{
				Debug.LogError("Can't find Indicator on " + base.gameObject.name + ". Ignoring init");
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			if (!string.IsNullOrEmpty(fuseId))
			{
				SimulationFlow simulationFlow = train.SimController?.simFlow;
				if (simulationFlow == null)
				{
					Debug.LogError("Couldn't find simFlow, ignoring fuseId won't be functional!");
				}
				else if (!simulationFlow.TryGetFuse(fuseId, out fuse))
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: AIndicatorBrakePressureReader isn't initialized properly, fuse won't be set");
				}
			}
		}

		private void Update()
		{
			if (fuse != null && !fuse.State)
			{
				indicator.Value = indicator.minValue;
			}
			else
			{
				indicator.Value = GetPressureValue;
			}
		}
	}
}
