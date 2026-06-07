using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker nJuEiTUiNegAMDarxojpdgDdTGi;

			private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

			public Wrapper(T instance)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
			}

			public void Dispose()
			{
			}

			~Wrapper()
			{
			}

			protected virtual void Dispose(bool disposing)
			{
			}
		}

		private static ObjectInstanceTracker iyjhAIiEQFGydRvfLhBrkesaltbL;

		private readonly Dictionary<uint, object> uARMcJaIxvJvGooeUSfHpVJMaZI;

		private readonly object lCKLjXIjgygcAZvEOYvtFygDeVi;

		private uint cNRIeLNckZanSygNkCvjDeyXHvyG;

		private int SuyafVHJxmwFeVDiwIkbrjLzUIhP;

		private bool TAfHVrYTocAwgawmDrxaHiccqMfk;

		public static ObjectInstanceTracker Default => null;

		public uint Register(object instance)
		{
			return 0u;
		}

		public void Unregister(uint instanceId)
		{
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			instance = null;
			return false;
		}

		public void Dispose()
		{
		}

		private void oQMoaBcFsGYTuYwuqNRBUiNwGWs(bool P_0)
		{
		}

		~ObjectInstanceTracker()
		{
		}
	}
}
