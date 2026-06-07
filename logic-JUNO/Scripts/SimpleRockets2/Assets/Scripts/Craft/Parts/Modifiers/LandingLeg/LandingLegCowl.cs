using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegCowl : LandingLegCommon
	{
		private Transform _foot;

		private Transform _footSupport1;

		private Transform _footSupport2;

		private Transform _movingAssembly;

		private Transform _refPoint;

		private Transform _support1;

		private Transform _support2;

		private Transform _suspensionRoot;

		public LandingLegCowl(LandingLegScript landingLegScript)
			: base(landingLegScript)
		{
			_support1 = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLegPivotBase1", base.GameObject).transform;
			_support2 = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLegPivotBase2", base.GameObject).transform;
			_footSupport1 = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLegPivotFoot1", base.GameObject).transform;
			_footSupport2 = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLegPivotFoot2", base.GameObject).transform;
			_refPoint = Utilities.FindFirstGameObjectMyselfOrChildren("RefPoint", base.GameObject).transform;
			_movingAssembly = Utilities.FindFirstGameObjectMyselfOrChildren("MovingAssembly", base.GameObject).transform;
			_suspensionRoot = Utilities.FindFirstGameObjectMyselfOrChildren("SuspensionRoot", base.GameObject).transform;
			_foot = Utilities.FindFirstGameObjectMyselfOrChildren("LandingLegFoot", base.GameObject).transform;
			UpdateScale();
			SetDeploymentState(base.Data.ExtensionPercentage, Game.InFlightScene);
		}

		public override void PrepareForPartIcon()
		{
			SetDeploymentState(1f, flight: false);
		}

		protected override void SetDeploymentState(float extensionPercentage, bool flight)
		{
			extensionPercentage = Mathf.Clamp01(extensionPercentage);
			base.Data.CurrentRotation = new Vector3(Mathf.Lerp(0f, base.Data.DeployedAngle, extensionPercentage), 0f, 0f);
			_support1.localRotation = Quaternion.Euler(base.Data.CurrentRotation);
			_support2.localRotation = _support1.localRotation;
			float t = Mathf.Clamp01((extensionPercentage - 0.6f) / 0.4f);
			_footSupport1.localRotation = Quaternion.Euler(new Vector3(Mathf.Lerp(0f, 125.701f, t), 0f, 0f));
			_footSupport2.localRotation = Quaternion.Euler(new Vector3(Mathf.Lerp(0f, -141.091f, t), 0f, 0f));
			_movingAssembly.position = _refPoint.position;
			if (flight)
			{
				base.Suspension.Data.SuspensionDistance = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				float y = 0f - (base.Suspension.CurrentDistance - base.Suspension.Data.MinSuspensionDistance);
				_suspensionRoot.localPosition = new Vector3(0f, y, 0f);
				_foot.localRotation = Quaternion.Euler(Mathf.Lerp(0f, 90f, t), 0f, 0f);
			}
			else
			{
				float num = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				_suspensionRoot.localPosition = new Vector3(0f, 0f - (num - base.Suspension.Data.MinSuspensionDistance), 0f);
				_foot.localRotation = Quaternion.Euler(Mathf.Lerp(0f, 90f, t), 0f, 0f);
			}
		}
	}
}
