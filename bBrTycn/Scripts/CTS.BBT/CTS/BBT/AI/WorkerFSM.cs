using System;
using CTS.Core;
using CareBoo.Serially;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class WorkerFSM : FSM<Worker>, ISpreadUpdatable, IUpdatable
	{
		[SerializeField]
		private CareBoo.Serially.SerializableType _initState;

		public string TickKey { get; } = "Agent";

		private State<Worker> initState { get; set; } = new WorkerIdleState();

		protected override State<Worker> GetInitState()
		{
			if ((object)_initState.Type == null)
			{
				return initState;
			}
			return (State<Worker>)Activator.CreateInstance(_initState.Type);
		}

		protected override void OnEnabled()
		{
			UpdateSpreader.Add(this);
			UpdateSpreader.AddUpdate(this);
			base.OnEnabled();
		}

		protected override void OnDisabled()
		{
			UpdateSpreader.Remove(this);
			UpdateSpreader.RemoveUpdate(this);
			base.OnDisabled();
		}

		public void SpreadUpdate()
		{
			if (base.CurrentState is WorkerState workerState)
			{
				workerState.SpreadUpdate();
			}
		}

		public void OnUpdate()
		{
			if (base.CurrentState is WorkerState workerState)
			{
				workerState.Update();
			}
		}
	}
}
