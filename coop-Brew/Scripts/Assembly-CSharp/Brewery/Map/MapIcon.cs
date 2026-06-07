using System;
using UnityEngine;

namespace Brewery.Map
{
	public class MapIcon : MonoBehaviour
	{
		[Header("References")]
		public Transform target;

		public MapIconDefinition definition;

		[NonSerialized]
		public IMapController mapController;

		private bool hasAnimated;

		private bool isWaitingToAnimate;

		private bool isPlayingExitAnimation;

		private float targetScale;

		private bool isHovered;

		private Vector3 baseScale;

		private int hoverTweenId;

		private MapIconTarget iconTarget;

		private int pulsateTweenId;

		private bool isPulsating;

		private bool wasMapOpen;

		private Quaternion targetRotation;

		private bool hasInitializedRotation;

		[Header("Debug")]
		public bool showDebugLogs;

		private void Start()
		{
		}

		public void UpdateTransform(Vector3 cameraPosition, bool isMapOpen, bool isTransitioning)
		{
		}

		private void PlayPopAnimation()
		{
		}

		private void PlayPopOutAnimation()
		{
		}

		public void OnHoverEnter()
		{
		}

		public void OnHoverExit()
		{
		}

		private void StartPulsate()
		{
		}

		private void PulsateUp(Vector3 targetUp, float duration)
		{
		}

		private void PulsateDown(float duration)
		{
		}

		private void StopPulsate()
		{
		}
	}
}
