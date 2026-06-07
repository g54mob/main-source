using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Data;
using InventorySystem;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Favors
{
	public class FavorBoardUIController : MonoBehaviour, IUIPanel
	{
		private class PendingPortrait
		{
			public string NpcId;

			public string HouseId;

			public VisualElement PortraitElement;

			public VisualElement SpinnerElement;

			public float RotationAngle;
		}

		[CompilerGenerated]
		private sealed class _003CDelayedRefresh_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FavorBoardUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedRefresh_003Ed__60(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("UI References")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private VisualTreeAsset favorCardTemplate;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement root;

		private VisualElement container;

		private VisualElement boardRoot;

		private bool isOpen;

		private string currentFilter;

		private string currentSort;

		private Label availableCountLabel;

		private Label myFavorsCountLabel;

		private VisualElement myFavorsSection;

		private VisualElement myFavorsContainer;

		private Label myFavorsBadgeCount;

		private VisualElement availableFavorsContainer;

		private Label availableSectionCount;

		private VisualElement emptyState;

		private Label refreshTimerLabel;

		private float lastTimerValue;

		private bool wasTimerAtZero;

		private bool isSubscribedToFavorManager;

		private static Dictionary<string, NPCProfile> _cachedProfilesByNpcId;

		private List<PendingPortrait> pendingPortraits;

		private const float SPINNER_ROTATION_SPEED = 360f;

		private Button filterAvailableBtn;

		private Button filterMineBtn;

		private Button sortAllBtn;

		private Button sortFurnitureBtn;

		private Button sortMaterialsBtn;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void TrySubscribeToFavorManager()
		{
		}

		private void UnsubscribeFromFavorManager()
		{
		}

		private void OnFavorsChanged()
		{
		}

		private void InitializeUI()
		{
		}

		private void SetupFilterButtons()
		{
		}

		private void SetupSortButtons()
		{
		}

		public void OpenBoard()
		{
		}

		public void CloseBoard()
		{
		}

		public void Toggle()
		{
		}

		private void RefreshFavorList()
		{
		}

		private void UpdateMyFavorsSection(List<FavorRequest> myFavors)
		{
		}

		private void UpdateAvailableFavorsSection(List<FavorRequest> availableFavors, List<FavorRequest> myFavors)
		{
		}

		private List<FavorRequest> SortFavors(List<FavorRequest> favors)
		{
			return null;
		}

		private void CreateFavorCard(VisualElement parent, FavorRequest favor, bool isMyFavor)
		{
		}

		private void SetFilter(string filter)
		{
		}

		private void SetSort(string sort)
		{
		}

		private void OnAcceptClicked(int favorId, VisualElement card)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedRefresh_003Ed__60))]
		private IEnumerator DelayedRefresh()
		{
			return null;
		}

		private void OnTrackClicked(int favorId, Button trackBtn)
		{
		}

		private void OnClearActiveClicked()
		{
		}

		private NPCProfile FindNPCProfile(string npcId, string houseId = null)
		{
			return null;
		}

		private void Log(string message)
		{
		}

		private void ShowItemTooltip(Item item, int quantity)
		{
		}

		private void HideItemTooltip()
		{
		}

		private void UpdatePendingPortraits()
		{
		}

		private void ClearPendingPortraits()
		{
		}
	}
}
