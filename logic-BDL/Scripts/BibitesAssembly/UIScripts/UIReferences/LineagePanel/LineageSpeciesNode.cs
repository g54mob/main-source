using System;
using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageSpeciesNode : PoolableDictItem<Species, LineageSpeciesNode>, IPointerClickHandler, IEventSystemHandler
	{
		[Header("References")]
		private LineageSpeciesNode parentSpeciesNode;

		public FlexibleLineageElement verticalLine;

		public LineageLinkToParentNode linkToParent;

		public LineageSpeciesNodePoint extinctionPoint;

		public LineageSpeciesNodePoint aliveArrow;

		public LineageSpeciesNodePoint templatePoint;

		public LineageSpeciesNodePoint speciesNode;

		public BibiteGenePreviewer previewer;

		public RectTransform previewBoxRT;

		public TooltipTrigger speciesTooltip;

		[Header("Images Highlight References")]
		public List<Image> imagesToHighlightOnSelect;

		public Image previewContainer;

		public Material mat;

		private Vector2 defaultPreviewSizeDelta;

		private RectTransform rt;

		[NonSerialized]
		public Species species;

		[NonSerialized]
		public Vector2 topAnchor;

		private Vector2 bottomAnchor;

		public bool hasParent;

		private bool alive;

		[NonSerialized]
		public float topHeight;

		[NonSerialized]
		public float bottomHeight;

		private float heightSpan;

		private float availableHeight;

		private bool canFitPreview;

		[NonSerialized]
		private float previewScale;

		[NonSerialized]
		public bool willRender;

		[NonSerialized]
		public float preferredWidth;

		[NonSerialized]
		public float assignedWidth;

		public const float MinWidth = 35f;

		public const float MinPreviewScale = 0.5f;

		public const float MinHeight = 50f;

		public float branchWeight;

		public int nColumns;

		private Rect rect;

		[NonSerialized]
		public readonly List<LineageSpeciesNode> children = new List<LineageSpeciesNode>();

		private static readonly int Focus = Shader.PropertyToID("_focus");

		public Vector2 centerPoint => rt.rect.center;

		public float weight
		{
			get
			{
				if (!willRender)
				{
					return 0f;
				}
				return Mathf.Sqrt(children.Count + 1) * preferredWidth * (alive ? 3f : 1f);
			}
		}

		public override void Initialize()
		{
			rt = GetComponent<RectTransform>();
			rect = rt.rect;
			verticalLine.Init();
			speciesNode.Init();
			previewer.InitializePreview();
			defaultPreviewSizeDelta = previewBoxRT.sizeDelta;
			mat = UnityEngine.Object.Instantiate(mat);
			foreach (Image item in imagesToHighlightOnSelect)
			{
				item.material = mat;
			}
		}

		public override void Retire()
		{
			base.Retire();
			if (species != null)
			{
				species.onSpeciesChange.RemoveListener(OnSpeciesInfoChange);
			}
			SetParentNode(null);
			species = null;
			children.Clear();
		}

		public void NotRenderedAndRetire()
		{
			willRender = false;
			foreach (LineageSpeciesNode item in children.ToList())
			{
				item.SetParentNode(parentSpeciesNode);
			}
			if (parentSpeciesNode != null)
			{
				parentSpeciesNode.children.Remove(this);
				parentSpeciesNode.bottomHeight = Mathf.Min(parentSpeciesNode.bottomHeight, bottomHeight);
			}
			ReturnToPool();
		}

		public override void AssignKey(Species speciesToAssign)
		{
			species = speciesToAssign;
			UpdateSpeciesData();
			species.onSpeciesChange.AddListener(OnSpeciesInfoChange);
			OnSpeciesInfoChange();
			previewer.UpdateTemplate(species.template);
		}

		public void UpdateSpeciesData()
		{
			alive = species.speciesData.totalIndexOfDisappearance < 0;
			speciesTooltip.UpdateText(species.name, (species.parentSpecies == null) ? null : ("Child species of " + species.parentSpecies.name));
			extinctionPoint.SetActive(!alive);
			aliveArrow.SetActive(alive);
			linkToParent.SetActive(hasParent);
			templatePoint.SetActive(!hasParent);
			if (!alive)
			{
				string text = species.speciesData.TimeFormatOfDisappearance().FormattedTimeValue(1, " ", smallUnits: false, spaceBeforeUnits: true, Timescale.Minutes);
				extinctionPoint.UpdateTooltip("Extinction", species.name + " went extinct approximately " + text + " ago");
			}
			else
			{
				aliveArrow.UpdateTooltip("Alive", species.name + " is still around and well.");
			}
			string text2 = species.speciesData.TimeFormatOfApparition().FormattedTimeValue(1, " ", smallUnits: false, spaceBeforeUnits: true, Timescale.Minutes);
			if (hasParent)
			{
				linkToParent.UpdateTooltip("Species' Birth", species.name + " diverged from " + species.parentSpecies.name + " approximately " + text2 + " ago");
				speciesNode.UpdateTooltip(species.name, "A child species of " + species.parentSpecies.name);
			}
			else
			{
				templatePoint.UpdateTooltip("Species' Introduction", species.name + " was introduced in the simulation as a template approximately " + text2 + " ago");
			}
		}

		public void SetAnchors(float topY, float bottomY)
		{
			topHeight = (hasParent ? (topY + 28.5f) : topY);
			bottomHeight = bottomY;
			heightSpan = topY - bottomY;
			float num = (alive ? 20f : 17.5f) + (hasParent ? 50.5f : 17.5f);
			willRender = !hasParent || heightSpan >= num;
			if (willRender)
			{
				availableHeight = heightSpan - 25f - (hasParent ? 27.5f : 0f);
				previewScale = Mathf.Min(availableHeight / defaultPreviewSizeDelta.y * (hasParent ? 1f : 2f), 1f);
				canFitPreview = previewScale > 0.5f;
				preferredWidth = (canFitPreview ? (defaultPreviewSizeDelta.x * previewScale) : 35f);
			}
		}

		public void SetParentNode(LineageSpeciesNode newParentNode)
		{
			hasParent = newParentNode != null;
			if (!(parentSpeciesNode == newParentNode))
			{
				if (newParentNode == null && parentSpeciesNode != null)
				{
					parentSpeciesNode.children.Remove(this);
				}
				parentSpeciesNode = newParentNode;
				if (newParentNode != null)
				{
					newParentNode.children.Add(this);
				}
			}
		}

		public bool CheckDescendants(bool hideIfNoAliveDescendants, bool showFavorites)
		{
			branchWeight = weight;
			bool flag = false;
			foreach (LineageSpeciesNode item in children.ToList())
			{
				flag |= item.CheckDescendants(hideIfNoAliveDescendants, showFavorites);
			}
			foreach (LineageSpeciesNode item2 in children.Where((LineageSpeciesNode s) => s.willRender))
			{
				branchWeight += item2.branchWeight;
			}
			if (!hideIfNoAliveDescendants || alive || flag || (showFavorites && species.favorite))
			{
				return true;
			}
			willRender = false;
			ReturnToPool();
			return false;
		}

		public List<int> BuildColumns(List<SpeciesColumn> columns, List<SpeciesColumn> columnsToAvoid = null, int index = 0)
		{
			if (columnsToAvoid == null)
			{
				columnsToAvoid = columns.ToList();
			}
			float num = 0f;
			float num2 = 0f;
			List<int> list = new List<int>();
			LineageSpeciesNode lineageSpeciesNode = children.OrderByDescending((LineageSpeciesNode s) => s.branchWeight).FirstOrDefault();
			foreach (LineageSpeciesNode item2 in children.OrderByDescending((LineageSpeciesNode n) => n.topHeight))
			{
				bool flag = item2.children.Count > 0;
				if (!flag)
				{
					bool flag2 = false;
					if (index > 0 && !columnsToAvoid.Contains(columns[index - 1]))
					{
						flag2 |= columns[index - 1].CheckToInsertNode(item2);
					}
					else if (index < columns.Count - 1 && !columnsToAvoid.Contains(columns[index + 1]))
					{
						flag2 |= columns[index + 1].CheckToInsertNode(item2);
					}
					if (flag2)
					{
						continue;
					}
				}
				int num3 = 0;
				if (item2 == lineageSpeciesNode || num <= num2)
				{
					num3 = index++;
					num += item2.weight;
				}
				else
				{
					num3 = index + 1;
					num2 += item2.weight;
				}
				SpeciesColumn item = new SpeciesColumn(item2);
				columns.Insert(num3, item);
				list.Add(num3);
				if (flag)
				{
					columnsToAvoid.Add(item);
					List<int> list2 = item2.BuildColumns(columns, columnsToAvoid, num3);
					if (num3 < index)
					{
						index += list2.Count;
					}
					list.AddRange(list2);
					columnsToAvoid.Remove(item);
				}
			}
			return list;
		}

		public void UpdatePlacement(float posX, float availableWidth)
		{
			assignedWidth = availableWidth;
			if (children.Count > 0)
			{
				float num = ((children.Count > 0) ? children.Max((LineageSpeciesNode c) => c.topHeight) : bottomHeight);
				topHeight = Mathf.Max(topHeight, num + 27.5f);
			}
			topAnchor = new Vector2(posX, topHeight);
			bottomAnchor = new Vector2(posX, bottomHeight);
			rt.anchoredPosition = (topAnchor + bottomAnchor) / 2f;
			verticalLine.rt.offsetMax = new Vector2(verticalLine.rt.offsetMax.x, hasParent ? (-50.5f) : (-17.5f));
			availableHeight = topHeight - ((children.Count > 0) ? (children.Max((LineageSpeciesNode c) => c.topHeight) + 10f) : bottomHeight) - (hasParent ? 27.5f : 0f);
			previewScale = Mathf.Min(availableHeight / defaultPreviewSizeDelta.y * (hasParent ? 1f : 2f), previewScale);
			if (availableWidth < preferredWidth)
			{
				previewScale = Mathf.Min(availableWidth / defaultPreviewSizeDelta.x, previewScale);
			}
			canFitPreview = previewScale > 0.5f;
			if (canFitPreview)
			{
				previewBoxRT.localScale = Vector3.one * previewScale;
			}
			previewBoxRT.gameObject.SetActive(canFitPreview);
			speciesNode.gameObject.SetActive(!canFitPreview && hasParent);
			if (hasParent)
			{
				(canFitPreview ? previewBoxRT : speciesNode.rt).anchoredPosition = new Vector2(0f, -27.5f);
			}
			else if (canFitPreview)
			{
				previewBoxRT.anchoredPosition = new Vector2(0f, defaultPreviewSizeDelta.y * previewScale / 2f);
			}
			rt.sizeDelta = new Vector2(0f, topAnchor.y - bottomAnchor.y);
		}

		public void UpdateLinkToParent()
		{
			if (hasParent)
			{
				linkToParent.SetDist(parentSpeciesNode.topAnchor.x - topAnchor.x);
			}
		}

		private void OnSpeciesInfoChange()
		{
			previewer.nameText.text = species.name;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			SpeciesPanel.instance.SelectAndFocusSpecies(species);
		}

		public void FocusSpecies(bool focus)
		{
			foreach (Image item in imagesToHighlightOnSelect)
			{
				item.materialForRendering.SetFloat(Focus, focus ? 1f : 0f);
			}
			previewContainer.color = (focus ? Color.yellow : Color.white);
		}

		public override void Destroy()
		{
			base.Destroy();
			UnityEngine.Object.Destroy(mat);
		}
	}
}
