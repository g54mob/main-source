using System;
using System.Collections;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementIdleSO", menuName = "Story/StoryElementIdleSO")]
	public class StoryElementIdleSO : StoryElementSO
	{
		[SerializeField]
		private float _timeIdlingSeconds;

		[SerializeField]
		private StoryManagerLocator _storyManagerLocator;

		private float _timePassed;

		private IDisposable _anyInputObservable;

		private Coroutine _anyInputCoroutine;

		public override void Initialize()
		{
			_timePassed = 0f;
			_anyInputCoroutine = _storyManagerLocator.StoryManager.StartCoroutine(CheckAnyInput());
			_anyInputObservable = InputSystem.onAnyButtonPress.Call(delegate
			{
				_timePassed = 0f;
			});
		}

		private IEnumerator CheckAnyInput()
		{
			while (_timePassed < _timeIdlingSeconds)
			{
				_timePassed += Time.deltaTime;
				yield return null;
			}
			_anyInputObservable?.Dispose();
			TryExecute();
		}

		public override void Destroy()
		{
			if (_anyInputCoroutine != null)
			{
				_storyManagerLocator.StoryManager.StopCoroutine(_anyInputCoroutine);
			}
			_anyInputObservable?.Dispose();
		}
	}
}
