using System;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ViewLoaderCrewAttribute : CrewAttribute
	{
		public ViewLoaderCrewAttribute(Type viewLoaderType)
			: base(null)
		{
		}

		public ViewLoaderCrewAttribute()
			: base(null)
		{
		}
	}
}
