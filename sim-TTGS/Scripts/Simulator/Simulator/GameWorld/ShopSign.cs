using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShopSign : WorldManager, ISensable, IMainInteractable
	{
		[Header("Visuals")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private ToggleInputHint m_inputHint;

		[Space(10f)]
		[SerializeField]
		private MeshRenderer m_renderer;

		[SerializeField]
		private Material m_openMat;

		[SerializeField]
		private Material m_closeMat;

		[Header("Texts")]
		[SerializeField]
		private List<TextMeshPro> m_texts;

		public bool IsOpen { get; private set; }

		public event Action OnOpened;

		public event Action OnClosed;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			if (worldEvent == EWorldEvent.START)
			{
				SetOpen(SaveManager.CurrentSave.shop.shopOpen);
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			if (gameEvent == EGameEvent.DAY_CLEANUP)
			{
				SetOpen(open: false, worldEvents: false);
			}
		}

		private void SetOpen(bool open, bool worldEvents = true)
		{
			if (IsOpen != open)
			{
				IsOpen = open;
				if (worldEvents)
				{
					World.SetShopOpen(IsOpen);
				}
				if (IsOpen)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
		}

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				EPlayerCharacterContext characterContext = World.PlayerCharacter.CharacterContext;
				return characterContext == EPlayerCharacterContext.NONE || characterContext == EPlayerCharacterContext.GRABBING;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
				RefreshInputHint();
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		bool IMainInteractable.CanMainInteract(Character character)
		{
			return character.Controller.IsPlayer;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			SetOpen(!IsOpen);
		}

		private void Open()
		{
			OnOpen();
			this.OnOpened?.Invoke();
		}

		private void OnOpen()
		{
			m_renderer.material = m_openMat;
			foreach (TextMeshPro text in m_texts)
			{
				text.text = "OPEN";
			}
			RefreshInputHint();
		}

		private void Close()
		{
			OnClose();
			this.OnClosed?.Invoke();
		}

		private void OnClose()
		{
			m_renderer.material = m_closeMat;
			foreach (TextMeshPro text in m_texts)
			{
				text.text = "CLOSED";
			}
			RefreshInputHint();
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				m_inputHint.RemoveFlagsAndRefreshInputHint((ToggleInputHint.EActionStates)(-1));
				m_inputHint.AddFlagsAndRefreshInputHint((!IsOpen) ? ToggleInputHint.EActionStates.TRUE : ToggleInputHint.EActionStates.FALSE);
			}
		}
	}
}
