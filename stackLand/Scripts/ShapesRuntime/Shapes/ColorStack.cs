using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ColorStack : IDisposable
	{
		private static readonly Stack<Color> colors = new Stack<Color>();

		internal static void Push(Color prevState)
		{
			colors.Push(prevState);
		}

		internal static void Pop()
		{
			try
			{
				Draw.Color = colors.Pop();
			}
			catch (Exception ex)
			{
				Debug.LogError("You are popping more Color stacks than you are pushing. error: " + ex.Message);
			}
		}

		internal ColorStack(Color mtx)
		{
			colors.Push(mtx);
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
