using System;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Common
{
	public class OverlayCanvasProviderService
	{
		private Transform mainCanvas;

		private Transform buildingPopoversCanvas;

		private Transform markersCanvas;

		private Transform playerPopoversCanvas;

		public OverlayCanvasProviderService([Inject(Id = "GameplayOverlayCanvas")] Transform mainCanvas, [Inject(Id = "BuildingPopoversCanvas")] Transform buildingPopoversCanvas, [Inject(Id = "MarkersCanvas")] Transform markersCanvas, [Inject(Id = "PlayerPopoversCanvas")] Transform playerPopoversCanvas)
		{
			this.mainCanvas = mainCanvas;
			this.markersCanvas = markersCanvas;
			this.buildingPopoversCanvas = buildingPopoversCanvas;
			this.playerPopoversCanvas = playerPopoversCanvas;
		}

		public Transform GetCanvasTransform(GameplayOverlaySubCanvas canvas)
		{
			return canvas switch
			{
				GameplayOverlaySubCanvas.Default => mainCanvas, 
				GameplayOverlaySubCanvas.BuildingPopovers => buildingPopoversCanvas, 
				GameplayOverlaySubCanvas.CommonMarkers => markersCanvas, 
				GameplayOverlaySubCanvas.PlayerPopovers => playerPopoversCanvas, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
