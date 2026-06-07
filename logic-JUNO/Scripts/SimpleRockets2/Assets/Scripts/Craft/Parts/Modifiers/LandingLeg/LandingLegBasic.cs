using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegBasic : LandingLegCommon
	{
		private Transform _foot;

		private Transform _pivot;

		private Transform _supportArm;

		private Transform _supportArmTarget;

		private Transform _suspensionRoot;

		public LandingLegBasic(LandingLegScript landingLegScript)
			: base(landingLegScript)
		{
			_pivot = Utilities.FindFirstGameObjectMyselfOrChildren("Pivot", base.GameObject).transform;
			_foot = Utilities.FindFirstGameObjectMyselfOrChildren("Foot", base.GameObject).transform;
			_supportArm = Utilities.FindFirstGameObjectMyselfOrChildren("SupportArm", base.GameObject).transform;
			_supportArmTarget = Utilities.FindFirstGameObjectMyselfOrChildren("SupportTarget", base.GameObject).transform;
			_suspensionRoot = Utilities.FindFirstGameObjectMyselfOrChildren("SuspensionRoot", base.GameObject).transform;
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
			float num = Mathf.Lerp(0f, base.Data.DeployedAngle, extensionPercentage);
			base.Data.CurrentRotation = new Vector3(0f - num, 0f, 0f);
			_pivot.localRotation = Quaternion.Euler(base.Data.CurrentRotation);
			_foot.localRotation = Quaternion.Euler(num + base.Data.FootPivot * extensionPercentage, 0f, 0f);
			Vector3 vector = _supportArm.parent.InverseTransformPoint(_supportArmTarget.position);
			float num2 = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f;
			_supportArm.localRotation = Quaternion.Euler(0f - num2, 0f, 0f);
			float y = vector.magnitude / 2.954999f;
			_supportArm.localScale = new Vector3(1f, y, 1f);
			if (flight)
			{
				base.Suspension.Data.SuspensionDistance = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				float num3 = base.Suspension.CurrentDistance - base.Suspension.Data.MinSuspensionDistance;
				_suspensionRoot.localPosition = new Vector3(0f, 0f - num3, 0f);
			}
			else
			{
				float num4 = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				_suspensionRoot.localPosition = new Vector3(0f, 0f - num4 + base.Suspension.Data.MinSuspensionDistance, 0f);
			}
		}
	}
}
