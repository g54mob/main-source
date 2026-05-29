using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSelect")]
	[AddComponentMenu("Lean/Common/Lean Select")]
	public class LeanSelect : MonoBehaviour
	{
		[Serializable]
		public class LeanSelectableEvent : UnityEvent<LeanSelectable>
		{
		}

		public enum ReselectType
		{
			KeepSelected = 0,
			Deselect = 1,
			DeselectAndSelect = 2,
			SelectAgain = 3
		}

		public enum LimitType
		{
			Unlimited = 0,
			StopAtMax = 1,
			DeselectFirst = 2
		}

		public static LinkedList<LeanSelect> Instances;

		[NonSerialized]
		private LinkedListNode<LeanSelect> instancesNode;

		[SerializeField]
		private bool deselectWithNothing;

		[SerializeField]
		private LimitType limit;

		[SerializeField]
		private int maxSelectables;

		[SerializeField]
		private ReselectType reselect;

		[SerializeField]
		protected List<LeanSelectable> selectables;

		[SerializeField]
		private LeanSelectableEvent onSelected;

		[SerializeField]
		private LeanSelectableEvent onDeselected;

		[SerializeField]
		private UnityEvent onNothing;

		public bool DeselectWithNothing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LimitType Limit
		{
			get
			{
				return default(LimitType);
			}
			set
			{
			}
		}

		public int MaxSelectables
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ReselectType Reselect
		{
			get
			{
				return default(ReselectType);
			}
			set
			{
			}
		}

		public List<LeanSelectable> Selectables => null;

		public LeanSelectableEvent OnSelected => null;

		public LeanSelectableEvent OnDeselected => null;

		public UnityEvent OnNothing => null;

		public static event Action<LeanSelect, LeanSelectable> OnAnySelected
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

		public static event Action<LeanSelect, LeanSelectable> OnAnyDeselected
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

		public bool IsSelected(LeanSelectable selectable)
		{
			return false;
		}

		public void Select(LeanSelectable selectable)
		{
		}

		public void Deselect(LeanSelectable selectable)
		{
		}

		protected bool TrySelect(LeanSelectable selectable)
		{
			return false;
		}

		private bool TryReselect(LeanSelectable selectable)
		{
			return false;
		}

		protected bool TryDeselect(LeanSelectable selectable)
		{
			return false;
		}

		protected bool TryDeselect(int index)
		{
			return false;
		}

		[ContextMenu("Deselect All")]
		public void DeselectAll()
		{
		}

		public void Cull(int maxCount)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
