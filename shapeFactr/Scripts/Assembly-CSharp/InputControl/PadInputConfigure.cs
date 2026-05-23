using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace InputControl
{
	public class PadInputConfigure : MonoBehaviour
	{
		[SerializeField]
		private bool _isAutoEnable;

		[SerializeField]
		private bool _isDisableAutoInitialize;

		[SerializeField]
		private bool _isOverride;

		[SerializeField]
		private CursorUIGroup _defaultCursorUIGroup;

		[SerializeField]
		private bool _isFixCursor;

		[Header("All Applicable Events")]
		public UnityEvent AllApplicableCancel;

		public UnityEvent AllApplicableSwitch;

		public UnityEvent AllApplicableRightTrigger;

		public UnityEvent AllApplicableLeftTrigger;

		public UnityEvent AllApplicableLeftShoulder;

		public UnityEvent AllApplicableRightShoulder;

		public UnityEvent AllApplicableSelect;

		public UnityEvent AllApplicableStart;

		public UnityEvent AllApplicableRightStickPress;

		private List<CursorUIGroup> _allCursorUIGroups;

		private List<AutoCursorUIGroupSelector> _allAutoCursorUIGroupSelectors;

		private CursorUIGroup _currentCursorUIGroup;

		private CursorUIGroup _beforeCursorUIGroup;

		private bool _isInitialized;

		public CursorUIGroup CurrentCursorUIGroup => null;

		public IReadOnlyList<CursorUIGroup> AllCursorUIGroups => null;

		public event Action<CursorUIGroup> OnGroupChanged
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

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Initialize()
		{
		}

		public void Initialize(List<CursorUIGroup> externalCursorGroups)
		{
		}

		private void CommonInitialize()
		{
		}

		public void SetSelectGroup(CursorUIGroup cursorUIGroup)
		{
		}

		public void DeSelectGroup()
		{
		}

		public void SetSelectGroup()
		{
		}

		private void ResetCursor()
		{
		}
	}
}
