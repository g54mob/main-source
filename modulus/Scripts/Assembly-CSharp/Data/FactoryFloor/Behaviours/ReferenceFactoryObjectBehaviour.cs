using System;
using System.Collections.Generic;
using System.Text;
using NaughtyAttributes;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ReferenceableFactoryObjectBehaviour", fileName = "ReferenceableFactoryObjectBehaviour", order = 0)]
	public class ReferenceFactoryObjectBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[SerializeField]
		private bool _manuallySetReferenceId;

		[SerializeField]
		[ShowIf("_manuallySetReferenceId")]
		private int _referenceId = -1;

		private int _referenceID;

		private readonly List<ReferenceFactoryObjectBehaviour> _referencedObjects = new List<ReferenceFactoryObjectBehaviour>();

		public int ReferenceID => _referenceID;

		public int ManuallySetReferenceID => _referenceId;

		public List<ReferenceFactoryObjectBehaviour> ReferencedObjects => _referencedObjects;

		public event Action<ReferenceFactoryObjectBehaviour> OnReferencesInitialized = delegate
		{
		};

		public event Action<ReferenceFactoryObjectBehaviour> OnAddedReferencedObject = delegate
		{
		};

		public event Action<ReferenceFactoryObjectBehaviour> OnRemovedReferencedObject = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_factoryObject.OnObjectLinked += AddReference;
			_factoryObject.OnObjectUnLinked += RemoveReference;
			AddLinkedObjectsAsReferences();
			ReferenceableFactoryObjectSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<ReferenceableFactoryObjectSaveStateDto>();
			if (_manuallySetReferenceId)
			{
				_referenceID = _referenceId;
			}
			else if (behaviourSaveStateDto == null)
			{
				_referenceID = _referenceObjectDatabase.AddReferenceableObject(this);
			}
			else
			{
				_referenceID = _referenceObjectDatabase.AddReferenceableObject(this, behaviourSaveStateDto.ReferenceID);
			}
			if (behaviourSaveStateDto == null || behaviourSaveStateDto.ReferencedObjectIDs == null)
			{
				return;
			}
			foreach (int referencedObjectID in behaviourSaveStateDto.ReferencedObjectIDs)
			{
				if (_referenceObjectDatabase.TryGetObjectFromReferenceID(referencedObjectID, out var referenceObject))
				{
					AddReference(referenceObject);
				}
			}
			this.OnReferencesInitialized(this);
		}

		public override void UnInit()
		{
			_referenceObjectDatabase.RemoveReferenceableObject(_referenceID);
			_factoryObject.OnObjectLinked -= AddReference;
			_factoryObject.OnObjectUnLinked -= RemoveReference;
			base.UnInit();
		}

		private void AddLinkedObjectsAsReferences()
		{
			if (_factoryObject.IsSoftLinked)
			{
				foreach (FactoryObject softLinkedObject in _factoryObject.SoftLinkedObjects)
				{
					if (softLinkedObject.HasFactoryObjectBehaviour(out ReferenceFactoryObjectBehaviour behaviour))
					{
						AddReference(behaviour);
					}
				}
			}
			if (!_factoryObject.IsHardLinked)
			{
				return;
			}
			foreach (FactoryObject hardLinkedObject in _factoryObject.HardLinkedObjects)
			{
				if (hardLinkedObject.HasFactoryObjectBehaviour(out ReferenceFactoryObjectBehaviour behaviour2))
				{
					AddReference(behaviour2);
				}
			}
		}

		private void AddReference(FactoryObject factoryObject)
		{
			if (factoryObject.HasFactoryObjectBehaviour(out ReferenceFactoryObjectBehaviour behaviour))
			{
				AddReference(behaviour);
			}
		}

		public void AddReference(ReferenceFactoryObjectBehaviour referenceObject)
		{
			if (!_referencedObjects.Contains(referenceObject))
			{
				_referencedObjects.Add(referenceObject);
				referenceObject.AddReference(this);
				this.OnAddedReferencedObject(referenceObject);
			}
		}

		private void RemoveReference(FactoryObject thisFactoryObject, FactoryObject linkFactoryObject)
		{
			if (linkFactoryObject.HasFactoryObjectBehaviour(out ReferenceFactoryObjectBehaviour behaviour))
			{
				RemoveReference(behaviour);
			}
		}

		public void RemoveReference(ReferenceFactoryObjectBehaviour removeReference)
		{
			if (_referencedObjects.Contains(removeReference))
			{
				_referencedObjects.Remove(removeReference);
				removeReference.RemoveReference(this);
				this.OnRemovedReferencedObject(removeReference);
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			List<int> list = new List<int>();
			foreach (ReferenceFactoryObjectBehaviour referencedObject in _referencedObjects)
			{
				list.Add(referencedObject.ReferenceID);
			}
			return new ReferenceableFactoryObjectSaveStateDto(_referenceID, list);
		}

		public override void Update()
		{
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("ReferenceID: ");
			stringBuilder.Append(_referenceID);
			for (int i = 0; i < _referencedObjects.Count; i++)
			{
				stringBuilder.Append("\nReferenced Object ");
				stringBuilder.Append(i);
				stringBuilder.Append(" ID: ");
				stringBuilder.Append("_referencedObjects[i].ReferenceID");
			}
			return stringBuilder.ToString();
		}
	}
}
