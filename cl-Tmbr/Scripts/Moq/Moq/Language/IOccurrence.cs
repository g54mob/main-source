using System;
using System.ComponentModel;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IOccurrence : IFluentInterface
	{
		[Obsolete("Use 'mock.Verify(call, Times.AtMostOnce)' or 'setup.Verifiable(Times.AtMostOnce)' instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IVerifies AtMostOnce();

		[Obsolete("Use 'mock.Verify(call, Times.AtMost(callCount))' or 'setup.Verifiable(Times.AtMost(callCount))' instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IVerifies AtMost(int callCount);
	}
}
