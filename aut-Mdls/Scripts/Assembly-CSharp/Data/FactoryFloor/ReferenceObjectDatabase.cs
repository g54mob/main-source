#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor
{
	[CreateAssetMenu(menuName = "Factory/ReferenceableObjectDatabase", fileName = "ReferenceableObjectDatabase", order = 0)]
	public class ReferenceObjectDatabase : ScriptableObject
	{
		private int _currentIndex;

		private readonly Dictionary<int, ReferenceFactoryObjectBehaviour> _referenceableObjects = new Dictionary<int, ReferenceFactoryObjectBehaviour>();

		public bool TryGetObjectFromReferenceID(int referenceID, out ReferenceFactoryObjectBehaviour referenceObject)
		{
			return _referenceableObjects.TryGetValue(referenceID, out referenceObject);
		}

		public ReferenceFactoryObjectBehaviour GetObjectFromReferenceID(int referenceID)
		{
			return _referenceableObjects[referenceID];
		}

		public bool ContainsReferenceID(int referenceID)
		{
			return _referenceableObjects.ContainsKey(referenceID);
		}

		public int AddReferenceableObject(ReferenceFactoryObjectBehaviour referenceObject)
		{
			int currentIndex = _currentIndex;
			_referenceableObjects.Add(_currentIndex, referenceObject);
			_currentIndex++;
			return currentIndex;
		}

		public int AddReferenceableObject(ReferenceFactoryObjectBehaviour referenceObject, int referenceID)
		{
			if (_referenceableObjects.ContainsKey(referenceID))
			{
				int num = AddReferenceableObject(referenceObject);
				this.LogError($"Tried to add duplicate referenceable object with ID: {referenceID} Added it with ID: {num} instead.", "AddReferenceableObject", 43);
				return num;
			}
			_referenceableObjects.Add(referenceID, referenceObject);
			_currentIndex = Math.Max(referenceID + 1, _currentIndex);
			return referenceID;
		}

		public void RemoveReferenceableObject(int referenceID)
		{
			_referenceableObjects.Remove(referenceID);
		}

		public void Reset()
		{
			_referenceableObjects.Clear();
			_currentIndex = 0;
		}
	}
}
