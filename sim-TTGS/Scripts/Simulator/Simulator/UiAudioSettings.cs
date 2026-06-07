using Dhs5.Utility.Settings;
using FMODUnity;
using UnityEngine;

namespace Simulator
{
	[Settings("Audio/UI", Scope.Project)]
	public class UiAudioSettings : CustomSettings<UiAudioSettings>
	{
		[field: SerializeField]
		public EventReference Highlighted { get; private set; }

		[field: SerializeField]
		public EventReference Pressed { get; private set; }

		[field: SerializeField]
		public EventReference PopupShowed { get; private set; }

		[field: SerializeField]
		public EventReference PopupValidated { get; private set; }
	}
}
