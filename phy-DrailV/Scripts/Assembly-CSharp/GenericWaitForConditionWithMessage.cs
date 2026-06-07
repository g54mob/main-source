using Bolt;
using DV.Game.Tutorial;
using DV.Utils;
using Ludiq;
using UnityEngine;

public abstract class GenericWaitForConditionWithMessage : GenericWaitForCondition
{
	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput floatieMessage;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput vrFloatieMessage;

	[DoNotSerialize]
	public ValueInput floatieAnchor;

	[DoNotSerialize]
	public ValueInput floatieOffset;

	protected virtual string MessageFieldName => "Message";

	protected virtual string VRMessageFieldName => string.Empty;

	protected virtual string AnchorFieldName => "Anchor";

	protected virtual string OffsetFieldName => "Offset";

	protected virtual bool LocalizeMessage => true;

	protected virtual bool GUITarget => false;

	protected virtual TutorialHelper.SoundType SoundType => TutorialHelper.SoundType.Regular;

	protected override void Definition()
	{
		base.Definition();
		floatieMessage = (string.IsNullOrEmpty(MessageFieldName) ? null : ValueInput<string>(MessageFieldName, null));
		vrFloatieMessage = (string.IsNullOrEmpty(VRMessageFieldName) ? null : ValueInput<string>(VRMessageFieldName, null));
		floatieAnchor = (string.IsNullOrEmpty(AnchorFieldName) ? null : ValueInput<GameObject>(AnchorFieldName, null));
		floatieOffset = (string.IsNullOrEmpty(OffsetFieldName) ? null : ValueInput(OffsetFieldName, Vector3.zero));
	}

	protected virtual string GetMessageText(Flow flow, object context)
	{
		if (VRManager.IsVREnabled() && vrFloatieMessage != null)
		{
			return flow.GetValue<string>(vrFloatieMessage);
		}
		if (floatieMessage == null)
		{
			return "!!!ERROR!!!";
		}
		return flow.GetValue<string>(floatieMessage);
	}

	protected virtual GameObject GetMessageAnchor(Flow flow, object context)
	{
		if (floatieAnchor == null)
		{
			return null;
		}
		return flow.GetValue<GameObject>(floatieAnchor);
	}

	protected virtual Vector3 GetMessageOffset(Flow flow, object context)
	{
		if (floatieOffset == null)
		{
			return Vector3.zero;
		}
		return flow.GetValue<Vector3>(floatieOffset);
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		base.Initialize(flow, context, silent);
		if (!silent)
		{
			UpdateMessage(flow, context);
		}
	}

	protected void UpdateMessage(Flow flow, object context)
	{
		string messageText = GetMessageText(flow, context);
		GameObject messageAnchor = GetMessageAnchor(flow, context);
		Vector3 messageOffset = GetMessageOffset(flow, context);
		if (!string.IsNullOrEmpty(messageText))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(messageText, (messageAnchor != null) ? messageAnchor.transform : null, messageOffset, LocalizeMessage, GUITarget, SoundType);
		}
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		base.Deinitialize(flow, context, silent);
		if (!silent && !string.IsNullOrEmpty(GetMessageText(flow, context)))
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
	}
}
