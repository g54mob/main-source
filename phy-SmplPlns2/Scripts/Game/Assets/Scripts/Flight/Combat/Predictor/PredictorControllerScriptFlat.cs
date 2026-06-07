using Assets.Scripts.Flight.UI.Targeting;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class PredictorControllerScriptFlat : PredictorControllerScript
	{
		private ImageWidget _aimReticle;

		private Camera _camera;

		private ImageWidget _gunAimReticle;

		private Widget _parentWidget;

		private ImageWidget _targetReticle;

		protected override MonoBehaviour AimReticle => _aimReticle;

		protected override MonoBehaviour GunReticle => _gunAimReticle;

		protected override MonoBehaviour TargetReticle => _targetReticle;

		public void Initialize(Camera camera, TargetingScript targetingScript, Widget rootWidget)
		{
			_camera = camera;
			_aimReticle = rootWidget.FindWidget<ImageWidget>("aim-reticle");
			_gunAimReticle = rootWidget.FindWidget<ImageWidget>("gun-lead-reticle");
			_targetReticle = rootWidget.FindWidget<ImageWidget>("bomb-reticle");
			_parentWidget = _targetReticle.Parent;
			InitializePredictors(targetingScript);
		}

		protected override Vector3 GetScreenPos(Vector3 worldPos, out bool shouldDisplay)
		{
			Vector3 result = _mainCamera.WorldToScreenPoint(worldPos);
			shouldDisplay = result.z >= 0f;
			return result;
		}

		protected override Vector3 GetWorldPoint(Vector3 screenPos)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentWidget.Rect, screenPos, null, out var localPoint);
			return _parentWidget.Rect.TransformPoint(localPoint);
		}

		protected override void SetReticleColor(MonoBehaviour reticle, Color color)
		{
			(reticle as ImageWidget).Color.Base = color;
		}

		protected override void Start()
		{
		}
	}
}
