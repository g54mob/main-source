using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public interface IDragDropElement
	{
		GameObject GameObject { get; }

		bool ShowReadyForDragIndication { get; set; }
	}
}
