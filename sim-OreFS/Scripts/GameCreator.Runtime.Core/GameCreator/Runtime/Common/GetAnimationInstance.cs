using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Animation Clip")]
	[Category("Animation Clip")]
	[Image(typeof(IconAnimationClip), ColorTheme.Type.Teal)]
	[Description("An Animation Clip asset")]
	[HideLabelsInEditor(true)]
	public class GetAnimationInstance : PropertyTypeGetAnimation
	{
		[SerializeField]
		protected AnimationClip m_Value;

		public static PropertyGetAnimation Create => new PropertyGetAnimation(new GetAnimationInstance());

		public override string String
		{
			get
			{
				if (!(m_Value != null))
				{
					return "(none)";
				}
				return m_Value.name;
			}
		}

		public override AnimationClip EditorValue => m_Value;

		public override AnimationClip Get(Args args)
		{
			return m_Value;
		}

		public override AnimationClip Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetAnimationInstance()
		{
		}

		public GetAnimationInstance(AnimationClip value = null)
			: this()
		{
			m_Value = value;
		}
	}
}
