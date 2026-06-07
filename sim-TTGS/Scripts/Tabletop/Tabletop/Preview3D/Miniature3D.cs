using System;
using DG.Tweening;
using Simulator.Preview3D;
using Tabletop.GameWorld;
using UnityEngine;

namespace Tabletop.Preview3D
{
	public class Miniature3D : MonoBehaviour, IPreview3DObject
	{
		public const int MaxPiecesCount = 5;

		[Header("Miniature Info")]
		[SerializeField]
		[ReadOnly(false, false)]
		private MiniatureData m_data;

		[SerializeField]
		private EMiniatureSize m_size;

		[Header("Main Components")]
		[SerializeField]
		private Transform m_rotationPlatform;

		[SerializeField]
		private Transform m_piecesContainer;

		[SerializeField]
		private GameObject m_visual;

		[Header("Pieces")]
		[SerializeField]
		private GameObject[] m_pieces;

		[SerializeField]
		private MeshRenderer[] m_renderers;

		[SerializeField]
		private MeshRenderer m_baseRenderer;

		private Material m_texturedMaterial;

		private Material m_unpaintedMaterial;

		private Vector3 m_basePosition;

		private Quaternion m_baseRotation;

		private static readonly float m_paintYOffset = 0.05f;

		private static readonly float m_anglePower = 10f;

		private Sequence m_paintAnimationSequence;

		private Bounds m_bounds;

		public MiniatureData Data => m_data;

		public Vector2 NormalizedAnchor => Vector2.down;

		Transform IPreview3DObject.transform => base.transform;

		private void OnDestroy()
		{
			m_paintAnimationSequence?.Kill();
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Remove(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnTry));
			UI_BasePaintMiniGame.Completed = (Action<int>)Delegate.Remove(UI_BasePaintMiniGame.Completed, new Action<int>(Completed));
		}

		public virtual void Init()
		{
			SetBounds();
			float x = m_visual.transform.position.x;
			float num = Mathf.Max((m_bounds.max.x - x) * 2f, (x - m_bounds.min.x) * 2f, m_bounds.size.y + 0.05f);
			float num2 = Mathf.Min(MiniatureSettings.Miniature3DSize / num, MiniatureSettings.Miniature3DSize);
			m_visual.transform.localScale = Vector3.one * num2;
			m_texturedMaterial = m_renderers[0].material;
			PaintingSettings.SetMaterialValuesByScore(m_texturedMaterial, 0);
			m_unpaintedMaterial = PaintingSettings.GetMiniaturesUnpaintedMat(Data.Rarity);
			Paint();
		}

		private void SetBounds()
		{
			Bounds bounds = m_renderers[0].bounds;
			for (int i = 0; i < m_renderers.Length; i++)
			{
				bounds.Encapsulate(m_renderers[i].bounds);
			}
			bounds.Encapsulate(m_baseRenderer.bounds);
			m_bounds = bounds;
		}

		public void HighlightMissingPieces(bool highlight)
		{
			MiniatureCollectionState miniatureState = Collection.GetMiniatureState(m_data.UID);
			bool flag = miniatureState.completedCount + miniatureState.paintedCount > 0;
			if (highlight && !flag)
			{
				for (int i = 0; i < Data.NecessaryPiecesCount; i++)
				{
					if (m_renderers.IsIndexValid(i))
					{
						m_renderers[i].sharedMaterial = (miniatureState.missingPiecesList.Contains(i) ? MiniatureSettings.HighlightMissingPieceMaterial : m_unpaintedMaterial);
					}
				}
				return;
			}
			if (miniatureState.paintedCount > 0)
			{
				for (int j = 0; j < Data.NecessaryPiecesCount; j++)
				{
					if (m_renderers.IsIndexValid(j))
					{
						m_renderers[j].sharedMaterial = m_texturedMaterial;
					}
				}
				return;
			}
			for (int k = 0; k < Data.NecessaryPiecesCount; k++)
			{
				if (m_renderers.IsIndexValid(k))
				{
					m_renderers[k].sharedMaterial = m_unpaintedMaterial;
				}
			}
		}

		public void ResetRotation()
		{
			m_rotationPlatform.rotation = Quaternion.identity;
		}

		public void Rotate(Vector2 delta)
		{
			if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
			{
				m_rotationPlatform.Rotate(Vector3.up, delta.x);
			}
			else
			{
				m_rotationPlatform.Rotate(Vector3.right, delta.y);
			}
		}

		public void Paint(ECollectionPaintingMode mode)
		{
			switch (mode)
			{
			case ECollectionPaintingMode.PREVIEW:
				Paint();
				break;
			case ECollectionPaintingMode.NO_PAINT:
				Paint(0);
				break;
			case ECollectionPaintingMode.BEST_SCORE:
				Paint(Collection.GetPaintMaxScore(m_data.UID));
				break;
			}
		}

		public void Paint(int scoreOverride = -1, bool whilePainting = false)
		{
			int num = ((scoreOverride > -1) ? scoreOverride : Collection.GetPreviewPaintScore(m_data.UID));
			Material material;
			if (num > 0 || whilePainting)
			{
				material = m_texturedMaterial;
				PaintingSettings.SetMaterialValuesByScore(material, num);
			}
			else
			{
				material = m_unpaintedMaterial;
			}
			MeshRenderer[] renderers = m_renderers;
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material = material;
			}
			if (whilePainting)
			{
				PaintingSettings.SetCachedMaterial(m_renderers[0].sharedMaterial);
				m_basePosition = base.transform.position;
				m_baseRotation = base.transform.rotation;
				UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Combine(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnTry));
				UI_BasePaintMiniGame.Completed = (Action<int>)Delegate.Combine(UI_BasePaintMiniGame.Completed, new Action<int>(Completed));
			}
		}

		private void OnTry(bool success, int score)
		{
			PaintFeedback();
		}

		private void Completed(int score)
		{
			ResetPaintFeedbackAndUnsub();
		}

		public void PaintFeedback()
		{
			JuiceManager.AddBounce(EBouncePresets.PAINT_MINIATURE, base.transform);
			float y = UnityEngine.Random.Range(-180, 180);
			float num = UnityEngine.Random.Range(0f, 1f);
			Vector2 vector = UnityEngine.Random.insideUnitCircle * (num * m_anglePower);
			Vector3 finalPosition = m_basePosition + new Vector3(0f, m_paintYOffset, 0f) * num;
			Quaternion finalRotation = m_baseRotation * Quaternion.Euler(vector.x, y, vector.y);
			MoveToAnimated(finalPosition, finalRotation);
		}

		public void ResetPaintFeedbackAndUnsub()
		{
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Remove(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnTry));
			UI_BasePaintMiniGame.Completed = (Action<int>)Delegate.Remove(UI_BasePaintMiniGame.Completed, new Action<int>(Completed));
			MoveToAnimated(m_basePosition, m_baseRotation);
		}

		private void MoveToAnimated(Vector3 finalPosition, Quaternion finalRotation)
		{
			if (m_paintAnimationSequence.IsActive())
			{
				m_paintAnimationSequence.Kill();
			}
			m_paintAnimationSequence = DOTween.Sequence();
			m_paintAnimationSequence.Append(base.transform.DOMove(finalPosition, 1f).SetEase(Ease.InOutQuint));
			m_paintAnimationSequence.Join(base.transform.DORotateQuaternion(finalRotation, 1f).SetEase(Ease.InOutQuint));
			m_paintAnimationSequence.SetUpdate(isIndependentUpdate: true);
			m_paintAnimationSequence.Play();
		}
	}
}
