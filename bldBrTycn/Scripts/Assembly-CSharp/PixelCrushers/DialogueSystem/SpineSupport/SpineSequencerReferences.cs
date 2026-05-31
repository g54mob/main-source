using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SpineSupport
{
	public class SpineSequencerReferences : MonoBehaviour
	{
		[HelpBox("Assign a SkeletonAnimation or SkeletonGraphic. Then assign animations that the SpineAnimation() sequencer command can use.", HelpBoxMessageType.None)]
		public SkeletonAnimation skeletonAnimation;

		public SkeletonGraphic skeletonGraphic;

		public List<AnimationReferenceAsset> animationReferenceAssets = new List<AnimationReferenceAsset>();
	}
}
