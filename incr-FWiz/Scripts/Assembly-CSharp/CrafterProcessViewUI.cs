using UnityEngine;
using UnityEngine.UI;

public class CrafterProcessViewUI : MonoBehaviour
{
	[SerializeField]
	private StandingQuotaUI _standingQuotaUI;

	[SerializeField]
	private CrafterOutputUI _outputUI;

	[SerializeField]
	private Image _progressBar;

	[SerializeField]
	private RectTransform _transform;

	[SerializeField]
	private UIFadeInOnEnable _fader;

	[SerializeField]
	private UIBobAnimation _bobAnimation;

	private Crafter _crafter;

	public void Initiate(Crafter crafter)
	{
	}

	public void Clear()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnUpdateProgress(float progresss)
	{
	}
}
