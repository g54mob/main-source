using System;
using System.Collections;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureBoxProduct : TabletopProduct
	{
		[SerializeField]
		private Animator m_animator;

		public static event Action<int> StartOpenBox;

		public static event Action BoxShake;

		public override bool CanBeToggled()
		{
			return !base.IsOpen;
		}

		protected override void OnOpen()
		{
			base.OnOpen();
			if (base.ProductData is MiniatureBoxProductData miniatureBoxProductData)
			{
				OnOpenMiniatureBox(miniatureBoxProductData);
			}
		}

		protected virtual void OnOpenMiniatureBox(MiniatureBoxProductData miniatureBoxProductData)
		{
			Collection.Unpack(miniatureBoxProductData);
			GameAnalytics.NewOrAddDesignEvent("id_analytics_figboxopen", 1f);
			TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.NONE);
			MiniatureOpening_VFXBox.Init(this);
		}

		public IEnumerator LookAtAnimationBeforeUnpacking()
		{
			m_animator.SetBool(BaseBox.OpenParamID, value: true);
			MiniatureBoxProduct.StartOpenBox?.Invoke(base.ProductData.UID);
			int iterations = 0;
			while (m_animator.GetAnimatorTransitionInfo(0).duration == 0f && iterations < 10)
			{
				yield return null;
				iterations++;
			}
			MiniatureBoxProduct.BoxShake?.Invoke();
			yield return new WaitForSeconds(m_animator.GetAnimatorTransitionInfo(0).duration + MiniatureSettings.UnpackingDelay);
			MiniatureUnpacking();
		}

		public void MiniatureUnpacking()
		{
			MiniatureOpening_VFXBox.CurrentlyPlaying.NowAnimatingPieces();
			TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.MINIATURE_OPENING);
			if (base.InputHint is MiniatureBoxProductInputHint miniatureBoxProductInputHint)
			{
				miniatureBoxProductInputHint.RemoveFlagsAndRefreshInputHint(MiniatureBoxProductInputHint.EActionStates.UNPACK);
				miniatureBoxProductInputHint.AddFlagsAndRefreshInputHint(MiniatureBoxProductInputHint.EActionStates.NEXT);
				base.InputHint.enabled = true;
			}
		}
	}
}
