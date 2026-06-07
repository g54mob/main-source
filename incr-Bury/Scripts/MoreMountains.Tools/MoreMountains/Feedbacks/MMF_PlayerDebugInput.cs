using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public class MMF_PlayerDebugInput : MonoBehaviour
	{
		public KeyCode PlayButton = KeyCode.P;

		protected MMF_Player _player;

		protected virtual void Awake()
		{
			_player = base.gameObject.GetComponent<MMF_Player>();
		}

		protected virtual void Update()
		{
			if (Input.GetKeyDown(PlayButton))
			{
				_player.PlayFeedbacks();
			}
		}
	}
}
