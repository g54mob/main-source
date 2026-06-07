using System;
using System.Runtime.CompilerServices;
using LitMotion.Collections;
using UnityEngine;

namespace LitMotion
{
	[DisallowMultipleComponent]
	[AddComponentMenu("")]
	internal sealed class MotionHandleLinker : MonoBehaviour
	{
		private FastListCore<MotionHandle> cancelOnDestroyList;

		private FastListCore<MotionHandle> cancelOnDisableList;

		private FastListCore<MotionHandle> completeOnDisableList;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Register(MotionHandle handle, LinkBehavior linkBehaviour)
		{
			switch (linkBehaviour)
			{
			case LinkBehavior.CancelOnDestroy:
				cancelOnDestroyList.Add(handle);
				break;
			case LinkBehavior.CancelOnDisable:
				cancelOnDisableList.Add(handle);
				break;
			case LinkBehavior.CompleteOnDisable:
				completeOnDisableList.Add(handle);
				break;
			}
		}

		private void OnDisable()
		{
			Span<MotionHandle> span = cancelOnDisableList.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				ref MotionHandle reference = ref span[i];
				if (reference.IsActive())
				{
					reference.Cancel();
				}
			}
			Span<MotionHandle> span2 = completeOnDisableList.AsSpan();
			for (int j = 0; j < span2.Length; j++)
			{
				ref MotionHandle reference2 = ref span2[j];
				if (reference2.IsActive())
				{
					reference2.Complete();
				}
			}
		}

		private void OnDestroy()
		{
			Span<MotionHandle> span = cancelOnDestroyList.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				ref MotionHandle reference = ref span[i];
				if (reference.IsActive())
				{
					reference.Cancel();
				}
			}
		}
	}
}
