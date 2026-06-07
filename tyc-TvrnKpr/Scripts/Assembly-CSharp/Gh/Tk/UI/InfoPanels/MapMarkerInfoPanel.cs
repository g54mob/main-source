using System.Collections.Specialized;

namespace Gh.Tk.UI.InfoPanels
{
	public class MapMarkerInfoPanel : InfoPanel
	{
		public Container3DUIView actionList;

		public TextButton3DUIView actionButtonprefab;

		private MapMarker _mapMarker;

		public MapMarker MapMarker
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnContextMenuItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		public virtual void Refresh()
		{
		}

		public override void ShowInfo(MapMarker mapMarker)
		{
		}

		protected void UpdateActionList()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
