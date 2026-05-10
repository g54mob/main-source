using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Animation")]
	public class PlayAnimationSimple : ActionTask<Animation>
	{
		[RequiredField]
		public BBParameter<AnimationClip> animationClip;

		[SliderField(0, 1)]
		public float crossFadeTime;

		public WrapMode animationWrap;

		public bool waitActionFinish;

		private static Dictionary<Animation, AnimationClip> lastPlayedClips;

		protected override string info => null;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
