using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class WorkerRoomAssignationCursor : CTSBehaviour
	{
		[SerializeField]
		private CursorSO _addCursor;

		[SerializeField]
		private CursorSO _removeCursor;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private RoomAssignationsTool _assignationsTool;

		[SerializeField]
		[Inject(false)]
		private CursorManager _cursorManager;

		private static readonly StringKey _cursorKey = "WorkerAssignation";

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_assignationsTool.CurrentModeChanged += OnCurrentModeChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_assignationsTool.CurrentModeChanged -= OnCurrentModeChanged;
		}

		private void OnCurrentModeChanged(EventChange<RoomAssignationsTool.EMode> change)
		{
			switch (change.Current)
			{
			case RoomAssignationsTool.EMode.None:
				_cursorManager.RemoveCursorVisual(_cursorKey);
				break;
			case RoomAssignationsTool.EMode.Add:
				_cursorManager.AddCursorVisual(_cursorKey, _addCursor);
				break;
			case RoomAssignationsTool.EMode.Remove:
				_cursorManager.AddCursorVisual(_cursorKey, _removeCursor);
				break;
			default:
				throw new ArgumentOutOfRangeException("Current", change.Current, null);
			}
		}
	}
}
