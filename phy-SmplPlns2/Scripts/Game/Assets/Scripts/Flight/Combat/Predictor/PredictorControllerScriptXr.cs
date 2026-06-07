using CurvedUI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class PredictorControllerScriptXr : PredictorControllerScript
	{
		[SerializeField]
		private Image _aimReticle;

		private CurvedUISettings _curvedUI;

		[SerializeField]
		private Image _gunAimReticle;

		[SerializeField]
		private Image _targetReticle;

		protected override MonoBehaviour AimReticle => _aimReticle;

		protected override MonoBehaviour GunReticle => _gunAimReticle;

		protected override MonoBehaviour TargetReticle => _targetReticle;

		protected override void Awake()
		{
			base.Awake();
			_curvedUI = GetComponentInParent<CurvedUISettings>();
		}

		protected override Quaternion GetRotation(Vector3 forward)
		{
			return Quaternion.LookRotation(forward);
		}

		protected override Vector3 GetScreenPos(Vector3 worldPos, out bool shouldDisplay)
		{
			Vector3 position = _mainCamera.transform.position;
			_curvedUI.RaycastToCanvasSpace(new Ray(position, (worldPos - position).normalized), out var o_positionOnCanvas);
			shouldDisplay = true;
			return o_positionOnCanvas;
		}

		protected override Vector3 GetWorldPoint(Vector3 screenPos)
		{
			return _curvedUI.CanvasToCurvedCanvas(screenPos);
		}

		protected override void SetReticleColor(MonoBehaviour reticle, Color color)
		{
			(reticle as Image).color = color;
		}
	}
}
