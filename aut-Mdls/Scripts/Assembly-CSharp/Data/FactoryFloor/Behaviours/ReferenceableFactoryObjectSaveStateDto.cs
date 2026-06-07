using System;
using System.Collections.Generic;
using SaveData.FactoryFloor.SaveStates;

namespace Data.FactoryFloor.Behaviours
{
	[Serializable]
	public class ReferenceableFactoryObjectSaveStateDto : BehaviourSaveStateDto
	{
		public int ReferenceID;

		public List<int> ReferencedObjectIDs = new List<int>();

		public ReferenceableFactoryObjectSaveStateDto(int referenceID, List<int> referencedObjectIDs)
		{
			ReferenceID = referenceID;
			ReferencedObjectIDs = referencedObjectIDs;
		}
	}
}
