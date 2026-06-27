using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class BoxContainersCreationService
	{
		private readonly InteractiveObjectFactory interactiveObjectFactory;

		private readonly IDService idService;

		public BoxContainersCreationService(InteractiveObjectFactory interactiveObjectFactory, IDService idService)
		{
			this.idService = idService;
			this.interactiveObjectFactory = interactiveObjectFactory;
		}

		public InteractiveObjectBoxContainer TryToCreateOrReplaceBox(InteractiveObjectBoxContainer oldBox, InteractiveObjectInfo boxInfo, Transform spawnPoint, InteractiveObjectState boxState)
		{
			if ((bool)oldBox)
			{
				if (!oldBox.IsEmpty)
				{
					Debug.LogError("Failed to replace oldBox, it is not empty");
					return null;
				}
				interactiveObjectFactory.DestroyInteractiveObject(oldBox.InteractiveObject);
			}
			InteractiveObject interactiveObject = interactiveObjectFactory.CreateInteractiveObject(boxInfo, spawnPoint);
			if (!interactiveObject.TryGetComponent<InteractiveObjectBoxContainer>(out var component))
			{
				Debug.LogError("Failed to create boxContainer, " + boxInfo.ID + " not contains one");
				interactiveObjectFactory.DestroyInteractiveObject(interactiveObject);
				return null;
			}
			interactiveObject.Init(boxState, idService.GenerateNew(), false);
			return component;
		}

		public InteractiveObjectBoxContainer RestoreBox(InteractiveObjectData boxData, Transform boxSpawnPoint, Transform parentForChangedBox)
		{
			if (boxData == null || boxData.HasChanged)
			{
				return null;
			}
			InteractiveObject interactiveObject = interactiveObjectFactory.CreateInteractiveObject(boxData.InteractiveObjectInfo, boxData.HasChanged ? parentForChangedBox : boxSpawnPoint);
			if (!interactiveObject.TryGetComponent<InteractiveObjectBoxContainer>(out var component))
			{
				Debug.LogError("Failed to create box, " + boxData.InteractiveObjectInfo.ID + " not contains one");
				interactiveObjectFactory.DestroyInteractiveObject(interactiveObject);
				return null;
			}
			interactiveObject.Init(boxData.State, boxData.UniqueId, boxData.HasChanged);
			component.transform.SetPositionAndRotation(boxData.InteractiveObjectTransform.Position, boxData.InteractiveObjectTransform.Rotation);
			return component;
		}
	}
}
