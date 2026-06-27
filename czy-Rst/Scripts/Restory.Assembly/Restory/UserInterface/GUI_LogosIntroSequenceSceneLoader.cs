using System.Collections;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_LogosIntroSequenceSceneLoader : MonoBehaviour
	{
		[SerializeField]
		private GUI_LogosIntroSequence introSequence;

		[SerializeField]
		private GUI_GameModeLoadButton nextSceneLoader;

		private GlobalStateMachine globalStateMachine;

		private Coroutine startSequenceWhenFullyLoadedCoroutine;

		[Inject]
		private void Construct(GlobalStateMachine globalStateMachine)
		{
			this.globalStateMachine = globalStateMachine;
		}

		private void OnEnable()
		{
			introSequence.OnSequenceEnded += ResolveSequenceEnded;
			startSequenceWhenFullyLoadedCoroutine = StartCoroutine(StartSequenceWhenFullyLoadedCoroutine());
		}

		private void OnDisable()
		{
			if (introSequence.MonoShellExists())
			{
				introSequence.OnSequenceEnded -= ResolveSequenceEnded;
			}
			if (startSequenceWhenFullyLoadedCoroutine != null)
			{
				StopCoroutine(startSequenceWhenFullyLoadedCoroutine);
				startSequenceWhenFullyLoadedCoroutine = null;
			}
		}

		private IEnumerator StartSequenceWhenFullyLoadedCoroutine()
		{
			yield return new WaitUntil(delegate
			{
				GlobalStateMachine globalStateMachine = this.globalStateMachine;
				return globalStateMachine != null && globalStateMachine.ActiveState is GameIntroLogosState;
			});
			introSequence.StartSequence();
			startSequenceWhenFullyLoadedCoroutine = null;
		}

		private void ResolveSequenceEnded()
		{
			nextSceneLoader.LoadPreset();
		}
	}
}
