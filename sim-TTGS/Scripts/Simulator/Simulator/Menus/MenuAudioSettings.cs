using Dhs5.Utility.Settings;
using FMODUnity;
using UnityEngine;

namespace Simulator.Menus
{
	[Settings("Audio/Menu", Scope.Project)]
	public class MenuAudioSettings : CustomSettings<MenuAudioSettings>
	{
		[Header("Music")]
		[SerializeField]
		private EventReference m_music;

		public static EventReference Music => CustomSettings<MenuAudioSettings>.I.m_music;
	}
}
