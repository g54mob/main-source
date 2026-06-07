using System.Collections.Generic;
using System.Linq;
using CTS.BBT.TechTree;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS.TechTree
{
	public class TechTreeCategorieSetup : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("GameObject Links")]
		private LayoutElement _layoutElement;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _categoryTitle;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _categoryDescription;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _nodesAnchor;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TechTreeNodeSetup _nodePrefab;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TechTreeNodeSetup _nodePrefabNotInDemo;

		[SerializeField]
		[Range(0f, 10f)]
		private int _maxTechnologiesPerColumn;

		[HideInInspector]
		public TechTreeCategoriesSO CategorySO;

		[HideInInspector]
		public TechTreeVisualManager TechTreeVisualManager;

		[HideInInspector]
		public LocalizedString CategoryName;

		[HideInInspector]
		public LocalizedString CategoryDescription;

		[HideInInspector]
		public float CategorySize;

		private GridLayoutGroup _categoryGridLayout;

		private TechTreeTechnologySO[] _nodesData;

		private TechTreeTechnologySO[] _filteredNodes;

		private List<TechTreeNodeSetup> _nodesDataList = new List<TechTreeNodeSetup>();

		public List<TechTreeNodeSetup> GetNode()
		{
			return _nodesDataList;
		}

		private void Awake()
		{
			_categoryGridLayout = _nodesAnchor.GetComponent<GridLayoutGroup>();
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= LangChanged;
		}

		private void LangChanged(Locale locale)
		{
			_categoryTitle.text = CategoryName.GetLocalizedString();
			_categoryDescription.text = CategoryDescription.GetLocalizedString();
		}

		private void PopulateVisual()
		{
			for (int i = 0; i < _filteredNodes.Length; i++)
			{
				TechTreeNodeSetup techTreeNodeSetup = Object.Instantiate(_nodePrefab, _nodesAnchor.transform);
				techTreeNodeSetup.TechnologySO = _filteredNodes[i];
				techTreeNodeSetup.Setup();
				_nodesDataList.Add(techTreeNodeSetup);
			}
		}

		public void Setup()
		{
			_nodesData = TechTreeVisualManager.GetNodesList();
			_filteredNodes = (from node in _nodesData
				where node.TechTreeCategorySO == CategorySO
				orderby node.name
				select node).ToArray();
			_categoryGridLayout.constraintCount = ((_filteredNodes.Length <= _maxTechnologiesPerColumn) ? 1 : 2);
			_categoryTitle.text = CategoryName.GetLocalizedString();
			_categoryDescription.text = CategoryDescription.GetLocalizedString();
			_layoutElement.flexibleWidth = CategorySize;
			LocalizationSettings.SelectedLocaleChanged += LangChanged;
			PopulateVisual();
		}
	}
}
