using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class WorkerPowerFeature : CTSBehaviour
	{
		public enum e_PowerFeatures
		{
			SirenSong_REMOVED = 0,
			Blinker = 1,
			Hypnosis = 2,
			ClearingMemory = 3,
			Invisibility = 4,
			VampireAura_REMOVED = 5,
			Reaper = 6,
			None = 7
		}

		[Inject(false)]
		private WorkerChoreAssigner _worker;

		private e_PowerFeatures _power = e_PowerFeatures.None;

		public static PowerFeatureTable PowerFeatureTable { get; private set; }

		public event Action OnPowerAdded;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (PowerFeatureTable == null)
			{
				PowerFeatureTable = Resources.LoadAll<PowerFeatureTable>("Scriptables/WorkerConfigs")[0];
			}
		}

		public bool UnlockRandomCapacity(e_PowerFeatures[] p_workerPowerFeatures)
		{
			if (_power != e_PowerFeatures.None)
			{
				return false;
			}
			e_PowerFeatures power = p_workerPowerFeatures[UnityEngine.Random.Range(0, p_workerPowerFeatures.Length)];
			SetPower(power);
			return true;
		}

		public bool UnlockCapacity(e_PowerFeatures p_workerPowerFeatures)
		{
			if (_power != e_PowerFeatures.None)
			{
				return false;
			}
			SetPower(p_workerPowerFeatures);
			return true;
		}

		public bool HavePower(e_PowerFeatures p_powerFeatures)
		{
			return _power == p_powerFeatures;
		}

		public e_PowerFeatures GetPower()
		{
			return _power;
		}

		public void SetPower(e_PowerFeatures power)
		{
			_power = power;
			_worker.RemovePriority(ChoreCategory.Witnesses);
			_worker.RemovePriority(ChoreCategory.Investigators);
			_worker.RemovePriority(ChoreCategory.Capture);
			switch (power)
			{
			case e_PowerFeatures.Hypnosis:
				_worker.AddPriority(ChoreCategory.Capture, 1);
				break;
			case e_PowerFeatures.ClearingMemory:
				_worker.AddPriority(ChoreCategory.Witnesses, 1);
				break;
			case e_PowerFeatures.Reaper:
				_worker.AddPriority(ChoreCategory.Investigators, 1);
				break;
			default:
				throw new ArgumentOutOfRangeException("power", power, null);
			case e_PowerFeatures.SirenSong_REMOVED:
			case e_PowerFeatures.Blinker:
			case e_PowerFeatures.Invisibility:
			case e_PowerFeatures.VampireAura_REMOVED:
			case e_PowerFeatures.None:
				break;
			}
			this.OnPowerAdded?.Invoke();
		}
	}
}
