using System;
using System.Collections.Generic;
using FullInspector;
using TH20.Analytics;
using TH20.UI;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace TH20
{
	public class ContentCarouselMenu : MonoBehaviour
	{
		public class Data
		{
			public DLCItemDefinition DLCItem;

			public CarouselContentDefinition ContentDefinition;
		}

		public class DataInstance
		{
			public Data Data;

			public int Count;
		}

		[SerializeField]
		private GameObject _carouselPageMarkerPrefab;

		[SerializeField]
		private GameObject _pageMarkerContainer;

		[SerializeField]
		private Color _pageMarkerOffColour;

		[SerializeField]
		private Color _pageMarkerOnColour;

		[SerializeField]
		private DynamicButton _leftArrowButton;

		[SerializeField]
		private DynamicButton _rightArrowButton;

		[SerializeField]
		private ContentCarouselItem _carousalHolderA;

		[SerializeField]
		private ContentCarouselItem _carousalHolderB;

		[SerializeField]
		private Image _carouselTimerFill;

		[SerializeField]
		private PlayableDirector _rotatePlayableDirector;

		[SerializeField]
		private PlayableDirector _rotateReversePlayableDirector;

		[SerializeField]
		private float _pageTimer = 10f;

		[SerializeField]
		private CarouselContentDefinition[] _beforeDLCContent;

		[SerializeField]
		private CarouselContentDefinition[] _afterDLCContent;

		[SerializeField]
		private List<string> _tipsList;

		private float _elapsedTime;

		private int _currentPageIndex;

		private ContentCarouselItem _currentCarouselHolder;

		private ContentCarouselItem _nextCarouselHolder;

		private readonly List<Image> _pageMarkers = new List<Image>();

		private readonly List<DataInstance> _carouselDataList = new List<DataInstance>();

		private PlayableBinding _carouselHolderPlayableBindingA;

		private PlayableBinding _carouselHolderPlayableBindingB;

		private PlayableBinding _carouselHolderPlayableReverseBindingA;

		private PlayableBinding _carouselHolderPlayableReverseBindingB;

		private AnalyticsManager _analyticsManager;

		private MessageBox _messageBox;

		public void Initialise(DLCManager dlcManager, AnalyticsManager analyticsManager, MessageBox messageBox, CloudDataManager cloudDataManager)
		{
			_analyticsManager = analyticsManager;
			_messageBox = messageBox;
			CarouselContentDefinition.Platform currentPlatform = CarouselContentDefinition.Platform.STEAM;
			_currentPageIndex = 0;
			_elapsedTime = 0f;
			_currentCarouselHolder = _carousalHolderA;
			_nextCarouselHolder = _carousalHolderB;
			_carouselDataList.Clear();
			CarouselContentDefinition[] beforeDLCContent = _beforeDLCContent;
			foreach (CarouselContentDefinition carouselContentDefinition in beforeDLCContent)
			{
				if (!(carouselContentDefinition == null) && PlatformFeatureSupport.IsFeatureSupported(carouselContentDefinition.m_featureType, cloudDataManager) && ShouldShowOnPlatform(currentPlatform, carouselContentDefinition.OnlyShowOn) && (!carouselContentDefinition.RequiresOnlineAccountLogin || OnlineManager.IsInitializedAndLoggedOn()))
				{
					uint serverTime = OnlineManager.GetServerTime();
					if ((carouselContentDefinition.StartTime == 0 || serverTime > carouselContentDefinition.StartTime) && (carouselContentDefinition.ExpiryTime == 0 || serverTime <= carouselContentDefinition.ExpiryTime))
					{
						DataInstance item = new DataInstance
						{
							Data = new Data
							{
								ContentDefinition = carouselContentDefinition
							}
						};
						_carouselDataList.Add(item);
					}
				}
			}
			foreach (SharedInstance<DLCItemDefinition> availableItem in dlcManager.AvailableItems)
			{
				if (!availableItem.IsNull())
				{
					DLCItemDefinition instance = availableItem.Instance;
					if (instance.ShowInCarousel && !DLCUtils.IsDLCInstalled(instance))
					{
						DataInstance item2 = new DataInstance
						{
							Data = new Data
							{
								DLCItem = instance
							}
						};
						_carouselDataList.Add(item2);
					}
				}
			}
			beforeDLCContent = _afterDLCContent;
			foreach (CarouselContentDefinition carouselContentDefinition2 in beforeDLCContent)
			{
				if (!(carouselContentDefinition2 == null) && PlatformFeatureSupport.IsFeatureSupported(carouselContentDefinition2.m_featureType, cloudDataManager) && ShouldShowOnPlatform(currentPlatform, carouselContentDefinition2.OnlyShowOn) && (!carouselContentDefinition2.RequiresOnlineAccountLogin || OnlineManager.IsInitialized()))
				{
					uint serverTime2 = OnlineManager.GetServerTime();
					if ((carouselContentDefinition2.StartTime == 0 || serverTime2 > carouselContentDefinition2.StartTime) && (carouselContentDefinition2.ExpiryTime == 0 || serverTime2 <= carouselContentDefinition2.ExpiryTime))
					{
						DataInstance item3 = new DataInstance
						{
							Data = new Data
							{
								ContentDefinition = carouselContentDefinition2
							}
						};
						_carouselDataList.Add(item3);
					}
				}
			}
			_carouselDataList.Add(new DataInstance());
			foreach (Image pageMarker in _pageMarkers)
			{
				UnityEngine.Object.Destroy(pageMarker.gameObject);
			}
			_pageMarkers.Clear();
			for (int j = 0; j < _carouselDataList.Count; j++)
			{
				Image component = UnityEngine.Object.Instantiate(_carouselPageMarkerPrefab, _pageMarkerContainer.transform, worldPositionStays: false).GetComponent<Image>();
				_pageMarkers.Add(component);
			}
			_currentPageIndex = 0;
			_currentCarouselHolder.Setup(_carouselDataList[0], _tipsList, 0);
			_nextCarouselHolder.Setup(_carouselDataList[0], _tipsList, 0);
			_carouselDataList[0].Count++;
			_currentCarouselHolder.CanvasGroup.alpha = 1f;
			_nextCarouselHolder.CanvasGroup.alpha = 0f;
			foreach (PlayableBinding output in _rotatePlayableDirector.playableAsset.outputs)
			{
				if (output.streamName == "CarouselHolderA")
				{
					_carouselHolderPlayableBindingA = output;
				}
				else if (output.streamName == "CarouselHolderB")
				{
					_carouselHolderPlayableBindingB = output;
				}
			}
			_rotatePlayableDirector.SetGenericBinding(_carouselHolderPlayableBindingA.sourceObject, _currentCarouselHolder.gameObject);
			_rotatePlayableDirector.SetGenericBinding(_carouselHolderPlayableBindingB.sourceObject, _nextCarouselHolder.gameObject);
			foreach (PlayableBinding output2 in _rotateReversePlayableDirector.playableAsset.outputs)
			{
				if (output2.streamName == "CarouselHolderA")
				{
					_carouselHolderPlayableReverseBindingA = output2;
				}
				else if (output2.streamName == "CarouselHolderB")
				{
					_carouselHolderPlayableReverseBindingB = output2;
				}
			}
			_rotateReversePlayableDirector.SetGenericBinding(_carouselHolderPlayableReverseBindingA.sourceObject, _currentCarouselHolder.gameObject);
			_rotateReversePlayableDirector.SetGenericBinding(_carouselHolderPlayableReverseBindingB.sourceObject, _nextCarouselHolder.gameObject);
			SetupPageMarkers();
		}

		private void OnEnable()
		{
			_leftArrowButton.onPrimaryDown.AddListener(OnLeftArrowPressed);
			_rightArrowButton.onPrimaryDown.AddListener(OnRightArrowPressed);
			ContentCarouselItem carousalHolderA = _carousalHolderA;
			carousalHolderA.OnSelected = (Action<Data>)Delegate.Combine(carousalHolderA.OnSelected, new Action<Data>(OnCarousalHolderSelected));
			ContentCarouselItem carousalHolderB = _carousalHolderB;
			carousalHolderB.OnSelected = (Action<Data>)Delegate.Combine(carousalHolderB.OnSelected, new Action<Data>(OnCarousalHolderSelected));
		}

		private void OnDisable()
		{
			_leftArrowButton.onPrimaryDown.RemoveListener(OnLeftArrowPressed);
			_rightArrowButton.onPrimaryDown.RemoveListener(OnRightArrowPressed);
			ContentCarouselItem carousalHolderA = _carousalHolderA;
			carousalHolderA.OnSelected = (Action<Data>)Delegate.Remove(carousalHolderA.OnSelected, new Action<Data>(OnCarousalHolderSelected));
			ContentCarouselItem carousalHolderB = _carousalHolderB;
			carousalHolderB.OnSelected = (Action<Data>)Delegate.Remove(carousalHolderB.OnSelected, new Action<Data>(OnCarousalHolderSelected));
		}

		private void Update()
		{
			_elapsedTime += Time.unscaledDeltaTime;
			_carouselTimerFill.fillAmount = _elapsedTime / _pageTimer;
			if (_elapsedTime >= _pageTimer)
			{
				TriggerNextCarouselSlide(reverse: false);
			}
		}

		private void TriggerNextCarouselSlide(bool reverse)
		{
			_elapsedTime = 0f;
			ContentCarouselItem currentCarouselHolder = _currentCarouselHolder;
			_currentCarouselHolder = _nextCarouselHolder;
			_nextCarouselHolder = currentCarouselHolder;
			if (reverse)
			{
				_currentPageIndex--;
				if (_currentPageIndex < 0)
				{
					_currentPageIndex = _carouselDataList.Count - 1;
				}
				_rotatePlayableDirector.Stop();
				_rotateReversePlayableDirector.Stop();
				SetupSlides();
				SetupPageMarkers();
				_rotateReversePlayableDirector.Play();
			}
			else
			{
				_currentPageIndex++;
				if (_currentPageIndex >= _carouselDataList.Count)
				{
					_currentPageIndex = 0;
				}
				_rotatePlayableDirector.Stop();
				_rotateReversePlayableDirector.Stop();
				SetupSlides();
				SetupPageMarkers();
				_rotatePlayableDirector.Play();
			}
		}

		private bool ShouldShowOnPlatform(CarouselContentDefinition.Platform currentPlatform, List<CarouselContentDefinition.Platform> onlyShowOn)
		{
			if (onlyShowOn == null || onlyShowOn.Count == 0)
			{
				return true;
			}
			foreach (CarouselContentDefinition.Platform item in onlyShowOn)
			{
				if (currentPlatform == item)
				{
					return true;
				}
			}
			return false;
		}

		private void SetupSlides()
		{
			_nextCarouselHolder.Setup(_carouselDataList[_currentPageIndex], _tipsList);
			_carouselDataList[_currentPageIndex].Count++;
			_currentCarouselHolder.SetInteractable(interactable: false);
			_nextCarouselHolder.SetInteractable(interactable: true);
			_rotatePlayableDirector.SetGenericBinding(_carouselHolderPlayableBindingA.sourceObject, _currentCarouselHolder.gameObject);
			_rotatePlayableDirector.SetGenericBinding(_carouselHolderPlayableBindingB.sourceObject, _nextCarouselHolder.gameObject);
			_rotateReversePlayableDirector.SetGenericBinding(_carouselHolderPlayableReverseBindingA.sourceObject, _currentCarouselHolder.gameObject);
			_rotateReversePlayableDirector.SetGenericBinding(_carouselHolderPlayableReverseBindingB.sourceObject, _nextCarouselHolder.gameObject);
		}

		private void SetupPageMarkers()
		{
			GameObjectUtils.SetActive(_pageMarkerContainer, _pageMarkers.Count > 1);
			for (int i = 0; i < _pageMarkers.Count; i++)
			{
				_pageMarkers[i].color = ((_currentPageIndex == i) ? _pageMarkerOnColour : _pageMarkerOffColour);
			}
		}

		private void OnLeftArrowPressed()
		{
			TriggerNextCarouselSlide(reverse: true);
		}

		private void OnRightArrowPressed()
		{
			TriggerNextCarouselSlide(reverse: false);
		}

		private void OnCarousalHolderSelected(Data selectedData)
		{
			if (selectedData != null && OnlineManager.IsInitializedAndLoggedOn())
			{
				if (selectedData.ContentDefinition != null && !selectedData.ContentDefinition.ClickUrl.IsNullOrEmpty())
				{
					ExtraContentMenu.ShowBrowser(null, _analyticsManager, _messageBox, selectedData.ContentDefinition.ClickUrl);
				}
				else if (selectedData.DLCItem != null)
				{
					ExtraContentMenu.ShowBrowser(selectedData.DLCItem, _analyticsManager, _messageBox);
				}
			}
		}
	}
}
