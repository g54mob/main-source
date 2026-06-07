using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildablePanel3DUIView : MonoBehaviour
	{
		[Serializable]
		public class SlotsBacker
		{
			public int slots;

			public GameObject backer;
		}

		private UIController _uc;

		public int maxButtonInstances;

		private int _currentPage;

		[SerializeField]
		private Button3DUIView _previousPageButton;

		[SerializeField]
		private Button3DUIView _nextPageButton;

		public List<SlotsBacker> slotBackers;

		private BuildableTemplate[] _allBuildables;

		private BuildableTemplate _selectedBuildable;

		public bool filterWithBuildSearch;

		public bool IsGalleryMode { get; set; }

		public bool IsPanelOpen => false;

		public BuildableTemplate CurrentVariantGroup { get; private set; }

		public List<PropBuildButton3DUIView> BuildableButtonInstances { get; private set; }

		public void Start()
		{
		}

		private void SetParentSlot(Transform button, Transform transform, string slotName)
		{
		}

		public void ShowPanel(BuildableTemplate variantGroup)
		{
		}

		public void ShowPanel(BuildableTemplate[] props)
		{
		}

		public void HidePanel()
		{
		}

		public void RefreshPanel()
		{
		}

		private int GetBuildablePage(BuildableTemplate variant)
		{
			return 0;
		}

		private void InitSlot(int slot)
		{
		}

		private void DisplayPage(int page)
		{
		}

		private void UpdatePageButtons(int page, BuildableTemplate[] items)
		{
		}

		private void PopulateBuildableButtons(BuildableTemplate[] displayItems)
		{
		}

		private SlotsBacker ShowBackerForSize(int size)
		{
			return null;
		}

		private void NextBuildablePage()
		{
		}

		private void PreviousBuildablePage()
		{
		}

		public bool IsTemplateInCurrentVariantGroup(BuildableTemplate template)
		{
			return false;
		}
	}
}
