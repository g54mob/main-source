using Simulator.Menus;

namespace Tabletop.Menus
{
	public class TabletopMenus : Simulator.Menus.Menus
	{
		protected override void InitStaticSystems()
		{
			base.InitStaticSystems();
			JuiceManager.RegisterUpdate(register: true);
		}

		protected override void QuitStaticSystems()
		{
			base.QuitStaticSystems();
			JuiceManager.RegisterUpdate(register: false);
		}
	}
}
