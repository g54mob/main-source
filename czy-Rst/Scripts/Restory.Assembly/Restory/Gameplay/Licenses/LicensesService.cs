using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Licenses;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Licenses
{
	public sealed class LicensesService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly HashSet<LicenseInfo> activeLicenses = new HashSet<LicenseInfo>();

		public IReadOnlyCollection<LicenseInfo> ActiveLicenses => activeLicenses;

		public event Action<LicensesService, LicenseInfo> OnLicenseAdded;

		public event Action<LicensesService> OnLicensesChanged;

		public void Add(LicenseInfo license)
		{
			activeLicenses.Add(license);
			this.OnLicenseAdded?.Invoke(this, license);
			this.OnLicensesChanged?.Invoke(this);
		}

		public void Remove(LicenseInfo license)
		{
			activeLicenses.Remove(license);
			this.OnLicensesChanged?.Invoke(this);
		}

		public bool Contains(LicenseInfo license)
		{
			return activeLicenses.Contains(license);
		}

		public bool IsLicensed(DeviceInfo deviceInfo)
		{
			if ((bool)deviceInfo.License)
			{
				return Contains(deviceInfo.License);
			}
			return true;
		}

		public void RestoreState(object state)
		{
			try
			{
				LicensesServiceSaveData licensesServiceSaveData = DataMigrationWizard.Migrate<LicensesServiceSaveData>(state, base.gameObject);
				activeLicenses.Clear();
				LicenseInfo[] array = licensesServiceSaveData.ActiveLicenses;
				foreach (LicenseInfo item in array)
				{
					activeLicenses.Add(item);
				}
				this.OnLicensesChanged?.Invoke(this);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new LicensesServiceSaveData
				{
					ActiveLicenses = activeLicenses.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
