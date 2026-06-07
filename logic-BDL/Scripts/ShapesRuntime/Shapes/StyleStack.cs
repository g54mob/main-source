using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct StyleStack : IDisposable
	{
		private static readonly Stack<DrawStyle> styles = new Stack<DrawStyle>();

		internal static void Push(DrawStyle prevState)
		{
			styles.Push(prevState);
		}

		internal static void Pop()
		{
			try
			{
				Draw.style = styles.Pop();
			}
			catch (Exception ex)
			{
				Debug.LogError("You are popping more DrawStyle stacks than you are pushing. error: " + ex.Message);
			}
		}

		internal StyleStack(DrawStyle style)
		{
			styles.Push(style);
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
