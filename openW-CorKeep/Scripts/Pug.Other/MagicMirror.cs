public class MagicMirror : EntityMonoBehaviour
{
	public virtual void Use()
	{
		Manager.input.StartMenuInputCooldown(0.05f);
		Manager.menu.PushMenu(RadicalMenu.MenuType.MAGIC_MIRROR);
	}

	public void OnPlayerLeftBuilding()
	{
		Manager.menu.PopAllMenus();
	}
}
