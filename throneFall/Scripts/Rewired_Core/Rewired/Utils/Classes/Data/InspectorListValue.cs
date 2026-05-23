using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InspectorListValue<T>
	{
		private IList<T> wOpkLFKSTktpzNiQCGrwAkfoZAhoA;

		private readonly List<T> JYYwvjUxpLCaeRDqjUbylcQZGoEbA = new List<T>();

		private bool leERgAkYxPSDHVdSRYDUSPEAuZOu;

		public bool isSet => leERgAkYxPSDHVdSRYDUSPEAuZOu;

		public IList<T> value
		{
			get
			{
				return wOpkLFKSTktpzNiQCGrwAkfoZAhoA;
			}
			set
			{
				wOpkLFKSTktpzNiQCGrwAkfoZAhoA = value;
				leERgAkYxPSDHVdSRYDUSPEAuZOu = true;
				JYYwvjUxpLCaeRDqjUbylcQZGoEbA.Clear();
				if (wOpkLFKSTktpzNiQCGrwAkfoZAhoA != null)
				{
					JYYwvjUxpLCaeRDqjUbylcQZGoEbA.AddRange(wOpkLFKSTktpzNiQCGrwAkfoZAhoA);
				}
			}
		}

		public bool SetIfChanged(IList<T> value)
		{
			if (!leERgAkYxPSDHVdSRYDUSPEAuZOu)
			{
				this.value = value;
				return false;
			}
			if (wOpkLFKSTktpzNiQCGrwAkfoZAhoA != value)
			{
				this.value = value;
				return true;
			}
			if (!XdKyfCgfUsFPAfGipvxGJlldySjG(value, JYYwvjUxpLCaeRDqjUbylcQZGoEbA))
			{
				this.value = value;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			leERgAkYxPSDHVdSRYDUSPEAuZOu = false;
			wOpkLFKSTktpzNiQCGrwAkfoZAhoA = null;
			JYYwvjUxpLCaeRDqjUbylcQZGoEbA.Clear();
		}

		private static bool XdKyfCgfUsFPAfGipvxGJlldySjG(IList<T> P_0, IList<T> P_1)
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
