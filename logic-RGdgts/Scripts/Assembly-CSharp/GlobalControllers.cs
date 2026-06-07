using UnityEngine;

public class GlobalControllers : MonoBehaviour
{
	public static LoggerController loggerController;

	public static SteamController steamController;

	public static WorkshopController workshopController;

	public static ConfigurationController configurationController;

	private void Awake()
	{
	}

	private static T Init<T>() where T : Controller
	{
		return null;
	}
}
