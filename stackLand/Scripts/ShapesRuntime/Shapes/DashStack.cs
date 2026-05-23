using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct DashStack : IDisposable
	{
		private static readonly Stack<(bool, DashStyle)> dashes = new Stack<(bool, DashStyle)>();

		internal static void Push(bool prevOn, DashStyle prevState)
		{
			dashes.Push((prevOn, prevState));
		}

		internal static void Pop()
		{
			try
			{
				(Draw.UseDashes, Draw.DashStyle) = dashes.Pop();
			}
			catch (Exception ex)
			{
				Debug.LogError("You are popping more DashStyle stacks than you are pushing. error: " + ex.Message);
			}
		}

		internal DashStack(bool on, DashStyle dash)
		{
			dashes.Push((on, dash));
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
