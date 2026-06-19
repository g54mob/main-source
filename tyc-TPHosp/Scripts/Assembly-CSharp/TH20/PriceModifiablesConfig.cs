using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Pricing Categories", order = 1107)]
	public class PriceModifiablesConfig : BaseScriptableObject
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Modifiable
		{
			public LocalisedString NameLocalised;

			public SharedInstance<FinanceModifier> FinanceModifier;

			public int PercentageDelta = 5;

			public int PercentageMin = -50;

			public int PercentageMax = 50;

			public Sprite IconSprite;
		}

		[InspectorMargin(8)]
		public int DiagnosisPercentageDelta = 5;

		public int DiagnosisPercentageMin = -50;

		public int DiagnosisPercentageMax = 50;

		[InspectorMargin(8)]
		public int TreatmentPercentageDelta = 5;

		public int TreatmentPercentageMin = -50;

		public int TreatmentPercentageMax = 50;

		[InspectorMargin(8)]
		public List<Modifiable> Modifiables = new List<Modifiable>();
	}
}
