using System;
using System.Collections.Generic;
using Simulator.Preview3D;
using Tabletop.GameWorld;
using UnityEngine;

namespace Tabletop.Preview3D
{
	public class TabletopPreview3DObjects : Preview3DObjects
	{
		[SerializeField]
		private Transform m_miniatureContainer;

		private Dictionary<int, Miniature3D> m_miniatures = new Dictionary<int, Miniature3D>();

		public Miniature3D FocusedMiniature { get; private set; }

		public MiniaturePiece3D FocusedPiece { get; private set; }

		protected override void HideObjects()
		{
			for (int i = 0; i < m_objects.Length - 1; i++)
			{
				if (m_objects[i] != null)
				{
					m_objects[i].transform.localPosition = Vector3.zero;
				}
			}
		}

		protected override void ClearObjects(bool destroy)
		{
			for (int i = 0; i < m_objects.Length - 1; i++)
			{
				if (m_objects[i] != null)
				{
					if (destroy)
					{
						UnityEngine.Object.Destroy(m_objects[i].transform.gameObject);
					}
					else
					{
						m_objects[i].transform.localPosition = Vector3.zero;
					}
				}
				m_objects[i] = null;
			}
		}

		public void SetupMiniatures(List<int> miniaturesUIDs, ECollectionPaintingMode mode, bool highlightMissingPieces)
		{
			ClearObjects(destroy: false);
			if (miniaturesUIDs.IsValid())
			{
				for (int i = 0; i < miniaturesUIDs.Count; i++)
				{
					int miniatureUID = miniaturesUIDs[i];
					Miniature3D miniature = GetMiniature(miniatureUID);
					m_objects[i] = miniature;
					miniature.Paint(mode);
					miniature.HighlightMissingPieces(highlightMissingPieces);
				}
			}
			UpdateObjects();
		}

		private Miniature3D GetMiniature(int miniatureUID)
		{
			if (!m_miniatures.TryGetValue(miniatureUID, out var value))
			{
				return CreateMiniature(miniatureUID, reusable: true);
			}
			return value;
		}

		private Miniature3D CreateMiniature(int miniatureUID, bool reusable)
		{
			Miniature3D component = UnityEngine.Object.Instantiate(MiniatureDatabase.Get(miniatureUID).Preview3D, m_miniatureContainer).GetComponent<Miniature3D>();
			component.Init();
			if (reusable)
			{
				m_miniatures[miniatureUID] = component;
			}
			return component;
		}

		public int GetMiniatureIndex(int miniatureUID)
		{
			Miniature3D miniature = GetMiniature(miniatureUID);
			int num = -1;
			for (int i = 0; i < m_objects.Length; i++)
			{
				if (miniature == m_objects[i] as UnityEngine.Object)
				{
					return i;
				}
				if (num == -1 && m_objects[i] == null)
				{
					num = i;
				}
			}
			if (num == -1)
			{
				num = 11;
			}
			m_objects[num] = miniature;
			UpdateObjects();
			return num;
		}

		public int FocusMiniature(int miniatureUID, bool highlightMissingPieces)
		{
			CleanFocusedObject();
			FocusedMiniature = CreateMiniature(miniatureUID, reusable: false);
			FocusedMiniature.HighlightMissingPieces(highlightMissingPieces);
			if (m_objects[12] != null)
			{
				HideObject(m_objects[12]);
			}
			m_objects[12] = FocusedMiniature;
			UpdateObjectAtIndex(12);
			FocusObjectAtIndex(12);
			return 12;
		}

		public int AssembleMiniature(int miniatureUID, Action<int> onComplete)
		{
			if (m_miniatures.TryGetValue(miniatureUID, out var value))
			{
				UnityEngine.Object.Instantiate(value.Data.Assembly, m_miniatureContainer).GetComponent<MiniatureAssembly>().PlayAssembleAnimation(onComplete);
			}
			return FocusMiniature(miniatureUID, highlightMissingPieces: false);
		}

		public void PaintMiniature(int miniatureUID, int scoreOverride = -1, bool whilePainting = false)
		{
			if (m_miniatures.TryGetValue(miniatureUID, out var value))
			{
				value.Paint(scoreOverride, whilePainting);
			}
		}

		public void PaintFocusedMiniature(int scoreOverride = -1, bool whilePainting = false)
		{
			if (FocusedMiniature != null)
			{
				FocusedMiniature.Paint(scoreOverride, whilePainting);
			}
		}

		public void PaintFocusedMiniature(ECollectionPaintingMode mode)
		{
			if (FocusedMiniature != null)
			{
				FocusedMiniature.Paint(mode);
			}
		}

		public override void LoseFocus()
		{
			base.LoseFocus();
			if (FocusedMiniature != null)
			{
				UnityEngine.Object.Destroy(FocusedMiniature.gameObject);
			}
			FocusedMiniature = null;
			m_objects[12] = null;
		}

		private MiniaturePiece3D CreateMiniaturePiece(MiniaturePieceData pieceData)
		{
			MiniaturePiece3D component = UnityEngine.Object.Instantiate(pieceData.Prefab, m_miniatureContainer).GetComponent<MiniaturePiece3D>();
			component.Init(inUI: true);
			return component;
		}

		public int FocusMiniaturePiece(MiniaturePieceData pieceData)
		{
			CleanFocusedObject();
			FocusedPiece = CreateMiniaturePiece(pieceData);
			if (m_objects[12] != null)
			{
				HideObject(m_objects[12]);
			}
			m_objects[12] = FocusedPiece;
			UpdateObjectAtIndex(12);
			FocusObjectAtIndex(12);
			return 12;
		}

		private void CleanFocusedObject()
		{
			if (FocusedMiniature != null)
			{
				UnityEngine.Object.Destroy(FocusedMiniature.gameObject);
			}
			if (FocusedPiece != null)
			{
				UnityEngine.Object.Destroy(FocusedPiece.gameObject);
			}
		}
	}
}
