using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class CritterInfoPanel : InfoPanel
	{
		public GameObject PreviewParent;

		private Critter _critter;

		private GameObject _model;

		public virtual Critter Critter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}
	}
}
