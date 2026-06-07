using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class InfestationNestInfoPanel : GameObjectXInfoPanel
	{
		[SerializeField]
		protected Button3DUIView _cleanNestButton;

		[SerializeField]
		protected Button3DUIView _cleanNestWithBombButton;

		public override GameObjectX Gox
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
	}
}
