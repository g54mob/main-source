using System.Collections;
using Presentation.Locators;
using Presentation.UI.Credits;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Logic.Audio
{
	public class AudioMusicSwapManager : MonoBehaviour
	{
		private enum State
		{
			Default = 0,
			TechTreeNode = 1,
			CreditsUI = 2
		}

		[SerializeField]
		private AudioMusicSwapManagerLocator _audioMusicSwapManagerLocator;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private ShowUIMenuEvent _willShowUIMenuEvent;

		[SerializeField]
		private HideUIMenuEvent _hideUIMenuEvent;

		private State _currentState;

		private Coroutine _coroutine;

		private void Start()
		{
			_audioMusicSwapManagerLocator.MusicSwapManager = this;
			_willShowUIMenuEvent.Register(OnWillShowUIMenu);
			_hideUIMenuEvent.Register(OnHideUIMenu);
		}

		private void OnDestroy()
		{
			_audioMusicSwapManagerLocator.MusicSwapManager = null;
			_willShowUIMenuEvent.UnRegister(OnWillShowUIMenu);
			_hideUIMenuEvent.UnRegister(OnHideUIMenu);
		}

		public void TriggerImportantTechTreeNodeUnlocked()
		{
			if (_currentState == State.Default || _currentState == State.TechTreeNode)
			{
				StopCoroutine();
				_coroutine = StartCoroutine(SetStateForSeconds(State.TechTreeNode, 60f));
			}
		}

		private void OnWillShowUIMenu(AbstractUIMenuData data)
		{
			if (data.UIMenu is CreditsUI)
			{
				StopCoroutine();
				SetState(State.CreditsUI);
			}
		}

		private void OnHideUIMenu(AbstractUIMenuData data)
		{
			if (data.UIMenu is CreditsUI && _currentState == State.CreditsUI)
			{
				StopCoroutine();
				SetState(State.Default);
			}
		}

		private IEnumerator SetStateForSeconds(State state, float seconds)
		{
			SetState(state);
			yield return new WaitForSeconds(seconds);
			SetState(State.Default);
		}

		private void StopCoroutine()
		{
			if (_coroutine != null)
			{
				StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}

		private void SetState(State state)
		{
			_currentState = state;
			switch (state)
			{
			case State.TechTreeNode:
				_audioManagerLocator.AudioManager.SetTechTreeCreditsMusicParameter(1f);
				break;
			case State.CreditsUI:
				_audioManagerLocator.AudioManager.SetTechTreeCreditsMusicParameter(1f);
				break;
			case State.Default:
				_audioManagerLocator.AudioManager.SetTechTreeCreditsMusicParameter(0f);
				break;
			}
		}
	}
}
