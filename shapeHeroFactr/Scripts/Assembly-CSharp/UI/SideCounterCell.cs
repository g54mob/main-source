using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public abstract class SideCounterCell : MonoBehaviour
	{
		[Header("プレート開閉時のサイズ")]
		[SerializeField]
		private float plateMinWidth;

		[SerializeField]
		private float plateMaxWidth;

		[SerializeField]
		private float plateMaskMaxWidth;

		[SerializeField]
		private Image plate;

		[SerializeField]
		private Image mask;

		[SerializeField]
		private Image selectedCursor;

		[SerializeField]
		private Image button;

		[SerializeField]
		private Image luggageIcon;

		[SerializeField]
		private bool fixedHeader;

		protected bool isPlayAnimation;

		public Func<eLuggage, bool> updateCheck;

		protected Action<eLuggage> onPointerEnterAction;

		protected Action onPointerExitAction;

		protected void FixedHeader()
		{
		}

		public void SetIcon(Sprite sprite)
		{
		}

		public abstract void InitComponent(eLuggage luggage, Action<eLuggage> onPointerEnter, Action onPointerExit);

		public abstract void UpdateCounter();

		public abstract void ResetCell();

		public void SwitchOpenClose(bool open, float animationTime)
		{
		}

		public virtual void OnPointerEnter()
		{
		}

		public virtual void OnPointerExit()
		{
		}
	}
}
