using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public class PlatformFeatureGameObjectSwitcher : MonoBehaviour
	{
		[SerializeField]
		private PlatformFeature m_enabledForFeatures;

		private IPlatform m_platform;

		private IKeyboard m_keyboard;

		private bool m_supportsUsers;

		private bool m_supportsAchievements;

		private void Awake()
		{
			ServiceLocator.TryGetService<IPlatform>(out m_platform);
			ServiceLocator.TryGetService<IKeyboard>(out m_keyboard);
			m_supportsUsers = ServiceLocator.TryGetService<IUserService>(out var _);
			m_supportsAchievements = ServiceLocator.TryGetService<IAchievementService>(out var _);
		}

		private void OnEnable()
		{
			switch (m_enabledForFeatures)
			{
			case PlatformFeature.CanQuit:
				SetEnabled(m_platform.SupportsQuit);
				break;
			case PlatformFeature.CanModifyWindowSettings:
				SetEnabled(m_platform.AllowsUserWindowModification);
				break;
			case PlatformFeature.SupportsSystemUsers:
				SetEnabled(m_supportsUsers);
				break;
			case PlatformFeature.SupportsSystemAchievements:
				SetEnabled(m_supportsAchievements);
				break;
			case PlatformFeature.SupportsOnScreenKeyboard:
				break;
			}
		}

		private void SetEnabled(bool value)
		{
			base.gameObject.SetActive(value);
		}

		public static bool CurrentPlatformSupportsFeature(PlatformFeature feature)
		{
			switch (feature)
			{
			case PlatformFeature.CanQuit:
			{
				ServiceLocator.TryGetService<IPlatform>(out var service5);
				return service5.SupportsQuit;
			}
			case PlatformFeature.CanModifyWindowSettings:
			{
				ServiceLocator.TryGetService<IPlatform>(out var service4);
				return service4.AllowsUserWindowModification;
			}
			case PlatformFeature.SupportsSystemUsers:
			{
				IUserService service3;
				return ServiceLocator.TryGetService<IUserService>(out service3);
			}
			case PlatformFeature.SupportsSystemAchievements:
			{
				IAchievementService service2;
				return ServiceLocator.TryGetService<IAchievementService>(out service2);
			}
			case PlatformFeature.SupportsOnScreenKeyboard:
			{
				IKeyboard service;
				return ServiceLocator.TryGetService<IKeyboard>(out service);
			}
			case PlatformFeature.SupportsMouse:
				return true;
			case PlatformFeature.SupportsHardwareKeyboard:
				return true;
			default:
				return false;
			}
		}
	}
}
