using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class ShareCodeImportGallery3DUIView : MonoBehaviour
	{
		private BuildableTemplate[] _allTemplates;

		[SerializeField]
		private List<ShareCodeImportPanel3DUIView> _decorationsPanel;

		[SerializeField]
		private List<ShareCodeImportPanel3DUIView> _propsPanel;

		public void ShowPanel(BuildableTemplate[] props)
		{
		}

		private void ShowTemplates(List<ShareCodeImportPanel3DUIView> panelSets, IEnumerable<BuildableTemplate> templates)
		{
		}

		public void Hide()
		{
		}
	}
}
