using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Shapes
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct StateStack : IDisposable
	{
		internal static void Push(DrawStyle style, Matrix4x4 mtx)
		{
			StyleStack.Push(style);
			MatrixStack.Push(mtx);
		}

		internal static void Pop()
		{
			MatrixStack.Pop();
			StyleStack.Pop();
		}

		internal StateStack(DrawStyle style, Matrix4x4 mtx)
		{
			Push(style, mtx);
		}

		public void Dispose()
		{
			Pop();
		}
	}
}
