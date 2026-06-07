using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Audio Clip")]
	[Category("Random/Random Audio Clip")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow)]
	[Description("A random Audio Clip asset from a list")]
	[HideLabelsInEditor(true)]
	public class GetAudioRandomClip : PropertyTypeGetAudio
	{
		[SerializeField]
		protected AudioClip[] m_Values = Array.Empty<AudioClip>();

		public static PropertyGetAudio Create => new PropertyGetAudio(new GetAudioRandomClip());

		public override string String => "Random Clip";

		public override AudioClip Get(Args args)
		{
			AudioClip[] values = m_Values;
			if (values == null || values.Length == 0)
			{
				return null;
			}
			int num = UnityEngine.Random.Range(0, m_Values.Length);
			return m_Values[num];
		}
	}
}
