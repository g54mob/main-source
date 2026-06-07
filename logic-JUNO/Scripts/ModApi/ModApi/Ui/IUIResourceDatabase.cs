using UnityEngine;

namespace ModApi.Ui
{
	public interface IUIResourceDatabase
	{
		void AddResource(string path, Object resource);

		T GetResource<T>(string path) where T : Object;
	}
}
