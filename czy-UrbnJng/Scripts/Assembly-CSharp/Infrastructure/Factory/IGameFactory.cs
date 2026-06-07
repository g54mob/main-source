using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory : IService
	{
		List<ISavedProgressReader> ProgressReaders { get; }

		List<ISavedProgress> ProgressWriters { get; }

		void Cleanup();

		void WarmUp();

		Task CreateLevelTransfer(Vector3 at);
	}
}
