using Aggro.Core;
using Aggro.Core.Networking;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModifierChoiceButtonUI : EntityBehaviourBase, IPointerClickHandler, IEventSystemHandler
{
	public PlayersManager.VoteOption voteOption;

	public Image[] players;

	public Image iconA;

	public Image timer;

	public Transform timerParent;

	public Transform container;

	public LocalizedText titleText;

	public LocalizedText descText;

	public TextMeshProUGUI bonusPayText;

	protected override void OnUpdatePresentation()
	{
		bool flag = NetworkAggroManagerBase<PlayersManager>.instance.GetMyVote() == voteOption;
		container.transform.localScale = Vector3.Lerp(container.transform.localScale, flag ? (1.15f * Vector3.one) : (0.95f * Vector3.one), 2f);
		float normalizedVoteValue = NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedVoteValue();
		timerParent.gameObject.SetActive(normalizedVoteValue > 0f && flag);
		timer.fillAmount = normalizedVoteValue;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Vote();
	}

	public void Vote()
	{
		NetworkAggroManagerBase<PlayersManager>.instance.RequestVote(voteOption);
	}
}
