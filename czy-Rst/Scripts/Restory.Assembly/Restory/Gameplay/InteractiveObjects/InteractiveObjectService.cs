using System;
using System.Collections.Generic;
using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Workplace;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IDisposable
	{
		private IDService idService;

		private InteractiveObjectFactory interactiveObjectFactory;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private StorageSpaces storageSpaces;

		private WorkSurface workSurface;

		public bool AnyObjectOnSurface
		{
			get
			{
				foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
				{
					if (key.State == InteractiveObjectState.Placed)
					{
						return true;
					}
				}
				return false;
			}
		}

		[Inject]
		private void Construct(IDService idService, InteractiveObjectFactory interactiveObjectFactory, InteractiveObjectRegistry interactiveObjectRegistry, StorageSpaces storageSpaces, WorkSurface workSurface)
		{
			this.idService = idService;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.storageSpaces = storageSpaces;
			this.workSurface = workSurface;
		}

		public void Dispose()
		{
			interactiveObjectRegistry.Clear();
		}

		public InteractiveObject CreateNewInteractiveObject(InteractiveObjectInfo objectInfo, Transform targetTransform)
		{
			string uniqueId = idService.GenerateNew();
			InteractiveObjectState state = (targetTransform.IsChildOf(workSurface.transform) ? InteractiveObjectState.Placed : InteractiveObjectState.Stored);
			InteractiveObject interactiveObject = interactiveObjectFactory.CreateInteractiveObject(objectInfo, targetTransform.parent);
			interactiveObject.transform.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
			interactiveObject.Init(state, uniqueId, false);
			interactiveObjectRegistry.Register(interactiveObject, objectInfo);
			return interactiveObject;
		}

		public void RestoreState(object state)
		{
			try
			{
				foreach (InteractiveObjectData interactiveObject2 in DataMigrationWizard.Migrate<InteractiveObjectRegistrySaveData>(state, base.gameObject).InteractiveObjects)
				{
					InteractiveObject interactiveObject = interactiveObjectFactory.CreateInteractiveObject(interactiveObject2.InteractiveObjectInfo, storageSpaces.transform);
					interactiveObject.transform.position = interactiveObject2.InteractiveObjectTransform.Position;
					interactiveObject.transform.rotation = interactiveObject2.InteractiveObjectTransform.Rotation;
					interactiveObjectRegistry.Register(interactiveObject, interactiveObject2.InteractiveObjectInfo);
					interactiveObject.Init(interactiveObject2.State, interactiveObject2.UniqueId, interactiveObject2.HasChanged, interactiveObject2.InteractiveObjectAdditionalProperties);
				}
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
				List<InteractiveObjectData> list = new List<InteractiveObjectData>();
				foreach (var (interactiveObject2, interactiveObjectInfo2) in interactiveObjectRegistry.All)
				{
					if (interactiveObject2 == null)
					{
						Debug.LogError("[InteractiveObjectService] Attempt to save an empty interactive object " + interactiveObjectInfo2?.ID);
						continue;
					}
					list.Add(new InteractiveObjectData
					{
						InteractiveObjectInfo = interactiveObjectInfo2,
						InteractiveObjectTransform = new SerializableTransform(interactiveObject2.transform),
						State = interactiveObject2.State,
						UniqueId = interactiveObject2.UniqueId,
						HasChanged = interactiveObject2.HasChanged,
						InteractiveObjectAdditionalProperties = interactiveObject2.AdditionalProperties
					});
				}
				return new InteractiveObjectRegistrySaveData
				{
					InteractiveObjects = list
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
