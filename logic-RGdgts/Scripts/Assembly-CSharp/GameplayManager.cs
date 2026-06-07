using System.Collections.Generic;
using Sirenix.OdinInspector;

public abstract class GameplayManager : SerializedMonoBehaviour
{
	protected HashSet<ModulesDrawerBehaviour> moduleDrawers;

	protected HashSet<ModuleGestalt.ModuleCategory> modulesVisibilityInDrawerChanged;

	protected bool motherboardVisibilityInDrawerChanged;

	public abstract void Init();

	public abstract bool IsLocked(GameplayInteraction interaction);

	public abstract bool IsAvailable(GameplayInteraction interaction);

	public abstract bool IsModuleAvailable(ModuleGestaltVariationEnum variation);

	public abstract bool IsModuleVisibleInDrawer(ModuleGestaltVariationEnum variation);

	public abstract bool IsMotherboardAvailable(MotherboardSectionEnum variation);

	public abstract bool IsMotherboardVisibleInDrawer(MotherboardSectionEnum variation);

	public virtual void OnDayEndInteraction()
	{
	}

	public abstract bool SkipIntro();

	public void RegisterModulesDrawer(ModulesDrawerBehaviour drawer)
	{
	}

	public void UnregisterModulesDrawer(ModulesDrawerBehaviour drawer)
	{
	}

	protected virtual void LateUpdate()
	{
	}
}
