using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PersonalBoxService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private InteractiveObjectFactory interactiveObjectFactory;

		private StorageSpaces storageSpaces;

		private InteractiveObjectInfo personalBoxInfo;

		private InteractiveObjectBoxContainer personalBox;

		private PersonalBoxAppearanceController appearanceController;

		public InteractiveObjectBoxContainer PersonalBox => personalBox;

		public event Action<PersonalBoxService> OnPersonalBoxCreated;

		public event Action<PersonalBoxService> OnPersonalBoxAppearanceCompleted;

		[Inject]
		private void Construct(InteractiveObjectFactory interactiveObjectFactory, StorageSpaces storageSpaces)
		{
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.storageSpaces = storageSpaces;
		}

		public void CreatePersonalBox(IEnumerable<InteractiveObjectInfo> personalObjects, InteractiveObjectData boxData)
		{
			List<ContainedInteractiveObject> list = new List<ContainedInteractiveObject>();
			foreach (InteractiveObjectInfo personalObject in personalObjects)
			{
				list.Add(new ContainedInteractiveObject(personalObject));
			}
			CreatePersonalBox(list, boxData);
		}

		public void CreatePersonalBox(IEnumerable<ContainedInteractiveObject> personalObjects, InteractiveObjectData boxData)
		{
			if ((bool)personalBox)
			{
				Debug.LogError("personalBox have already been created");
				return;
			}
			InteractiveObject interactiveObject = interactiveObjectFactory.CreateInteractiveObject(boxData.InteractiveObjectInfo, storageSpaces.transform);
			if (!interactiveObject.TryGetComponent<InteractiveObjectBoxContainer>(out personalBox))
			{
				Debug.LogError("Interactive object " + personalBoxInfo.ID + " prefab is not a personal box");
				interactiveObjectFactory.DestroyInteractiveObject(interactiveObject);
				return;
			}
			interactiveObject.Init(boxData.State, boxData.UniqueId, boxData.HasChanged);
			personalBoxInfo = boxData.InteractiveObjectInfo;
			personalBox.transform.SetPositionAndRotation(boxData.InteractiveObjectTransform.Position, boxData.InteractiveObjectTransform.Rotation);
			personalBox.Init(personalObjects);
			this.OnPersonalBoxCreated?.Invoke(this);
		}

		public void ActivatePersonalBoxAppearance()
		{
			if ((bool)appearanceController)
			{
				Debug.LogError("PersonalBoxAppearanceController is already activated");
				return;
			}
			if (!personalBox || !personalBox.TryGetComponent<PersonalBoxAppearanceController>(out appearanceController))
			{
				Debug.LogError("Appearance of personalBox have not been activated");
				return;
			}
			appearanceController.OnAppearanceCompleted += ResolveOnAppearanceCompleted;
			appearanceController.ActivateAppearance();
		}

		private void ResolveOnAppearanceCompleted()
		{
			appearanceController.OnAppearanceCompleted -= ResolveOnAppearanceCompleted;
			appearanceController = null;
			this.OnPersonalBoxAppearanceCompleted?.Invoke(this);
		}

		public void RestoreState(object state)
		{
			try
			{
				PersonalBoxSaveData personalBoxSaveData = DataMigrationWizard.Migrate<PersonalBoxSaveData>(state, base.gameObject);
				if (!personalBoxSaveData.IsRemoved)
				{
					InteractiveObjectData interactiveObjectData = personalBoxSaveData.InteractiveObjectData;
					CreatePersonalBox(personalBoxSaveData.BoxContent, interactiveObjectData);
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
				PersonalBoxSaveData personalBoxSaveData = new PersonalBoxSaveData();
				if (!personalBox)
				{
					personalBoxSaveData.IsRemoved = true;
					return personalBoxSaveData;
				}
				InteractiveObjectData interactiveObjectData = new InteractiveObjectData
				{
					InteractiveObjectInfo = personalBoxInfo,
					InteractiveObjectTransform = new SerializableTransform(personalBox.transform),
					State = personalBox.InteractiveObject.State,
					HasChanged = personalBox.InteractiveObject.HasChanged,
					InteractiveObjectAdditionalProperties = (personalBox.InteractiveObject.AdditionalProperties.Clone() as InteractiveObjectAdditionalProperties)
				};
				personalBoxSaveData.BoxContent = personalBox.Content.ToList();
				personalBoxSaveData.InteractiveObjectData = interactiveObjectData;
				return personalBoxSaveData;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
