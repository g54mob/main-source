using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[RequireComponent(typeof(CanvasGroup))]
	public class UI_CollectionIconDisplayer : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup m_canvasGroup;

		private void OnEnable()
		{
			InputManager.MapChanged += OnMapChanged;
		}

		private void OnDisable()
		{
			InputManager.MapChanged -= OnMapChanged;
		}

		private void OnMapChanged(InputManager.EMap _Map)
		{
			bool flag = _Map == InputManager.EMap.PLAYER;
			IPlayerInputReceiver receiver;
			bool flag2 = IPlayerInputReceiver.HasCurrent(out receiver) && receiver is ITabletopPlayerInputReceiver;
			m_canvasGroup.alpha = ((flag && flag2) ? 1f : 0f);
		}
	}
}
