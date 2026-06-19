using Pug.Conversion;
using UnityEngine;

namespace Pug.Automation
{
	public class ElectricityConverter : SingleAuthoringComponentConverter<ElectricityAuthoring>
	{
		protected override void Convert(ElectricityAuthoring authoring)
		{
			CircuitType circuitType = authoring.circuitType;
			if ((uint)(circuitType - 1) <= 1u)
			{
				EnsureHasComponent<DirectionBasedOnVariationCD>();
			}
			if (authoring.direction != Vector2Int.zero)
			{
				CircuitConnectionMode circuitConnectionMode = authoring.circuitConnectionMode;
				if (circuitConnectionMode != CircuitConnectionMode.AccordingToDirection && circuitConnectionMode != CircuitConnectionMode.None)
				{
					Debug.LogError("Incompatible options on " + authoring.name + ": direction ignored for cross connector");
				}
			}
			if (authoring.circuitType == CircuitType.None && authoring.circuitConnectionMode == CircuitConnectionMode.AccordingToDirection)
			{
				Debug.LogError("Non supported setup with circuit connection mode according to direction without circuit type");
			}
			CircuitConnectionMode circuitConnectionMode2 = authoring.circuitConnectionMode;
			if (authoring.circuitType != CircuitType.None)
			{
				circuitConnectionMode2 = CircuitConnectionMode.None;
			}
			AddComponentData(new ElectricityCD
			{
				blocksElectricity = (authoring.circuitType != CircuitType.None || authoring.blocksElectricity),
				hasDirection = (authoring.direction != Vector2Int.zero),
				sourceEnergy = Mathf.Min(25, authoring.sourceEnergy),
				circuitType = authoring.circuitType,
				blocksElectricityWhenVariationIsZero = authoring.isLever,
				circuitConnectionMode = circuitConnectionMode2,
				deprioritize = authoring.isWire
			});
		}
	}
}
