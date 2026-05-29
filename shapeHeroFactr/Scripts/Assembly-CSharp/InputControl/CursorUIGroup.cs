using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace InputControl
{
	public class CursorUIGroup : PadInputBase
	{
		public enum CursorMoveType
		{
			None = 0,
			Vertical = 1,
			Horizontal = 2,
			Grid = 3,
			Nearest = 4
		}

		public enum DirectionType
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3
		}

		[SerializeField]
		private CursorMoveType _cursorMoveType;

		[SerializeField]
		private bool _isInheritancePos;

		[SerializeField]
		private int _row;

		[SerializeField]
		private int _column;

		[SerializeField]
		private bool _isLoop;

		[SerializeField]
		private float alignmentWeight;

		[SerializeField]
		private float distanceWeight;

		[SerializeField]
		private bool _autoRefreshItemsOnSelect;

		[SerializeField]
		private bool _resetCursorOnCall;

		[SerializeField]
		private bool _excludeChild;

		[SerializeField]
		private bool _isExcludeInactiveInHierarchy;

		[FormerlySerializedAs("_cursorUIItems")]
		public List<CursorUIBase> CursorUIItems;

		private int _itemCount;

		private int[] _activeIndices;

		[SerializeField]
		private CursorUIBase _initialCursorUIBase;

		public UnityEvent RightOverFlow;

		public UnityEvent LeftOverFlow;

		public UnityEvent UpOverFlow;

		public UnityEvent DownOverFlow;

		public UnityEvent AllApplicableCancel;

		public UnityEvent AllApplicableSwitch;

		public UnityEvent AllApplicableRightTrigger;

		public UnityEvent AllApplicableLeftTrigger;

		public UnityEvent AllApplicableSelect;

		public UnityEvent AllApplicableLeftShoulder;

		public UnityEvent AllApplicableRightShoulder;

		public UnityEvent AllApplicableStart;

		public UnityEvent AllApplicableRightStickPush;

		public UnityEvent OnSelectItemEvent;

		public UnityEvent OnDecideItemEvent;

		public UnityEvent OnSelectGroupEvent;

		public UnityEvent OnDeselectGroupEvent;

		private bool _isOverride;

		private int _currentIndex;

		private MonoBehaviour _parent;

		private PadInputConfigure _padInputConfigure;

		private Dictionary<CursorUIBase, int> _itemToIndexMap;

		private static readonly Vector2[] DirectionVectors;

		private Vector2[] _cachedPositions;

		private float[] _cachedScores;

		public CursorUIBase InitialCursorUIBase => null;

		public int CurrentIndex => 0;

		public event Action OnRightOverFlow
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnLeftOverFlow
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnUpOverFlow
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnDownOverFlow
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal void InitializeConfigure(PadInputConfigure padInputConfigure, UnityAction allApplicableCancel, UnityAction allApplicableSwitch, UnityAction allApplicableRightTrigger, UnityAction allApplicableLeftTrigger, UnityAction allApplicableLeftShoulder, UnityAction allApplicableRightShoulder, UnityAction allApplicableSelect, UnityAction allApplicableStart, UnityAction allApplicableRightStickPush)
		{
		}

		private void UpdateCaches()
		{
		}

		private void RefreshActiveIndices()
		{
		}

		private int GetInitialCursorIndex()
		{
			return 0;
		}

		private void ReattachAllApplicableEvents(UnityAction allApplicableCancel, UnityAction allApplicableSwitch, UnityAction allApplicableRightTrigger, UnityAction allApplicableLeftTrigger, UnityAction allApplicableLeftShoulder, UnityAction allApplicableRightShoulder, UnityAction allApplicableSelect, UnityAction allApplicableStart, UnityAction allApplicableRightStickPush)
		{
		}

		private void SetupNavigationByType(CursorMoveType cursorMoveType)
		{
		}

		private void BindOverflowEvents()
		{
		}

		public void BindCommonItemEvents()
		{
		}

		public void SetCursorUIItems(List<CursorUIBase> cursorUIItems, bool fixPos = false)
		{
		}

		private void RecalculateGridIfNeeded()
		{
		}

		public void SetAutoListItem()
		{
		}

		public void SetAutoIncludeInactiveInHierarchyListItem()
		{
		}

		internal void OnSelect(MonoBehaviour parent, bool isOverride = false)
		{
		}

		internal void OnDeselect(MonoBehaviour parent)
		{
		}

		internal void SetInput(PadInputSetting input)
		{
		}

		public void SetSimpleVerticalList(bool isLoop = true)
		{
		}

		public void SetSimpleHorizontalList(bool isLoop = true)
		{
		}

		public void SetSimpleGridList(int row, int column, bool isLoop = true)
		{
		}

		public void SetSingleObject()
		{
		}

		public void ConfigureNavigation(int? up = null, int? down = null, int? left = null, int? right = null, bool isLoop = true)
		{
		}

		private void ConfigureCommonNavigation()
		{
		}

		public CursorUIBase GetCurrentCursorItem()
		{
			return null;
		}

		private void UpdateSelection(InputAction.CallbackContext context, DirectionType directionType, bool isLoop = true)
		{
		}

		private int GetNextIndexGrid(int currentIndex, DirectionType directionType, bool isLoop)
		{
			return 0;
		}

		private int GetNextIndexList(int currentIndex, DirectionType directionType, bool isLoop)
		{
			return 0;
		}

		private void CallOverflowEvent(DirectionType directionType)
		{
		}

		private bool IsIndexEnable(int index)
		{
			return false;
		}

		public void SetDefaultCursorPosition()
		{
		}

		private void InheritanceCursor(Transform source)
		{
		}

		public void SelectThisGroup()
		{
		}

		public void SelectThisGroup(CursorUIBase cursorUIBase)
		{
		}

		public void SelectThisGroup(bool isInheritancePos)
		{
		}

		public void SelectThisGroup(int directionType)
		{
		}

		public void SelectThisGroupFirst()
		{
		}

		public void SelectThisGroupLast()
		{
		}

		public void SelectThisGroupUp()
		{
		}

		public void SelectThisGroupDown()
		{
		}

		public void SelectThisGroupLeft()
		{
		}

		public void SelectThisGroupRight()
		{
		}

		private void OnDestroy()
		{
		}

		private void Dispose()
		{
		}

		private int FindFirstActiveIndex()
		{
			return 0;
		}

		public void SetNearestNavigation(bool isLoop = false)
		{
		}

		private void MoveNearest(DirectionType directionType)
		{
		}

		public void SelectNearGroup(int directionType)
		{
		}

		public void CurrentCursorDeselect()
		{
		}
	}
}
