using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.ObjectMapper;
using NSMedieval.Repository;
using UnityEngine;
using Utils;

namespace NSEipix.Repository
{
	public abstract class MonoRepository<T, M> : MonoBehaviour where T : MonoBehaviour where M : NSEipix.Base.Model
	{
		private static T instance;

		private static bool instanceInit;

		private static readonly object Padlock = new object();

		[SerializeField]
		protected List<M> repository = new List<M>();

		private Dictionary<string, string> formerIdsMap;

		[NonSerialized]
		protected readonly Dictionary<string, M> dictionary = new Dictionary<string, M>();

		public static T Instance
		{
			get
			{
				lock (Padlock)
				{
					if (!instanceInit)
					{
						instance = MonoSingleton<RepositoryManager>.Instance.GetRepository<T>();
						MonoRepository<T, M> monoRepository = instance as MonoRepository<T, M>;
						if (monoRepository.dictionary.Count == 0)
						{
							monoRepository.Deserialize();
						}
						instanceInit = true;
						DomainReloadHelper.OnDomainReloadEvent = (Action)Delegate.Combine(DomainReloadHelper.OnDomainReloadEvent, new Action(OnDomainReload));
					}
					return instance;
				}
			}
		}

		public static bool InstanceInit => instanceInit;

		public IEnumerable<M> AllItems => repository;

		private static void OnDomainReload()
		{
			instance = null;
			instanceInit = false;
		}

		public static bool IsInstantiated()
		{
			return instance != null;
		}

		private void OnDestroy()
		{
			lock (Padlock)
			{
				instance = null;
				instanceInit = false;
			}
		}

		public M GetFirst()
		{
			if (repository != null && repository.Count > 0)
			{
				return repository[0];
			}
			return null;
		}

		public M GetFirst(Func<M, bool> predicate)
		{
			foreach (M item in repository)
			{
				if (predicate(item))
				{
					return item;
				}
			}
			return null;
		}

		public M GetLast()
		{
			if (repository.Count == 0)
			{
				return null;
			}
			return repository[repository.Count - 1];
		}

		public M GetAt(int index)
		{
			if (index >= repository.Count)
			{
				return null;
			}
			return repository[index];
		}

		public bool ContainsKey(string id)
		{
			if (dictionary.ContainsKey(id))
			{
				return true;
			}
			if (formerIdsMap != null && formerIdsMap.TryGetValue(id, out var value))
			{
				return dictionary.ContainsKey(value);
			}
			return false;
		}

		public virtual bool TryGetValue(string id, out M model)
		{
			if (dictionary.TryGetValue(id, out model))
			{
				return true;
			}
			if (formerIdsMap != null && formerIdsMap.TryGetValue(id, out var value))
			{
				return dictionary.TryGetValue(value, out model);
			}
			return false;
		}

		public virtual M GetByID(string id)
		{
			if (dictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			if (formerIdsMap != null && formerIdsMap.TryGetValue(id, out var value2))
			{
				return dictionary[value2];
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(44, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\MonoRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Could not find model with ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(" in repository ");
				messageBuilder.AppendFormatted(typeof(T).Name);
			}
			Log.Warning(messageBuilder);
			return null;
		}

		public M[] GetRange(int index, int count)
		{
			return repository.Skip(index).Take(count).ToArray();
		}

		public int GetCount()
		{
			return repository.Count;
		}

		public bool Exists(M model)
		{
			if (model == null)
			{
				return false;
			}
			return dictionary.ContainsKey(model.GetID());
		}

		public bool Add(M model)
		{
			if (model != null && !Exists(model))
			{
				repository.Add(model);
				dictionary.Add(model.GetID(), model);
				return true;
			}
			return false;
		}

		public bool Remove(M model)
		{
			if (model != null && dictionary.ContainsKey(model.GetID()))
			{
				dictionary.Remove(model.GetID());
			}
			return repository.Remove(model);
		}

		public bool RemoveByID(string id)
		{
			return Remove(GetByID(id));
		}

		public void RemoveAll()
		{
			dictionary.Clear();
			repository.Clear();
		}

		public virtual void Reload()
		{
		}

		protected virtual ISerializer<RepositoryDto<M>> Serializer()
		{
			return NullSerializer<RepositoryDto<M>>.Instance;
		}

		public virtual void Deserialize()
		{
			RepositoryDto<M> repositoryDto = Serializer().Deserialize();
			if (repositoryDto != null)
			{
				bool flag = typeof(M).IsSubclassOf(typeof(IndexedModel));
				int num = 0;
				foreach (M item in repositoryDto.Repository)
				{
					if (flag)
					{
						(item as IndexedModel).SetModelIndex(num++);
					}
					repository.Add(item);
				}
			}
			repository.RemoveAll((M m) => m.HideInGame);
			formerIdsMap = new Dictionary<string, string>();
			foreach (M item2 in repository)
			{
				if (item2.GetID() == null)
				{
					Log.Debug(item2.ToString(), "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\MonoRepository.cs");
				}
				if (!dictionary.ContainsKey(item2.GetID()))
				{
					dictionary.Add(item2.GetID(), item2);
				}
				if (item2.FormerIDs == null || item2.FormerIDs.Length == 0)
				{
					continue;
				}
				string[] formerIDs = item2.FormerIDs;
				foreach (string key in formerIDs)
				{
					if (!formerIdsMap.TryAdd(key, item2.GetID()))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\MonoRepository.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Duplicate former ID detected for model ");
							messageBuilder.AppendFormatted(item2.GetID());
						}
						Log.Error(messageBuilder);
					}
				}
			}
			if (instance == null)
			{
				instance = MonoSingleton<RepositoryManager>.Instance.GetRepository<T>();
				instanceInit = instance != null;
			}
		}

		protected virtual void Serialize()
		{
			RepositoryDto<M> obj = new RepositoryDto<M>(repository.ToList());
			Serializer().Serialize(obj);
		}
	}
}
