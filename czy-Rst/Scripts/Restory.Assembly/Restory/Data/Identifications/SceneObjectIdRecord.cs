using System;
using Restory.TimeSystems;

namespace Restory.Data.Identifications
{
	[Serializable]
	public record SceneObjectIdRecord
	{
		public string ID;

		public string AssetName;

		public string SceneName;

		public string FullPath;

		public UDateTime RegistrationDate;
	}
}
