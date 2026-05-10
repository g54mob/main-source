using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;

namespace CTS
{
	public class PanicCounter : CTSBehaviour
	{
		private readonly List<Agent> _panickingAgents = new List<Agent>();

		private static readonly StringKey _canvasGroupExclusivity = "MainCanvases";

		public ReadOnlyList<Agent> PanickingAgents => _panickingAgents;

		public static bool IsPanicActive { get; private set; }

		public event Action<Agent, bool> AgentPanicked;

		public static event Action<bool> PanicActive;

		[Button(null, EButtonEnableMode.Playmode)]
		private void SimulatePanicOn()
		{
			IsPanicActive = true;
			PanicCounter.PanicActive?.Invoke(obj: true);
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void SimulatePanicOff()
		{
			IsPanicActive = false;
			PanicCounter.PanicActive?.Invoke(obj: false);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			IsPanicActive = _panickingAgents.Count > 0;
			ContextualStatePanicking.Panicking += AddAgent;
			ContextualStatePanicking.StoppedPanicking += RemoveAgent;
			Agent.LeavingBar += RemoveAgent;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			ContextualStatePanicking.Panicking -= AddAgent;
			ContextualStatePanicking.StoppedPanicking -= RemoveAgent;
			Agent.LeavingBar -= RemoveAgent;
			IsPanicActive = false;
			while (_panickingAgents.Count > 0)
			{
				Agent agent = _panickingAgents[0];
				RemoveAgent(agent);
				_panickingAgents.Remove(agent);
			}
		}

		private void AddAgent(Agent agent)
		{
			if (!_panickingAgents.Contains(agent) && !agent.GetComponent<Wanderer>())
			{
				_panickingAgents.Add(agent);
				this.AgentPanicked?.Invoke(agent, arg2: true);
				agent.Despawned += RemoveAgent;
				if (_panickingAgents.Count == 1)
				{
					CanvasExclusivity.Close(null, _canvasGroupExclusivity);
					IsPanicActive = true;
					PanicCounter.PanicActive?.Invoke(obj: true);
				}
			}
		}

		private void RemoveAgent(Agent agent)
		{
			agent.Despawned -= RemoveAgent;
			if (_panickingAgents.Contains(agent))
			{
				_panickingAgents.Remove(agent);
				this.AgentPanicked?.Invoke(agent, arg2: false);
				if (_panickingAgents.Count <= 0)
				{
					IsPanicActive = false;
					PanicCounter.PanicActive?.Invoke(obj: false);
				}
			}
		}
	}
}
