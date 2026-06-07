using System;
using System.Runtime.CompilerServices;
using Audio;
using UnityEngine;

namespace Infrastructure.Project.Registration.Native.Audio
{
	[Serializable]
	public class AudioComponentsHandler : NativePrefabsGroupHandler
	{
		[SerializeField]
		private SingleShotAudioSource m_singleShotAudioSource;

		public PrefabPassport<SingleShotAudioSource> syw
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public override void isj()
		{
		}
	}
}
