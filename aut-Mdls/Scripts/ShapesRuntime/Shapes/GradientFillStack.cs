using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct GradientFillStack : IDisposable
	{
		private static readonly Stack<(bool, GradientFill)> gradients = new Stack<(bool, GradientFill)>();

		internal static void Push(bool prevOn, GradientFill prevState)
		{
			gradients.Push((prevOn, prevState));
		}

		internal static void Pop()
		{
			try
			{
				(Draw.UseGradientFill, Draw.GradientFill) = gradients.Pop();
			}
			catch (Exception ex)
			{
				Debug.LogError("You are popping more GradientFill stacks than you are pushing. error: " + ex.Message);
			}
		}

		internal GradientFillStack(bool on, GradientFill gradient)
		{
			gradients.Push((on, gradient));
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
