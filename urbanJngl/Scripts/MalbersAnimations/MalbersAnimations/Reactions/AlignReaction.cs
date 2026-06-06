using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Tools/Align Look At", 0)]
	public class AlignReaction : Reaction
	{
		[Tooltip("The target to Look At Align")]
		public TransformReference Target;

		public float AlignTime = 0.15f;

		public AnimationCurve AlignCurve = new AnimationCurve(MTools.DefaultCurve);

		public float AlignOffset;

		public override Type ReactionType => typeof(Component);

		protected override bool _TryReact(Component component)
		{
			if (component.TryGetComponent<MonoBehaviour>(out var component2))
			{
				component2.StartCoroutine(MTools.AlignLookAtTransform(component.transform, Target, AlignTime, AlignOffset, AlignCurve));
				return true;
			}
			return false;
		}
	}
}
