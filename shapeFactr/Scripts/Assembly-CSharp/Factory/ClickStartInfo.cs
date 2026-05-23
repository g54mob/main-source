using System.Runtime.InteropServices;
using Libs;
using UnityEngine;

namespace Factory
{
	public class ClickStartInfo
	{
		public eMachine machineId;

		private Vector2IntBundle[] gridRectQueue;

		public Vector2IntBundle? JustBeforeGridRect;

		public Vector2IntBundle? previousGridRect;

		public int LenLimit;

		public int jointIndex;

		public eLuggage? inkColor;

		public Vector2Int? sourceAddr;

		public readonly bool BeltUpgradable;

		private double longPushStartTime;

		public eMachine prevStructureMachine;

		public ClickMode Mode { get; private set; }

		public Vector2IntBundle GridRect { get; private set; }

		public bool StreamHasNotMovedYet => false;

		private int edgeFrameCount { get; set; }

		public bool RestartStream { get; }

		public bool HasGridRectQueue => false;

		public bool HasJoint => false;

		public bool IsClickEdge => false;

		public bool LongPushTimerFinished => false;

		public double LongPushTimer => 0.0;

		public double LongPushTimerMax => 0.0;

		public bool BridgeHasNotMovedYet(Vector2IntBundle newGridRect)
		{
			return false;
		}

		public ClickStartInfo(ClickMode mode, Vector2IntBundle gridRect, eMachine machineId, [Optional][DefaultParameterValue(0)] int lenLimit, [Optional] eLuggage? inkColor, Vector2Int? sourceAddr = null, bool restartStream = false, FieldManager field = null)
		{
		}

		public static Vector2IntBundle G2A(Vector2IntBundle ri)
		{
			return default(Vector2IntBundle);
		}

		public static Vector2IntBundle G2A(Vector2IntBundle? ri)
		{
			return default(Vector2IntBundle);
		}

		public static string G2AStr(Vector2IntBundle ri)
		{
			return null;
		}

		public static string G2AStr(Vector2IntBundle? ri)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public void UpdateGridRect(Vector2IntBundle prevGridRect, Vector2IntBundle? inNewGridRect, out Vector2IntBundle outNewGridRect)
		{
			outNewGridRect = default(Vector2IntBundle);
		}

		public bool Enqueue(Vector2IntBundle prevGridRect, Vector2IntBundle newGridRect)
		{
			return false;
		}

		public void EnqueueStraight(Vector2IntBundle startGridRect, Vector2IntBundle totalGridRect)
		{
		}

		private Vector2IntBundle? Dequeue(Vector2IntBundle prevGridRect, bool keepNeighbor = true)
		{
			return null;
		}

		private Vector2IntBundle PseudoDequeue()
		{
			return default(Vector2IntBundle);
		}

		private void PseudoEnqueue(Vector2IntBundle entry)
		{
		}

		public void AddJoint(Vector2IntBundle vector2IntBundle)
		{
		}

		public void ChangeMode(ClickMode nextMode)
		{
		}

		public static ClickStartInfo Click(PaletteManager palette, FieldManager field, Vector2IntBundle cursorGridRect, InputActionController input)
		{
			return null;
		}

		public static ClickStartInfo RestartDrawStream(PaletteManager palette, FieldManager field, Vector2IntBundle cursorGridRect)
		{
			return null;
		}

		public void ResetLongPushTimer()
		{
		}
	}
}
