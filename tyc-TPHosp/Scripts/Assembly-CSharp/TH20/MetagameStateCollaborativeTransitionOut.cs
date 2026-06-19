using UnityEngine;

namespace TH20
{
	public class MetagameStateCollaborativeTransitionOut : MetagameState
	{
		private bool _hasFadedOut;

		private bool _hasFadedIn;

		private bool _isFading;

		public MetagameStateCollaborativeTransitionOut(MetagameMap map)
			: base(map)
		{
			_hasFadedIn = false;
			_hasFadedOut = false;
			_isFading = false;
		}

		public override void Update()
		{
			if (_isFading)
			{
				return;
			}
			if (!_hasFadedOut)
			{
				MetagameMap.App.FadeOut(0.5f, Color.black, delegate
				{
					_isFading = false;
				});
				_isFading = true;
				_hasFadedOut = true;
			}
			else if (!_hasFadedIn)
			{
				CameraGentleSwayComponent component = MetagameMap.CameraLogic.CameraComponent.gameObject.GetComponent<CameraGentleSwayComponent>();
				if (component != null)
				{
					Object.Destroy(component);
				}
				MetagameMap.CameraLogic.SetFixedTransform(null);
				MetagameMap.App.FadeIn(0.5f, Color.black, delegate
				{
					_isFading = false;
				});
				_isFading = true;
				_hasFadedIn = true;
			}
			else
			{
				PopState();
			}
		}
	}
}
