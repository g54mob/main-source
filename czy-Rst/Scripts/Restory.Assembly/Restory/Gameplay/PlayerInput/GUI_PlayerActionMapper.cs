using Restory.UserInterface;

namespace Restory.Gameplay.PlayerInput
{
	public class GUI_PlayerActionMapper : PlayerActionMapperBase
	{
		private GUI_ScreenObjectBase screenObjectBase;

		private void OnEnable()
		{
			screenObjectBase = GetComponent<GUI_ScreenObjectBase>();
			if ((bool)screenObjectBase)
			{
				screenObjectBase.OnShown.AddListener(Initialize);
				screenObjectBase.OnHidden.AddListener(base.UnsubscribeAll);
				screenObjectBase.OnClosed.AddListener(base.UnsubscribeAll);
			}
		}

		private void OnDisable()
		{
			if ((bool)screenObjectBase)
			{
				screenObjectBase.OnShown.RemoveListener(Initialize);
				screenObjectBase.OnHidden.RemoveListener(base.UnsubscribeAll);
				screenObjectBase.OnClosed.RemoveListener(base.UnsubscribeAll);
			}
		}
	}
}
