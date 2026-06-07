using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Image(typeof(IconAudioClip), ColorTheme.Type.Yellow)]
	[Title("Audio Clip")]
	[Category("References/Audio Clip")]
	public class ValueAudioClip : TValue
	{
		public static readonly IdString TYPE_ID = new IdString("audio-clip");

		[SerializeField]
		private AudioClip m_Value;

		public override IdString TypeID => TYPE_ID;

		public override Type Type => typeof(AudioClip);

		public override bool CanSave => false;

		public override TValue Copy => new ValueAudioClip
		{
			m_Value = m_Value
		};

		public ValueAudioClip()
		{
		}

		public ValueAudioClip(AudioClip value)
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
			m_Value = value as AudioClip;
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
			TValue.RegisterValueType(TYPE_ID, new TypeData(typeof(ValueAudioClip), CreateValue), typeof(AudioClip));
		}

		private static ValueAudioClip CreateValue(object value)
		{
			return new ValueAudioClip(value as AudioClip);
		}
	}
}
