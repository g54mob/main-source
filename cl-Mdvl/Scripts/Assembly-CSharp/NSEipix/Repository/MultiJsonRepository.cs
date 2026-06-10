using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.ObjectMapper;
using UnityEngine;

namespace NSEipix.Repository
{
	public abstract class MultiJsonRepository<T, M> : Repository<T, M> where T : Repository<T, M> where M : NSEipix.Base.Model
	{
		[Serializable]
		private class RepositoryDtoExtended : RepositoryDto<M>
		{
			[SerializeField]
			private string name;

			public string Name => name;
		}

		private Dictionary<string, RepositoryDtoExtended> repositories = new Dictionary<string, RepositoryDtoExtended>();

		public MultiJsonRepository()
		{
		}

		public M GetByID(string repoName, string id)
		{
			if (!repositories.TryGetValue(repoName, out var value))
			{
				return null;
			}
			return value.Repository.FirstOrDefault((M item) => item.GetID().Equals(id));
		}

		public List<M> GetAll(string repoName)
		{
			if (!repositories.TryGetValue(repoName, out var value))
			{
				return null;
			}
			return value.Repository;
		}

		protected override void Initialize()
		{
			base.Initialize();
			if (!base.AllItems.Any())
			{
				Deserialize();
			}
		}

		public override void Deserialize()
		{
			string[] array = JsonFiles();
			for (int i = 0; i < array.Length; i++)
			{
				RepositoryDtoExtended repositoryDtoExtended = new JsonSerializer<RepositoryDtoExtended>.Builder(array[i]).BuildWithoutSerializer().Deserialize();
				repositories.Add(repositoryDtoExtended.Name, repositoryDtoExtended);
			}
		}

		protected abstract string[] JsonFiles();

		private void OnEnable()
		{
			Deserialize();
		}
	}
}
