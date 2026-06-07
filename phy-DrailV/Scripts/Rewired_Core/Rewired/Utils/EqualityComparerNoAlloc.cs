using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		private class ESWFnltIPhtMJjdyeEFpDrsLQveEA : IEqualityComparer, IEqualityComparer<int>
		{
			private static ESWFnltIPhtMJjdyeEFpDrsLQveEA GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static ESWFnltIPhtMJjdyeEFpDrsLQveEA LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new ESWFnltIPhtMJjdyeEFpDrsLQveEA());

			public bool Equals(int x, int y)
			{
				return x == y;
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is int) || !(y is int))
				{
					return false;
				}
				return Equals((int)x, (int)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is int))
				{
					return 0;
				}
				return GetHashCode((int)obj);
			}
		}

		private class fvgdDtURldBRUTVgCfHhJuRhOgAoA : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static fvgdDtURldBRUTVgCfHhJuRhOgAoA GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static fvgdDtURldBRUTVgCfHhJuRhOgAoA LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new fvgdDtURldBRUTVgCfHhJuRhOgAoA());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is ulong) || !(y is ulong))
				{
					return false;
				}
				return Equals((ulong)x, (ulong)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return GetHashCode((ulong)obj);
			}
		}

		private class bomiLPGxnSyxsdHCPzDRLaGFetRf : IEqualityComparer, IEqualityComparer<uint>
		{
			private static bomiLPGxnSyxsdHCPzDRLaGFetRf GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static bomiLPGxnSyxsdHCPzDRLaGFetRf LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new bomiLPGxnSyxsdHCPzDRLaGFetRf());

			public bool Equals(uint x, uint y)
			{
				return x == y;
			}

			public int GetHashCode(uint obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is uint) || !(y is uint))
				{
					return false;
				}
				return Equals((uint)x, (uint)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is uint))
				{
					return 0;
				}
				return GetHashCode((uint)obj);
			}
		}

		private class MssjiksEoTYWwbGMEUWZrvRXqTyS : IEqualityComparer, IEqualityComparer<ulong>
		{
			private static MssjiksEoTYWwbGMEUWZrvRXqTyS GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static MssjiksEoTYWwbGMEUWZrvRXqTyS LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new MssjiksEoTYWwbGMEUWZrvRXqTyS());

			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is ulong) || !(y is ulong))
				{
					return false;
				}
				return Equals((ulong)x, (ulong)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return GetHashCode((ulong)obj);
			}
		}

		private class JDGACAEhARacXuMmKpXIDUENApme : IEqualityComparer, IEqualityComparer<float>
		{
			private static JDGACAEhARacXuMmKpXIDUENApme GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static JDGACAEhARacXuMmKpXIDUENApme LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new JDGACAEhARacXuMmKpXIDUENApme());

			public bool Equals(float x, float y)
			{
				return x == y;
			}

			public int GetHashCode(float obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is float) || !(y is float))
				{
					return false;
				}
				return Equals((float)x, (float)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is float))
				{
					return 0;
				}
				return GetHashCode((float)obj);
			}
		}

		private class ADfXrEiXkBbxUvjcfDfBegQcdqqU : IEqualityComparer, IEqualityComparer<double>
		{
			private static ADfXrEiXkBbxUvjcfDfBegQcdqqU GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static ADfXrEiXkBbxUvjcfDfBegQcdqqU LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new ADfXrEiXkBbxUvjcfDfBegQcdqqU());

			public bool Equals(double x, double y)
			{
				return x == y;
			}

			public int GetHashCode(double obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is double) || !(y is double))
				{
					return false;
				}
				return Equals((double)x, (double)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is double))
				{
					return 0;
				}
				return GetHashCode((double)obj);
			}
		}

		private class AjGfrzghbvbAKIcDLxXLUfLTEQzC : IEqualityComparer, IEqualityComparer<byte>
		{
			private static AjGfrzghbvbAKIcDLxXLUfLTEQzC GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static AjGfrzghbvbAKIcDLxXLUfLTEQzC LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new AjGfrzghbvbAKIcDLxXLUfLTEQzC());

			public bool Equals(byte x, byte y)
			{
				return x == y;
			}

			public int GetHashCode(byte obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is byte) || !(y is byte))
				{
					return false;
				}
				return Equals((byte)x, (byte)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is byte))
				{
					return 0;
				}
				return GetHashCode((byte)obj);
			}
		}

		private class NDwMlmodihSVIbiXMbPVIdlvMwfG : IEqualityComparer, IEqualityComparer<sbyte>
		{
			private static NDwMlmodihSVIbiXMbPVIdlvMwfG GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static NDwMlmodihSVIbiXMbPVIdlvMwfG LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new NDwMlmodihSVIbiXMbPVIdlvMwfG());

			public bool Equals(sbyte x, sbyte y)
			{
				return x == y;
			}

			public int GetHashCode(sbyte obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is sbyte) || !(y is sbyte))
				{
					return false;
				}
				return Equals((sbyte)x, (sbyte)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is sbyte))
				{
					return 0;
				}
				return GetHashCode((sbyte)obj);
			}
		}

		private class mkrraNNbeodCQCfCMqJHnUHyNNWY : IEqualityComparer, IEqualityComparer<bool>
		{
			private static mkrraNNbeodCQCfCMqJHnUHyNNWY GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static mkrraNNbeodCQCfCMqJHnUHyNNWY LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new mkrraNNbeodCQCfCMqJHnUHyNNWY());

			public bool Equals(bool x, bool y)
			{
				return x == y;
			}

			public int GetHashCode(bool obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is bool) || !(y is bool))
				{
					return false;
				}
				return Equals((bool)x, (bool)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is bool))
				{
					return 0;
				}
				return GetHashCode((bool)obj);
			}
		}

		private class idwEJcbGUailSFRxOOgZkBkTeehiA : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			private static idwEJcbGUailSFRxOOgZkBkTeehiA GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static idwEJcbGUailSFRxOOgZkBkTeehiA LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new idwEJcbGUailSFRxOOgZkBkTeehiA());

			public bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			public int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is IntPtr) || !(y is IntPtr))
				{
					return false;
				}
				return Equals((IntPtr)x, (IntPtr)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is IntPtr))
				{
					return 0;
				}
				return GetHashCode((IntPtr)obj);
			}
		}

		private class ahzztMMaADDYYTUEibdcRKuZoiFG : IEqualityComparer, IEqualityComparer<Guid>
		{
			private static ahzztMMaADDYYTUEibdcRKuZoiFG GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static ahzztMMaADDYYTUEibdcRKuZoiFG LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new ahzztMMaADDYYTUEibdcRKuZoiFG());

			public bool Equals(Guid x, Guid y)
			{
				return x == y;
			}

			public int GetHashCode(Guid obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is Guid) || !(y is Guid))
				{
					return false;
				}
				return Equals((Guid)x, (Guid)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is Guid))
				{
					return 0;
				}
				return GetHashCode((Guid)obj);
			}
		}

		private class VuJipXLPzEdadqyqKEsZnkebBczHA : IEqualityComparer, IEqualityComparer<Bytes20>
		{
			private static VuJipXLPzEdadqyqKEsZnkebBczHA GqDALwgguyETOeBMlCEepDjQNfbvA;

			public static VuJipXLPzEdadqyqKEsZnkebBczHA LSiMwhYpzbixHWLRsspDEMspSxKF => GqDALwgguyETOeBMlCEepDjQNfbvA ?? (GqDALwgguyETOeBMlCEepDjQNfbvA = new VuJipXLPzEdadqyqKEsZnkebBczHA());

			public bool Equals(Bytes20 x, Bytes20 y)
			{
				return x == y;
			}

			public int GetHashCode(Bytes20 obj)
			{
				return obj.GetHashCode();
			}

			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return true;
					}
					return false;
				}
				if (!(x is Bytes20) || !(y is Bytes20))
				{
					return false;
				}
				return Equals((Bytes20)x, (Bytes20)y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is Bytes20))
				{
					return 0;
				}
				return GetHashCode((Bytes20)obj);
			}
		}

		public static IEqualityComparer<T> Default
		{
			get
			{
				Type typeFromHandle = typeof(T);
				if ((object)typeFromHandle == typeof(int))
				{
					return (IEqualityComparer<T>)ESWFnltIPhtMJjdyeEFpDrsLQveEA.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(long))
				{
					return (IEqualityComparer<T>)fvgdDtURldBRUTVgCfHhJuRhOgAoA.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(uint))
				{
					return (IEqualityComparer<T>)bomiLPGxnSyxsdHCPzDRLaGFetRf.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(ulong))
				{
					return (IEqualityComparer<T>)MssjiksEoTYWwbGMEUWZrvRXqTyS.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(float))
				{
					return (IEqualityComparer<T>)JDGACAEhARacXuMmKpXIDUENApme.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(double))
				{
					return (IEqualityComparer<T>)ADfXrEiXkBbxUvjcfDfBegQcdqqU.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(byte))
				{
					return (IEqualityComparer<T>)AjGfrzghbvbAKIcDLxXLUfLTEQzC.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(sbyte))
				{
					return (IEqualityComparer<T>)NDwMlmodihSVIbiXMbPVIdlvMwfG.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(bool))
				{
					return (IEqualityComparer<T>)mkrraNNbeodCQCfCMqJHnUHyNNWY.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(IntPtr))
				{
					return (IEqualityComparer<T>)idwEJcbGUailSFRxOOgZkBkTeehiA.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(Guid))
				{
					return (IEqualityComparer<T>)ahzztMMaADDYYTUEibdcRKuZoiFG.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				if ((object)typeFromHandle == typeof(Bytes20))
				{
					return (IEqualityComparer<T>)VuJipXLPzEdadqyqKEsZnkebBczHA.LSiMwhYpzbixHWLRsspDEMspSxKF;
				}
				return EqualityComparer<T>.Default;
			}
		}
	}
}
