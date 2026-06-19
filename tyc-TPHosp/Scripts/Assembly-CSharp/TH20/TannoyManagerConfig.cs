using JetBrains.Annotations;
using UnityEngine.Audio;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TannoyManagerConfig
	{
		public float MinimumAnnouncementDelay = 5f;

		public float MinGeneralAnnouncementTime = 60f;

		public float MaxGeneralAnnouncementTime = 120f;

		public int MaxAnnouncementQueueLength = 2;

		public AudioMixerGroup AudioMixerGroup;
	}
}
