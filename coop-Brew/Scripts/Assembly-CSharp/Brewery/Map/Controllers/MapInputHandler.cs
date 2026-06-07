using System;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace Brewery.Map.Controllers
{
	public class MapInputHandler
	{
		private readonly InputReader inputReader;

		private readonly MapCameraSettings settings;

		private Vector3 navigationVelocity;

		private bool isSprintHeld;

		public Action OnMapToggleRequested;

		public Action OnCancelRequested;

		public Action<float> OnZoomRequested;

		public Action OnRecenterRequested;

		public Vector3 NavigationVelocity => default(Vector3);

		public bool IsSprintHeld => false;

		public MapInputHandler(InputReader inputReader, MapCameraSettings settings)
		{
		}

		public void Subscribe()
		{
		}

		public void Unsubscribe()
		{
		}

		private void HandleMapToggle()
		{
		}

		private void HandleCancel()
		{
		}

		private void HandleZoom(float delta)
		{
		}

		private void HandleRecenter()
		{
		}

		private void HandleSprintStart()
		{
		}

		private void HandleSprintEnd()
		{
		}

		public Vector2 GetMoveInput()
		{
			return default(Vector2);
		}

		public void UpdateNavigation(Vector2 input, Transform cameraRig, float deltaTime)
		{
		}

		private Vector3 CalculateMoveDirection(Vector2 input, Transform cameraRig)
		{
			return default(Vector3);
		}

		public void ResetVelocity()
		{
		}
	}
}
