using Ludiq;
using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("Bolt/Flow Machine")]
	[RequireComponent(typeof(Variables))]
	[DisableAnnotation]
	public sealed class FlowMachine : EventMachine<FlowGraph, FlowMacro>
	{
		public override FlowGraph DefaultGraph()
		{
			return FlowGraph.WithStartUpdate();
		}

		protected override void OnEnable()
		{
			if (base.hasGraph)
			{
				base.graph.StartListening(base.reference);
			}
			base.OnEnable();
		}

		protected override void OnInstantiateWhileEnabled()
		{
			if (base.hasGraph)
			{
				base.graph.StartListening(base.reference);
			}
			base.OnInstantiateWhileEnabled();
		}

		protected override void OnUninstantiateWhileEnabled()
		{
			base.OnUninstantiateWhileEnabled();
			if (base.hasGraph)
			{
				base.graph.StopListening(base.reference);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (base.hasGraph)
			{
				base.graph.StopListening(base.reference);
			}
		}

		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}
	}
}
