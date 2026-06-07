using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_SDKTransformModifyDV")]
	public class VRTK_SDKTransformModify_DV : VRTK_SDKTransformModify
	{
		[InspectorNote("Don't use the above field \"Sdk Overrides\", this implementation doesn't use it.", "")]
		public float handScale = 0.89f;

		public override void UpdateTransform(VRTK_ControllerReference controllerReference = null)
		{
			if (!(target == null) && controllerReference.scriptAlias.transform.Equals(target.parent))
			{
				PipaUtils.AnchorData anchorData = PipaUtils.GetAnchorData(controllerReference);
				Transform child = base.transform.GetChild(0);
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
				child.localPosition = anchorData.handOffset;
				child.localRotation = anchorData.handRotation;
				Vector3 localScale = Vector3.one * handScale;
				if (controllerReference.hand == SDK_BaseController.ControllerHand.Left)
				{
					localScale.x *= -1f;
				}
				base.transform.localScale = localScale;
				base.Applied = true;
			}
		}
	}
}
