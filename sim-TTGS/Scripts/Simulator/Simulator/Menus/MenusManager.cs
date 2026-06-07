using UnityEngine;

namespace Simulator.Menus
{
	public abstract class MenusManager : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
		}

		protected virtual void OnDisable()
		{
			EventManager.OnMenuEvent -= OnMenuEvent;
		}

		protected virtual void OnMenuEvent(EMenuEvent menuEvent)
		{
			if (menuEvent == EMenuEvent.MENU_REGISTRATION)
			{
				Menus.RegisterSingleton(this);
			}
		}
	}
}
