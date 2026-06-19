using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public class RoboJanitorDefinition : StaffDefinition
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Robo Janitor Data")]
		public CharacterName Name;

		public int UpfrontCost;

		public LocalisedString JobDescription;

		public int Rank;

		public LocalisedString FlavourTrait;

		public SharedInstance<CharacterTraitDefinition>[] Traits;

		public SharedInstance<QualificationDefinition>[] Qualifications;

		public List<JobDescription> JobExclusions;
	}
}
