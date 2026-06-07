using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> VKXFmjOfIknieinRiqVJchGEMMgX;

		private readonly List<T> qziUIXESkFqljeYpHqLTxobpAoBKA = new List<T>();

		private bool MqkPJkyKwLJSYcHZrBbbWFxwlJZt;

		public bool isSet => MqkPJkyKwLJSYcHZrBbbWFxwlJZt;

		public IList<T> value
		{
			get
			{
				return VKXFmjOfIknieinRiqVJchGEMMgX;
			}
			set
			{
				VKXFmjOfIknieinRiqVJchGEMMgX = value;
				MqkPJkyKwLJSYcHZrBbbWFxwlJZt = true;
				qziUIXESkFqljeYpHqLTxobpAoBKA.Clear();
				if (VKXFmjOfIknieinRiqVJchGEMMgX != null)
				{
					qziUIXESkFqljeYpHqLTxobpAoBKA.AddRange(VKXFmjOfIknieinRiqVJchGEMMgX);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!MqkPJkyKwLJSYcHZrBbbWFxwlJZt)
			{
				this.value = value;
				return false;
			}
			if (VKXFmjOfIknieinRiqVJchGEMMgX != value)
			{
				this.value = value;
				return true;
			}
			if (!oRgZdegBVqKGDQDjXJHvBgORqgis(value, qziUIXESkFqljeYpHqLTxobpAoBKA))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			MqkPJkyKwLJSYcHZrBbbWFxwlJZt = false;
			VKXFmjOfIknieinRiqVJchGEMMgX = null;
			qziUIXESkFqljeYpHqLTxobpAoBKA.Clear();
		}

		private static bool oRgZdegBVqKGDQDjXJHvBgORqgis(IList<T> P_0, IList<T> P_1)
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
