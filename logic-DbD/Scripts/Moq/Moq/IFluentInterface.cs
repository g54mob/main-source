using System;
using System.ComponentModel;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IFluentInterface
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		new Type GetType();

		[EditorBrowsable(EditorBrowsableState.Never)]
		new int GetHashCode();

		[EditorBrowsable(EditorBrowsableState.Never)]
		new string ToString();

		[EditorBrowsable(EditorBrowsableState.Never)]
		new bool Equals(object obj);
	}
}
