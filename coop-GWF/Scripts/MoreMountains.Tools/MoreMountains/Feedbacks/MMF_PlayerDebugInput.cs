using UnityEngine;
using UnityEngine.InputSystem;

namespace MoreMountains.Feedbacks
{
	public class MMF_PlayerDebugInput : MonoBehaviour
	{
		public Key PlayKey = Key.P;

		protected MMF_Player _player;

		protected virtual void Awake()
		{
			_player = base.gameObject.GetComponent<MMF_Player>();
		}

		protected virtual void Update()
		{
			if (Keyboard.current[PlayKey].wasPressedThisFrame)
			{
				_player.PlayFeedbacks();
			}
		}
	}
}
