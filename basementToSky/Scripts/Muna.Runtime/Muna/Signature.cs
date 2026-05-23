using System;

namespace Muna
{
	[Serializable]
	[Preserve]
	public class Signature
	{
		public Parameter[] inputs;

		public Parameter[] outputs;
	}
}
