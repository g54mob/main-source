using FMOD.Studio;
using FMODUnity;
using Simulator.GameWorld;
using Simulator.Menus;

namespace Simulator
{
	public class MusicManager : TransientManager<MusicManager>
	{
		private EventInstance m_currentEventInstance;

		protected override void OnMenuEvent(EMenuEvent menuEvent)
		{
			base.OnMenuEvent(menuEvent);
			if (menuEvent == EMenuEvent.START || menuEvent == EMenuEvent.BACK_TO_MENU)
			{
				PlayMusic(MenuAudioSettings.Music);
			}
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			if (worldEvent == EWorldEvent.START)
			{
				PlayMusic(WorldAudioSettings.Music);
			}
		}

		private void PlayMusic(EventReference eventReference)
		{
			AudioManager.StopEvent(m_currentEventInstance);
			m_currentEventInstance = AudioManager.PlayPersistentEvent(eventReference);
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				m_currentEventInstance.setParameterByName("Day-Night_Cycle", 0f);
				break;
			case EGameEvent.NIGHT:
				m_currentEventInstance.setParameterByName("Day-Night_Cycle", 1f);
				break;
			}
		}
	}
}
