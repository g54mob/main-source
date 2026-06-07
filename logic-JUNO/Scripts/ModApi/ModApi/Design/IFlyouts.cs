using System.Collections.Generic;
using ModApi.Ui;

namespace ModApi.Design
{
	public interface IFlyouts
	{
		IReadOnlyList<IFlyout> All { get; }

		IFlyout CraftParts { get; }

		IFlyout LoadCraft { get; }

		IFlyout Menu { get; }

		IFlyout PartConnections { get; }

		IFlyout PartList { get; }

		IFlyout PartProperties { get; }

		IFlyout Preflight { get; }

		IFlyout Symmetry { get; }

		IFlyout Tools { get; }

		IFlyout ViewOptions { get; }

		IFlyout XMLedit { get; }
	}
}
