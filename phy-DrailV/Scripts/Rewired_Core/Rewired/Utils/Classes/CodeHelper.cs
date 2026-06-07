using System.ComponentModel;

namespace Rewired.Utils.Classes
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class CodeHelper
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
