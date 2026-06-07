using Ink.Runtime;

namespace Ink.Parsed
{
	public class TunnelOnwards : Object
	{
		private Divert _divertAfter;

		private DivertTargetValue _overrideDivertTarget;

		public Divert divertAfter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
