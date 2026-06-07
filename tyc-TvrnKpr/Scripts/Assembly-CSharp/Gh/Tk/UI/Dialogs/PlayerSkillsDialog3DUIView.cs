using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PlayerSkillsDialog3DUIView : BaseDialog3DUIView, IPrefabProvider
	{
		private bool _isInitialized;

		[SerializeField]
		private TextMeshProI18n _title;

		[SerializeField]
		private SkillSettingsPage3DUIView _skillsPage;

		[SerializeField]
		private Button3DUIView _saveButton;

		[SerializeField]
		private Button3DUIView _cancelButton;

		private bool _isSlidersDirty;

		private Dictionary<string, int> _previousSkillValues;

		[SerializeField]
		private List<GameObject> _layoutPrefabs;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnSliderValueChanged(object sender, EventArgs e)
		{
		}

		private void OpenSkillsPage()
		{
		}

		public GameObject GetPrefab(string prefabName)
		{
			return null;
		}

		private void CloseAllPages()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
