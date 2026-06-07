using System.Threading.Tasks;
using Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
	public interface IAssetProvider : IService
	{
		Task<GameObject> Instantiate(string path, Vector3 at);

		Task<GameObject> Instantiate(string path);

		void Cleanup();

		Task<T> Load<T>(string address) where T : class;

		void Initialize();

		Task<GameObject> Instantiate(string address, Transform under);
	}
}
