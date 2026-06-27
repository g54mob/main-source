using System;
using System.Collections.Generic;
using Restory.Data.Projections;
using Restory.Gameplay.Devices;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementAssembleController : IInitializable
	{
		private readonly AssembleProjectionSettings projectionSettings;

		private readonly IPlayerInput playerInput;

		private readonly DeviceService deviceService;

		private readonly GameCursorDetector cursorDetector;

		private readonly ElementProjectionFactory projectionFactory;

		private float rotationAdjustmentInterval;

		private ElementProjectionData elementProjectionData;

		private bool projectionEnabled = true;

		private bool adjustRotationEnabled = true;

		private Transform elementTransform;

		private Quaternion elementPlacementRotation;

		private Quaternion elementCurrentRotation;

		private Quaternion elementTargetRotation;

		private List<ElementSocket> availableSockets = new List<ElementSocket>();

		private ElementProjection assembleProjection;

		public bool ProjectionEnabled
		{
			get
			{
				return projectionEnabled;
			}
			set
			{
				projectionEnabled = value;
			}
		}

		public bool AdjustRotationEnabled
		{
			get
			{
				return adjustRotationEnabled;
			}
			set
			{
				adjustRotationEnabled = value;
			}
		}

		public ElementSocket SelectedSocket { get; private set; }

		public Vector3 AssemblePosition { private get; set; }

		public bool AreAnySocketsAvailableForDraggedElement => availableSockets.Count > 0;

		[Inject]
		public ElementAssembleController(AssembleProjectionSettings projectionSettings, IPlayerInput playerInput, DeviceService deviceService, GameCursorDetector cursorDetector, ElementProjectionFactory projectionFactory)
		{
			this.projectionSettings = projectionSettings;
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.cursorDetector = cursorDetector;
			this.projectionFactory = projectionFactory;
		}

		public void Initialize()
		{
			rotationAdjustmentInterval = projectionSettings.RotationAdjustmentInterval;
			if (rotationAdjustmentInterval <= 0f)
			{
				Debug.LogError("Projection appearance distance must be greater than projection activation distance.");
				rotationAdjustmentInterval = projectionSettings.ProjectionActivationDistance;
			}
		}

		public void StartDrag(ElementBase element)
		{
			if (element == null)
			{
				Debug.LogException(new NullReferenceException("ElementBase is null"));
			}
			if (element.PlacementPositionHandler.PlacementPositionData == null)
			{
				Debug.LogError("ElementPlacementPositionData is null on element " + element.Info.ID);
				element.Init();
				element.SkipProgress();
			}
			if (element.ProjectionData == null)
			{
				Debug.LogException(new NullReferenceException("ProjectionData is null on element " + element.Info.ID));
			}
			elementProjectionData = element.ProjectionData;
			elementTransform = element.transform;
			elementPlacementRotation = element.PlacementRotation;
			elementCurrentRotation = elementTransform.rotation;
			elementTargetRotation = elementPlacementRotation;
			availableSockets = deviceService.GetAvailableSockets(element);
		}

		public void OnDrag(float deltaTime, bool isOverDevice, bool isOverEquipment)
		{
			if (isOverEquipment)
			{
				elementCurrentRotation = elementTransform.rotation;
			}
			else
			{
				UpdateRotation(deltaTime);
			}
			if (!elementTransform || !isOverDevice)
			{
				ClearSelectedSocket();
				return;
			}
			if (availableSockets.Count == 0)
			{
				elementTransform.position = AssemblePosition;
				return;
			}
			ElementSocket nearestSocket;
			float nearestSocketDistance = GetNearestSocketDistance(out nearestSocket);
			if (nearestSocketDistance < projectionSettings.ProjectionAppearanceDistance)
			{
				elementTransform.position = AssemblePosition;
				if (adjustRotationEnabled)
				{
					AdjustRotation(nearestSocketDistance);
				}
				SetSelectedSocket(nearestSocket);
			}
			else
			{
				elementTransform.position = AssemblePosition;
				ClearSelectedSocket();
			}
		}

		public void Clear()
		{
			ClearSelectedSocket();
			elementProjectionData = null;
			elementTransform = null;
			SelectedSocket = null;
			availableSockets.Clear();
		}

		private void UpdateRotation(float deltaTime)
		{
			if (availableSockets.Count == 0)
			{
				elementTransform.rotation = elementPlacementRotation;
			}
			else if ((bool)elementTransform)
			{
				elementCurrentRotation = Quaternion.RotateTowards(elementCurrentRotation, elementTargetRotation, projectionSettings.ElementRotationSpeed * deltaTime);
				elementTransform.rotation = elementCurrentRotation;
			}
		}

		private void SetSelectedSocket(ElementSocket nearestSocket)
		{
			if ((bool)assembleProjection)
			{
				if (SelectedSocket == nearestSocket)
				{
					return;
				}
				ClearSelectedSocket();
			}
			SelectedSocket = nearestSocket;
			if ((bool)SelectedSocket && projectionEnabled)
			{
				assembleProjection = projectionFactory.CreateElementProjection(elementProjectionData, SelectedSocket.transform);
				assembleProjection.MakeDim();
				assembleProjection.SetOutlineLayer(1);
			}
		}

		private void ClearSelectedSocket()
		{
			SelectedSocket = null;
			elementTargetRotation = elementPlacementRotation;
			if (assembleProjection != null)
			{
				projectionFactory.DestroyElementProjection(assembleProjection);
				assembleProjection = null;
			}
		}

		private void AdjustRotation(float installDistance)
		{
			if (elementProjectionData != null && (bool)SelectedSocket)
			{
				if (installDistance < projectionSettings.ProjectionActivationDistance)
				{
					elementTargetRotation = SelectedSocket.transform.rotation;
					return;
				}
				float t = Mathf.Clamp01((installDistance - projectionSettings.ProjectionActivationDistance) / rotationAdjustmentInterval);
				elementTargetRotation = Quaternion.Slerp(SelectedSocket.transform.rotation, elementPlacementRotation, t);
			}
		}

		private float GetNearestSocketDistance(out ElementSocket nearestSocket)
		{
			if (availableSockets.Count == 1)
			{
				nearestSocket = availableSockets[0];
				return GetSocketDistance(nearestSocket);
			}
			nearestSocket = null;
			float num = float.MaxValue;
			foreach (ElementSocket availableSocket in availableSockets)
			{
				float socketDistance = GetSocketDistance(availableSocket);
				if (socketDistance < num)
				{
					num = socketDistance;
					nearestSocket = availableSocket;
				}
			}
			return num;
		}

		private float GetSocketDistance(ElementSocket socket)
		{
			return cursorDetector.GetPointerToTargetDistance(playerInput.GetMousePosition(), socket.transform.TransformPoint(elementProjectionData.ElementAttachmentPosition));
		}
	}
}
