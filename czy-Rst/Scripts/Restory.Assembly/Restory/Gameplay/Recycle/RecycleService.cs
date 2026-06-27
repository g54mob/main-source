using System;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Recycle
{
	public class RecycleService : IConfirmationRequester
	{
		private readonly TrashCan trashCan;

		private readonly ElementService elementService;

		private readonly DeviceService deviceService;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly InteractiveObjectFactory interactiveObjectFactory;

		private readonly ConfirmationService confirmationService;

		private readonly ExplanationService explanationService;

		private readonly VfxService vfxService;

		private IRecycleRequest activeRequest;

		public bool IsReadyToRecycle
		{
			get
			{
				if (trashCan.IsDetected)
				{
					return trashCan.IsActive;
				}
				return false;
			}
		}

		public event Action<RecycleService> OnRecycled;

		public event Action<RecycleService> OnElementRecycled;

		public event Action<RecycleService> OnInteractiveObjectRecycled;

		[Inject]
		public RecycleService(TrashCan trashCan, ElementService elementService, DeviceService deviceService, InteractiveObjectRegistry interactiveObjectRegistry, InteractiveObjectFactory interactiveObjectFactory, ConfirmationService confirmationService, ExplanationService explanationService, VfxService vfxService)
		{
			this.trashCan = trashCan;
			this.elementService = elementService;
			this.deviceService = deviceService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.confirmationService = confirmationService;
			this.explanationService = explanationService;
			this.vfxService = vfxService;
		}

		public bool TryToRecycleInteractiveObject(InteractiveObject interactiveObject)
		{
			if (!IsReadyToRecycle)
			{
				return false;
			}
			RecycleInteractiveObject(interactiveObject);
			return true;
		}

		public bool CanSendRecycleRequest(IRecycleRequest request)
		{
			if (!(request is ElementRecycleRequest request2))
			{
				if (request is InteractiveObjectRecycleRequest request3)
				{
					return CanInteractiveObjectRecycleRequest(request3);
				}
				return false;
			}
			return CanElementRecycleRequest(request2);
		}

		private bool CanElementRecycleRequest(ElementRecycleRequest request)
		{
			return request.Element.ConditionHandler.ElementData.Condition is DamagedElementCondition;
		}

		private bool CanInteractiveObjectRecycleRequest(InteractiveObjectRecycleRequest request)
		{
			TrashObject component;
			return request.InteractiveObject.TryGetComponent<TrashObject>(out component);
		}

		public void SendRecycleRequest(IRecycleRequest request)
		{
			if (activeRequest != null)
			{
				Debug.LogError(string.Format("{0} has active request already from {1}", "RecycleService", activeRequest.Requester.GetType()));
				request.Requester.OnRecycleResponse(isCompleted: false);
				return;
			}
			if (!CanSendRecycleRequest(request))
			{
				request.Requester.OnRecycleResponse(isCompleted: false);
				return;
			}
			activeRequest = request;
			IRecycleRequest recycleRequest = activeRequest;
			if (!(recycleRequest is ElementRecycleRequest request2))
			{
				if (!(recycleRequest is InteractiveObjectRecycleRequest request3))
				{
					throw new NotImplementedException("activeRequest processing is not implemented");
				}
				ProcessInteractiveObjectRecycleRequest(request3);
			}
			else
			{
				ProcessElementRecycleRequest(request2);
			}
		}

		private void ProcessElementRecycleRequest(ElementRecycleRequest request)
		{
			if (request.Element.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				RecycleElement(request.Element);
				ResponseToRequester(isCompleted: true);
			}
			else
			{
				confirmationService.RequestConfirmation(this);
			}
		}

		private void ProcessInteractiveObjectRecycleRequest(InteractiveObjectRecycleRequest request)
		{
			if (request.InteractiveObject.TryGetComponent<TrashObject>(out var _))
			{
				RecycleInteractiveObject(request.InteractiveObject);
				ResponseToRequester(isCompleted: true);
			}
			else
			{
				confirmationService.RequestConfirmation(this);
			}
		}

		private void RecycleElement(ElementBase element)
		{
			elementService.DestroyElement(element);
			vfxService.PlayPlacementEffect(trashCan.EffectPoint);
			this.OnElementRecycled?.Invoke(this);
			this.OnRecycled?.Invoke(this);
		}

		private void RecycleInteractiveObject(InteractiveObject interactiveObject)
		{
			interactiveObject.Remove();
			vfxService.PlayPlacementEffect(trashCan.EffectPoint);
			if (!(interactiveObject is DeviceContainer deviceContainer))
			{
				if (interactiveObject is DevicePack devicePack)
				{
					deviceService.DestroyPackedDeviceContainer(devicePack);
				}
				else
				{
					interactiveObjectRegistry.Unregister(interactiveObject);
					interactiveObjectFactory.DestroyInteractiveObject(interactiveObject);
				}
			}
			else
			{
				deviceService.DestroyDeviceContainer(deviceContainer);
			}
			this.OnInteractiveObjectRecycled?.Invoke(this);
			this.OnRecycled?.Invoke(this);
		}

		private void ResponseToRequester(bool isCompleted)
		{
			if (activeRequest == null)
			{
				Debug.LogError("Recycle request was lost in RecycleService");
				return;
			}
			activeRequest.Requester.OnRecycleResponse(isCompleted);
			activeRequest = null;
		}

		void IConfirmationRequester.OnConfirmationResponse(bool isConfirmed)
		{
			if (isConfirmed && activeRequest != null)
			{
				IRecycleRequest recycleRequest = activeRequest;
				if (!(recycleRequest is ElementRecycleRequest elementRecycleRequest))
				{
					if (!(recycleRequest is InteractiveObjectRecycleRequest interactiveObjectRecycleRequest))
					{
						throw new NotImplementedException("activeRequest processing is not implemented");
					}
					RecycleInteractiveObject(interactiveObjectRecycleRequest.InteractiveObject);
				}
				else
				{
					RecycleElement(elementRecycleRequest.Element);
				}
			}
			ResponseToRequester(isConfirmed);
		}
	}
}
