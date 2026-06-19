using System;
using Loxodon.Framework.Contexts;
using UI.HUD.Assistant;
using UnityEngine;

namespace Services.Markers
{
	public class WorldMarkerObjectView : MonoBehaviour
	{
		[SerializeField]
		private LayerMask _collisionLayer;

		private AssistantPopupViewModel _assistantPopupViewModel;

		private event Action _onTriggerEnter;

		public void Init(Action onMarkerEnter)
		{
			this._onTriggerEnter = onMarkerEnter;
		}

		private void Start()
		{
			_assistantPopupViewModel = Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if ((_collisionLayer.value & (1 << other.gameObject.layer)) != 0)
			{
				this._onTriggerEnter?.Invoke();
				_assistantPopupViewModel.Appear();
				_assistantPopupViewModel.SetSpeechBubbleVisible(value: true);
				_assistantPopupViewModel.SetSpeechBubbleText("Good! Now it's time to come back at email and take you award!");
			}
		}
	}
}
