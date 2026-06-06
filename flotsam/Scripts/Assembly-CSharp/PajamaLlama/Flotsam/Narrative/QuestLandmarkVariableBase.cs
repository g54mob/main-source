using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public abstract class QuestLandmarkVariableBase : QuestVariableBase
	{
		[Serializable]
		public class PersistentData : IPersistentData
		{
			private uint _id;

			private LandmarkSpawner.PersistentReference _reference;

			public uint ID => _id;

			public LandmarkSpawner.PersistentReference Reference => _reference;

			public PersistentData(QuestLandmarkVariableBase questLandmarkVariableBase)
			{
				_ = questLandmarkVariableBase._landmarkSpawner.Region;
				_id = questLandmarkVariableBase.Id;
				_reference = questLandmarkVariableBase._landmarkSpawner.GetPersistentReference();
			}
		}

		[NonSerialized]
		protected LandmarkSpawner _landmarkSpawner;

		[NonSerialized]
		private PersistentData _persistentData;

		public override QuestVariableType Type => QuestVariableType.Landmark;

		public QuestLandmarkVariableBase()
		{
		}

		public QuestLandmarkVariableBase(QuestLandmarkVariableBase other)
			: base(other)
		{
		}

		public override bool Initialize()
		{
			if (_landmarkSpawner == null)
			{
				_landmarkSpawner = GetLandmarkSpawner();
			}
			return _landmarkSpawner != null;
		}

		public override bool Validate()
		{
			if (IsReferencedByActiveObjective())
			{
				if (_landmarkSpawner != null)
				{
					return _landmarkSpawner.WorldTile.IsActive;
				}
				return false;
			}
			return true;
		}

		public override void Dispose()
		{
			_landmarkSpawner?.Dispose();
			_landmarkSpawner = null;
		}

		protected override T Get<T>()
		{
			if (_landmarkSpawner == null && !TryRestore())
			{
				_landmarkSpawner = GetLandmarkSpawner();
			}
			LandmarkSpawner landmarkSpawner = _landmarkSpawner;
			if (landmarkSpawner is T)
			{
				return (T)(object)((landmarkSpawner is T) ? landmarkSpawner : null);
			}
			return default(T);
		}

		protected abstract LandmarkSpawner GetLandmarkSpawner();

		public override bool TryGetPersistentData(out IPersistentData persistentData)
		{
			if (_landmarkSpawner == null)
			{
				persistentData = null;
				return false;
			}
			persistentData = new PersistentData(this);
			return true;
		}

		public override bool TryRestorePersistentData(IPersistentData persistentData)
		{
			if (persistentData.ID == base.Id)
			{
				_persistentData = persistentData as PersistentData;
				if (_persistentData == null)
				{
					Debug.LogException(new Exception("Unable to restore QuestLandmarkVariable.PersistentData, cast failed."));
				}
				return true;
			}
			return false;
		}

		protected virtual bool TryRestore()
		{
			if (_persistentData == null)
			{
				return false;
			}
			if (_persistentData.Reference.TryGet(out _landmarkSpawner))
			{
				return true;
			}
			Debug.LogException(new Exception("Unable to restore landmark variable."));
			_persistentData = null;
			return false;
		}
	}
}
