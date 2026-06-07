using System.Collections.Generic;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Framework.Cursors
{
	public class CursorsManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _CursorIndicatorPrefab;

		private SignalBus _signalBus;

		private ObjectPool _cursorsPool;

		private bool _cursorsHidden;

		private readonly Dictionary<GameObject, CursorIndicator> _cursorIndicators;

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		public void Awake()
		{
		}

		protected void OnDestroy()
		{
		}

		protected void LateUpdate()
		{
		}

		private void SpawnCursor(UISignals.SpawnOffScreenCursorSignal signal)
		{
		}

		private void RemoveCursor(UISignals.RemoveOffScreenCursorSignal signal)
		{
		}

		private void HideCursor(UISignals.HideCursorSignal signal)
		{
		}

		private void ShowCursor(UISignals.ShowCursorSignal signal)
		{
		}

		private void HideAllCursors(UISignals.HideAllCursorsSignal signal)
		{
		}

		private void UnHideCursors(UISignals.UnhideCursorsSignal signal)
		{
		}

		private CursorIndicator SpawnCursorIndicator()
		{
			return null;
		}

		private void PositionNearScreenEdge(CursorIndicator cursorIndicator, Vector3 targetPos)
		{
		}

		private void PointAtTarget(CursorIndicator cursorIndicator, Vector3 targetPos)
		{
		}

		private void GenerateCursorsPool()
		{
		}

		private static bool IsTargetVisible(Vector3 screenPosition)
		{
			return false;
		}

		private static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, float proportionOfScreenFromCenter = 0.45f)
		{
		}

		private static Vector2 GetPPURoundedPosition(Vector2 position)
		{
			return default(Vector2);
		}

		private void RefreshCursors()
		{
		}
	}
}
