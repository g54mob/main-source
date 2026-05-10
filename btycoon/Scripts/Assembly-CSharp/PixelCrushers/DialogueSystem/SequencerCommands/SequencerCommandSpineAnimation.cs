using PixelCrushers.DialogueSystem.SpineSupport;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	public class SequencerCommandSpineAnimation : SequencerCommand
	{
		public void Start()
		{
			string animationName = GetParameter(0);
			Transform subject = GetSubject(1, base.speaker);
			int parameterAsInt = GetParameterAsInt(2);
			bool parameterAsBool = GetParameterAsBool(3, defaultValue: true);
			SpineSequencerReferences spineSequencerReferences = ((subject != null) ? subject.GetComponentInChildren<SpineSequencerReferences>() : null);
			AnimationReferenceAsset animationReferenceAsset = ((spineSequencerReferences != null) ? spineSequencerReferences.animationReferenceAssets.Find((AnimationReferenceAsset x) => x.name == animationName) : null);
			Spine.AnimationState animationState = null;
			if (spineSequencerReferences != null)
			{
				if (spineSequencerReferences.skeletonAnimation != null)
				{
					animationState = spineSequencerReferences.skeletonAnimation.AnimationState;
				}
				else if (spineSequencerReferences.skeletonGraphic != null)
				{
					animationState = spineSequencerReferences.skeletonGraphic.AnimationState;
				}
			}
			if (subject == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: SpineAnimation(" + GetParameters() + ") can't find the subject.");
				}
			}
			else if (spineSequencerReferences == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: SpineAnimation(" + GetParameters() + ") subject " + subject?.ToString() + " needs a SpineSequencerReferences component.", subject);
				}
			}
			else if (animationReferenceAsset == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: SpineAnimation(" + GetParameters() + ") SpineSequencerReferences on " + subject?.ToString() + " doesn't have an AnimationReferenceAsset named '" + animationName + "'.", subject);
				}
			}
			else if (animationState == null)
			{
				if (DialogueDebug.logWarnings)
				{
					Debug.LogWarning("Dialogue System: Sequencer: SpineAnimation(" + GetParameters() + ") SkeletonAnimation referenced by SpineSequencerReferences on " + subject?.ToString() + " doesn't have an AnimationState.", subject);
				}
			}
			else
			{
				if (DialogueDebug.logInfo)
				{
					Debug.Log("Dialogue System: Sequencer: SpineAnimation(" + GetParameters() + ")", subject);
				}
				animationState.SetAnimation(parameterAsInt, animationReferenceAsset, parameterAsBool);
			}
			Stop();
		}
	}
}
