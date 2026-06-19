using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CollaborativeProjectList
	{
		public List<SharedInstance<CollaborativeProjectDefinition>> Projects;

		public Dictionary<CollaborativeMetagameData.TutorialType, CollaborativeMetagameData.TutorialData> TutorialData;

		public Sprite SuperBugIcon;
	}
}
