using Ink.Runtime;

namespace Ink.Parsed
{
	public class DivertTarget : Expression
	{
		public Divert divert;

		private DivertTargetValue _runtimeDivertTargetValue;

		private Ink.Runtime.Divert _runtimeDivert;

		public DivertTarget(Divert divert)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
