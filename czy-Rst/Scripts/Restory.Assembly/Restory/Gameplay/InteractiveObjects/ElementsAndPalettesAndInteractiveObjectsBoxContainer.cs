using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.InteractiveObjects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Shops.Devices;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class ElementsAndPalettesAndInteractiveObjectsBoxContainer : InteractiveObjectBoxContainer
	{
		[SerializeField]
		private InteractiveObjectInfo elementsContainerInfo;

		[SerializeField]
		private InteractiveObjectInfo palettesContainerInfo;

		private readonly HeldElements containedElements = new HeldElements();

		private readonly List<PaintingPaletteInfo> containedPaintingPalettes = new List<PaintingPaletteInfo>();

		private readonly List<ElementsBoxData> containedElementsBoxes = new List<ElementsBoxData>();

		public override bool IsEmpty
		{
			get
			{
				if (containedElements.AllHeldElements.Count == 0 && containedPaintingPalettes.Count == 0 && containedElementsBoxes.Count == 0)
				{
					return base.IsEmpty;
				}
				return false;
			}
		}

		public IReadOnlyList<HeldElement> ContainedElements => containedElements.AllHeldElements;

		public IReadOnlyList<PaintingPaletteInfo> ContainedPaintingPalettes => containedPaintingPalettes;

		public event Action<InteractiveObject> OnInteractiveObjectTakenOutCompletedWithObjectDestroyed;

		public void SetUpElements(IEnumerable<HeldElement> elements)
		{
			ClearElements();
			foreach (HeldElement element in elements)
			{
				containedElements.AddElement(element);
			}
		}

		public void AddElement(ElementData element)
		{
			containedElements.AddElement(element);
			OnContentAdded();
		}

		public void AddElement(ElementData element, int amount)
		{
			containedElements.AddElement(element, amount);
			OnContentAdded();
		}

		public void AddElement(HeldElement heldElement)
		{
			containedElements.AddElement(heldElement);
			OnContentAdded();
		}

		public void SetUpPalettes(IEnumerable<PaintingPaletteInfo> palettes)
		{
			ClearPalettes();
			containedPaintingPalettes.AddRange(palettes);
		}

		public void AddPalette(PaintingPaletteInfo paintingPalette)
		{
			containedPaintingPalettes.Add(paintingPalette);
			OnContentAdded();
		}

		public void AddElementsBox(ElementsBoxData elementsBoxe)
		{
			containedElementsBoxes.Add(elementsBoxe);
			OnContentAdded();
		}

		public void ClearElements()
		{
			containedElements.Clear();
		}

		public void ClearPalettes()
		{
			containedPaintingPalettes.Clear();
		}

		protected override bool TryToTakeOutObject()
		{
			if (!TryToTakeOutElements() && !TryToTakeOutPalettes() && !TryToTakeOutEllementsBox())
			{
				return base.TryToTakeOutObject();
			}
			return true;
		}

		private bool TryToTakeOutElements()
		{
			if (containedElements.AllHeldElements.Count == 0)
			{
				return false;
			}
			takenObjectInfo = elementsContainerInfo;
			takenObject = GetInteractiveObject(takenObjectInfo);
			if (!takenObject.TryGetComponent<ElementsContainer>(out var component))
			{
				interactiveObjectFactory.DestroyInteractiveObject(takenObject);
				Debug.LogError("[ElementsAndPalettesAndInteractiveObjectsBoxContainer] was unable to create an elements container, because prefab from SO '" + takenObjectInfo.ID + "' has no [ElementsContainer] component!");
				return false;
			}
			foreach (HeldElement allHeldElement in containedElements.AllHeldElements)
			{
				component.AddElement(allHeldElement);
			}
			return true;
		}

		private bool TryToTakeOutPalettes()
		{
			if (containedPaintingPalettes.Count == 0)
			{
				return false;
			}
			takenObjectInfo = palettesContainerInfo;
			takenObject = GetInteractiveObject(takenObjectInfo);
			if (!takenObject.TryGetComponent<PaintingPalettesContainer>(out var component))
			{
				interactiveObjectFactory.DestroyInteractiveObject(takenObject);
				Debug.LogError("[ElementsAndPalettesAndInteractiveObjectsBoxContainer] was unable to create a painting palettes container, because prefab from SO '" + takenObjectInfo.ID + "' has no [PaintingPalettesContainer] component!");
				return false;
			}
			foreach (PaintingPaletteInfo containedPaintingPalette in containedPaintingPalettes)
			{
				component.AddPalette(containedPaintingPalette);
			}
			return true;
		}

		private bool TryToTakeOutEllementsBox()
		{
			if (containedElementsBoxes.Count == 0)
			{
				return false;
			}
			ElementsBoxData elementsBoxData = containedElementsBoxes[0];
			takenObjectInfo = elementsBoxData.Info;
			takenObject = GetInteractiveObject(takenObjectInfo);
			if (!takenObject.TryGetComponent<ElementsBox>(out var component))
			{
				interactiveObjectFactory.DestroyInteractiveObject(takenObject);
				Debug.LogError("[ElementsAndPalettesAndInteractiveObjectsBoxContainer] was unable to create an elements box, because prefab from SO '" + takenObjectInfo.ID + "' has no [ElementsBox] component!");
				return false;
			}
			component.Init(elementsBoxData);
			return true;
		}

		protected override void RemoveTakenObjectContentsFromTheBox()
		{
			PaintingPalettesContainer component2;
			ElementsBox component3;
			if (takenObject.TryGetComponent<ElementsContainer>(out var _))
			{
				ClearElements();
			}
			else if (takenObject.TryGetComponent<PaintingPalettesContainer>(out component2))
			{
				ClearPalettes();
			}
			else if (takenObject.TryGetComponent<ElementsBox>(out component3))
			{
				if (containedElementsBoxes.Count == 0 || takenObjectInfo != containedElementsBoxes[0].Info)
				{
					Debug.LogError("First contained ElementsBox not equal to taken object");
				}
				else
				{
					containedElementsBoxes.RemoveAt(0);
				}
			}
			else
			{
				base.RemoveTakenObjectContentsFromTheBox();
			}
		}

		protected override void HandleObjectDragSuccessfullyCompleted()
		{
			if (takenObject.TryGetComponent<ElementsContainer>(out var _) || takenObject.TryGetComponent<PaintingPalettesContainer>(out var _) || takenObject.TryGetComponent<ElementsBox>(out var _))
			{
				DestroyTakenObject();
			}
			else
			{
				base.HandleObjectDragSuccessfullyCompleted();
			}
		}

		private void DestroyTakenObject()
		{
			if (!takenObject)
			{
				Debug.LogError("Failed to destroy taken object, it is lost");
				return;
			}
			RemoveTakenObjectContentsFromTheBox();
			DestroyInteractiveObjectInstance(takenObject);
			this.OnInteractiveObjectTakenOutCompletedWithObjectDestroyed?.Invoke(takenObject);
			takenObject = null;
			takenObjectInfo = null;
		}
	}
}
