using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct MatrixStack : IDisposable
	{
		private static readonly Stack<Matrix4x4> matrices = new Stack<Matrix4x4>();

		internal static void Push(Matrix4x4 prevState)
		{
			matrices.Push(prevState);
		}

		internal static void Pop()
		{
			try
			{
				Draw.Matrix = matrices.Pop();
			}
			catch (Exception ex)
			{
				Debug.LogError("You are popping more Matrix4x4 stacks than you are pushing. error: " + ex.Message);
			}
		}

		internal MatrixStack(Matrix4x4 mtx)
		{
			matrices.Push(mtx);
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
