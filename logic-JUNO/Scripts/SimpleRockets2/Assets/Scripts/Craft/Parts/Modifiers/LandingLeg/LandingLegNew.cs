using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegNew : LandingLegCommon
	{
		private Transform _pivot;

		private Transform _suspensionRoot;

		public LandingLegNew(LandingLegScript landingLegScript)
			: base(landingLegScript)
		{
			_pivot = Utilities.FindFirstGameObjectMyselfOrChildren("Pivot", base.GameObject).transform;
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
			base.Data.CurrentRotation = new Vector3(0f, 0f, Mathf.Lerp(0f, 180f - base.Data.DeployedAngle, extensionPercentage));
			_pivot.localRotation = Quaternion.Euler(base.Data.CurrentRotation);
			if (flight)
			{
				base.Suspension.Data.SuspensionDistance = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				float y = base.Suspension.CurrentDistance - base.Suspension.Data.MinSuspensionDistance;
				_suspensionRoot.localPosition = new Vector3(0f, y, 0f);
			}
			else
			{
				float num = Mathf.Lerp(base.Suspension.Data.MinSuspensionDistance, base.Suspension.Data.MaxSuspensionDistance, extensionPercentage);
				_suspensionRoot.localPosition = new Vector3(0f, num - base.Suspension.Data.MinSuspensionDistance, 0f);
			}
		}
	}
}
