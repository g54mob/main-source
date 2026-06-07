using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T lettOrzMQsIGsyBGUbgHMlIqLorO;

		private bool TxsrTtyLKlVpvxpHgljGdEpmOshm;

		public bool isSet => TxsrTtyLKlVpvxpHgljGdEpmOshm;

		public T value
		{
			get
			{
				return lettOrzMQsIGsyBGUbgHMlIqLorO;
			}
			set
			{
				lettOrzMQsIGsyBGUbgHMlIqLorO = value;
				TxsrTtyLKlVpvxpHgljGdEpmOshm = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!TxsrTtyLKlVpvxpHgljGdEpmOshm)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(lettOrzMQsIGsyBGUbgHMlIqLorO, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			TxsrTtyLKlVpvxpHgljGdEpmOshm = false;
			lettOrzMQsIGsyBGUbgHMlIqLorO = default(T);
		}
	}
}
