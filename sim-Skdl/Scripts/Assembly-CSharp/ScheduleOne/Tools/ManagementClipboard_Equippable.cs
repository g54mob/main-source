using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.Misc;
using ScheduleOne.Property;
using ScheduleOne.UI.Management;
using TMPro;
using UnityEngine;

namespace ScheduleOne.Tools
{
	public class ManagementClipboard_Equippable : Equippable_Viewmodel
	{
		[Header("References")]
		public Transform Clipboard;

		public Transform LoweredPosition;

		public Transform RaisedPosition;

		public ToggleableLight Light;

		public SelectionInfoUI SelectionInfo;

		public TextMeshProUGUI OverrideText;

		private static bool _heatmapToggledOn;

		private ScheduleOne.Property.Property _propertyWithHeatmapShown;

		private static bool _canToggleHeatmap => false;

		public static bool ResetHeatmapToggle()
		{
			return false;
		}

		public override void Equip(ItemInstance item)
		{
		}

		private void ShowInputPrompts()
		{
		}

		private void HideInputPrompts()
		{
		}

		public override void Unequip()
		{
		}

		protected override void Update()
		{
		}

		private bool CanToggleClipboard()
		{
			return false;
		}

		private void UpdateHeatmap()
		{
		}

		private void ClearPropertyWithHeatmapShown()
		{
		}

		private void FullscreenEnter()
		{
		}

		private void FullscreenExit()
		{
		}

		public void OverrideClipboardText(string overriddenText)
		{
		}

		public void EndOverride()
		{
		}
	}
}
