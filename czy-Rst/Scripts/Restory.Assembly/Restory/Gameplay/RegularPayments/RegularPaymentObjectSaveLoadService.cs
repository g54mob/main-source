using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentObjectSaveLoadService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent, IDisposable
	{
		private RegularPaymentObjectRegistry registry;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private RegularPaymentObjectServiceSaveData restoredState;

		[Inject]
		private void Construct(RegularPaymentObjectRegistry registry, InteractiveObjectRegistry interactiveObjectRegistry)
		{
			this.registry = registry;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
		}

		public void Dispose()
		{
			registry.Clear();
		}

		public object CaptureState()
		{
			try
			{
				RegularPaymentObjectServiceSaveData regularPaymentObjectServiceSaveData = new RegularPaymentObjectServiceSaveData();
				List<RegularPaymentObjectSaveData> value;
				using (CollectionPool<List<RegularPaymentObjectSaveData>, RegularPaymentObjectSaveData>.Get(out value))
				{
					foreach (RegularPaymentObject item in registry.All)
					{
						if ((bool)item)
						{
							value.Add(new RegularPaymentObjectSaveData
							{
								ID = item.InteractiveObject.UniqueId,
								RegularPaymentInfo = item.RegularPaymentInfo
							});
						}
					}
					regularPaymentObjectServiceSaveData.RegularPaymentObjects = value.ToArray();
				}
				return regularPaymentObjectServiceSaveData;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<RegularPaymentObjectServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState == null || restoredState.RegularPaymentObjects == null)
			{
				return;
			}
			foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
			{
				if (!key.TryGetComponent<RegularPaymentObject>(out var component))
				{
					continue;
				}
				RegularPaymentObjectSaveData[] regularPaymentObjects = restoredState.RegularPaymentObjects;
				foreach (RegularPaymentObjectSaveData regularPaymentObjectSaveData in regularPaymentObjects)
				{
					if (component.InteractiveObject.UniqueId == regularPaymentObjectSaveData.ID)
					{
						component.SetUp(regularPaymentObjectSaveData.RegularPaymentInfo);
						registry.Register(component);
						break;
					}
				}
			}
		}
	}
}
