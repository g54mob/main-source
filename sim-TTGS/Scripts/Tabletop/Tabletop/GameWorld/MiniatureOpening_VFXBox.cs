using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureOpening_VFXBox : MonoBehaviour, IUIInputReceiver
	{
		private enum EVFXBoxStatus
		{
			None = 0,
			AnimatingBox = 1,
			AnimatingPieces = 2
		}

		private MiniatureBoxProduct miniatureBoxProduct;

		private List<MiniatureOpening_VFXPiece> pieces = new List<MiniatureOpening_VFXPiece>();

		private float m_t;

		private Vector2 m_mousePosition;

		private int m_currentPiece = -1;

		private Transform m_camTR;

		private Action m_callbackOnEnd;

		private bool m_ended;

		private EVFXBoxStatus m_boxStatus;

		private bool m_updateRegistered;

		public static MiniatureOpening_VFXBox CurrentlyPlaying { get; private set; }

		public static void Init(MiniatureBoxProduct product)
		{
			CurrentlyPlaying = product.gameObject.AddComponent<MiniatureOpening_VFXBox>();
			CurrentlyPlaying.miniatureBoxProduct = product;
			CurrentlyPlaying.SetupAndStartAnimCloseUp();
		}

		private void SetupAndStartAnimCloseUp()
		{
			if ((bool)CurrentlyPlaying && CurrentlyPlaying != this)
			{
				CurrentlyPlaying.LastElementFinished();
			}
			CurrentlyPlaying = this;
			m_camTR = TransientManager<CameraManager>.Instance.transform;
			m_boxStatus = EVFXBoxStatus.AnimatingBox;
			m_t = 0f;
			RegisterToUpdate(register: true);
		}

		private void StartOpeningAnimation()
		{
			StartCoroutine(miniatureBoxProduct.LookAtAnimationBeforeUnpacking());
		}

		public void NowAnimatingPieces()
		{
			m_boxStatus = EVFXBoxStatus.AnimatingPieces;
			UnityEngine.Object.Instantiate(MiniatureUnpackingSettings.VisualEffect, miniatureBoxProduct.transform.position + MiniatureUnpackingSettings.VisualEffectOffset, Quaternion.identity).Play();
		}

		public void OnEnd(Action callback)
		{
			if (!m_ended)
			{
				m_ended = true;
				m_callbackOnEnd = callback;
				OnSkip();
			}
		}

		private void LastElementFinished()
		{
			foreach (MiniatureOpening_VFXPiece piece in pieces)
			{
				UnityEngine.Object.Destroy(piece.gameObject);
			}
			m_boxStatus = EVFXBoxStatus.None;
			m_callbackOnEnd?.Invoke();
			m_ended = false;
			RegisterToUpdate(register: false);
		}

		public void OnSkip()
		{
			if (pieces.IsIndexValid(m_currentPiece))
			{
				pieces[m_currentPiece].RequestLeaveCenter();
			}
			m_currentPiece++;
			if (pieces.IsIndexValid(m_currentPiece))
			{
				pieces[m_currentPiece].RequestLeaveBox();
			}
		}

		public void OnCreateCard(MiniaturePieceData pieceData, int index)
		{
			MiniatureOpening_VFXPiece component = UnityEngine.Object.Instantiate(MiniatureUnpackingSettings.PieceVFXPrefab, base.transform.position, base.transform.rotation).GetComponent<MiniatureOpening_VFXPiece>();
			component.Init(pieceData, MiniatureUnpackingSettings.CamPosOffsetForPieces, base.transform.position, m_camTR.localToWorldMatrix);
			pieces.Add(component);
		}

		private void RegisterToUpdate(bool register)
		{
			if (m_updateRegistered != register)
			{
				m_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
				if (register)
				{
					IUIInputReceiver.SetCurrent(this);
				}
				else
				{
					IUIInputReceiver.SetCurrent(null);
				}
			}
		}

		private void OnUpdate(float deltaTime)
		{
			switch (m_boxStatus)
			{
			case EVFXBoxStatus.AnimatingBox:
				if (m_t > MiniatureUnpackingSettings.BoxToTargetDuration)
				{
					StartOpeningAnimation();
					m_boxStatus = EVFXBoxStatus.None;
					break;
				}
				m_t += Time.deltaTime / MiniatureUnpackingSettings.BoxToTargetDuration;
				base.transform.position = Vector3.LerpUnclamped(base.transform.position, m_camTR.TransformPoint(MiniatureUnpackingSettings.BoxPosTargetRelativeToCamera), MiniatureUnpackingSettings.BoxToTargetCurve.Evaluate(m_t));
				base.transform.rotation = Quaternion.LerpUnclamped(base.transform.rotation, Quaternion.LookRotation(-m_camTR.forward), MiniatureUnpackingSettings.BoxToTargetCurve.Evaluate(m_t));
				base.transform.localScale = Vector3.LerpUnclamped(base.transform.localScale, MiniatureUnpackingSettings.BoxScaleTarget, MiniatureUnpackingSettings.BoxToTargetCurve.Evaluate(m_t));
				break;
			case EVFXBoxStatus.AnimatingPieces:
			{
				float smoothDeltaTime = Time.smoothDeltaTime;
				bool flag = true;
				foreach (MiniatureOpening_VFXPiece piece in pieces)
				{
					if (piece.Animate(smoothDeltaTime, m_mousePosition) != MiniatureOpening_VFXPiece.EPieceState.LeftView)
					{
						flag = false;
					}
				}
				if (flag)
				{
					LastElementFinished();
				}
				break;
			}
			case EVFXBoxStatus.None:
				break;
			}
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
			m_mousePosition += direction;
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
			m_mousePosition = mousePosition;
		}

		public void OnUIInput_Submit()
		{
		}

		public void OnUIInput_Space()
		{
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_GamepadNorthButton()
		{
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
		}
	}
}
