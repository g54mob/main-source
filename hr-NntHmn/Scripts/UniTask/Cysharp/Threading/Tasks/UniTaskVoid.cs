using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[AsyncMethodBuilder(typeof(AsyncUniTaskVoidMethodBuilder))]
	public readonly struct UniTaskVoid
	{
		public void Forget()
		{
		}
	}
}
