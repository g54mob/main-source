using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.View;
using UnityEngine;

public class FireArrowVisuals : MonoBehaviour
{
	[SerializeField]
	private GameObject fireVisuals;

	private HumanoidView humanoidView;

	private EquipmentInstance equippedWeapon;

	private Timer flameVisualsTimer;

	private void ToggleFlameVisuals()
	{
		if (!(humanoidView == null) && humanoidView.HumanoidInstance != null && !humanoidView.HumanoidInstance.HasDisposed && !(fireVisuals == null))
		{
			if (humanoidView.HumanoidInstance.IsNextRoundFlammable())
			{
				fireVisuals.SetActive(value: true);
			}
			else
			{
				fireVisuals.SetActive(value: false);
			}
		}
	}

	private void OnEnable()
	{
		humanoidView = GetComponentInParent<HumanoidView>();
		flameVisualsTimer = new Timer(0.2f);
		flameVisualsTimer.AddCallback(ToggleFlameVisuals);
		flameVisualsTimer.SetRestartOnEnd(value: true);
	}

	private void OnDisable()
	{
		flameVisualsTimer?.Dispose();
		flameVisualsTimer = null;
	}
}
