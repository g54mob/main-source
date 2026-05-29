using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviour.UI
{
	public class MilestoneUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public static TechNode[] MilestoneTech = new TechNode[4] { "t2_tech", "t3_tech", "t4_tech", "t4f_demo_turtle" };

		[SerializeField]
		private Image _milestoneIcon;

		[SerializeField]
		private TMP_Text _milestoneText;

		[SerializeField]
		private RectTransform _prestigeContent;

		[SerializeField]
		private TMP_Text _prestigeText;

		private float _updateTimer;

		private TechNode _currentMilestone;

		public static MilestoneUI Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		private void OnEnable()
		{
			if (Screen.width > 1400)
			{
				_prestigeContent.anchorMin = new Vector2(0.5f, 0f);
				_prestigeContent.anchorMax = new Vector2(0.5f, 1f);
			}
			else
			{
				_prestigeContent.anchorMin = new Vector2(0.62f, 0f);
				_prestigeContent.anchorMax = new Vector2(0.62f, 1f);
			}
		}

		private void Update()
		{
			_updateTimer -= Time.deltaTime;
			if (!(_updateTimer < 0f))
			{
				return;
			}
			_updateTimer = 0.5f;
			_currentMilestone = null;
			TechNode[] milestoneTech = MilestoneTech;
			foreach (TechNode techNode in milestoneTech)
			{
				if (GamePlayer.Current.HasTech(techNode))
				{
					continue;
				}
				_currentMilestone = techNode;
				_milestoneIcon.sprite = techNode.Icon;
				string text = techNode.Name + " ";
				ConstructionProgress techConstruction = GamePlayer.Current.GetTechConstruction(techNode);
				if (techConstruction != null)
				{
					using IEnumerator<KeyValuePair<ItemType, int>> enumerator = techConstruction.RequiredMaterials.GetEnumerator();
					if (enumerator.MoveNext())
					{
						KeyValuePair<ItemType, int> current = enumerator.Current;
						int consumedCount = techConstruction.GetConsumedCount(current.Key);
						text = text + GameMath.FormatNumber(consumedCount) + "/" + GameMath.FormatNumber(current.Value);
					}
				}
				else
				{
					using Dictionary<ItemType, int>.Enumerator enumerator2 = techNode.GetCost().GetEnumerator();
					if (enumerator2.MoveNext())
					{
						text = text + "0/" + GameMath.FormatNumber(enumerator2.Current.Value);
					}
				}
				_milestoneText.text = text;
				return;
			}
			_milestoneIcon.sprite = SpriteLibrary.Get("Items_7");
			_milestoneText.text = "Assemble Statue " + GameMath.FormatNumber(GamePlayer.Current.DemoTurtleParts) + "/" + GameMath.FormatNumber(DemoTurtle.PartsPerTurtle);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (_currentMilestone != null)
			{
				GameUI.Instance.ShowFullScreenUI(TechTreeUI.Instance);
				return;
			}
			DemoTurtle frame = WorldMap.Current.GetFrame<DemoTurtle>();
			if (frame != null)
			{
				UISounds.WindowOpen();
				WorldManager.Instance.ShowFrame(frame, showUI: true);
			}
		}
	}
}
