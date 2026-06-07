using ModApi.Common;
using UnityEngine;
using UnityFS;

namespace ModApi
{
	public interface IResourceLoader
	{
		GameObject InstantiatePrefab(string path, bool logErrors = true);

		T InstantiatePrefab<T>(string path, bool logErrors = true);

		T Load<T>(string path, bool logErrors = true) where T : Object;

		Aerofoil LoadAirfoil(string airfoilName);

		T[] LoadAll<T>(string path, bool logErrors = true) where T : Object;

		ResourceRequestWrapper<T> LoadAsync<T>(string path, bool logErrors = true) where T : Object;

		AudioClip LoadAudio(string path, bool logErrors = true);

		Material LoadMaterial(string path, bool logErrors = true);

		GameObject LoadPrefab(string path, bool logErrors = true);

		T LoadScriptableObject<T>(string path, bool logErrors = true) where T : class;

		string LoadText(string path, bool logErrors = true);

		Texture2D LoadTexture(string path, bool logErrors = true);
	}
}
