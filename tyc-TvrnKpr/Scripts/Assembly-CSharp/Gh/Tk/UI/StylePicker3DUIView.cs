using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class StylePicker3DUIView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _styleButtonPrefab;

		[SerializeField]
		private Container3DUIView _styleButtonContainer;

		[SerializeField]
		private RelativeScaler3DUIView _backerScaler;

		private List<Style> _styles;

		private List<StyleButton3DUIView> _styleButtons;

		private bool _isBuildMenuMode;

		private BuildableTemplate _buildMenuBuildableTemplate;

		private bool _isPreviewStyleApplied;

		private List<string> _startingStyles;

		public BuildableTemplate SelectedTemplate => null;

		public bool IsOpen => false;

		public static bool CanOpen => false;

		private void Start()
		{
		}

		public void OpenInDecorationEditingMode(BuildableTemplate buildMenuTemplate = null)
		{
		}

		public void OpenInBuildMenuMode(BuildableTemplate template)
		{
		}

		private void OpenInternal()
		{
		}

		private void UpdateCostLabels()
		{
		}

		public IEnumerable<EntityObject> GetApplicableEntityObjects(string styleId)
		{
			return null;
		}

		public void SetUpStyles(List<Style> styles)
		{
		}

		private void StyleButtonContainer_LayoutUpdated(object sender, EventArgs e)
		{
		}

		private void ApplyStyle(List<string> styleIds, bool shouldBeUndoable = false, bool applyCost = false)
		{
		}

		private void OnSyncedEntitiesChanged(object sender, EventArgs e)
		{
		}

		public void Close()
		{
		}
	}
}
