using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
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
		public static TechNode[] MilestoneTech = new TechNode[12]
		{
			"t2_tech", "t3_tech", "t4_tech", "t5_tech", "t6_tech", "t7_tech", "t8_tech", "t9_tech", "t10_tech", "t11_tech",
			"t12_tech", "t12f_launch_facility"
		};

		[SerializeField]
		private TMP_Text _milestoneLabel;

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

		private void Start()
		{
			_milestoneIcon.rectTransform.anchoredPosition = new UnityEngine.Vector2(_milestoneLabel.preferredWidth + 12f, 0f);
			_milestoneText.rectTransform.anchoredPosition = new UnityEngine.Vector2(_milestoneLabel.preferredWidth + 50f, _milestoneText.rectTransform.anchoredPosition.y);
		}

		private void OnEnable()
		{
			if (Screen.width > 1400)
			{
				_prestigeContent.anchorMin = new UnityEngine.Vector2(0.5f, 0f);
				_prestigeContent.anchorMax = new UnityEngine.Vector2(0.5f, 1f);
			}
			else
			{
				_prestigeContent.anchorMin = new UnityEngine.Vector2(0.62f, 0f);
				_prestigeContent.anchorMax = new UnityEngine.Vector2(0.62f, 1f);
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
			if (GamePlayer.Current.Prestige != 0 || GamePlayer.Current.RocketsLaunched != 0)
			{
				_prestigeContent.gameObject.SetActive(value: true);
				if (GamePlayer.Current.RocketsLaunched > 0)
				{
					_prestigeText.TL("@CurrentPrestigePlusLaunches", GamePlayer.Current.Prestige, GamePlayer.Current.RocketsLaunched);
				}
				else
				{
					_prestigeText.TL("@CurrentPrestige", GamePlayer.Current.Prestige);
				}
			}
			TechNode[] milestoneTech = MilestoneTech;
			foreach (TechNode techNode in milestoneTech)
			{
				if (GamePlayer.Current.HasTech(techNode))
				{
					continue;
				}
				_currentMilestone = techNode;
				_milestoneIcon.sprite = techNode.Icon;
				ConstructionProgress techConstruction = GamePlayer.Current.GetTechConstruction(techNode);
				if (techConstruction != null)
				{
					using (IEnumerator<KeyValuePair<ItemType, BigInteger>> enumerator = techConstruction.RequiredMaterials.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							KeyValuePair<ItemType, BigInteger> current = enumerator.Current;
							BigInteger consumedCount = techConstruction.GetConsumedCount(current.Key);
							_milestoneText.TL("@CurrentMilestoneTech", techNode.Name, consumedCount, current.Value);
						}
						return;
					}
				}
				using Dictionary<ItemType, BigInteger>.Enumerator enumerator2 = techNode.GetCost().GetEnumerator();
				if (enumerator2.MoveNext())
				{
					KeyValuePair<ItemType, BigInteger> current2 = enumerator2.Current;
					_milestoneText.TL("@CurrentMilestoneTech", techNode.Name, 0, current2.Value);
				}
				return;
			}
			_milestoneIcon.sprite = SpriteLibrary.Get("Items_60");
			_milestoneText.TL("@CurrentMilestoneRocket", GamePlayer.Current.RocketParts, T12LaunchFacility.PartsPerRocket);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (_currentMilestone != null)
			{
				GameUI.Instance.ShowFullScreenUI(TechTreeUI.Instance);
				return;
			}
			T12LaunchFacility frame = WorldMap.Current.GetFrame<T12LaunchFacility>();
			if (frame != null)
			{
				UISounds.WindowOpen();
				WorldManager.Instance.ShowFrame(frame, showUI: true);
			}
		}
	}
}
