using System;

namespace Coherence
{
	[Serializable]
	public abstract class BaseDefinition
	{
		public int id;

		public string name;

		protected BaseDefinition(string name)
		{
		}
	}
}
