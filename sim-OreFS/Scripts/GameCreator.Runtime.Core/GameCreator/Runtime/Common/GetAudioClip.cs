using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Audio Clip")]
	[Category("Audio Clip")]
	[Image(typeof(IconQuaver), ColorTheme.Type.Yellow)]
	[Description("An Audio Clip asset")]
	[HideLabelsInEditor(true)]
	public class GetAudioClip : PropertyTypeGetAudio
	{
		[SerializeField]
		protected AudioClip m_Value;

		public static PropertyGetAudio Create => new PropertyGetAudio(new GetAudioClip());

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

		public override AudioClip EditorValue => m_Value;

		public override AudioClip Get(Args args)
		{
			return m_Value;
		}

		public override AudioClip Get(GameObject gameObject)
		{
			return m_Value;
		}

		public GetAudioClip()
		{
		}

		public GetAudioClip(AudioClip value = null)
			: this()
		{
			m_Value = value;
		}
	}
}
