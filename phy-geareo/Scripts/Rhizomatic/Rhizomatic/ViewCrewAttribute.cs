using System;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ViewCrewAttribute : CrewAttribute
	{
		public ViewCrewAttribute(Type viewType)
			: base(null)
		{
		}
	}
}
