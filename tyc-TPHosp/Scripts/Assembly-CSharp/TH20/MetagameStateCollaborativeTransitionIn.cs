using UnityEngine;

namespace TH20
{
	public class MetagameStateCollaborativeTransitionIn : MetagameState
	{
		private Transform _fixedCameraTransform;

		private bool _hasFadedOut;

		private bool _hasFadedIn;

		private bool _isFading;

		public MetagameStateCollaborativeTransitionIn(Transform fixedCameraTransform, MetagameMap map)
			: base(map)
		{
			_fixedCameraTransform = fixedCameraTransform;
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
				CameraGentleSwayComponent orAddComponent = MetagameMap.CameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraGentleSwayComponent>();
				orAddComponent.CameraSwayAmplitude = new Vector2(3f, 3f);
				orAddComponent.CameraSwayFrequency = new Vector2(0.41f, 0.73f);
				MetagameMap.CameraLogic.SetFixedTransform(_fixedCameraTransform);
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
