using System.ComponentModel;

namespace Rewired.Utils.Classes
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public abstract class CodeHelper
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
