using System;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public class SaintsInterface<TObject, TInterface> : IWrapProp where TObject : UnityEngine.Object where TInterface : class
	{
		public TObject V { get; private set; }

		public TInterface I => V as TInterface;

		public static implicit operator TInterface(SaintsInterface<TObject, TInterface> saintsInterface)
		{
			return saintsInterface.I;
		}

		public static implicit operator TObject(SaintsInterface<TObject, TInterface> saintsInterface)
		{
			return saintsInterface.V;
		}

		public override string ToString()
		{
			return $"<Interface I={I} V={V}/>";
		}

		public override bool Equals(object obj)
		{
			if (obj is SaintsInterface<TObject, TInterface> saintsInterface)
			{
				return (object)saintsInterface.V == V;
			}
			return false;
		}

		public static bool operator ==(SaintsInterface<TObject, TInterface> a, SaintsInterface<TObject, TInterface> b)
		{
			return (((object)a != null) ? a.V : null) == (((object)b != null) ? b.V : null);
		}

		public static bool operator !=(SaintsInterface<TObject, TInterface> a, SaintsInterface<TObject, TInterface> b)
		{
			return (((object)a != null) ? a.V : null) != (((object)b != null) ? b.V : null);
		}

		public override int GetHashCode()
		{
			return V?.GetHashCode() ?? 0;
		}
	}
}
