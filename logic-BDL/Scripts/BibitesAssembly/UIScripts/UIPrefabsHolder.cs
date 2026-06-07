using UnityEngine;

namespace UIScripts
{
	public class UIPrefabsHolder : MonoBehaviour
	{
		public static UIPrefabsHolder Instance;

		[Header("UI Prefabs")]
		public GameObject SettingSliderPrefab;

		public GameObject BoolSettingPrefab;

		public GameObject SettingDropdownPrefab;

		public GameObject SettingGroupPrefab;

		public GameObject SubSettingsGroupPrefab;

		public GameObject SubSettingsToggleMasterPrefab;

		public GameObject MaterialParametersPrefab;

		public GameObject ChallengeParametersPrefab;

		public GameObject ColorPickerPrefab;

		public GameObject TextLinePrefab;

		public GameObject ConditionGroupPrefab;

		public Texture2D editCursor;

		private void Awake()
		{
			Instance = this;
		}
	}
}
