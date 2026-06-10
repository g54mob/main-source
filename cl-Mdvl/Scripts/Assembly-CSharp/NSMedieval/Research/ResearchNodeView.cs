using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Tools.Lines;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Research
{
	[Serializable]
	public class ResearchNodeView : NSEipix.Base.View
	{
		[SerializeField]
		private ResearchNodeInstance researchNodeInstance;

		[SerializeField]
		private string nodeID;

		[SerializeField]
		private Button button;

		[SerializeField]
		private LocalizedTextTooltipView tooltipView;

		[SerializeField]
		private Image icon;

		[SerializeField]
		private ResearchButtonSet locekdSpriteSet;

		[SerializeField]
		private ResearchButtonSet unlocekdSpriteSet;

		[SerializeField]
		private ResearchButtonSet activeSpriteSet;

		[SerializeField]
		private Line linePrefab;

		[SerializeField]
		private List<Line> lines = new List<Line>();

		[SerializeField]
		private Line parentLine;

		[SerializeField]
		private RectTransform inputPoint;

		[SerializeField]
		private RectTransform outputPoint;

		[SerializeField]
		private List<ResearchNodeView> children = new List<ResearchNodeView>();

		[SerializeField]
		private TextMeshProUGUI nodeName;

		private RectTransform rowRect;

		private RectTransform rectTransform;

		public Vector2 GetPositionAndSelect()
		{
			button.Select();
			return rectTransform.position;
		}

		public void SetNodeID(string nodeID)
		{
			this.nodeID = nodeID;
			base.gameObject.name = nodeID;
		}

		public void Unlock()
		{
			SwapButtonSprites(unlocekdSpriteSet);
		}

		public void Lock()
		{
			SwapButtonSprites(locekdSpriteSet);
		}

		public void Activate()
		{
			SwapButtonSprites(activeSpriteSet);
		}

		public void SetParentLine(Line parentLine)
		{
			this.parentLine = parentLine;
		}

		public void Setup()
		{
			researchNodeInstance.SetInitialState();
			ResearchState researchState = researchNodeInstance.ResearchState;
			if (researchState.Equals(ResearchState.Unlocked))
			{
				Unlock();
			}
			if (researchState.Equals(ResearchState.Locked))
			{
				Lock();
			}
			InitializeLines();
		}

		public void ForceInitialize()
		{
			StartHelper();
		}

		public void Locked()
		{
			foreach (Line line in lines)
			{
				line.SetColorLocked();
			}
		}

		public void Unlocked()
		{
			foreach (Line line in lines)
			{
				line.SetColorLocked();
			}
		}

		public void Activated()
		{
			foreach (Line line in lines)
			{
				line.SetColorUnlocked();
			}
			if (parentLine != null)
			{
				parentLine.SetColorActivated();
			}
		}

		public void RedrawLines()
		{
			for (int i = 0; i < researchNodeInstance.Children.Count; i++)
			{
				ResearchNodeInstance nodeInstance = researchNodeInstance.Children[i];
				ResearchNodeView view = MonoSingleton<ResearchManager>.Instance.GetView(nodeInstance);
				if (!(view == null))
				{
					lines[i].Draw(rectTransform, view.rectTransform);
				}
			}
		}

		private void InitializeLines()
		{
			if (researchNodeInstance == null)
			{
				return;
			}
			foreach (ResearchNodeInstance child in researchNodeInstance.Children)
			{
				ResearchNodeView view = MonoSingleton<ResearchManager>.Instance.GetView(child);
				if (!(view == null))
				{
					Line line = UnityEngine.Object.Instantiate(linePrefab, outputPoint.position, Quaternion.identity, outputPoint.transform);
					lines.Add(line);
					view.SetParentLine(line);
					line.SetColorLocked();
					line.Draw(outputPoint, view.inputPoint);
				}
			}
		}

		private void StartHelper()
		{
			ResearchModel byID = Repository<ResearchRepository, ResearchModel>.Instance.GetByID(nodeID);
			if (!(byID == null))
			{
				researchNodeInstance = new ResearchNodeInstance(byID);
				MonoSingleton<ResearchManager>.Instance.AddToDictionary(researchNodeInstance, this);
				button = GetComponent<Button>();
				button.onClick.AddListener(OnClick);
				ColorBlock colors = button.colors;
				colors.disabledColor = Color.red;
				button.colors = colors;
				tooltipView = button.GetComponentInChildren<LocalizedTextTooltipView>();
				tooltipView.SetTooltipKey(LocKeyUtils.GetName(researchNodeInstance.Blueprint.LocKeys));
				rowRect = base.gameObject.transform.parent.GetComponent<RectTransform>();
				rectTransform = base.gameObject.GetComponent<RectTransform>();
				locekdSpriteSet.SetIconSprite(MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress(byID.IconLocked));
				unlocekdSpriteSet.SetIconSprite(MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress(byID.IconUnlocked));
				activeSpriteSet.SetIconSprite(MonoRepository<SpriteRepository, KeySpritePair>.Instance.GetByAddress(byID.IconActive));
			}
		}

		private void OnClick()
		{
			MonoSingleton<ResearchUIController>.Instance.NodeSelected(researchNodeInstance);
		}

		private void OnValidate()
		{
			base.gameObject.name = nodeID;
			nodeName.text = base.gameObject.name;
		}

		private void SwapButtonSprites(ResearchButtonSet set)
		{
			button.image.sprite = set.BaseSprite;
			SpriteState spriteState = new SpriteState
			{
				highlightedSprite = set.HighlightetSprite,
				pressedSprite = set.PressedSprite,
				selectedSprite = set.SelectedSprite,
				disabledSprite = set.DisabledSprite
			};
			button.spriteState = spriteState;
			icon.sprite = set.IconSprite;
		}

		private void Start()
		{
			nodeName.enabled = false;
		}

		private void OnDrawGizmos()
		{
			foreach (ResearchNodeView child in children)
			{
				Gizmos.DrawLine(outputPoint.position, child.inputPoint.position);
			}
		}
	}
}
