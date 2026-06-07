using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Coffee.UIEffects.Timeline
{
	[Serializable]
	public abstract class UIEffectBehaviour : PlayableBehaviour
	{
		public bool m_Tween;

		public AnimationCurve m_Curve;

		public UIEffectClip clip { get; set; }
	}
}
