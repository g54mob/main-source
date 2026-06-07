using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class AudioClipReference : ReferenceVar
	{
		public AudioClip ConstantValue;

		[RequiredField]
		public AudioClipListVar Variable;

		public AudioClip Value
		{
			get
			{
				if (!UseConstant)
				{
					if (!(Variable != null))
					{
						return null;
					}
					return Variable.Item_GetRandom();
				}
				return ConstantValue;
			}
		}

		public bool NullOrEmpty()
		{
			if (!UseConstant)
			{
				return Variable == null;
			}
			return ConstantValue == null;
		}

		public void Play(AudioSource source)
		{
			if (!(source == null) && source.isActiveAndEnabled)
			{
				if (UseConstant)
				{
					source.clip = ConstantValue;
					source.Play();
				}
				else
				{
					Variable.Play(source);
				}
			}
		}
	}
}
