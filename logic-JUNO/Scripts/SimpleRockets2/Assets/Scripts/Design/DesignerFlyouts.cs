using System.Collections.Generic;
using ModApi.Design;
using ModApi.Ui;

namespace Assets.Scripts.Design
{
	public class DesignerFlyouts : IFlyouts
	{
		private List<IFlyout> _flyouts = new List<IFlyout>();

		public IReadOnlyList<IFlyout> All => _flyouts;

		public IFlyout CraftParts { get; private set; }

		public IFlyout LoadCraft { get; private set; }

		public IFlyout Menu { get; private set; }

		public IFlyout PartConnections { get; private set; }

		public IFlyout PartList { get; private set; }

		public IFlyout PartProperties { get; private set; }

		public IFlyout Preflight { get; private set; }

		public IFlyout Symmetry { get; private set; }

		public IFlyout Tools { get; private set; }

		public IFlyout ViewOptions { get; private set; }

		public IFlyout XMLedit { get; private set; }

		public void ClearFlyouts()
		{
			_flyouts.Clear();
		}

		public void RegisterFlyout(string id, IFlyout flyout)
		{
			_flyouts.Add(flyout);
			switch (id)
			{
			case "flyout-menu":
				Menu = flyout;
				break;
			case "flyout-craft-parts":
				CraftParts = flyout;
				break;
			case "flyout-part-list":
				PartList = flyout;
				break;
			case "flyout-load-craft":
				LoadCraft = flyout;
				break;
			case "flyout-part-properties":
				PartProperties = flyout;
				break;
			case "flyout-tools":
				Tools = flyout;
				break;
			case "flyout-preflight":
				Preflight = flyout;
				break;
			case "flyout-symmetry":
				Symmetry = flyout;
				break;
			case "flyout-part-connections":
				PartConnections = flyout;
				break;
			case "flyout-xml-edit":
				XMLedit = flyout;
				break;
			case "flyout-view":
				ViewOptions = flyout;
				break;
			}
		}
	}
}
