using System.Collections.Generic;
using GRP.Pages.NSNewPart;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NewPartPage : Page
	{
		[ListLoaderCrew]
		public List<PartItemViewable> parts;

		public readonly Project project;

		public NewPartPage(Project project)
		{
		}

		public override void OnContext()
		{
		}

		public void SelectPart(PartConfig partConfig)
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
