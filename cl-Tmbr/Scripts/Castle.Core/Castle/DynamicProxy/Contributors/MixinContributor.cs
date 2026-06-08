using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Contributors
{
	internal class MixinContributor : CompositeTypeContributor
	{
		private readonly bool canChangeTarget;

		private readonly IList<Type> empty = new List<Type>();

		private readonly IDictionary<Type, FieldReference> fields = new SortedDictionary<Type, FieldReference>(new FieldReferenceComparer());

		private readonly GetTargetExpressionDelegate getTargetExpression;

		public IEnumerable<FieldReference> Fields => fields.Values;

		public MixinContributor(INamingScope namingScope, bool canChangeTarget)
			: base(namingScope)
		{
			this.canChangeTarget = canChangeTarget;
			getTargetExpression = BuildGetTargetExpression();
		}

		public void AddEmptyInterface(Type @interface)
		{
			empty.Add(@interface);
		}

		public override void Generate(ClassEmitter @class)
		{
			foreach (Type @interface in interfaces)
			{
				fields[@interface] = BuildTargetField(@class, @interface);
			}
			foreach (Type item in empty)
			{
				fields[item] = BuildTargetField(@class, item);
			}
			base.Generate(@class);
		}

		protected override IEnumerable<MembersCollector> GetCollectors()
		{
			foreach (Type @interface in interfaces)
			{
				yield return (!@interface.IsInterface) ? ((MembersCollector)new DelegateTypeMembersCollector(@interface)) : ((MembersCollector)new InterfaceMembersCollector(@interface));
			}
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod)
		{
			if (!method.Proxyable)
			{
				return new ForwardingMethodGenerator(method, overrideMethod, (ClassEmitter c, MethodInfo i) => fields[i.DeclaringType]);
			}
			Type invocationType = GetInvocationType(method, @class);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, getTargetExpression, overrideMethod, null);
		}

		private GetTargetExpressionDelegate BuildGetTargetExpression()
		{
			if (!canChangeTarget)
			{
				return (ClassEmitter c, MethodInfo m) => fields[m.DeclaringType];
			}
			return (ClassEmitter c, MethodInfo m) => new NullCoalescingOperatorExpression(new AsTypeReference(c.GetField("__target"), m.DeclaringType), fields[m.DeclaringType]);
		}

		private FieldReference BuildTargetField(ClassEmitter @class, Type type)
		{
			string suggestedName = "__mixin_" + type.FullName.Replace(".", "_");
			return @class.CreateField(namingScope.GetUniqueName(suggestedName), type);
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter emitter)
		{
			ModuleScope moduleScope = emitter.ModuleScope;
			CacheKey key = new CacheKey(interfaces: (!canChangeTarget) ? new Type[1] { typeof(IInvocation) } : new Type[2]
			{
				typeof(IInvocation),
				typeof(IChangeProxyTarget)
			}, target: method.Method, type: CompositionInvocationTypeGenerator.BaseType, options: null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget, null).Generate(emitter, namingScope).BuildType());
		}
	}
}
