using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> YZxUdzxmklZNPuQQfDdyVZJzmbxt;

		private readonly List<T> DDNbnpgcvfDZOSJmJhsTxDPxKIumA = new List<T>();

		private bool lbwUixkqUlSFSizAloKUszfYPccf;

		public bool isSet => lbwUixkqUlSFSizAloKUszfYPccf;

		public IList<T> value
		{
			get
			{
				return YZxUdzxmklZNPuQQfDdyVZJzmbxt;
			}
			set
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = value;
				lbwUixkqUlSFSizAloKUszfYPccf = true;
				DDNbnpgcvfDZOSJmJhsTxDPxKIumA.Clear();
				if (YZxUdzxmklZNPuQQfDdyVZJzmbxt != null)
				{
					DDNbnpgcvfDZOSJmJhsTxDPxKIumA.AddRange(YZxUdzxmklZNPuQQfDdyVZJzmbxt);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!lbwUixkqUlSFSizAloKUszfYPccf)
			{
				this.value = value;
				return false;
			}
			if (YZxUdzxmklZNPuQQfDdyVZJzmbxt != value)
			{
				this.value = value;
				return true;
			}
			if (!UBYHlLddYIgTpGuniOdbQfUrbkLWb(value, DDNbnpgcvfDZOSJmJhsTxDPxKIumA))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			lbwUixkqUlSFSizAloKUszfYPccf = false;
			YZxUdzxmklZNPuQQfDdyVZJzmbxt = null;
			DDNbnpgcvfDZOSJmJhsTxDPxKIumA.Clear();
		}

		private static bool UBYHlLddYIgTpGuniOdbQfUrbkLWb(IList<T> P_0, IList<T> P_1)
		{
			if (P_0 == P_1)
			{
				return true;
			}
			if (P_0 == null != (P_1 == null))
			{
				return false;
			}
			if (P_0.Count != P_1.Count)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (!EqualityComparer<T>.Default.Equals(P_0[i], P_1[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
