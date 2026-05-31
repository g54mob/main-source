using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSelectable")]
	[AddComponentMenu("Lean/Common/Lean Selectable")]
	public class LeanSelectable : MonoBehaviour
	{
		[Serializable]
		public class LeanSelectEvent : UnityEvent<LeanSelect>
		{
		}

		public static LinkedList<LeanSelectable> Instances;

		[NonSerialized]
		private LinkedListNode<LeanSelectable> instancesNode;

		[SerializeField]
		private bool selfSelected;

		[SerializeField]
		private LeanSelectEvent onSelected;

		[SerializeField]
		private LeanSelectEvent onDeselected;

		protected static List<LeanSelectable> tempSelectables;

		public bool SelfSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LeanSelectEvent OnSelected => null;

		public LeanSelectEvent OnDeselected => null;

		public int SelectedCount => 0;

		public bool IsSelected => false;

		public static int IsSelectedCount => 0;

		public static event Action<LeanSelectable> OnAnyEnabled
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

		public static event Action<LeanSelectable> OnAnyDisabled
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

		[ContextMenu("Deselect")]
		public void Deselect()
		{
		}

		public static void DeselectAll()
		{
		}

		public void InvokeOnSelected(LeanSelect select)
		{
		}

		public void InvokeOnDeslected(LeanSelect select)
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
