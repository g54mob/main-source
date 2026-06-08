using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using Dorfromantik.Challenges;
using UnityEngine;

public class SessionQuestBar : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<RewardProgressBubble, bool> _003C_003E9__16_0;

		public static Func<RewardProgressBubble, bool> _003C_003E9__16_1;

		public static Func<RewardProgressBubble, float> _003C_003E9__16_2;

		internal bool _003CReorderDisplays_003Eb__16_0(RewardProgressBubble x)
		{
			return x.Challenge.CurrentState == RewardState.InProgress;
		}

		internal bool _003CReorderDisplays_003Eb__16_1(RewardProgressBubble x)
		{
			return x.Challenge.isPinned;
		}

		internal float _003CReorderDisplays_003Eb__16_2(RewardProgressBubble x)
		{
			return x.GetProgress();
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public SessionQuest challenge;

		internal bool _003CSetDefaultTooltip_003Eb__0(RewardProgressBubble x)
		{
			return x.Challenge == challenge;
		}

		internal bool _003CSetDefaultTooltip_003Eb__1(RewardProgressBubble x)
		{
			return x.Challenge == challenge;
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public SessionQuest challenge;

		internal bool _003CShowTooltip_003Eb__0(RewardProgressBubble x)
		{
			return x.Challenge == challenge;
		}
	}

	[SerializeField]
	private RewardProgressBubble ingameDisplayPrefab;

	[SerializeField]
	private Transform sessionQuestContainer;

	[SerializeField]
	private SessionQuestTooltip tooltip;

	[SerializeField]
	private Vector2 ingameDisplayAnchorPos;

	[SerializeField]
	private Vector2 ingameDisplayOffset;

	[SerializeField]
	private float animationDuration = 0.3f;

	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	private List<RewardProgressBubble> visibleIngameDisplays = new List<RewardProgressBubble>();

	private ChallengeTooltipState defaultTooltipState;

	private void Start()
	{
		ShowTooltip(0, null, -1);
		sessionQuestManager.OnOrderUpdated += ReorderDisplays;
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized += ReorderDisplaysFromTilePlaced;
		tilePlacementEventBroadcaster.OnTurnUndone += ReorderDisplaysFromTurnUndone;
		vfxManager.OnChallengeFxStarted += SetDefaultTooltip;
		vfxManager.OnChallengeRewardClaimed += RemoveDefaultTooltip;
	}

	public void SetupDisplay(WatchedSessionQuest watchedSessionQuest, RewardTileViewer tileViewer)
	{
		RewardProgressBubble rewardProgressBubble = UnityEngine.Object.Instantiate(ingameDisplayPrefab, sessionQuestContainer);
		rewardProgressBubble.Setup(visibleIngameDisplays.Count, watchedSessionQuest, tileViewer, this);
		visibleIngameDisplays.Add(rewardProgressBubble);
		ReorderDisplays(animate: false);
	}

	public void ReorderDisplays()
	{
		ReorderDisplays(animate: true);
	}

	private void ReorderDisplaysFromTurnUndone(Vector3 undoneTurnPos)
	{
		ReorderDisplays(animate: true);
	}

	private void ReorderDisplaysFromTilePlaced(Tile arg1, bool arg2)
	{
		ReorderDisplays(animate: true);
	}

	public void ReorderDisplays(bool animate)
	{
		visibleIngameDisplays = Enumerable.ToList(Enumerable.ThenByDescending(Enumerable.ThenByDescending(Enumerable.OrderByDescending(visibleIngameDisplays, (RewardProgressBubble x) => x.Challenge.CurrentState == RewardState.InProgress), (RewardProgressBubble x) => x.Challenge.isPinned), (RewardProgressBubble x) => x.GetProgress()));
		int num = 0;
		if (visibleIngameDisplays.Count < 3)
		{
			num = 3 - visibleIngameDisplays.Count;
		}
		for (int num2 = 0; num2 < visibleIngameDisplays.Count; num2++)
		{
			if (num2 < 3)
			{
				visibleIngameDisplays[num2].gameObject.SetActive(value: true);
			}
			visibleIngameDisplays[num2].MoveTo(ingameDisplayAnchorPos + ingameDisplayOffset * Mathf.Clamp(num2 + num, 0, 3), animate ? animationDuration : 0f, num2 >= 3);
			visibleIngameDisplays[num2].index = num2;
		}
	}

	public void SetDefaultTooltip(SessionQuest challenge, int watchLevel)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals5.challenge = challenge;
		Debug.Log("Set default tooltip");
		if (Enumerable.Count(visibleIngameDisplays, (RewardProgressBubble x) => x.Challenge == CS_0024_003C_003E8__locals5.challenge) != 0)
		{
			defaultTooltipState = new ChallengeTooltipState(CS_0024_003C_003E8__locals5.challenge, watchLevel);
			int index = visibleIngameDisplays.IndexOf(Enumerable.First(visibleIngameDisplays, (RewardProgressBubble x) => x.Challenge == CS_0024_003C_003E8__locals5.challenge));
			ShowTooltip(index, CS_0024_003C_003E8__locals5.challenge, watchLevel);
		}
	}

	private void RemoveDefaultTooltip(SessionQuest challenge, int watchLevel)
	{
		Debug.Log("Remove default tooltip");
		if (defaultTooltipState != null && defaultTooltipState.challenge == challenge)
		{
			defaultTooltipState = null;
			ShowTooltip(0, null, 0);
		}
	}

	public void ShowTooltip(int index, SessionQuest challenge, int level)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals7.challenge = challenge;
		if (CS_0024_003C_003E8__locals7.challenge == null && defaultTooltipState != null)
		{
			CS_0024_003C_003E8__locals7.challenge = defaultTooltipState.challenge;
			level = defaultTooltipState.level;
			index = visibleIngameDisplays.IndexOf(Enumerable.First(visibleIngameDisplays, (RewardProgressBubble x) => x.Challenge == CS_0024_003C_003E8__locals7.challenge));
		}
		if (visibleIngameDisplays.Count < 3)
		{
			index = Mathf.Clamp(index + 3 - visibleIngameDisplays.Count, 0, 2);
		}
		tooltip.Show(CS_0024_003C_003E8__locals7.challenge);
		if ((bool)CS_0024_003C_003E8__locals7.challenge)
		{
			tooltip.Setup(index, CS_0024_003C_003E8__locals7.challenge, level);
		}
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= ReorderDisplaysFromTilePlaced;
		tilePlacementEventBroadcaster.OnTurnUndone -= ReorderDisplaysFromTurnUndone;
		vfxManager.OnChallengeFxStarted -= SetDefaultTooltip;
		vfxManager.OnChallengeRewardClaimed -= RemoveDefaultTooltip;
		sessionQuestManager.OnOrderUpdated -= ReorderDisplays;
		foreach (RewardProgressBubble visibleIngameDisplay in visibleIngameDisplays)
		{
			visibleIngameDisplay.Destroy();
		}
	}

	public void UnsubscribeChallenges()
	{
		OnDestroy();
	}
}
