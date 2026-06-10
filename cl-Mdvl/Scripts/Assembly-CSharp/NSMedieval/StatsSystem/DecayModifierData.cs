using NSMedieval.Model;

namespace NSMedieval.StatsSystem
{
	public class DecayModifierData
	{
		private DecayModifiers decomposeModifier;

		private DecayModifiers rotModifier;

		private DecayModifiers fermentModifier;

		public AttributeType AttributeType { get; }

		public string Label { get; private set; }

		public float GroundCoefficient { get; }

		public float TempCoefficient { get; }

		public float WeatherCoefficient { get; }

		public float WaterCoefficient { get; }

		public DecayModifierData(AttributeType attributeType, float groundCoefficient, float tempCoefficient, float weatherCoefficient, float waterCoefficient)
		{
			AttributeType = attributeType;
			GroundCoefficient = groundCoefficient;
			TempCoefficient = tempCoefficient;
			WeatherCoefficient = weatherCoefficient;
			WaterCoefficient = waterCoefficient;
		}

		public void SetLabel(string label)
		{
			Label = label;
		}

		public void SetModifiers(Resource blueprint)
		{
			decomposeModifier = blueprint.DecomposeModifiers;
			rotModifier = blueprint.RottingModifiers;
			fermentModifier = blueprint.FermentingModifiers;
		}

		public DecayModifiers GetModifier()
		{
			return AttributeType switch
			{
				AttributeType.DecomposeSpeed => decomposeModifier, 
				AttributeType.RottingSpeed => rotModifier, 
				AttributeType.FermentingSpeed => fermentModifier, 
				_ => null, 
			};
		}
	}
}
