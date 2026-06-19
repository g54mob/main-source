using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public struct ChallengeNoticeDef
	{
		[FullInspector.InspectorName("Title")]
		public LocalisedString TitleLocalised;

		[FullInspector.InspectorName("Main Body")]
		public LocalisedString MainBodyLocalised;

		[FullInspector.InspectorName("Main Body (alternatives)")]
		public List<LocalisedString> MainBodyAlternativesLocalised;

		[FullInspector.InspectorName("Button Accept Text")]
		public LocalisedString ButtonAcceptTextLocalised;

		[FullInspector.InspectorName("Button Decline Text")]
		public LocalisedString ButtonDeclineTextLocalised;

		public Sprite Icon;

		public bool ShowImmediately;

		public int TimeOutSeconds;

		public int DefaultChoice;
	}
}
