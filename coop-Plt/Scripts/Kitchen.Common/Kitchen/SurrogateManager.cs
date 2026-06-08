using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class SurrogateManager : GenericSystemBase
	{
		private static MethodInfo _CachedReplaceSurrogate;

		private static MethodInfo CachedReplaceSurrogate
		{
			get
			{
				if (_CachedReplaceSurrogate == null)
				{
					_CachedReplaceSurrogate = typeof(SurrogateManager).GetMethod("ReplaceSurrogate", BindingFlags.Instance | BindingFlags.NonPublic);
				}
				return _CachedReplaceSurrogate;
			}
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			try
			{
				ReplaceSurrogates();
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to replace some surrogates: {arg}");
			}
		}

		protected override void OnUpdate()
		{
		}

		[UsedImplicitly]
		private void ReplaceSurrogate<TSur>() where TSur : struct, TypeHash.ISurrogate
		{
			EntityManager entityManager = base.EntityManager;
			foreach (Entity allEntity in entityManager.GetAllEntities())
			{
				if (entityManager.HasComponent<TSur>(allEntity))
				{
					TSur val = (TypeManager.IsZeroSized(TypeManager.GetTypeIndex(typeof(TSur))) ? default(TSur) : entityManager.GetComponentData<TSur>(allEntity));
					if ((object)val is TypeHash.IExtendedSurrogate extendedSurrogate)
					{
						extendedSurrogate.Convert(entityManager, allEntity);
						continue;
					}
					IComponentData componentData = val.Convert();
					entityManager.RemoveComponent<TSur>(allEntity);
					entityManager.AddComponentData(allEntity, (dynamic)componentData);
				}
			}
		}

		private void ReplaceSurrogates()
		{
			foreach (Type item in from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
				where typeof(TypeHash.ISurrogate).IsAssignableFrom(p) && !p.IsInterface && p.IsValueType && !p.IsAbstract
				select p)
			{
				try
				{
					if (item.GetType() == typeof(CSplittableItemSurrogate))
					{
						ReplaceSurrogate<CSplittableItemSurrogate>();
					}
					else if (PlatformSettings.AllowsDynamicVariables)
					{
						CachedReplaceSurrogate.MakeGenericMethod(item).Invoke(this, new object[0]);
					}
				}
				catch (Exception arg)
				{
					Debug.LogError($"Failed to replace surrogates for type {item.Name}: {arg}");
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
