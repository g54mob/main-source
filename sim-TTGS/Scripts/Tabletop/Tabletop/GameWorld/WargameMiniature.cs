using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	public class WargameMiniature : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("Data")]
		[SerializeField]
		private MiniatureData m_data;

		[Header("References")]
		[SerializeField]
		private GameObject m_visual;

		[SerializeField]
		private VisualEffect m_aura;

		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private BoxCollider m_collider;

		[SerializeField]
		private Renderer[] m_renderers;

		private Material[] m_rendererMaterials;

		private Color[] m_rendererBaseColors;

		private Sequence m_highlightSequence;

		public int Index { get; private set; }

		public bool IsHovered { get; private set; }

		public EWargameMiniatureState State { get; private set; }

		public event Action<WargameMiniature> Hovered;

		private void OnEnable()
		{
			if (m_outline != null)
			{
				m_outline.enabled = false;
			}
			m_rendererMaterials = new Material[m_renderers.Length];
			m_rendererBaseColors = new Color[m_renderers.Length];
			for (int i = 0; i < m_renderers.Length; i++)
			{
				m_rendererMaterials[i] = m_renderers[i].material;
				m_rendererBaseColors[i] = m_rendererMaterials[i].color;
			}
			base.transform.localScale = Vector3.one * WargameSettings.MiniatureScale;
		}

		private void OnDisable()
		{
		}

		public void Init(bool belongToPlayer, int index)
		{
			Index = index;
			for (int i = 1; i < m_renderers.Length; i++)
			{
				m_rendererMaterials[i].SetFloat(JuiceManager.UseWargameStuffShaderKey, 1f);
			}
		}

		public void ForceResetAura()
		{
			m_aura.SetInt("level", 0);
		}

		public void SetState(EWargameMiniatureState state, int activatedCount = -1)
		{
			State = state;
			if (activatedCount != -1)
			{
				m_aura.SetInt("level", activatedCount);
			}
			if (IsHovered)
			{
				m_outline.enabled = true;
				m_outline.OutlineColor = WargameSettings.HoverMiniatureOutlineColor;
				m_outline.OutlineWidth = 2f;
				JuiceManager.SetHighlightValue(active: true, m_rendererMaterials, m_highlightSequence, 1);
				return;
			}
			switch (State)
			{
			case EWargameMiniatureState.IDLE:
			{
				m_outline.enabled = false;
				for (int k = 0; k < m_renderers.Length; k++)
				{
					m_rendererMaterials[k].color = m_rendererBaseColors[k];
				}
				JuiceManager.SetHighlightValue(active: false, m_rendererMaterials, m_highlightSequence, 1);
				break;
			}
			case EWargameMiniatureState.ACTIVE:
			{
				m_outline.enabled = true;
				m_outline.OutlineColor = WargameSettings.ActiveMiniatureColor;
				m_outline.OutlineWidth = 2f;
				for (int j = 0; j < m_renderers.Length; j++)
				{
					m_rendererMaterials[j].color = m_rendererBaseColors[j] * WargameSettings.ActiveMiniatureColor;
				}
				JuiceManager.SetHighlightValue(active: true, m_rendererMaterials, m_highlightSequence, 1);
				JuiceManager.AddBounce(EBouncePresets.WARGAME_MINIATURE, base.transform);
				break;
			}
			case EWargameMiniatureState.DEAD:
			{
				m_outline.enabled = false;
				for (int i = 0; i < m_renderers.Length; i++)
				{
					m_rendererMaterials[i].color = m_rendererBaseColors[i] * Color.grey;
				}
				JuiceManager.SetHighlightValue(active: false, m_rendererMaterials, m_highlightSequence, 1);
				break;
			}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!eventData.dragging)
			{
				IsHovered = true;
				SetState(State);
				JuiceManager.AddBounce(EBouncePresets.WARGAME_MINIATURE_HOVER_ENTER, base.transform);
				for (int i = 1; i < m_renderers.Length; i++)
				{
					m_rendererMaterials[i].SetFloat(JuiceManager.HighlightShaderKey, 1f);
				}
				this.Hovered?.Invoke(this);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			IsHovered = false;
			SetState(State);
			JuiceManager.AddBounce(EBouncePresets.WARGAME_MINIATURE_HOVER_EXIT, base.transform);
			for (int i = 1; i < m_renderers.Length; i++)
			{
				m_rendererMaterials[i].SetFloat(JuiceManager.HighlightShaderKey, 0f);
			}
			this.Hovered?.Invoke(this);
		}
	}
}
