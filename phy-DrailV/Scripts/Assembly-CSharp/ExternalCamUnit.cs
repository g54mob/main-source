using Bolt;
using DV;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Wait for player enable or disable the external camera")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(Camera))]
[UnitTitle("External Cam")]
public class ExternalCamUnit : GenericWaitForConditionWithMessage
{
	[DoNotSerialize]
	public ValueInput targetValue;

	protected override string DoneFieldName => "Switch";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		targetValue = ValueInput("On", @default: true);
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		if (VRManager.IsVREnabled() || SingletonBehaviour<PlayerCameraSwitcher>.Instance == null || SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera == null)
		{
			return true;
		}
		return base.EarlyOutCheck(flow, context, silent);
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		if (flow.GetValue<bool>(targetValue))
		{
			Globals.G.GameParams.FreeCamAllowed = true;
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		bool value = flow.GetValue<bool>(targetValue);
		return SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.IsOn == value;
	}
}
