using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> KWkiUoVoDcWNXYQRRuPVFKTnkpFG;

		private readonly List<T> fEZYAKZrMFNrIOdEewwNCgnGUBgE = new List<T>();

		private bool PsLHTpdIxPdevOkDOfIvvgyFIfoy;

		public bool isSet => PsLHTpdIxPdevOkDOfIvvgyFIfoy;

		public IList<T> value
		{
			get
			{
				return KWkiUoVoDcWNXYQRRuPVFKTnkpFG;
			}
			set
			{
				KWkiUoVoDcWNXYQRRuPVFKTnkpFG = value;
				PsLHTpdIxPdevOkDOfIvvgyFIfoy = true;
				fEZYAKZrMFNrIOdEewwNCgnGUBgE.Clear();
				if (KWkiUoVoDcWNXYQRRuPVFKTnkpFG != null)
				{
					fEZYAKZrMFNrIOdEewwNCgnGUBgE.AddRange(KWkiUoVoDcWNXYQRRuPVFKTnkpFG);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!PsLHTpdIxPdevOkDOfIvvgyFIfoy)
			{
				this.value = value;
				return false;
			}
			if (KWkiUoVoDcWNXYQRRuPVFKTnkpFG != value)
			{
				this.value = value;
				return true;
			}
			if (!fSTCVhinGkoacVybmfwzzcPinYHtA(value, fEZYAKZrMFNrIOdEewwNCgnGUBgE))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			PsLHTpdIxPdevOkDOfIvvgyFIfoy = false;
			KWkiUoVoDcWNXYQRRuPVFKTnkpFG = null;
			fEZYAKZrMFNrIOdEewwNCgnGUBgE.Clear();
		}

		private static bool fSTCVhinGkoacVybmfwzzcPinYHtA(IList<T> P_0, IList<T> P_1)
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
