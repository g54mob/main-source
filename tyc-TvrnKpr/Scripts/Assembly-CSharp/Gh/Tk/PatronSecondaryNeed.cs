using System;
using LitJson;

namespace Gh.Tk
{
	public abstract class PatronSecondaryNeed : IPersistable, ICloneable
	{
		[JsonIgnore]
		public abstract string DisplayTitleKey { get; }

		public abstract bool CanTavernFulfillNeed(out string reasonKey);

		public virtual void OnPatronSpawned(Patron patron)
		{
		}

		public object Clone()
		{
			return null;
		}
	}
}
