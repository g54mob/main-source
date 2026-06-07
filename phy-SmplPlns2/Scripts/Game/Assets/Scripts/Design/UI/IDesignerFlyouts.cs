using System;
using Assets.Scripts.UI;

namespace Assets.Scripts.Design.UI
{
	public interface IDesignerFlyouts
	{
		IFlyout Blueprints { get; }

		IFlyout CraftProperties { get; }

		IFlyout DragVisualizer { get; }

		IFlyout Environment { get; }

		IFlyout FuselageShape { get; }

		IFlyout JFuselageShape { get; }

		IFlyout LoadCraft { get; }

		IFlyout Menu { get; }

		IFlyout Paint { get; }

		IFlyout PartConnections { get; }

		IFlyout PartList { get; }

		IFlyout PartProperties { get; }

		IFlyout SearchParts { get; }

		IFlyout Selected { get; set; }

		IFlyout Symmetry { get; }

		IFlyout TransformPart { get; }

		IFlyout Tutorials { get; }

		IFlyout UndoHistory { get; }

		IFlyout WingEditor { get; }

		IFlyout FindById(string id);

		void SelectFlyoutAndQueueAction(IFlyout flyout, Action<IFlyout> flyoutOpenedAction);

		void ToggleFlyout(IFlyout flyout);
	}
}
