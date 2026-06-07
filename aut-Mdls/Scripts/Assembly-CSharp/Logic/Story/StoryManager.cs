using System.Collections.Generic;
using Data.FeatureFlags.Validators;
using Data.Story;
using Data.Variables;
using Events;
using Logic.Factory;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;

namespace Logic.Story
{
	public class StoryManager : MonoBehaviour
	{
		[SerializeField]
		private StoryManagerLocator _storyManagerLocator;

		[SerializeField]
		private BoolVariableSO _zenModeSO;

		[SerializeField]
		private FeatureFlagValidator _storiesValidator;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		[InfoBox("This list updates automatically to keep the persisted order, add new elements by drag dropping them in", EInfoBoxType.Normal)]
		[SerializeField]
		private List<StoryElementSO> _storyElements = new List<StoryElementSO>();

		private List<StoryElementSO> _storyElementsToExecute = new List<StoryElementSO>();

		public bool[] CompletedStories
		{
			get
			{
				bool[] array = new bool[_storyElements.Count];
				for (int i = 0; i < _storyElements.Count; i++)
				{
					array[i] = _storyElements[i].IsComplete;
				}
				return array;
			}
		}

		private void Awake()
		{
			_storyManagerLocator.StoryManager = this;
		}

		private void OnDisable()
		{
			foreach (StoryElementSO storyElement in _storyElements)
			{
				storyElement.OnStoryCompleted -= OnStoryElementCompleted;
				storyElement.Destroy();
			}
			_finishedLoadingSaveEvent.UnRegister(InitializeStoryElements);
		}

		public void TryStartStory()
		{
			ResetToDefault();
			TryInitStory();
		}

		public void ApplyCompletedStories(bool[] completedStories)
		{
			for (int i = 0; i < completedStories.Length; i++)
			{
				if (i >= 0 && i < _storyElements.Count)
				{
					_storyElements[i].SetComplete(completedStories[i]);
				}
			}
			TryInitStory();
		}

		private void TryInitStory()
		{
			if (_factoryLoader.HasFinishedLoadingSave)
			{
				InitializeStoryElements();
			}
			else
			{
				_finishedLoadingSaveEvent.Register(InitializeStoryElements);
			}
		}

		private void InitializeStoryElements()
		{
			_finishedLoadingSaveEvent.UnRegister(InitializeStoryElements);
			if (_zenModeSO.Value || !_storiesValidator.IsEnabledFeatureFlag())
			{
				return;
			}
			foreach (StoryElementSO storyElement in _storyElements)
			{
				if (storyElement.IsComplete)
				{
					storyElement.EnsureCompletedEventsAreTriggered();
				}
				else
				{
					InitializeStoryElement(storyElement);
				}
			}
		}

		private void InitializeStoryElement(StoryElementSO storyElement)
		{
			storyElement.SetComplete(complete: false);
			storyElement.OnStoryCompleted += OnStoryElementCompleted;
			storyElement.Initialize();
		}

		private void OnStoryElementCompleted(StoryElementSO storyElement)
		{
			storyElement.OnStoryCompleted -= OnStoryElementCompleted;
			List<StoryElementSO> list = new List<StoryElementSO>();
			bool flag = false;
			for (int i = 0; i < _storyElementsToExecute.Count; i++)
			{
				if (!flag && storyElement.ExecutionOrder < _storyElementsToExecute[i].ExecutionOrder)
				{
					list.Add(storyElement);
					flag = true;
				}
				list.Add(_storyElementsToExecute[i]);
			}
			if (!flag)
			{
				list.Add(storyElement);
			}
			_storyElementsToExecute = list;
		}

		private void Update()
		{
			if (_storyElementsToExecute.Count <= 0)
			{
				return;
			}
			foreach (StoryElementSO item in _storyElementsToExecute)
			{
				item.Execute();
			}
			_storyElementsToExecute.Clear();
		}

		public void ResetToDefault()
		{
			foreach (StoryElementSO storyElement in _storyElements)
			{
				storyElement.SetComplete(complete: false);
			}
		}
	}
}
