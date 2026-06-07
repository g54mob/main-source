using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageTreePanel : UIPanel
	{
		public static LineageTreePanel instance;

		public LineageWindow lineageWindow;

		public GameObject lineageHolder;

		public GameObject graphElementHolder;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject speciesNodePrefab;

		[Header("Junction Sprites")]
		public Sprite elbowRight;

		public Sprite elbowLeft;

		public Sprite junctionRight;

		public Sprite junctionLeft;

		private float viewportWidth;

		private float viewportHeight;

		private float totalWeight;

		private int nColumns;

		private int maxN;

		private List<LineageSpeciesNode> templatesBibites = new List<LineageSpeciesNode>();

		[NonSerialized]
		public List<SpeciesColumn> treeColumns = new List<SpeciesColumn>();

		public bool treeBuilt;

		private int nTemplateLineages;

		private RectTransform graphRT;

		private float defaultStep = 75f;

		private float sidePadding = 150f;

		private float paddingBetweenColumns = 20f;

		private float paddingBetweenTemplateLineages = 100f;

		private float defaultColumnSize = 120f;

		private LogLikeFormat[] formats;

		private bool hideExtinctLineages;

		private bool showFavorites;

		private bool scaleSpecies;

		private LineageSpeciesNode selectedNode;

		private ItemDictPool<Species, LineageSpeciesNode> speciesNodes;

		public override void InitPanel()
		{
			if (!hasInit)
			{
				base.InitPanel();
				instance = this;
				speciesNodes = new ItemDictPool<Species, LineageSpeciesNode>(speciesNodePrefab, lineageHolder.transform);
				graphRT = graphElementHolder.GetComponent<RectTransform>();
				lineageWindow.onViewportSizeChange.AddListener(UpdateViewportDimensions);
				UpdateViewportDimensions(lineageWindow.viewportDimensions);
				LineagePanelSettingsManager.hideExtinctLineages.Subscribe(UpdateHideExtinctLineages);
				LineagePanelSettingsManager.showLineagesOfFavorite.Subscribe(UpdateShowFavorites);
				LineagePanelSettingsManager.scaleImportantSpecies.Subscribe(UpdateScaleImportantSpecies);
				hideExtinctLineages = LineagePanelSettingsManager.hideExtinctLineages.val;
				showFavorites = LineagePanelSettingsManager.showLineagesOfFavorite.val;
				scaleSpecies = LineagePanelSettingsManager.scaleImportantSpecies.val;
			}
		}

		public override void OpenPanel()
		{
			if (!hasInit)
			{
				InitPanel();
			}
			base.OpenPanel();
			lineageWindow.SetDefaultStep(defaultStep);
			BuildTree();
			lineageWindow.UpdateAxisPlacement(Vector2.one / 2f);
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
		}

		public override void ResetState()
		{
			base.ResetState();
			treeBuilt = false;
		}

		private void UpdateViewportDimensions(Vector2 size)
		{
			viewportWidth = size.x;
			viewportHeight = size.y;
			if (base.isActiveAndEnabled)
			{
				PlaceTree();
			}
		}

		private void UpdateHideExtinctLineages(bool val)
		{
			hideExtinctLineages = val;
			if (base.isActiveAndEnabled)
			{
				Species species = ((selectedNode != null) ? selectedNode.species : null);
				BuildTree();
				if (species != null && speciesNodes.HasItemWithKey(species))
				{
					SelectAndFocusSpecies(species);
				}
				else
				{
					SpeciesPanel.instance.SelectAndFocusSpecies(null);
				}
			}
		}

		private void UpdateShowFavorites(bool val)
		{
			showFavorites = val;
			if (base.isActiveAndEnabled)
			{
				Species species = ((selectedNode != null) ? selectedNode.species : null);
				BuildTree();
				if (species != null && speciesNodes.HasItemWithKey(species))
				{
					SelectAndFocusSpecies(species);
				}
				else
				{
					SpeciesPanel.instance.SelectAndFocusSpecies(null);
				}
			}
		}

		private void UpdateScaleImportantSpecies(bool val)
		{
			scaleSpecies = val;
			if (base.isActiveAndEnabled)
			{
				BuildTree();
			}
		}

		public void BuildTree()
		{
			speciesNodes.RetireAll();
			List<Species> list = (from s in GlobalLineageManager.Instance.recordedSpecies
				orderby s.speciesData.totalIndexOfApparition descending, s.speciesID
				select s).ToList();
			templatesBibites.Clear();
			maxN = list.Max((Species s) => s.speciesData.totalIndexOfApparition);
			lineageWindow.SetMaxN(maxN);
			foreach (Species item in list)
			{
				if (item.speciesData.totalIndexOfApparition < 2)
				{
					break;
				}
				LineageSpeciesNode itemWithKey = speciesNodes.GetItemWithKey(item);
				if (item.parentSpecies != null)
				{
					itemWithKey.SetParentNode(speciesNodes[item.parentSpecies]);
				}
				else
				{
					itemWithKey.SetParentNode(null);
					templatesBibites.Add(itemWithKey);
				}
				itemWithKey.UpdateSpeciesData();
				float bottomY = lineageWindow.HeightOfPoint(item.speciesData.totalIndexOfDisappearance);
				float topY = lineageWindow.HeightOfPoint(item.speciesData.totalIndexOfApparition);
				itemWithKey.SetAnchors(topY, bottomY);
			}
			(from p in speciesNodes.activeItems
				where !p.Value.willRender || (p.Key.speciesData.nPointsPresent < 1 && p.Value.children.Count < 1)
				select p.Value).ToList().ForEach(delegate(LineageSpeciesNode n)
			{
				n.NotRenderedAndRetire();
			});
			templatesBibites.RemoveAll((LineageSpeciesNode s) => !s.willRender);
			foreach (LineageSpeciesNode templatesBibite in templatesBibites)
			{
				templatesBibite.CheckDescendants(hideExtinctLineages, showFavorites);
			}
			templatesBibites.RemoveAll((LineageSpeciesNode s) => !s.willRender);
			nTemplateLineages = templatesBibites.Count;
			treeColumns.Clear();
			foreach (LineageSpeciesNode templatesBibite2 in templatesBibites)
			{
				List<SpeciesColumn> list2 = new List<SpeciesColumn>
				{
					new SpeciesColumn(templatesBibite2)
				};
				templatesBibite2.BuildColumns(list2);
				treeColumns.AddRange(list2);
			}
			totalWeight = treeColumns.Sum((SpeciesColumn c) => (!scaleSpecies) ? defaultColumnSize : c.weight);
			nColumns = treeColumns.Count;
			if (treeColumns.Count < 1)
			{
				treeBuilt = false;
				return;
			}
			treeBuilt = true;
			SpeciesPanel.instance.UpdateDisplayedSpecies((from k in speciesNodes.activeItems
				select k.Key into s
				orderby s.speciesData.totalIndexOfApparition descending
				select s).ToList());
			PlaceTree();
			List<KeyValuePair<Species, LineageSpeciesNode>> list3 = speciesNodes.activeItems.Where((KeyValuePair<Species, LineageSpeciesNode> p) => p.Value.bottomHeight < 1f).ToList();
			float num = viewportWidth / graphRT.rect.width;
			if (list3.Count > 0)
			{
				num = Mathf.Min(num, viewportHeight / (50f + list3.Max((KeyValuePair<Species, LineageSpeciesNode> p) => p.Value.topHeight)));
			}
			if (viewportWidth > 0f)
			{
				lineageWindow.ZoomToScale(num);
			}
			else
			{
				lineageWindow.Zoom(0f);
			}
		}

		public void PlaceTree()
		{
			if (!treeBuilt)
			{
				return;
			}
			float num = paddingBetweenColumns * (float)(nColumns - 1) + paddingBetweenTemplateLineages * (float)(nTemplateLineages - 1);
			float num2 = 35f * (float)nColumns;
			float b = (scaleSpecies ? (Mathf.Pow(totalWeight / num2, 0.66f) * num2) : totalWeight) + num;
			b = Mathf.Max(viewportWidth - 2f * sidePadding, b);
			float num3 = totalWeight;
			float num4 = b - num;
			foreach (SpeciesColumn item in treeColumns.OrderBy((SpeciesColumn c) => c.weight))
			{
				float num5 = (scaleSpecies ? item.weight : defaultColumnSize);
				float num6 = Mathf.Max(num4 * num5 / num3, 35f);
				num3 -= num5;
				num4 -= num6;
				item.SetWidth(num6);
			}
			Species rootSpecies = treeColumns[0].rootSpecies;
			float num7 = 0f;
			foreach (SpeciesColumn treeColumn in treeColumns)
			{
				if (rootSpecies != treeColumn.rootSpecies)
				{
					num7 += paddingBetweenTemplateLineages;
					rootSpecies = treeColumn.rootSpecies;
				}
				treeColumn.SetPlacement(num7 + treeColumn.width / 2f);
				num7 += treeColumn.width + paddingBetweenColumns;
			}
			foreach (SpeciesColumn treeColumn2 in treeColumns)
			{
				foreach (LineageSpeciesNode node in treeColumn2.nodes)
				{
					node.UpdateLinkToParent();
				}
			}
			lineageWindow.SetDimension(b + 2f * sidePadding, lineageWindow.HeightOfPoint(maxN) + 120f);
			float a = Mathf.Min(1f, viewportHeight / graphRT.rect.height, viewportWidth / graphRT.rect.width);
			a = Mathf.Max(a, viewportHeight / lineageWindow.HeightOfPoint(lineageWindow.nonInfiniteMaxN));
			lineageWindow.SetMinMaxZoom(a, 1.5f);
		}

		public void OnSpeciesPruned(Species speciesPruned, Species mergeIntoSpecies)
		{
			LineageSpeciesNode itemWithKey = speciesNodes.GetItemWithKey(speciesPruned);
			List<LineageSpeciesNode> list = itemWithKey.children.ToList();
			itemWithKey.NotRenderedAndRetire();
			list.ForEach(delegate(LineageSpeciesNode n)
			{
				n.UpdateLinkToParent();
			});
			LineageSpeciesNode itemWithKey2 = speciesNodes.GetItemWithKey(mergeIntoSpecies);
			itemWithKey2.UpdateSpeciesData();
			float bottomY = lineageWindow.HeightOfPoint(mergeIntoSpecies.speciesData.totalIndexOfDisappearance);
			float topY = lineageWindow.HeightOfPoint(mergeIntoSpecies.speciesData.totalIndexOfApparition);
			itemWithKey2.SetAnchors(topY, bottomY);
			itemWithKey2.UpdatePlacement(itemWithKey2.topAnchor.x, itemWithKey2.assignedWidth);
		}

		public void SelectAndFocusSpecies(Species species = null)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (selectedNode != null)
			{
				selectedNode.FocusSpecies(focus: false);
			}
			if (species == null)
			{
				return;
			}
			selectedNode = speciesNodes.activeItemsList.FirstOrDefault((LineageSpeciesNode n) => n.species == species);
			if (selectedNode != null)
			{
				selectedNode.FocusSpecies(focus: true);
			}
			LineageSpeciesNode lineageSpeciesNode = selectedNode;
			Species nextParent = species.parentSpecies;
			while (lineageSpeciesNode == null && nextParent != null)
			{
				lineageSpeciesNode = speciesNodes.activeItemsList.FirstOrDefault((LineageSpeciesNode n) => n.species == nextParent);
				if (lineageSpeciesNode == null)
				{
					nextParent = nextParent.parentSpecies;
				}
			}
			if (lineageSpeciesNode == null)
			{
				graphRT.anchoredPosition = new Vector2(graphRT.anchoredPosition.x, (lineageWindow.HeightOfPoint(species.speciesData.totalIndexOfApparition) + lineageWindow.HeightOfPoint(species.speciesData.totalIndexOfDisappearance)) / 2f);
			}
			else
			{
				graphRT.anchoredPosition -= lineageSpeciesNode.centerPoint;
			}
		}

		private void OnDestroy()
		{
			LineagePanelSettingsManager.hideExtinctLineages.UnSubscribe(UpdateHideExtinctLineages);
			LineagePanelSettingsManager.showLineagesOfFavorite.UnSubscribe(UpdateShowFavorites);
			LineagePanelSettingsManager.scaleImportantSpecies.UnSubscribe(UpdateScaleImportantSpecies);
		}
	}
}
