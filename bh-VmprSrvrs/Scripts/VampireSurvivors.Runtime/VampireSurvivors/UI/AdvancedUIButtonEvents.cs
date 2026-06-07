using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AdvancedUIButtonEvents : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		private MultiplayerManager Multiplayer;

		private Rewired.Player Player;

		private bool _Selected;

		private bool _Pressed;

		public UnityEvent OnPressed;

		public UnityEvent OnUnpressed;

		public bool isPressed => false;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		[Inject]
		private void Construct(MultiplayerManager _mult)
		{
		}

		private void Update()
		{
		}
	}
}
