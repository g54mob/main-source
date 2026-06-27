using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.ObjectPools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.Identifications
{
	[DisallowMultipleComponent]
	public class Identificator : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, ICleanableComponent, IDirtyComponent
	{
		[SerializeField]
		[Tooltip("Unique ID - the ID, which should be filled for Unique GameObject (In prefab)")]
		private UniqueIdentificator uniqueId;

		[SerializeField]
		[FormerlySerializedAs("identifier")]
		[Tooltip("The ID, which should be generated on the Scene, or in runtime")]
		private string sceneIdentifier = string.Empty;

		public bool IsDirty { get; private set; } = true;

		public bool HasUniqueId => uniqueId != null;

		public bool HasDynamicId => !string.IsNullOrEmpty(sceneIdentifier);

		public bool HasAnyId
		{
			get
			{
				if (!HasUniqueId)
				{
					return HasDynamicId;
				}
				return true;
			}
		}

		public string ID
		{
			get
			{
				if (!HasUniqueId)
				{
					return sceneIdentifier;
				}
				return uniqueId.ID;
			}
		}

		public bool IsEmptyOrNull => string.IsNullOrEmpty(ID);

		public void SetID(string id)
		{
			sceneIdentifier = id;
			SetDirty();
		}

		public object CaptureState()
		{
			try
			{
				IdentificatorSaveData result = new IdentificatorSaveData
				{
					ID = (string)ID.Clone()
				};
				IsDirty = false;
				return result;
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
				if (HasUniqueId)
				{
					IsDirty = false;
					return;
				}
				IdentificatorSaveData identificatorSaveData = DataMigrationWizard.Migrate<IdentificatorSaveData>(state, base.gameObject);
				sceneIdentifier = identificatorSaveData.ID;
				IsDirty = false;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void Clean()
		{
			sceneIdentifier = string.Empty;
			SetDirty();
		}

		private void SetDirty()
		{
			IsDirty = true;
		}
	}
}
