using UnityEngine;
using UnityEngine.UI;

namespace ShellanderGames.WeaponWheel
{
	public class SgSelectable : MonoBehaviour
	{
		private RectTransform m_RectTransform;

		public Graphic m_TargetGraphic;

		public SgSelectableData colors;

		private bool m_IsHighlighted;

		private bool m_IsSelected;

		private Vector2 m_DefaultSize;

		private SgWeaponWheel m_WeaponWheel;

		public RectTransform RectTransform => null;

		public Image Image => null;

		public Graphic TargetGraphic => null;

		private SgSelectableData Data => null;

		protected SgWeaponWheel WeaponWheel => null;

		private SgAnimationManager AnimationManager => null;

		private void Start()
		{
		}

		protected virtual void Reset()
		{
		}

		public virtual void Refresh(bool forceImmediate)
		{
		}

		public void SetHighlighted(bool highlighted, bool forceImmediate)
		{
		}

		public void SetSelected()
		{
		}
	}
}
