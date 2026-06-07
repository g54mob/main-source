using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class StaffInfoPanel : InfoPanel
	{
		[SerializeField]
		private BaseInteractable3DUIView _followTargetButton;

		public StaffInfoPanelElement staffInfoPanelElement;

		private Staff _staff;

		public virtual Staff Staff
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		public override void ShowInfo(GameObjectX gox)
		{
		}
	}
}
