using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public static class UiUtility
	{
		private sealed class _003CRebuildHorizontalOrVerticalLayoutGroupsNextFrame_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<HorizontalOrVerticalLayoutGroup> layoutGroupsToUpdate;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CRebuildHorizontalOrVerticalLayoutGroupsNextFrame_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (isWaitingToRebuildLayoutGroup)
					{
						return false;
					}
					isWaitingToRebuildLayoutGroup = true;
					_003C_003E2__current = new WaitForEndOfFrame();
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(layoutGroupsToUpdate);
					isWaitingToRebuildLayoutGroup = false;
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private static bool isWaitingToRebuildLayoutGroup;

		internal static void RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(List<HorizontalOrVerticalLayoutGroup> horizontalOrVerticalLayoutGroup)
		{
			RebuildHorizontalOrVerticalLayoutGroups(horizontalOrVerticalLayoutGroup);
			RebuildCanvas();
		}

		internal static void RebuildHorizontalOrVerticalLayoutGroup(HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup)
		{
			if ((bool)horizontalOrVerticalLayoutGroup)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalOrVerticalLayoutGroup.GetComponent<RectTransform>());
				LayoutRebuilder.MarkLayoutForRebuild(horizontalOrVerticalLayoutGroup.GetComponent<RectTransform>());
			}
		}

		internal static void RebuildHorizontalOrVerticalLayoutGroups(List<HorizontalOrVerticalLayoutGroup> horizontalOrVerticalLayoutGroups)
		{
			foreach (HorizontalOrVerticalLayoutGroup horizontalOrVerticalLayoutGroup in horizontalOrVerticalLayoutGroups)
			{
				RebuildHorizontalOrVerticalLayoutGroup(horizontalOrVerticalLayoutGroup);
			}
		}

		internal static IEnumerator RebuildHorizontalOrVerticalLayoutGroupsNextFrame(List<HorizontalOrVerticalLayoutGroup> layoutGroupsToUpdate)
		{
			return new _003CRebuildHorizontalOrVerticalLayoutGroupsNextFrame_003Ed__5(0)
			{
				layoutGroupsToUpdate = layoutGroupsToUpdate
			};
		}

		internal static void RebuildCanvas()
		{
			Canvas.ForceUpdateCanvases();
		}
	}
}
