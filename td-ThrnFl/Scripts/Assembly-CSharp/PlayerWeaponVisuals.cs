using UnityEngine;

public class PlayerWeaponVisuals : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	private GameObject visuals;

	public void Init(GameObject _visuals, ManualAttack _attack)
	{
		visuals = _visuals;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		visuals.GetComponent<PlayerAttackAnimator>().AssignAttack(_attack);
		if (TutorialManager.instance != null)
		{
			visuals.SetActive(value: true);
		}
	}

	public void OnDawn_AfterSunrise()
	{
		visuals.SetActive(value: false);
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		visuals.SetActive(value: true);
	}

	public void OnDuskEarly()
	{
	}
}
