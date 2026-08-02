using System;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Pages.NSNewPart
{
	public class PartItemViewable : Viewable
	{
		[TextCrew]
		public string name;

		public PartConfig part;

		public Action select;

		public PartItemViewable(PartConfig part, Action select)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}
