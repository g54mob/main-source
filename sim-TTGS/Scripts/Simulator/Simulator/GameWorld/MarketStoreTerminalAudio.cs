using UnityEngine;

namespace Simulator.GameWorld
{
	public class MarketStoreTerminalAudio : MonoBehaviour
	{
		[SerializeField]
		private MarketStoreTerminal m_marketStoreTerminal;

		private void OnEnable()
		{
			EventManager.OnWorldEvent += OnWorldEvent;
			m_marketStoreTerminal.OnControlled += OnMarketStoreTerminalControlled_PlaySound;
		}

		private void OnDisable()
		{
			EventManager.OnWorldEvent -= OnWorldEvent;
			m_marketStoreTerminal.OnControlled -= OnMarketStoreTerminalControlled_PlaySound;
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
				MarketStore.BoughtBoxes += OnMarketStoreTerminalPurchase;
				MarketStore.BoughtLicense += OnMarketStoreTerminalPurchase;
				break;
			case EWorldEvent.PREPARE_QUIT:
				MarketStore.BoughtBoxes -= OnMarketStoreTerminalPurchase;
				MarketStore.BoughtLicense -= OnMarketStoreTerminalPurchase;
				break;
			}
		}

		private void OnMarketStoreTerminalControlled_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.MarketStoreOpen);
		}

		private void OnMarketStoreTerminalPurchase(float _)
		{
			OnMarketStorePurchase_PlaySound();
		}

		private void OnMarketStorePurchase_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.MarketStorePurchase);
		}
	}
}
