using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class CursorManager : MonoBehaviour
	{
		public CursorConfig defaultCursor;

		private List<CursorItem> items;

		public static CursorManager instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void EnsureCursor(CursorPointable pointable)
		{
		}

		public void RemoveCursor(CursorPointable pointable)
		{
		}

		public void AddCursor(CursorItem item)
		{
		}

		public void RemoveCursor(CursorItem item)
		{
		}

		private void UpdateCursor()
		{
		}

		private void SetCursor(CursorConfig config)
		{
		}
	}
}
