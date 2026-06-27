using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.Devices.Condition;
using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Effects;
using Restory.Gameplay.RegularPayments;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectBoxContainer : MonoBehaviour, IInteractiveObjectContainer
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private ParticleSystem interactionEffect;

		[SerializeField]
		private BounceEffect bounceEffect;

		private readonly List<ContainedInteractiveObject> content = new List<ContainedInteractiveObject>();

		private IDService idService;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		protected InteractiveObjectFactory interactiveObjectFactory;

		private DeviceService deviceService;

		private DeviceRegistry deviceRegistry;

		private DeviceFactory deviceFactory;

		private RegularPaymentObjectRegistry regularPaymentObjectsRegistry;

		protected InteractiveObject takenObject;

		protected IInteractiveObjectInfo takenObjectInfo;

		private DeviceContainer takenDeviceInsidePack;

		private Coroutine playContentAddedEffectsAfterEndOfFrameCoroutine;

		public InteractiveObject InteractiveObject => interactiveObject;

		public virtual bool IsEmpty => content.Count == 0;

		public IReadOnlyList<ContainedInteractiveObject> Content => content;

		public event Action OnObjectsAdded;

		public event Action<InteractiveObject> OnInteractiveObjectTakenOut;

		public event Action<InteractiveObject> OnInteractiveObjectTakenOutCompleted;

		public event Action<InteractiveObject> OnInteractiveObjectTakenOutCanceled;

		[Inject]
		private void Construct(IDService idService, InteractiveObjectRegistry interactiveObjectRegistry, InteractiveObjectFactory interactiveObjectFactory, DeviceService deviceService, DeviceRegistry deviceRegistry, DeviceFactory deviceFactory, RegularPaymentObjectRegistry regularPaymentObjectsRegistry)
		{
			this.regularPaymentObjectsRegistry = regularPaymentObjectsRegistry;
			this.idService = idService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.deviceService = deviceService;
			this.deviceRegistry = deviceRegistry;
			this.deviceFactory = deviceFactory;
		}

		protected virtual void OnDisable()
		{
			if (playContentAddedEffectsAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(playContentAddedEffectsAfterEndOfFrameCoroutine);
				playContentAddedEffectsAfterEndOfFrameCoroutine = null;
			}
		}

		public void Init(IEnumerable<ContainedInteractiveObject> containedObjects)
		{
			content.Clear();
			foreach (ContainedInteractiveObject containedObject in containedObjects)
			{
				content.Add(containedObject);
			}
		}

		public bool TryToAddObject(IInteractiveObjectInfo objectToAdd, params InteractiveObjectAdditionalProperty[] objectAdditionalProperties)
		{
			if (interactiveObject.HasChanged)
			{
				Debug.LogError("Failed to add object " + objectToAdd.ID + " to " + interactiveObject.gameObject.name + ", it is folded already");
				return false;
			}
			content.Add(new ContainedInteractiveObject(objectToAdd, objectAdditionalProperties));
			OnContentAdded();
			return true;
		}

		public bool TryToFindAndSilentlyRemoveContainedObject(InteractiveObjectInfo objectInfo, out ContainedInteractiveObject objectFromContainer)
		{
			for (int num = content.Count - 1; num >= 0; num--)
			{
				if (content[num].InteractiveObjectInfo.ID == objectInfo.ID)
				{
					objectFromContainer = content[num];
					content.RemoveAt(num);
					return true;
				}
			}
			objectFromContainer = null;
			return false;
		}

		public InteractiveObject GetContainedObject()
		{
			if ((bool)takenObject)
			{
				Debug.LogError("One object is dragging already");
				return takenObject;
			}
			if (!TryToTakeOutObject())
			{
				return null;
			}
			if ((bool)takenObject)
			{
				SubscribeTakenObject();
				interactionEffect.Play();
				this.OnInteractiveObjectTakenOut?.Invoke(takenObject);
				takenObject.SetState(interactiveObject.State);
				return takenObject;
			}
			Debug.LogError("Failed to create interactive object instance for " + takenObjectInfo.ID);
			return null;
		}

		protected virtual bool TryToTakeOutObject()
		{
			if (content.Count == 0)
			{
				Debug.LogError("No objects found in box");
				takenObject = null;
				takenObjectInfo = null;
				return false;
			}
			takenObjectInfo = content[0].InteractiveObjectInfo;
			if (takenObjectInfo == null)
			{
				Debug.LogError("Next object is null");
				content.RemoveAt(0);
				takenObject = null;
				takenObjectInfo = null;
				return false;
			}
			InteractiveObjectAdditionalProperties properties = content[0].Properties;
			takenObject = GetInteractiveObject(takenObjectInfo, properties);
			if (takenObject is DevicePack devicePack)
			{
				takenDeviceInsidePack = devicePack.DeviceContainer;
			}
			if (takenObject.TryGetComponent<PersonalConsumableTool>(out var component))
			{
				SpecifyConsumableToolAmount(component);
			}
			return true;
		}

		protected InteractiveObject GetInteractiveObject(IInteractiveObjectInfo interactiveObjectInfo, InteractiveObjectAdditionalProperties takenObjectProperties = null)
		{
			if (interactiveObjectInfo is IDeviceCondition deviceCondition)
			{
				DeviceData deviceData = deviceService.CreateDeviceData(deviceCondition, base.transform);
				if (takenObjectProperties != null)
				{
					foreach (InteractiveObjectAdditionalProperty allProperty in takenObjectProperties.GetAllProperties())
					{
						deviceData.InteractiveObjectAdditionalProperties.TryToAddProperty(allProperty);
					}
				}
				if (!deviceCondition.IsPartOfCompetition)
				{
					return deviceFactory.CreateDeviceContainer(deviceData, base.transform);
				}
				return deviceService.CreateInitialCompetitionPackedDeviceContainer(deviceData, base.transform);
			}
			if (interactiveObjectInfo is InteractiveObjectInfo interactiveObjectInfo2)
			{
				return interactiveObjectFactory.CreateInteractiveObject(interactiveObjectInfo2, base.transform);
			}
			return null;
		}

		protected virtual void OnContentAdded()
		{
			if (playContentAddedEffectsAfterEndOfFrameCoroutine == null)
			{
				playContentAddedEffectsAfterEndOfFrameCoroutine = StartCoroutine(PlayContentAddedEffectsAfterEndOfFrameCoroutine());
			}
		}

		private IEnumerator PlayContentAddedEffectsAfterEndOfFrameCoroutine()
		{
			yield return new WaitForEndOfFrame();
			playContentAddedEffectsAfterEndOfFrameCoroutine = null;
			interactionEffect.Play();
			bounceEffect.PlayBounce();
			this.OnObjectsAdded?.Invoke();
		}

		private void SubscribeTakenObject()
		{
			if (!takenObject)
			{
				Debug.LogError("Failed to subscribe, taken object is lost");
				return;
			}
			takenObject.OnDragComplete += ResolveDragComplete;
			takenObject.OnDragCanceled += ResolveDragCanceled;
			takenObject.OnRemove += ResolveObjectRemove;
		}

		private void UnsubscribeTakenObject()
		{
			if (!takenObject)
			{
				Debug.LogError("Failed to unsubscribe, taken object is lost");
				return;
			}
			takenObject.OnDragComplete -= ResolveDragComplete;
			takenObject.OnDragCanceled -= ResolveDragCanceled;
			takenObject.OnRemove -= ResolveObjectRemove;
		}

		private void ResolveDragComplete()
		{
			UnsubscribeTakenObject();
			HandleObjectDragSuccessfullyCompleted();
		}

		protected virtual void HandleObjectDragSuccessfullyCompleted()
		{
			RegisterTakenObject();
			RemoveTakenObject();
		}

		private void ResolveDragCanceled()
		{
			UnsubscribeTakenObject();
			ReturnTakenObject();
		}

		private void ResolveObjectRemove()
		{
			UnsubscribeTakenObject();
			RemoveTakenObject();
		}

		private void RegisterTakenObject()
		{
			if (!takenObject)
			{
				Debug.LogError("Failed to register taken object, it is lost");
				return;
			}
			if (takenObject is DeviceContainer device)
			{
				deviceRegistry.Register(device);
				return;
			}
			if (takenObject is DevicePack devicePack)
			{
				if ((bool)devicePack.DeviceContainer)
				{
					deviceRegistry.Register(devicePack.DeviceContainer);
				}
				else if ((bool)takenDeviceInsidePack)
				{
					deviceRegistry.Register(takenDeviceInsidePack);
				}
				return;
			}
			string uniqueId = idService.GenerateNew();
			takenObject.Init(InteractiveObjectState.Stored, uniqueId, false);
			if (takenObject.TryGetComponent<RegularPaymentObject>(out var component))
			{
				regularPaymentObjectsRegistry.Register(component);
			}
			if (takenObjectInfo is InteractiveObjectInfo interactiveObjectInfo)
			{
				interactiveObjectRegistry.Register(takenObject, interactiveObjectInfo);
			}
		}

		private void RemoveTakenObject()
		{
			RemoveTakenObjectContentsFromTheBox();
			this.OnInteractiveObjectTakenOutCompleted?.Invoke(takenObject);
			takenObject = null;
			takenObjectInfo = null;
			takenDeviceInsidePack = null;
		}

		private void ReturnTakenObject()
		{
			if (!takenObject)
			{
				Debug.LogError("Failed to return taken object, it is lost");
				return;
			}
			DestroyInteractiveObjectInstance(takenObject);
			this.OnInteractiveObjectTakenOutCanceled?.Invoke(takenObject);
			takenObject = null;
			takenObjectInfo = null;
			takenDeviceInsidePack = null;
		}

		protected void DestroyInteractiveObjectInstance(InteractiveObject objectToDestroy)
		{
			if (objectToDestroy is DeviceContainer deviceContainer)
			{
				deviceFactory.DestroyDeviceContainer(deviceContainer);
			}
			else
			{
				interactiveObjectFactory.DestroyInteractiveObject(objectToDestroy);
			}
		}

		protected virtual void RemoveTakenObjectContentsFromTheBox()
		{
			if (content.Count == 0 || takenObjectInfo != content[0].InteractiveObjectInfo)
			{
				Debug.LogError("First contained object not equal to taken object");
			}
			else
			{
				content.RemoveAt(0);
			}
			if (takenObject.TryGetComponent<PersonalConsumableTool>(out var component))
			{
				RemoveTakenConsumableObjectContentsFromTheBox(component.Amount - 1);
			}
		}

		private void SpecifyConsumableToolAmount(PersonalConsumableTool consumableTool)
		{
			int num = 0;
			foreach (ContainedInteractiveObject item in content)
			{
				if (item.InteractiveObjectInfo == takenObjectInfo)
				{
					num++;
				}
			}
			consumableTool.SpecifyAmount(num);
		}

		private void RemoveTakenConsumableObjectContentsFromTheBox(int amountToRemove)
		{
			for (int i = 0; i < content.Count; i++)
			{
				if (amountToRemove <= 0)
				{
					break;
				}
				if (content[i].InteractiveObjectInfo == takenObjectInfo)
				{
					content.RemoveAt(i);
					amountToRemove--;
					i--;
				}
			}
			if (amountToRemove > 0)
			{
				Debug.LogError("Not all taken " + takenObjectInfo.ID + " objects found in the box." + $" {amountToRemove} is lost.");
			}
		}
	}
}
