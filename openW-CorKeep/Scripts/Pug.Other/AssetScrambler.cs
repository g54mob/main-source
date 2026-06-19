using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Asset Scrambler", menuName = "Pug/Editor/Asset Scrambler", order = 100)]
public class AssetScrambler : ScriptableObject
{
	[Serializable]
	public class Group
	{
		public string name;

		public List<Texture2D> textures;

		public List<UnityEngine.Object> meshes;
	}

	public List<Group> groups = new List<Group>();

	public void Validate()
	{
		foreach (Group group in groups)
		{
			RemoveDuplicates(group.textures);
			RemoveDuplicates(group.meshes);
		}
	}

	private void RemoveDuplicates<T>(IList<T> assets) where T : UnityEngine.Object
	{
		HashSet<T> hashSet = new HashSet<T>();
		for (int i = 0; i < assets.Count; i++)
		{
			T item = assets[i];
			hashSet.Add(item);
		}
		assets.Clear();
		foreach (T item2 in hashSet)
		{
			assets.Add(item2);
		}
	}
}
