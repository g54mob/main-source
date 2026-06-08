using System.Runtime.CompilerServices;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Compiler.Resolvers;

namespace HandlebarsDotNet.PathStructure
{
	public static class PathResolver
	{
		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void Undefined(PathInfo pathInfo, UndefinedBindingResult undefinedBindingResult)
			{
				throw new HandlebarsUndefinedBindingException(pathInfo, undefinedBindingResult);
			}
		}

		public static object ResolvePath(BindingContext context, PathInfo pathInfo)
		{
			if (!pathInfo.HasValue)
			{
				return null;
			}
			if (pathInfo.IsPureThis)
			{
				return context.Value;
			}
			object value = context.Value;
			bool throwOnUnresolvedBindingExpression = context.Configuration.ThrowOnUnresolvedBindingExpression;
			PathSegment[] segments = pathInfo.Segments;
			int num = 0;
			while (true)
			{
				ChainSegment[] pathChain;
				int num2;
				if (num < segments.Length)
				{
					PathSegment pathSegment = segments[num];
					if (!pathSegment.IsThis)
					{
						if (pathSegment.IsParent)
						{
							context = context.ParentContext;
							if (context == null)
							{
								value = UndefinedBindingResult.Create("..");
								break;
							}
							value = context.Value;
							throwOnUnresolvedBindingExpression = context.Configuration.ThrowOnUnresolvedBindingExpression;
						}
						else
						{
							pathChain = pathSegment.PathChain;
							if (!TryResolveValue(pathInfo.IsVariable, context, pathChain[0], value, out value))
							{
								value = UndefinedBindingResult.Create(pathChain[0]);
								break;
							}
							num2 = 1;
							while (num2 < pathChain.Length)
							{
								if (TryAccessMember(context, value, pathChain[num2], out value))
								{
									num2++;
									continue;
								}
								goto IL_00cc;
							}
						}
					}
					num++;
					continue;
				}
				return value;
				IL_00cc:
				value = UndefinedBindingResult.Create(pathChain[num2]);
				break;
			}
			if (throwOnUnresolvedBindingExpression)
			{
				Throw.Undefined(pathInfo, (UndefinedBindingResult)value);
			}
			return value;
		}

		private static bool TryResolveValue(bool isVariable, BindingContext context, ChainSegment chainSegment, object instance, out object value)
		{
			if (isVariable)
			{
				return context.TryGetContextVariable(chainSegment, out value);
			}
			if (chainSegment.IsThis)
			{
				value = context.Value;
				return true;
			}
			if (context.TryGetVariable(chainSegment, out value) || (context.Value != instance && TryAccessMember(context, instance, chainSegment, out value)))
			{
				return true;
			}
			if (chainSegment.IsValue)
			{
				return context.TryGetContextVariable(chainSegment, out value);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryAccessMember(BindingContext context, object instance, ChainSegment chainSegment, out object value)
		{
			if (instance == null)
			{
				value = null;
				return false;
			}
			chainSegment = ResolveMemberName(instance, chainSegment, context.Configuration);
			return new ObjectAccessor(instance).TryGetValue(chainSegment, out value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static ChainSegment ResolveMemberName(object instance, ChainSegment memberName, ICompiledHandlebarsConfiguration configuration)
		{
			IExpressionNameResolver expressionNameResolver = configuration.ExpressionNameResolver;
			if (expressionNameResolver == null)
			{
				return memberName;
			}
			return expressionNameResolver.ResolveExpressionName(instance, memberName.TrimmedValue);
		}
	}
}
