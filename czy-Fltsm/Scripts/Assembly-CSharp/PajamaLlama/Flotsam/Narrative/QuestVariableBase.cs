using System;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public abstract class QuestVariableBase : ICloneable
	{
		public interface IPersistentData
		{
			uint ID { get; }
		}

		[SerializeField]
		[ReadOnly]
		private uint _id;

		[SerializeField]
		private string _name;

		private ListPool<QuestObjectiveBase>.List _referencingObjectives;

		public abstract QuestVariableType Type { get; }

		public string Name => _name;

		public uint Id => _id;

		public Quest OwningQuest { get; private set; }

		public QuestVariableBase()
		{
		}

		public QuestVariableBase(QuestVariableBase other)
		{
			_id = other._id;
			_name = other._name;
		}

		public virtual void SetOwningQuest(Quest quest)
		{
			OwningQuest = quest;
		}

		public void ClearReferencingObjectives()
		{
			_referencingObjectives?.Dispose();
		}

		public abstract bool Initialize();

		public abstract bool Validate();

		public virtual void Dispose()
		{
		}

		public T Get<T>(QuestObjectiveBase objective)
		{
			T result = Get<T>();
			if (objective != null)
			{
				if (_referencingObjectives == null)
				{
					_referencingObjectives = ListPool<QuestObjectiveBase>.Get();
				}
				_referencingObjectives.AddUnique(objective);
			}
			return result;
		}

		protected abstract T Get<T>();

		public virtual void Set<T>(T value)
		{
			Debug.Log(new NotImplementedException());
		}

		public bool IsReferencedByActiveObjective()
		{
			if (_referencingObjectives.IsNullOrEmpty())
			{
				return false;
			}
			foreach (QuestObjectiveBase referencingObjective in _referencingObjectives)
			{
				if (referencingObjective.IsActive && !referencingObjective.IsOptional && !referencingObjective.IsCompleted())
				{
					return true;
				}
			}
			return false;
		}

		public abstract bool ConditionsAreMet(QuestProperties questProperties);

		public abstract object Clone();

		public abstract bool TryGetPersistentData(out IPersistentData persistentData);

		public abstract bool TryRestorePersistentData(IPersistentData persistentData);

		public virtual void RestoreReferences()
		{
		}
	}
}
