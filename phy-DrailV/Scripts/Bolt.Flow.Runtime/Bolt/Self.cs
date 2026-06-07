using Ludiq;
using UnityEngine;

namespace Bolt
{
	[SpecialUnit]
	public sealed class Self : Unit
	{
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput self { get; private set; }

		protected override void Definition()
		{
			self = ValueOutput("self", Result).PredictableIf(IsPredictable);
		}

		private GameObject Result(Flow flow)
		{
			return flow.stack.self;
		}

		private bool IsPredictable(Flow flow)
		{
			return flow.stack.self != null;
		}
	}
}
