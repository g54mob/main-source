using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorValue<T>
	{
		private T ANBAqIHlmmFDTgvFhTtNDlJplxeD;

		private bool iWQQEAUAvrUtQddoPGBMibUjfBqN;

		public bool isSet => iWQQEAUAvrUtQddoPGBMibUjfBqN;

		public T value
		{
			get
			{
				return ANBAqIHlmmFDTgvFhTtNDlJplxeD;
			}
			set
			{
				ANBAqIHlmmFDTgvFhTtNDlJplxeD = value;
				iWQQEAUAvrUtQddoPGBMibUjfBqN = true;
			}
		}

		public bool SetIfChanged(T value)
		{
			if (!iWQQEAUAvrUtQddoPGBMibUjfBqN)
			{
				this.value = value;
				return false;
			}
			if (!EqualityComparer<T>.Default.Equals(ANBAqIHlmmFDTgvFhTtNDlJplxeD, value))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			iWQQEAUAvrUtQddoPGBMibUjfBqN = false;
			ANBAqIHlmmFDTgvFhTtNDlJplxeD = default(T);
		}
	}
}
