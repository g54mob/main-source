using System.ComponentModel;

namespace Moq
{
	public enum DefaultValue
	{
		Empty = 0,
		Mock = 1,
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Custom = 2
	}
}
