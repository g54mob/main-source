using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class BuildableVariable : QuestVariableBase
	{
		[Serializable]
		public class PersistentData : IPersistentData
		{
			private uint _id;

			private PersistentReference<Buildable>.Reference _reference;

			public uint ID => _id;

			public PersistentReference<Buildable>.Reference Reference => _reference;

			public PersistentData(BuildableVariable instance)
			{
				_id = instance.Id;
				_reference = instance._buildable;
			}
		}

		[NonSerialized]
		private Buildable _buildable;

		[NonSerialized]
		private PersistentData _persistentData;

		public override QuestVariableType Type => QuestVariableType.Buildable;

		public BuildableVariable()
		{
		}

		private BuildableVariable(BuildableVariable other)
			: base(other)
		{
			_buildable = other._buildable;
			_persistentData = other._persistentData;
		}

		public override bool Initialize()
		{
			return true;
		}

		public override bool Validate()
		{
			return true;
		}

		protected override T Get<T>()
		{
			Buildable buildable = _buildable;
			if (buildable is T)
			{
				return (T)(object)((buildable is T) ? buildable : null);
			}
			return default(T);
		}

		public override void Set<T>(T value)
		{
			if (value is Buildable buildable)
			{
				_buildable = buildable;
			}
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			return true;
		}

		public override object Clone()
		{
			return new BuildableVariable(this);
		}

		public override bool TryGetPersistentData(out IPersistentData persistentData)
		{
			if ((bool)_buildable)
			{
				persistentData = new PersistentData(this);
				return true;
			}
			persistentData = null;
			return false;
		}

		public override bool TryRestorePersistentData(IPersistentData persistentData)
		{
			if (persistentData.ID == base.Id)
			{
				if (persistentData is PersistentData persistentData2)
				{
					_persistentData = persistentData2;
				}
				else
				{
					Debug.LogException(new Exception("Unable to restore BuildableVariable.PersistentData, cast failed."));
				}
				return true;
			}
			return false;
		}

		public override void RestoreReferences()
		{
			_persistentData?.Reference.TryReturnInstance(out _buildable);
		}
	}
}
