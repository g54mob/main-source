using UnityEngine;
using UnityEngine.UI;

public class ChallengeController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public Text challengeInfoText;

	private string message;

	public int baseExpReward;

	public int maxCompletions;
}
