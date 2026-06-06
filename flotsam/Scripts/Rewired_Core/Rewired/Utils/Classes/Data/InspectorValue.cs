using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T CSBAtJhLRuHPhLhHmUrmMcvQwRuj;

		private bool etESzXyXOnWyiSMwYDurfKrKSPad;

		public bool isSet => etESzXyXOnWyiSMwYDurfKrKSPad;

		public T value
		{
			get
			{
				return CSBAtJhLRuHPhLhHmUrmMcvQwRuj;
			}
			set
			{
				CSBAtJhLRuHPhLhHmUrmMcvQwRuj = value;
				etESzXyXOnWyiSMwYDurfKrKSPad = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!etESzXyXOnWyiSMwYDurfKrKSPad)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(CSBAtJhLRuHPhLhHmUrmMcvQwRuj, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			etESzXyXOnWyiSMwYDurfKrKSPad = false;
			CSBAtJhLRuHPhLhHmUrmMcvQwRuj = default(T);
		}
	}
}
