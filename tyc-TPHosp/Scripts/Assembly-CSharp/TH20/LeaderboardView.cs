using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LeaderboardView : MonoBehaviour
	{
		public struct HospitalDefinition
		{
			public string Name;

			public string FoundationName;

			public Sprite AvatarIcon;

			public OnlinePlayerID PlayerID;
		}

		public struct Hospital
		{
			public HospitalDefinition HospitalDef;

			public bool IsPlayer;

			public bool IsFriend;

			public bool IsOnline;

			public int StarsAchieved;

			public int Value;

			public bool ShouldUseOnlineAvatar()
			{
				if (!IsPlayer)
				{
					return IsFriend;
				}
				return true;
			}
		}

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private DynamicLayoutGroup _layoutGroup;

		[SerializeField]
		private GameObject _rowPrefab;

		private readonly List<LeaderboardRowElement> _rowElements = new List<LeaderboardRowElement>();

		private List<Hospital> _hospitals = new List<Hospital>();

		private Metagame _metagame;

		public void Initialise(Metagame metagame)
		{
			_metagame = metagame;
		}

		private void OnDestroy()
		{
			foreach (LeaderboardRowElement rowElement in _rowElements)
			{
				Object.Destroy(rowElement);
			}
			_rowElements.Clear();
		}

		public void Setup(CareerStatsManager.Type statType, bool showFriends, LeaderboardConfig leaderboardConfig)
		{
			SetupHospitalList(statType, showFriends, leaderboardConfig);
			InstantiateRowPrefabs(statType);
		}

		private void Update()
		{
			_scroller.content.sizeDelta = new Vector2(_scroller.content.sizeDelta.x, _layoutGroup.preferredHeight);
		}

		private void InstantiateRowPrefabs(CareerStatsManager.Type statType)
		{
			for (int i = 0; i < _hospitals.Count; i++)
			{
				if (i < _rowElements.Count)
				{
					_rowElements[i].SetupForHospital(_hospitals[i], statType, i + 1);
					GameObjectUtils.SetActive(_rowElements[i].gameObject, isActive: true);
				}
				else
				{
					LeaderboardRowElement component = Object.Instantiate(_rowPrefab, _scroller.content.transform, worldPositionStays: false).GetComponent<LeaderboardRowElement>();
					component.SetupForHospital(_hospitals[i], statType, i + 1);
					_rowElements.Add(component);
				}
			}
			for (int j = _hospitals.Count; j < _rowElements.Count; j++)
			{
				GameObjectUtils.SetActive(_rowElements[j].gameObject, isActive: false);
			}
		}

		public void SetupHospitalList(CareerStatsManager.Type statType, bool showFriends, LeaderboardConfig leaderboardConfig)
		{
			_hospitals.Clear();
			bool flag = OnlineManager.IsInitializedAndLoggedOn();
			HospitalDefinition hospitalDef = ((!flag) ? new HospitalDefinition
			{
				Name = _metagame.OrganisationName,
				FoundationName = _metagame.OrganisationName,
				AvatarIcon = OnlineManager.DefaultAvatarSprite
			} : new HospitalDefinition
			{
				Name = _metagame.OrganisationName,
				FoundationName = (string.IsNullOrEmpty(OnlineManager.GetLocalPlayerInfo().DisplayName) ? "Player" : OnlineManager.GetLocalPlayerInfo().DisplayName),
				AvatarIcon = OnlineManager.DefaultAvatarSprite,
				PlayerID = OnlineManager.GetLocalPlayerID()
			});
			Hospital item = new Hospital
			{
				HospitalDef = hospitalDef,
				IsFriend = false,
				IsPlayer = true,
				Value = _metagame.CareerStatsManager.GetLocalPlayerStat(statType),
				IsOnline = flag
			};
			_hospitals.Add(item);
			if (flag && showFriends && _metagame.OnlineMetadataManager.LocalPlayerOnlineVisibility)
			{
				foreach (OnlinePlayerID friendPlayerID in OnlineManager.GetFriendPlayerIDs())
				{
					if (!(friendPlayerID == OnlineManager.GetLocalPlayerID()) && _metagame.OnlineMetadataManager.GetOnlineMetadata(friendPlayerID) != null)
					{
						_metagame.CareerStatsManager.GetFriendScore(statType, friendPlayerID, out var score);
						OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(friendPlayerID);
						string foundationName = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
						HospitalDefinition hospitalDef2 = new HospitalDefinition
						{
							Name = foundationName,
							FoundationName = foundationName,
							AvatarIcon = OnlineManager.DefaultAvatarSprite,
							PlayerID = friendPlayerID
						};
						Hospital item2 = new Hospital
						{
							HospitalDef = hospitalDef2,
							IsFriend = true,
							IsPlayer = false,
							Value = score
						};
						_hospitals.Add(item2);
					}
				}
			}
			if (leaderboardConfig != null)
			{
				leaderboardConfig.MinimumScores.TryGetValue(statType, out var value);
				leaderboardConfig.MaximumScores.TryGetValue(statType, out var value2);
				foreach (KeyValuePair<SharedInstance<RivalFoundationDefinition>, float> item4 in leaderboardConfig.RivalHospitalStrength)
				{
					Hospital item3 = new Hospital
					{
						HospitalDef = new HospitalDefinition
						{
							Name = item4.Key.Instance.FoundationName.Translation,
							FoundationName = item4.Key.Instance.FoundationName.Translation,
							AvatarIcon = item4.Key.Instance.Icon
						},
						IsFriend = false,
						IsPlayer = false,
						Value = (int)Mathf.Lerp(value, value2, item4.Value),
						IsOnline = false
					};
					_hospitals.Add(item3);
				}
			}
			_hospitals = _hospitals.OrderByDescending((Hospital h) => h.Value).ToList();
		}

		public void InstantiateRowPrefabsToTable(CareerStatsManager.Type statType, GameObject thePrefab, Table theTable)
		{
			for (int i = 0; i < _hospitals.Count; i++)
			{
				if (i < _rowElements.Count)
				{
					_rowElements[i].SetupForHospital(_hospitals[i], statType, i + 1);
					GameObjectUtils.SetActive(_rowElements[i].gameObject, isActive: true);
				}
				else
				{
					LeaderboardRowElement component = Object.Instantiate(thePrefab, theTable.Rows, worldPositionStays: false).GetComponent<LeaderboardRowElement>();
					component.SetupForHospital(_hospitals[i], statType, i + 1);
					_rowElements.Add(component);
				}
			}
			for (int j = _hospitals.Count; j < _rowElements.Count; j++)
			{
				GameObjectUtils.SetActive(_rowElements[j].gameObject, isActive: false);
			}
		}
	}
}
