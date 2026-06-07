using DV.Customization;
using DV.TimeKeeping;
using DV.UI.LocoHUD;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.HUD
{
	public class TrackInfoInterfacer : MonoBehaviour
	{
		private HUDManager manager;

		private void Start()
		{
			manager = SingletonBehaviour<HUDManager>.Instance;
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += InstanceOnHUDChanged;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged -= InstanceOnHUDChanged;
				if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
				{
					SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged -= CheckTime;
				}
			}
		}

		private void InstanceOnHUDChanged(HUDInterfacer.HUDChangeEvent ev)
		{
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				return;
			}
			if ((bool)ev.newControls && (bool)manager.currentHUD.cab.time)
			{
				bool flag = SingletonBehaviour<WorldClockController>.Instance != null && SingletonBehaviour<WorldClockController>.Instance.PlayerHasClock;
				if (!flag)
				{
					foreach (DV.Customization.Customization.CustomizerBase customizer in ev.newBase.car.Customization.Customizers)
					{
						if (customizer.name.StartsWith("gadget_digital_clock"))
						{
							flag = true;
							break;
						}
					}
				}
				manager.SetClockShown(flag);
				if (flag)
				{
					SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged += CheckTime;
					manager.SetTime(SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime, force: true);
				}
			}
			else
			{
				SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged -= CheckTime;
			}
		}

		private void CheckTime()
		{
			manager.SetTime(SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime);
		}
	}
}
