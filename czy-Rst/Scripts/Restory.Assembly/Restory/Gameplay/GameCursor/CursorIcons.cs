using System;
using UnityEngine;

namespace Restory.Gameplay.GameCursor
{
	[Serializable]
	public sealed class CursorIcons
	{
		[SerializeField]
		private Texture2D defaultCursor;

		[SerializeField]
		private Texture2D hoverCursor;

		[SerializeField]
		private Texture2D holdCursor;

		[SerializeField]
		private Texture2D unscrewingCursor;

		[SerializeField]
		private Texture2D screwingCursor;

		[SerializeField]
		private Texture2D cleaningCursor;

		[SerializeField]
		private Vector2 cleaningCursorSize;

		[SerializeField]
		private Texture2D soldererIdleCursor;

		[SerializeField]
		private Texture2D solderDetectedCursor;

		[SerializeField]
		private Texture2D paintingCursor;

		[SerializeField]
		private Texture2D invisibleCursor;

		public Texture2D DefaultCursor => defaultCursor;

		public Texture2D HoverCursor => hoverCursor;

		public Texture2D HoldCursor => holdCursor;

		public Texture2D UnscrewingCursor => unscrewingCursor;

		public Texture2D ScrewingCursor => screwingCursor;

		public Texture2D CleaningCursor => cleaningCursor;

		public Texture2D SoldererIdleCursor => soldererIdleCursor;

		public Texture2D SolderDetectedCursor => solderDetectedCursor;

		public Vector2 CleaningCursorSize => cleaningCursorSize;

		public Texture2D InvisibleCursor => invisibleCursor;

		public Texture2D PaintingCursor => paintingCursor;
	}
}
