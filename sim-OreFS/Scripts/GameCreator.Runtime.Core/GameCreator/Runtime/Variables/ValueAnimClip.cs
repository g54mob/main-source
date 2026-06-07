using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconAnimationClip), ColorTheme.Type.Teal)]
	[Title("Animation Clip")]
	[Category("References/Animation Clip")]
	public class ValueAnimClip : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("animation-clip");

		[SerializeField]
		private AnimationClip m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(AnimationClip);

		public override bool CanSave => false;

		public override TValue Copy => new ValueAnimClip
		{
			m_Value = m_Value
		};

		public ValueAnimClip()
		{
		}

		public ValueAnimClip(AnimationClip value)
			: this()
		{
			m_Value = value;
		}

		protected override object Get()
		{
			return m_Value;
		}

		protected override void Set(object value)
		{
			m_Value = value as AnimationClip;
		}

		public override string ToString()
		{
			if (!(m_Value != null))
			{
				return "(none)";
			}
			return m_Value.name;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RuntimeInit()
		{
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueAnimClip), CreateValue), typeof(AnimationClip));
		}

		private static ValueAnimClip CreateValue(object value)
		{
			return new ValueAnimClip(value as AnimationClip);
		}
	}
}
