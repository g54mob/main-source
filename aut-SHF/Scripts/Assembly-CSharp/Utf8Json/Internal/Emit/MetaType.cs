using System;
using System.Collections.Generic;
using System.Reflection;

namespace Utf8Json.Internal.Emit
{
	internal class MetaType
	{
		public Type Type { get; private set; }

		public bool IsClass { get; private set; }

		public bool IsStruct => false;

		public bool IsConcreteClass { get; private set; }

		public ConstructorInfo BestmatchConstructor { get; internal set; }

		public MetaMember[] ConstructorParameters { get; internal set; }

		public MetaMember[] Members { get; internal set; }

		public MetaType(Type type, Func<string, string> nameMutetor, bool allowPrivate)
		{
		}

		private static bool TryGetNextConstructor(IEnumerator<ConstructorInfo> ctorEnumerator, ref ConstructorInfo ctor)
		{
			return false;
		}
	}
}
