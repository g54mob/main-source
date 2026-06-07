using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Expressions.Exceptions;
using UnityEngine;

namespace ModApi.Expressions
{
	public static class Converters
	{
		private interface IConverter
		{
			Type From { get; }

			Type To { get; }

			Func<Expression, Expression> Expression { get; }
		}

		private struct FunkyConverter<TFrom, TTo> : IConverter
		{
			public Func<Func<double[], TFrom>, Func<double[], TTo>> Function { get; private set; }

			public Func<Expression, Expression> Expression { get; private set; }

			public Type From => typeof(TFrom);

			public Type To => typeof(TTo);

			public FunkyConverter(Func<Func<double[], TFrom>, Func<double[], TTo>> func, Func<Expression, Expression> exp)
			{
				Function = func;
				Expression = exp;
			}
		}

		private static MethodInfo _toString;

		private static PropertyInfo _magnitude;

		private static Dictionary<(Type, Type), IConverter> _converters;

		static Converters()
		{
			_toString = new Func<string>(new object().ToString).Method;
			Expression expression = ((Expression<Func<Vector3d, double>>)((Vector3d v) => v.magnitude)).Body;
			if (expression is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)
			{
				expression = unaryExpression.Operand;
			}
			_magnitude = (expression as MemberExpression).Member as PropertyInfo;
			IConverter[] obj = new IConverter[13]
			{
				new FunkyConverter<double, string>((Func<double[], double> src) => (double[] dat) => src(dat).ToString(), (Expression exp) => Expression.Call(exp, _toString)),
				new FunkyConverter<float, string>((Func<double[], float> src) => (double[] dat) => src(dat).ToString(), (Expression exp) => Expression.Call(exp, _toString)),
				new FunkyConverter<bool, string>((Func<double[], bool> src) => (double[] dat) => src(dat).ToString(), (Expression exp) => Expression.Call(exp, _toString)),
				new FunkyConverter<bool, double>((Func<double[], bool> src) => (double[] dat) => (!src(dat)) ? (-1.0) : 1.0, (Expression exp) => Expression.Condition(exp, Expression.Constant(1.0), Expression.Constant(-1.0))),
				new FunkyConverter<bool, float>((Func<double[], bool> src) => (double[] dat) => (!src(dat)) ? (-1f) : 1f, (Expression exp) => Expression.Condition(exp, Expression.Constant(1f), Expression.Constant(-1f))),
				new FunkyConverter<double, bool>((Func<double[], double> src) => (double[] dat) => src(dat) > 0.0, (Expression exp) => Expression.GreaterThan(exp, Expression.Constant(0.0))),
				new FunkyConverter<float, bool>((Func<double[], float> src) => (double[] dat) => src(dat) > 0f, (Expression exp) => Expression.GreaterThan(exp, Expression.Constant(0f))),
				new FunkyConverter<float, double>((Func<double[], float> src) => (double[] dat) => src(dat), (Expression exp) => Expression.Convert(exp, typeof(double))),
				new FunkyConverter<double, float>((Func<double[], double> src) => (double[] dat) => (float)src(dat), (Expression exp) => Expression.Convert(exp, typeof(float))),
				new FunkyConverter<int, double>((Func<double[], int> src) => (double[] dat) => src(dat), (Expression exp) => Expression.Convert(exp, typeof(double))),
				new FunkyConverter<double, int>((Func<double[], double> src) => (double[] dat) => (int)src(dat), (Expression exp) => Expression.Convert(exp, typeof(int))),
				new FunkyConverter<Vector3d, double>((Func<double[], Vector3d> src) => (double[] dat) => src(dat).magnitude, (Expression exp) => Expression.Property(exp, _magnitude)),
				new FunkyConverter<Vector3d, string>((Func<double[], Vector3d> src) => (double[] dat) => src(dat).ToString(), (Expression exp) => Expression.Call(exp, _toString))
			};
			_converters = new Dictionary<(Type, Type), IConverter>(obj.Length);
			IConverter[] array = obj;
			foreach (IConverter converter in array)
			{
				_converters.Add((converter.From, converter.To), converter);
			}
		}

		public static Func<double[], TTo> Convert<TFrom, TTo>(Func<double[], TFrom> func)
		{
			FunkyConverter<TFrom, TTo>? funkyConverter = _converters.GetValueOrDefault((typeof(TFrom), typeof(TTo))) as FunkyConverter<TFrom, TTo>?;
			if (funkyConverter.HasValue)
			{
				return funkyConverter.Value.Function(func);
			}
			throw new ExpressionCompileException("Cannot convert from type " + typeof(TFrom).Name + " to " + typeof(TTo).Name);
		}

		public static Expression Convert(Expression exp, Type to)
		{
			Type type = exp.Type;
			if (_converters.TryGetValue((type, to), out var value))
			{
				return value.Expression(exp);
			}
			throw new ExpressionCompileException("Cannot convert from type " + type.Name + " to " + to.Name);
		}
	}
}
