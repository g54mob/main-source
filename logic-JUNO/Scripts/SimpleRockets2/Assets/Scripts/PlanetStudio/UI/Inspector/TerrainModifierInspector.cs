using System;
using System.Collections.Generic;
using Assets.Scripts.PlanetStudio.Flyouts.Noise;
using Assets.Scripts.Ui.Inspector;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.PlanetStudio.UI.Inspector
{
	public class TerrainModifierInspector : ObjectInspector, ITerrainModifierInspector
	{
		public NoiseElement NoiseElement { get; private set; }

		public TerrainModifierInspector(string name, object target, NoiseElement noiseElement)
			: base(name, target)
		{
			NoiseElement = noiseElement;
		}

		public void UpdateVisualization(Action<List<DataSlotField>> getDataSlots)
		{
			NoiseElement.DataSlots.Clear();
			getDataSlots(NoiseElement.DataSlots);
			NoiseElement.PassContainer.UpdateVisualization();
		}
	}
}
