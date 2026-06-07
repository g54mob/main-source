using System.Collections.Generic;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class ShareCodeImportPanel3DUIView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _propBuildButtonPrefab;

		[SerializeField]
		private Button3DUIView _previousPageButton;

		[SerializeField]
		private Button3DUIView _nextPageButton;

		public bool allowPaging;

		public int maxSlots;

		public List<Transform> slots;

		private List<PropBuildButton3DUIView> _slotButtonInstances;

		[SerializeField]
		private Container3DUIView _slotsContainer;

		private int _currentPage;

		private List<BuildableTemplate> _allTemplates;

		public void Start()
		{
		}

		public void DisplayInSlots(IEnumerable<BuildableTemplate> template)
		{
		}

		private void ShowPage(int page)
		{
		}

		private void UpdatePagingButtons()
		{
		}

		private void InitSlot(Transform slot)
		{
		}

		public void Hide()
		{
		}
	}
}
