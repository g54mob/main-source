using DG.Tweening;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ClientCharacterModel : CharacterModel
	{
		[Header("Shopping Bag")]
		[SerializeField]
		private ShoppingBag m_shoppingBag;

		[SerializeField]
		private Transform m_shoppingBagSitAnchor;

		[Header("Payment")]
		[SerializeField]
		private ClientCash m_cash;

		private static int _showCashID;

		private static int _pickUpProductID;

		private static int _paintingID;

		private static int _playingID;

		private bool m_showingCash;

		private bool m_isPainting;

		private Tween m_paintingAnimTransitionTween;

		private bool m_isPlaying;

		private Tween m_playingAnimTransitionTween;

		public ShoppingBag ShoppingBag => m_shoppingBag;

		public ClientCash Cash => m_cash;

		private static int ShowCashID
		{
			get
			{
				if (_showCashID == 0)
				{
					_showCashID = Animator.StringToHash("ShowCash");
				}
				return _showCashID;
			}
		}

		private static int PickUpProductID
		{
			get
			{
				if (_pickUpProductID == 0)
				{
					_pickUpProductID = Animator.StringToHash("PickUpProduct");
				}
				return _pickUpProductID;
			}
		}

		private static int PaintingID
		{
			get
			{
				if (_paintingID == 0)
				{
					_paintingID = Animator.StringToHash("Painting");
				}
				return _paintingID;
			}
		}

		private static int PlayingID
		{
			get
			{
				if (_playingID == 0)
				{
					_playingID = Animator.StringToHash("Playing");
				}
				return _playingID;
			}
		}

		protected override float GetWalkingSpeed()
		{
			return AIClientSettings.Speed;
		}

		public void ShowCash(bool show)
		{
			if (base.HasAnimator && m_showingCash != show)
			{
				m_showingCash = show;
				base.Animator.SetBool(ShowCashID, show);
			}
		}

		protected override void OnSetSitted(bool sitted)
		{
			base.OnSetSitted(sitted);
			if (sitted)
			{
				m_shoppingBag.AddConstraint(m_shoppingBagSitAnchor);
				m_shoppingBag.Open(open: true);
			}
			else
			{
				m_shoppingBag.RemoveAddedConstraints();
				m_shoppingBag.Open(open: false);
			}
		}

		public void PickUpProduct()
		{
			if (base.HasAnimator)
			{
				base.Animator.SetTrigger(PickUpProductID);
			}
		}

		public void Painting(bool painting)
		{
			if (!base.HasAnimator || m_isPainting == painting)
			{
				return;
			}
			m_isPainting = painting;
			if (base.Animator.layerCount > AIModelSettings.PaintingLayerIndex)
			{
				m_paintingAnimTransitionTween.Kill();
				if (painting)
				{
					m_paintingAnimTransitionTween = DOTween.To(GetPaintingLayerWeight, SetPaintingLayerWeight, AIModelSettings.PaintingLayerWeight, AIModelSettings.PaintingAnimTransitionDuration).SetEase(AIModelSettings.PaintingAnimTransitionCurve).Play();
				}
				else
				{
					SetPaintingLayerWeight(0f);
				}
			}
			else
			{
				base.Animator.SetBool(PaintingID, painting);
			}
		}

		private float GetPaintingLayerWeight()
		{
			return base.Animator.GetLayerWeight(AIModelSettings.PaintingLayerIndex);
		}

		private void SetPaintingLayerWeight(float weight)
		{
			base.Animator.SetLayerWeight(AIModelSettings.PaintingLayerIndex, weight);
		}

		public void Playing(bool playing)
		{
			if (base.HasAnimator && m_isPlaying != playing)
			{
				m_isPlaying = playing;
				if (base.Animator.layerCount > AIModelSettings.PlayingLayerIndex)
				{
					m_playingAnimTransitionTween.Kill();
					m_playingAnimTransitionTween = DOTween.To(GetPlayingLayerWeight, SetPlayingLayerWeight, playing ? 1f : 0f, AIModelSettings.PlayingAnimTransitionDuration).SetEase(AIModelSettings.PlayingAnimTransitionCurve).Play();
				}
				else
				{
					base.Animator.SetBool(PlayingID, playing);
				}
			}
		}

		private float GetPlayingLayerWeight()
		{
			return base.Animator.GetLayerWeight(AIModelSettings.PlayingLayerIndex);
		}

		private void SetPlayingLayerWeight(float weight)
		{
			base.Animator.SetLayerWeight(AIModelSettings.PlayingLayerIndex, weight);
		}
	}
}
