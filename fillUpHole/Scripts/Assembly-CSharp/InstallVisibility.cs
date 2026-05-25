using UnityEngine;

public class InstallVisibility : MonoBehaviour
{
	public enum EntityTypeEnum
	{
		SteamLogo = 0,
		ItchLogo = 1,
		DemoLogo = 2,
		QuitButton = 3
	}

	public EntityTypeEnum EntityType;

	private void Start()
	{
		if (EntityType == EntityTypeEnum.SteamLogo)
		{
			base.gameObject.SetActive(Installation.CanSeeSteamLogo());
		}
		if (EntityType == EntityTypeEnum.ItchLogo)
		{
			base.gameObject.SetActive(Installation.CanSeeItchLogo());
		}
		if (EntityType == EntityTypeEnum.DemoLogo)
		{
			base.gameObject.SetActive(Installation.IsDemo());
		}
		if (EntityType == EntityTypeEnum.QuitButton)
		{
			base.gameObject.SetActive(!Installation.IsWeb());
		}
	}
}
