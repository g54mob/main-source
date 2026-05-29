using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.Graffiti
{
	[RequireComponent(typeof(SpraySurface))]
	public class SpraySurfaceInteraction : MonoBehaviour
	{
		public const float CAMERA_MOVE_TIME = 0.15f;

		public const int MAX_PIXELS_BEFORE_NEW_STROKE = 1000;

		public const int MANHATTAN_DISTANCE_BETWEEN_PAINTED_PIXELS = 3;

		public const int XP_GAIN = 50;

		public const float CARTEL_INFLUENCE_CHANGE = -0.05f;

		public const int PAINTED_PIXEL_LIMIT = 25000;

		public SpraySurface SpraySurface;

		public InteractableObject IntObj;

		public Transform CameraPosition;

		public Canvas Canvas;

		public Image SprayImg;

		public AudioSourceController SpraySound;

		public AudioSourceController CleanSound;

		private ESprayColor selectedColor;

		private UShort2 lastPaintedPixelCoord;

		private bool paintedLastFrame;

		private List<UShort2> currentStrokePixels;

		private bool isPaintingStroke;

		private float timeSinceStrokeStart;

		public bool IsOpen { get; private set; }

		private bool confirmationPanelOpen => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void PlayerSpawned()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnValidate()
		{
		}

		private void ResizeCanvas()
		{
		}

		private void Update()
		{
		}

		private void UpdateCursor()
		{
		}

		private void FixedUpdate()
		{
		}

		private void StartStroke()
		{
		}

		private void EndStroke(bool stopSpraySound)
		{
		}

		private bool GetCursorPositionOnSurface(out ushort pixelX, out ushort pixelY)
		{
			pixelX = default(ushort);
			pixelY = default(ushort);
			return false;
		}

		private Ray GetCursorRay()
		{
			return default(Ray);
		}

		private void Hovered()
		{
		}

		private void Interacted()
		{
		}

		private void UseGraffitiCleaner()
		{
		}

		private void Exit(ExitAction action)
		{
		}

		private void Open()
		{
		}

		private void Close()
		{
		}

		private void Reward()
		{
		}

		private void EquippedSlotChanged(int equippedSlotIndex)
		{
		}

		private void SetColor(ESprayColor color)
		{
		}

		private void Clear()
		{
		}

		private static bool IsSprayCanEquipped()
		{
			return false;
		}

		private static bool IsGraffitiCleanerEquipped()
		{
			return false;
		}
	}
}
