using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace MiscUtil.Reflection
{
	public static class PropertyCopy<TTarget> where TTarget : class, new()
	{
		private static class PropertyCopier<TSource> where TSource : class
		{
			private static readonly Func<TSource, TTarget> copier;

			private static readonly Exception initializationException;

			internal static TTarget Copy(TSource source)
			{
				if (initializationException != null)
				{
					throw initializationException;
				}
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				return copier(source);
			}

			static PropertyCopier()
			{
				try
				{
					copier = BuildCopier();
					initializationException = null;
				}
				catch (Exception ex)
				{
					copier = null;
					initializationException = ex;
				}
			}

			private static Func<TSource, TTarget> BuildCopier()
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "source");
				List<MemberBinding> list = new List<MemberBinding>();
				PropertyInfo[] properties = typeof(TSource).GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.CanRead)
					{
						PropertyInfo property = typeof(TTarget).GetProperty(propertyInfo.Name);
						if ((object)property == null)
						{
							throw new ArgumentException("Property " + propertyInfo.Name + " is not present and accessible in " + typeof(TTarget).FullName);
						}
						if (!property.CanWrite)
						{
							throw new ArgumentException("Property " + propertyInfo.Name + " is not writable in " + typeof(TTarget).FullName);
						}
						if (!property.PropertyType.IsAssignableFrom(propertyInfo.PropertyType))
						{
							throw new ArgumentException("Property " + propertyInfo.Name + " has an incompatible type in " + typeof(TTarget).FullName);
						}
						list.Add(Expression.Bind(property, Expression.Property(parameterExpression, propertyInfo)));
					}
				}
				Expression body = Expression.MemberInit(Expression.New(typeof(TTarget)), list);
				return Expression.Lambda<Func<TSource, TTarget>>(body, new ParameterExpression[1] { parameterExpression }).Compile();
			}
		}

		public static TTarget CopyFrom<TSource>(TSource source) where TSource : class
		{
			return PropertyCopier<TSource>.Copy(source);
		}
	}
}
