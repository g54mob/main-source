using Simulator.Preview3D;
using Tabletop.Preview3D;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class UI_MiniatureAssemblePopup : UI_CollectionPopup
	{
		[SerializeField]
		private GameObject m_container;

		private bool m_focusedBeforeAssemble;

		protected override void OnEnable()
		{
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_container.SetActive(value: true);
			m_focusedBeforeAssemble = Preview3DManager.Instance.Focused;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_container.SetActive(value: false);
			if (!m_focusedBeforeAssemble)
			{
				Preview3DManager.Instance.Unfocus();
			}
		}

		public override bool CanBeClosed()
		{
			return false;
		}

		private void OnAssembledMiniature(int uid, bool newMiniature)
		{
			SetActive(active: true);
			TabletopPreview3DManager.Instance.AssembleMiniature(uid, OnCompleteAssembleAnimation);
		}

		private void OnCompleteAssembleAnimation(int uid)
		{
			SetActive(active: false);
		}
	}
}
