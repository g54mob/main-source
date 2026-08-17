using System.Runtime.InteropServices;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)0, Size = 1)]
public struct UniTaskVoid
{
	public void Forget()
	{
	}
}
