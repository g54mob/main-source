using System.ComponentModel;

namespace Rewired.Utils.Classes
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public abstract class CodeHelper
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return 0;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return null;
		}
	}
}
