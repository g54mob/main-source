using UnityEngine;

public class LaunchableDefenseMechanismInteractor : InteractorBase, DayNightCycle.IDaytimeSensitive
{
	public GameObject focusIndicator;

	public LaunchableProjectile projectilePrefab;

	public Transform projectileSpawn;

	public bool autoReloadOnDawn = true;

	private LaunchableProjectile currentProjectile;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		Reload();
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public override void Focus(PlayerInteraction player)
	{
		if ((bool)currentProjectile)
		{
			focusIndicator.SetActive(value: true);
		}
	}

	public override void InteractionBegin(PlayerInteraction player)
	{
		if ((bool)currentProjectile)
		{
			currentProjectile.Launch();
			currentProjectile.transform.parent = null;
			currentProjectile = null;
			Unfocus(player);
		}
	}

	public void OnDawn_AfterSunrise()
	{
		base.gameObject.SetActive(value: false);
		if (autoReloadOnDawn)
		{
			Reload();
		}
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		base.gameObject.SetActive(value: true);
	}

	public override void Unfocus(PlayerInteraction player)
	{
		focusIndicator.SetActive(value: false);
	}

	public void Reload()
	{
		if (!currentProjectile)
		{
			currentProjectile = Object.Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation, base.transform.parent);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireMesh(projectilePrefab.GetComponentInChildren<MeshFilter>().sharedMesh, 0, projectileSpawn.position, projectileSpawn.rotation, projectilePrefab.transform.localScale);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(projectileSpawn.position, projectileSpawn.position + projectileSpawn.forward * 15f);
		Gizmos.DrawWireSphere(projectileSpawn.position + projectileSpawn.forward * 15f, 0.3f);
	}

	public void OnDuskEarly()
	{
	}
}
