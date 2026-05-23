using System;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class CutterBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public bool HasCutShape;

		public bool HasResource;

		public string[] OutputHashes;

		public int CurrentOutputIndex;

		public string CurrentResourceHash;
	}
}
