using System;
using System.Collections.Generic;
using Simulator.Preview3D;
using Tabletop.GameWorld;
using UnityEngine;

namespace Tabletop.Preview3D
{
	public class TabletopPreview3DManager : Preview3DManager
	{
		private TabletopPreview3DObjects m_tabletopObjects;

		public new static TabletopPreview3DManager Instance => Preview3DManager._instance as TabletopPreview3DManager;

		public TabletopPreview3DObjects TabletopObjects
		{
			get
			{
				if (m_tabletopObjects == null)
				{
					m_tabletopObjects = m_objects as TabletopPreview3DObjects;
				}
				return m_tabletopObjects;
			}
		}

		public void ShowCollection(List<int> miniatureUIDs, ECollectionPaintingMode mode)
		{
			m_camera.SetActive(active: true);
			m_camera.ShowAllObjects();
			TabletopObjects.SetupMiniatures(miniatureUIDs, mode, highlightMissingPieces: true);
		}

		public void AssembleMiniature(int miniatureUID, Action<int> callback)
		{
			if (TabletopObjects.AssembleMiniature(miniatureUID, callback) > -1)
			{
				m_camera.SetActive(active: true);
			}
		}

		public void FocusMiniature(int miniatureUID, bool highlightMissingPieces)
		{
			if (TabletopObjects.FocusMiniature(miniatureUID, highlightMissingPieces) > -1)
			{
				m_camera.SetActive(active: true);
			}
		}

		public Rect GetFocusedMiniatureRect()
		{
			return GetImageRectAtIndex(12);
		}

		public Rect GetImageRectForMiniature(int miniatureUID)
		{
			int miniatureIndex = TabletopObjects.GetMiniatureIndex(miniatureUID);
			return GetImageRectAtIndex(miniatureIndex);
		}

		public void PaintFocusedMiniature(int scoreOverride = -1, bool whilePainting = false)
		{
			TabletopObjects.PaintFocusedMiniature(scoreOverride, whilePainting);
		}

		public void PaintFocusedMiniature(ECollectionPaintingMode mode)
		{
			TabletopObjects.PaintFocusedMiniature(mode);
		}

		public void FocusPiece(MiniaturePieceData pieceData)
		{
			if (TabletopObjects.FocusMiniaturePiece(pieceData) > -1)
			{
				m_camera.SetActive(active: true);
			}
		}
	}
}
