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
		private const float CameraLerpTime = 0.15f;

		private const int MaxPixelsBeforeNewStroke = 1000;

		private const int ManhattanDistanceBetweenPaintedPixels = 3;

		private const int FixedPaintedPixelLimit = 25000;

		private const int CanvasPadding = 12;

		public SpraySurface SpraySurface;

		public InteractableObject IntObj;

		public Transform CameraPosition;

		public Canvas Canvas;

		public Image SprayImg;

		public AudioSourceController SpraySound;

		public AudioSourceController CleanSound;

		public bool _allowDraw;

		[Header("Settings")]
		[SerializeField]
		public float PaintedPixelLimitMultiplier;

		private ESprayColor selectedColor;

		private byte selectedStrokeSize;

		private UShort2 lastPaintedPixelCoord;

		private bool paintedLastFrame;

		private List<UShort2> currentStrokePixels;

		private bool isPaintingStroke;

		private float timeSinceStrokeStart;

		private int _startPaintedPixelCount;

		public bool IsOpen { get; private set; }

		private bool confirmationPanelOpen => false;

		private int _paintedPixelLimit => 0;

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

		private void ResizeCanvas()
		{
		}

		private void Update()
		{
		}

		private void UpdateCursor()
		{
		}

		private void UpdateSpraySound()
		{
		}

		private void CheckCameraInBounds()
		{
		}

		private void FixedUpdate()
		{
		}

		private void StartStroke(bool recordHistory = true)
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

		private void EquippedSlotChanged(int equippedSlotIndex)
		{
		}

		private void SetColor(ESprayColor color)
		{
		}

		private void SetStrokeSize(byte strokeSize)
		{
		}

		private void UpdateRemainingPaintIndicator()
		{
		}

		public void Undo()
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
