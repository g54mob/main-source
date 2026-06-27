using System;
using System.Diagnostics;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	[DebuggerDisplay("{Method}")]
	internal class MetaMethod : MetaTypeElement, IEquatable<MetaMethod>
	{
		private const MethodAttributes ExplicitImplementationAttributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask;

		public MethodAttributes Attributes { get; private set; }

		public bool HasTarget { get; private set; }

		public MethodInfo Method { get; private set; }

		public MethodInfo MethodOnTarget { get; private set; }

		public bool Ignore { get; internal set; }

		public bool Proxyable { get; private set; }

		public bool Standalone { get; private set; }

		public MetaMethod(MethodInfo method, MethodInfo methodOnTarget, bool standalone, bool proxyable, bool hasTarget)
			: base(method)
		{
			Method = method;
			MethodOnTarget = methodOnTarget;
			Standalone = standalone;
			Proxyable = proxyable;
			HasTarget = hasTarget;
			Attributes = ObtainAttributes();
		}

		public bool Equals(MetaMethod other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (!StringComparer.OrdinalIgnoreCase.Equals(base.Name, other.Name))
			{
				return false;
			}
			MethodSignatureComparer instance = MethodSignatureComparer.Instance;
			if (!instance.EqualReturnTypes(Method, other.Method))
			{
				return false;
			}
			if (!instance.EqualGenericParameters(Method, other.Method))
			{
				return false;
			}
			if (!instance.EqualParameters(Method, other.Method))
			{
				return false;
			}
			return true;
		}

		public override void SwitchToExplicitImplementation()
		{
			Attributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask;
			if (!Standalone)
			{
				Attributes |= MethodAttributes.SpecialName;
			}
			SwitchToExplicitImplementationName();
		}

		private MethodAttributes ObtainAttributes()
		{
			MethodInfo method = Method;
			MethodAttributes methodAttributes = MethodAttributes.Virtual;
			if (method.IsFinal || Method.DeclaringType.IsInterface)
			{
				methodAttributes |= MethodAttributes.VtableLayoutMask;
			}
			if (method.IsPublic)
			{
				methodAttributes |= MethodAttributes.Public;
			}
			if (method.IsHideBySig)
			{
				methodAttributes |= MethodAttributes.HideBySig;
			}
			if (ProxyUtil.IsInternal(method) && ProxyUtil.AreInternalsVisibleToDynamicProxy(method.DeclaringType.Assembly))
			{
				methodAttributes |= MethodAttributes.Assembly;
			}
			if (method.IsFamilyAndAssembly)
			{
				methodAttributes |= MethodAttributes.FamANDAssem;
			}
			else if (method.IsFamilyOrAssembly)
			{
				methodAttributes |= MethodAttributes.FamORAssem;
			}
			else if (method.IsFamily)
			{
				methodAttributes |= MethodAttributes.Family;
			}
			if (!Standalone)
			{
				methodAttributes |= MethodAttributes.SpecialName;
			}
			return methodAttributes;
		}
	}
}
