using System.Collections.Generic;
using Simulator;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionPage : NavBox, IActivable
	{
		[Header("UI Components")]
		[SerializeField]
		private CanvasGroup m_group;

		[SerializeField]
		private GridLayoutGroup m_gridLayout;

		[SerializeField]
		private List<UI_CollectionMiniatureButton> m_miniatureButtons;

		[SerializeField]
		private UI_DynamicScaler _mDynamicScaler;

		private Vector2Int m_currentLayout;

		private List<int> m_uids;

		private UI_CollectionMiniatureButton m_currentSelectedButton;

		public UI_CollectionMiniatureButton CurrentSelectedButton
		{
			get
			{
				return m_currentSelectedButton;
			}
			set
			{
				m_currentSelectedButton = value;
				SetCurrentElement(m_currentSelectedButton);
			}
		}

		public void SetContent(List<CollectionElement> elements, Vector2Int layout, Vector2 pageSizeReference, float horGridSpace)
		{
			m_uids = new List<int>();
			SetupLayout(layout);
			for (int i = 0; i < elements.Count; i++)
			{
				m_uids.Add(elements[i].UID);
				m_miniatureButtons[i].SetContent(elements[i]);
			}
			for (int j = elements.Count; j < m_miniatureButtons.Count; j++)
			{
				m_miniatureButtons[j].SetActive(active: false);
			}
			m_gridLayout.spacing = new Vector2(horGridSpace, m_gridLayout.spacing.y);
			_mDynamicScaler.UpdateSizeReference(pageSizeReference);
		}

		public int GetMiniaturesCount()
		{
			return m_uids.Count;
		}

		private void SetupLayout(Vector2Int layout)
		{
			if (!(m_currentLayout == layout))
			{
				m_currentLayout = layout;
				m_gridLayout.constraintCount = m_currentLayout.x;
				int num = m_currentLayout.x * m_currentLayout.y;
				for (int i = 0; i < m_miniatureButtons.Count; i++)
				{
					m_miniatureButtons[i].gameObject.SetActive(i < num);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(m_gridLayout.transform as RectTransform);
			}
		}

		public override void OnChildSelect(UINavElement child)
		{
			base.OnChildSelect(child);
			if (child is UI_CollectionMiniatureButton currentSelectedButton)
			{
				CurrentSelectedButton = currentSelectedButton;
			}
		}

		public bool GetPreviousSelectedMiniature(out UI_CollectionMiniatureButton button)
		{
			if (CurrentSelectedButton != null && UINavElement.IsValidElement(CurrentSelectedButton))
			{
				for (int num = m_miniatureButtons.IndexOf(CurrentSelectedButton) - 1; num >= 0; num--)
				{
					if (UINavElement.IsValidElement(m_miniatureButtons[num]))
					{
						button = m_miniatureButtons[num];
						return true;
					}
				}
			}
			button = null;
			return false;
		}

		public bool GetNextSelectedMiniature(out UI_CollectionMiniatureButton button)
		{
			if (CurrentSelectedButton != null && UINavElement.IsValidElement(CurrentSelectedButton))
			{
				for (int i = m_miniatureButtons.IndexOf(CurrentSelectedButton) + 1; i < m_miniatureButtons.Count; i++)
				{
					if (UINavElement.IsValidElement(m_miniatureButtons[i]))
					{
						button = m_miniatureButtons[i];
						return true;
					}
				}
			}
			button = null;
			return false;
		}

		void IActivable.SetActive(bool active)
		{
			m_group.alpha = (active ? 1f : 0f);
			m_group.blocksRaycasts = active;
			if (active)
			{
				TabletopPreview3DManager.Instance.ShowCollection(m_uids, Collection.GetPaintingMode());
				if (base.CurrentElement is UI_CollectionMiniatureButton currentSelectedButton)
				{
					CurrentSelectedButton = currentSelectedButton;
				}
			}
		}
	}
}
