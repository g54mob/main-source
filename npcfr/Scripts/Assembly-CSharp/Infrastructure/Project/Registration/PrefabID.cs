using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Infrastructure.Project.Registration
{
	[Serializable]
	public class PrefabID
	{
		[field: SerializeField]
		public string Namespace { get; private set; }

		[field: SerializeField]
		public string Name { get; private set; }

		public string swt
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public PrefabID(PrefabID id)
		{
		}

		public PrefabID(string @namespace, string name)
		{
		}

		public PrefabID(string id)
		{
		}

		public void irp()
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool irq(PrefabID a)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		[SpecialName]
		public static bool irr(PrefabID a, PrefabID b)
		{
			return false;
		}

		[SpecialName]
		public static bool irs(PrefabID a, PrefabID b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		private static string irt(string a, string b)
		{
			return null;
		}
	}
}
