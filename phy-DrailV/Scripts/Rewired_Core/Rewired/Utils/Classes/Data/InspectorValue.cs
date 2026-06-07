using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T YZxUdzxmklZNPuQQfDdyVZJzmbxt;

		private bool lbwUixkqUlSFSizAloKUszfYPccf;

		public bool isSet => lbwUixkqUlSFSizAloKUszfYPccf;

		public T value
		{
			get
			{
				return YZxUdzxmklZNPuQQfDdyVZJzmbxt;
			}
			set
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = value;
				lbwUixkqUlSFSizAloKUszfYPccf = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!lbwUixkqUlSFSizAloKUszfYPccf)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(YZxUdzxmklZNPuQQfDdyVZJzmbxt, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			lbwUixkqUlSFSizAloKUszfYPccf = false;
			YZxUdzxmklZNPuQQfDdyVZJzmbxt = default(T);
		}
	}
}
