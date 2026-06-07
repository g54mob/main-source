using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("UI/Dropdown", Scope.Project)]
	public class TabletopDropdownSettings : CustomSettings<TabletopDropdownSettings>
	{
		[Header("Controller Settings")]
		[field: SerializeField]
		public float ScrollDuration { get; private set; } = 0.2f;
	}
}
