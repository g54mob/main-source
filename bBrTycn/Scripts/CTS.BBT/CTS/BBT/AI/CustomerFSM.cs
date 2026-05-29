using System;
using CTS.Core;
using CareBoo.Serially;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class CustomerFSM : FSM<Customer>, ISpreadUpdatable, IUpdatable
	{
		[SerializeField]
		private CareBoo.Serially.SerializableType _initState;

		public string TickKey { get; } = "Agent";

		private State<Customer> initState { get; set; } = new CustomerIdleState();

		protected override State<Customer> GetInitState()
		{
			if (_initState == null)
			{
				return initState;
			}
			return (State<Customer>)Activator.CreateInstance(_initState.Type);
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
			if (base.CurrentState is CustomerState customerState)
			{
				customerState.SpreadUpdate();
			}
		}

		public void OnUpdate()
		{
			if (base.CurrentState is CustomerState customerState)
			{
				customerState.Update();
			}
		}
	}
}
