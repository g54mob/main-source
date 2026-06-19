using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VisitorDefinition : CharacterDefinition
	{
		[InspectorHeader("Visitor")]
		public ExternalBehavior InitialBehaviour;

		public CharacterName Name;

		public LocalisedString JobTitleLocalised;

		public Character.Sex Sex;

		public Sprite ArrivalSprite;

		public Sprite LeavingSprite;
	}
}
