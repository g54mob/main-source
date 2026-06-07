using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("Editor/Prefabs", Scope.Project)]
	public class PrefabSettings : CustomSettings<PrefabSettings>
	{
		[Header("UI")]
		[SerializeField]
		private GameObject m_background;

		[SerializeField]
		private GameObject m_navButton;

		public static GameObject Background => CustomSettings<PrefabSettings>.I.m_background;

		public static GameObject NavButton => CustomSettings<PrefabSettings>.I.m_navButton;
	}
}
