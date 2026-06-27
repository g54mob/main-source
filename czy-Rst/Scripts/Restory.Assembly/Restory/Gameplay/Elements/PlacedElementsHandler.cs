using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Workplace;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class PlacedElementsHandler
	{
		private readonly float elementAltitudeControlValue = 1f;

		private WorkSurface workSurface;

		private SmallElementBin smallElementBin;

		private ElementService elementService;

		private DefaultElementConditions defaultElementConditions;

		private CompetitionElementsPositioner competitionElementsPositioner;

		[Inject]
		public void Construct(WorkSurface workSurface, SmallElementBin smallElementBin, ElementService elementService, DefaultElementConditions defaultElementConditions, CompetitionElementsPositioner competitionElementsPositioner)
		{
			this.workSurface = workSurface;
			this.smallElementBin = smallElementBin;
			this.elementService = elementService;
			this.defaultElementConditions = defaultElementConditions;
			this.competitionElementsPositioner = competitionElementsPositioner;
		}

		public PlacedElements PackPlacedElements(DevicePack devicePack)
		{
			PlacedElements placedElements = new PlacedElements();
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				ElementTransformRecord item = new ElementTransformRecord(placedElement, placedElement.transform.localPosition, placedElement.transform.localRotation);
				if (placedElement.transform.parent == smallElementBin.transform)
				{
					placedElements.ElementsInBin.Add(item);
				}
				else
				{
					placedElements.ElementsOnSurface.Add(item);
				}
				PackPlacedElement(placedElement, devicePack);
			}
			foreach (ElementTransformRecord item2 in placedElements.ElementsInBin)
			{
				workSurface.RemoveElement(item2.Element, silent: true);
			}
			foreach (ElementTransformRecord item3 in placedElements.ElementsOnSurface)
			{
				workSurface.RemoveElement(item3.Element, silent: true);
			}
			return placedElements;
		}

		public PlacedElements CreatePlacedElements(PlacedElementsData placedElementsData)
		{
			PlacedElements placedElements = new PlacedElements();
			foreach (ElementTransformData item in placedElementsData.ElementsOnSurface)
			{
				CreatePlacedElement(item, placedElements.ElementsOnSurface);
			}
			foreach (ElementTransformData item2 in placedElementsData.ElementsInBin)
			{
				CreatePlacedElement(item2, placedElements.ElementsInBin).BehaviorSwitcher.SetPhysicsLayer(0);
			}
			UnpackPlacedElements(placedElements);
			return placedElements;
		}

		public PlacedElements CreateAndPackPlacedElements(DevicePack devicePack, PlacedElementsData placedElementsData)
		{
			PlacedElements placedElements = new PlacedElements();
			foreach (ElementTransformData item in placedElementsData.ElementsOnSurface)
			{
				ElementBase element = CreatePlacedElement(item, placedElements.ElementsOnSurface);
				PackPlacedElement(element, devicePack);
			}
			foreach (ElementTransformData item2 in placedElementsData.ElementsInBin)
			{
				ElementBase elementBase = CreatePlacedElement(item2, placedElements.ElementsInBin);
				elementBase.BehaviorSwitcher.SetPhysicsLayer(0);
				PackPlacedElement(elementBase, devicePack);
			}
			return placedElements;
		}

		public PlacedElements CreateAndPlaceSmallElements(DeviceData deviceData)
		{
			deviceData.PlacedElements.ElementsInBin.Clear();
			PlacedElements placedElements = new PlacedElements();
			foreach (ElementSocket socket in deviceData.DeviceInfo.Sockets)
			{
				if (socket.CompatibleElementInfo.Category == ElementCategory.Small)
				{
					ElementData elementData = new ElementData
					{
						Info = socket.CompatibleElementInfo,
						Condition = defaultElementConditions.PerfectElementCondition
					};
					ElementBase elementBase = elementService.CreateElementOnSurface(elementData);
					smallElementBin.PutElement(elementBase);
					ElementTransformData item = new ElementTransformData
					{
						ElementData = elementData,
						ElementTransform = new SerializableTransform(elementBase.transform.localPosition, elementBase.transform.localRotation)
					};
					deviceData.PlacedElements.ElementsInBin.Add(item);
					ElementTransformRecord item2 = new ElementTransformRecord(elementBase, elementBase.transform.localPosition, elementBase.transform.localRotation);
					placedElements.ElementsInBin.Add(item2);
				}
			}
			return placedElements;
		}

		public void UnpackPlacedElements(PlacedElements placedElements, bool isDevicePartOfCompetition = false)
		{
			if (isDevicePartOfCompetition && placedElements.ElementsOnSurface.Count > 0 && placedElements.ElementsOnSurface[0].Position == Vector3.zero)
			{
				competitionElementsPositioner.PlaceElementsForCompetitionInitially(placedElements);
			}
			else
			{
				foreach (ElementTransformRecord item in placedElements.ElementsOnSurface)
				{
					workSurface.AddElement(item.Element, silent: true);
					Vector3 position = item.Position;
					item.Element.transform.SetLocalPositionAndRotation(position, item.Rotation);
					item.Element.BehaviorSwitcher.SwitchToPlacedBehavior();
				}
				foreach (ElementTransformRecord item2 in placedElements.ElementsInBin)
				{
					workSurface.AddElement(item2.Element, silent: true);
					item2.Element.transform.SetParent(smallElementBin.transform);
					item2.Element.transform.SetLocalPositionAndRotation(item2.Position, item2.Rotation);
					item2.Element.BehaviorSwitcher.SetPhysicsLayer(0);
					item2.Element.BehaviorSwitcher.SwitchToPlacedBehavior();
				}
			}
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				placedElement.gameObject.SetActive(value: true);
			}
		}

		public PlacedElements GetPlacedElements()
		{
			PlacedElements placedElements = new PlacedElements();
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				ElementTransformRecord item = new ElementTransformRecord(placedElement, placedElement.transform.localPosition, placedElement.transform.localRotation);
				if (placedElement.transform.parent == smallElementBin.transform)
				{
					placedElements.ElementsInBin.Add(item);
				}
				else
				{
					placedElements.ElementsOnSurface.Add(item);
				}
			}
			return placedElements;
		}

		public PlacedElementsData GetPlacedElementsData()
		{
			PlacedElementsData placedElementsData = new PlacedElementsData();
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				ElementTransformData item = new ElementTransformData
				{
					ElementData = placedElement.ConditionHandler.ElementData,
					ElementTransform = new SerializableTransform(placedElement.transform.localPosition, placedElement.transform.localRotation)
				};
				if (placedElement.transform.parent == smallElementBin.transform)
				{
					placedElementsData.ElementsInBin.Add(item);
				}
				else
				{
					placedElementsData.ElementsOnSurface.Add(item);
				}
			}
			return placedElementsData;
		}

		public bool ValidatePlacedElementsPosition()
		{
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (placedElement.transform.position.y < elementAltitudeControlValue)
				{
					return false;
				}
			}
			return true;
		}

		public void ResolveElementsInvalidPosition()
		{
			List<ElementBase> list = new List<ElementBase>();
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (!(placedElement.transform.position.y > elementAltitudeControlValue))
				{
					list.Add(placedElement);
				}
			}
			foreach (ElementBase item in list)
			{
				HandleElementUnderSurface(item);
			}
		}

		private ElementBase CreatePlacedElement(ElementTransformData elementTransformData, List<ElementTransformRecord> elementTransformRecords)
		{
			ElementBase elementBase = elementService.CreateElement(elementTransformData.ElementData);
			ElementTransformRecord item = new ElementTransformRecord(elementBase, elementTransformData.ElementTransform.Position, elementTransformData.ElementTransform.Rotation);
			elementTransformRecords.Add(item);
			elementBase.SkipProgress();
			return elementBase;
		}

		private void PackPlacedElement(ElementBase element, DevicePack devicePack)
		{
			element.BehaviorSwitcher.SwitchToPackedBehavior();
			element.transform.gameObject.SetActive(value: false);
			element.transform.SetParent(devicePack.transform);
			element.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}

		private void HandleElementUnderSurface(ElementBase element)
		{
			if (element.Info.Category == ElementCategory.Small)
			{
				Debug.LogError("Small element " + element.Info.ID + " fell under surface, and will sent to bin");
				smallElementBin.PutElement(element);
			}
			else if (element.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				Debug.LogError("Element " + element.Info.ID + " fell under surface, and will be recycled");
				elementService.DestroyElement(element);
			}
			else
			{
				Debug.LogError("Element " + element.Info.ID + " fell under surface, and will be stored in inventory");
				elementService.TrySendItemToStorage(element);
			}
		}

		public void SetPerfectConditionToAllPlacedElements(PlacedElementsData placedElements)
		{
			foreach (ElementTransformData item in placedElements.ElementsOnSurface)
			{
				item.ElementData.Condition = defaultElementConditions.PerfectElementCondition;
			}
			foreach (ElementTransformData item2 in placedElements.ElementsInBin)
			{
				item2.ElementData.Condition = defaultElementConditions.PerfectElementCondition;
			}
		}

		public void RestorePlacedElementsToInitialPositions(PlacedElements initialPlacement)
		{
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (placedElement.Info.Category == ElementCategory.Small)
				{
					foreach (ElementTransformRecord item in initialPlacement.ElementsInBin)
					{
						if (item.Element == placedElement)
						{
							item.Element.transform.SetParent(smallElementBin.transform);
							item.Element.transform.SetLocalPositionAndRotation(item.Position, item.Rotation);
							item.Element.BehaviorSwitcher.SwitchToPlacedBehavior();
							break;
						}
					}
					continue;
				}
				foreach (ElementTransformRecord item2 in initialPlacement.ElementsOnSurface)
				{
					if (item2.Element == placedElement)
					{
						item2.Element.transform.SetLocalPositionAndRotation(item2.Position, item2.Rotation);
						item2.Element.BehaviorSwitcher.SwitchToPlacedBehavior();
					}
				}
			}
		}

		public void RestorePlacedElementsToInitialPositions(PlacedElementsData elementsInitialPlacement)
		{
			List<ElementTransformData> value;
			using (CollectionPool<List<ElementTransformData>, ElementTransformData>.Get(out value))
			{
				value.AddRange(elementsInitialPlacement.ElementsInBin);
				List<ElementTransformData> value2;
				using (CollectionPool<List<ElementTransformData>, ElementTransformData>.Get(out value2))
				{
					value2.AddRange(elementsInitialPlacement.ElementsOnSurface);
					SetPlacedElementsPositions(value, value2);
				}
			}
		}

		private void SetPlacedElementsPositions(List<ElementTransformData> binElementsPositions, List<ElementTransformData> surfaceElementsPositions)
		{
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (placedElement.Info.Category == ElementCategory.Small)
				{
					for (int num = binElementsPositions.Count - 1; num >= 0; num--)
					{
						if (binElementsPositions[num].ElementData.Info.ID == placedElement.Info.ID)
						{
							SerializableTransform elementTransform = binElementsPositions[num].ElementTransform;
							placedElement.transform.SetParent(smallElementBin.transform);
							placedElement.transform.SetLocalPositionAndRotation(elementTransform.Position, elementTransform.Rotation);
							placedElement.BehaviorSwitcher.SwitchToPlacedBehavior();
							binElementsPositions.RemoveAt(num);
							break;
						}
					}
					continue;
				}
				for (int num2 = surfaceElementsPositions.Count - 1; num2 >= 0; num2--)
				{
					if (surfaceElementsPositions[num2].ElementData.Info.ID == placedElement.Info.ID)
					{
						SerializableTransform elementTransform2 = surfaceElementsPositions[num2].ElementTransform;
						placedElement.transform.SetLocalPositionAndRotation(elementTransform2.Position, elementTransform2.Rotation);
						placedElement.BehaviorSwitcher.SwitchToPlacedBehavior();
						surfaceElementsPositions.RemoveAt(num2);
						break;
					}
				}
			}
		}
	}
}
