using System;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.Resources
{
	[Serializable]
	public class WorkerInstancePreset : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string name;

		[FormerlySerializedAs("workerInstance")]
		[SerializeField]
		public HumanoidInstance HumanoidInstance;

		[SerializeField]
		private string modifiedOnVersion;

		public string Name => name;

		public HumanoidInstance Instance => HumanoidInstance;

		public string ModifiedOnVersion => modifiedOnVersion;

		public WorkerInstancePreset(string id, string name, HumanoidInstance humanoidInstance)
		{
			this.id = id;
			this.name = name;
			HumanoidInstance = humanoidInstance;
			modifiedOnVersion = Application.version;
		}

		public void SetModifiedVersion(string version)
		{
			modifiedOnVersion = version;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
