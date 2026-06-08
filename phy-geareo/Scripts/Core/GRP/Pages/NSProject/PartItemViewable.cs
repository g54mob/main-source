using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Pages.NSProject
{
	public class PartItemViewable : Viewable, IListItemView<Part>
	{
		[TextCrew]
		public StateSelector<string> name;

		[GameObjectCrew]
		public StateSelector<bool> selected;

		public Part model { get; }

		public PartItemViewable(Part model)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}
