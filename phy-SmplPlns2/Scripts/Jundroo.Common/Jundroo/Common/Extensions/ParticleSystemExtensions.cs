using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class ParticleSystemExtensions
	{
		public static void Scale(this ParticleSystem.MainModule module, Expression<Func<ParticleSystem.MainModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.RotationBySpeedModule module, Expression<Func<ParticleSystem.RotationBySpeedModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.RotationOverLifetimeModule module, Expression<Func<ParticleSystem.RotationOverLifetimeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.SizeBySpeedModule module, Expression<Func<ParticleSystem.SizeBySpeedModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.SizeOverLifetimeModule module, Expression<Func<ParticleSystem.SizeOverLifetimeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.ForceOverLifetimeModule module, Expression<Func<ParticleSystem.ForceOverLifetimeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.InheritVelocityModule module, Expression<Func<ParticleSystem.InheritVelocityModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.LimitVelocityOverLifetimeModule module, Expression<Func<ParticleSystem.LimitVelocityOverLifetimeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.VelocityOverLifetimeModule module, Expression<Func<ParticleSystem.VelocityOverLifetimeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.ShapeModule module, Expression<Func<ParticleSystem.ShapeModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.EmissionModule module, Expression<Func<ParticleSystem.EmissionModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.NoiseModule module, Expression<Func<ParticleSystem.NoiseModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.CollisionModule module, Expression<Func<ParticleSystem.CollisionModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.Burst module, Expression<Func<ParticleSystem.Burst, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.TrailModule module, Expression<Func<ParticleSystem.TrailModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.LightsModule module, Expression<Func<ParticleSystem.LightsModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static void Scale(this ParticleSystem.TextureSheetAnimationModule module, Expression<Func<ParticleSystem.TextureSheetAnimationModule, ParticleSystem.MinMaxCurve>> property, float scale)
		{
			ScaleCommon(module, property, scale);
		}

		public static ParticleSystem.MinMaxCurve Scale(this ParticleSystem.MinMaxCurve curve, float scale)
		{
			switch (curve.mode)
			{
			case ParticleSystemCurveMode.Constant:
				curve.constant *= scale;
				break;
			case ParticleSystemCurveMode.TwoConstants:
				curve.constantMax *= scale;
				curve.constantMin *= scale;
				break;
			case ParticleSystemCurveMode.Curve:
			case ParticleSystemCurveMode.TwoCurves:
				curve.curveMultiplier *= scale;
				break;
			}
			return curve;
		}

		private static void ScaleCommon<TModule>(TModule module, Expression<Func<TModule, ParticleSystem.MinMaxCurve>> property, float scale) where TModule : struct
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			PropertyInfo propertyInfo = ((property.Body as MemberExpression) ?? throw new InvalidOperationException("The property expression is using an invalid expression format. Use this format: x => x.Property")).Member as PropertyInfo;
			if (propertyInfo == null)
			{
				throw new InvalidOperationException("The property expression did not provide a property. Use this format: x => x.Property");
			}
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)propertyInfo.GetGetMethod().Invoke(module, null);
			switch (minMaxCurve.mode)
			{
			case ParticleSystemCurveMode.Constant:
				minMaxCurve.constant *= scale;
				break;
			case ParticleSystemCurveMode.TwoConstants:
				minMaxCurve.constantMax *= scale;
				minMaxCurve.constantMin *= scale;
				break;
			case ParticleSystemCurveMode.Curve:
			case ParticleSystemCurveMode.TwoCurves:
				minMaxCurve.curveMultiplier *= scale;
				break;
			}
			propertyInfo.GetSetMethod().Invoke(module, new object[1] { minMaxCurve });
		}
	}
}
