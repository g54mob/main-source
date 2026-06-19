using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> JlDFqeAugqwuUjLhzNYqlbEhiFiHb;

		private readonly List<T> svuQUSqsIRSvBNZROQKkgvzIopNx = new List<T>();

		private bool CvmyBtCMWPaOkZhvsNwQZwdRORFK;

		public bool isSet => CvmyBtCMWPaOkZhvsNwQZwdRORFK;

		public IList<T> value
		{
			get
			{
				return JlDFqeAugqwuUjLhzNYqlbEhiFiHb;
			}
			set
			{
				JlDFqeAugqwuUjLhzNYqlbEhiFiHb = value;
				CvmyBtCMWPaOkZhvsNwQZwdRORFK = true;
				svuQUSqsIRSvBNZROQKkgvzIopNx.Clear();
				if (JlDFqeAugqwuUjLhzNYqlbEhiFiHb != null)
				{
					svuQUSqsIRSvBNZROQKkgvzIopNx.AddRange(JlDFqeAugqwuUjLhzNYqlbEhiFiHb);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!CvmyBtCMWPaOkZhvsNwQZwdRORFK)
			{
				this.value = value;
				return false;
			}
			if (JlDFqeAugqwuUjLhzNYqlbEhiFiHb != value)
			{
				this.value = value;
				return true;
			}
			if (!oocJyjWbxoMVplqNSAOKOFAigjgt(value, svuQUSqsIRSvBNZROQKkgvzIopNx))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			CvmyBtCMWPaOkZhvsNwQZwdRORFK = false;
			JlDFqeAugqwuUjLhzNYqlbEhiFiHb = null;
			svuQUSqsIRSvBNZROQKkgvzIopNx.Clear();
		}

		private static bool oocJyjWbxoMVplqNSAOKOFAigjgt(IList<T> P_0, IList<T> P_1)
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
