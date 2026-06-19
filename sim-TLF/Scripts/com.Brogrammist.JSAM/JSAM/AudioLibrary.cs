using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace JSAM
{
	[CreateAssetMenu(fileName = "New Audio Library", menuName = "AudioManager/New Audio Library", order = 1)]
	public class AudioLibrary : ScriptableObject
	{
		[Serializable]
		public class CategoryToList
		{
			public string name;

			public List<BaseAudioFileObject> files;

			public bool foldout;
		}

		public List<string> soundCategories = new List<string>();

		public List<string> musicCategories = new List<string>();

		public List<SoundFileObject> Sounds = new List<SoundFileObject>();

		public List<MusicFileObject> Music = new List<MusicFileObject>();

		[Tooltip("Allows you to customize the enum and namespace names for your generated audio. For advanced users.")]
		public bool useCustomNames;

		public string generatedName;

		public string musicEnum;

		public string musicEnumGenerated;

		public string musicNamespace;

		public string musicNamespaceGenerated;

		public string soundEnum;

		public string soundEnumGenerated;

		public string soundNamespace;

		public string soundNamespaceGenerated;

		[SerializeField]
		public List<CategoryToList> soundCategoriesToList = new List<CategoryToList>();

		[SerializeField]
		public List<CategoryToList> musicCategoriesToList = new List<CategoryToList>();

		public string SafeName => base.name.ConvertToAlphanumeric();

		public string defaultMusicEnum => base.name.ConvertToAlphanumeric() + "Music";

		public string defaultSoundEnum => base.name.ConvertToAlphanumeric() + "Sounds";

		private void Reset()
		{
			soundCategories.Add(string.Empty);
			musicCategories.Add(string.Empty);
			CategoryToList categoryToList = new CategoryToList();
			categoryToList.name = string.Empty;
			categoryToList.foldout = true;
			soundCategoriesToList.Add(categoryToList);
			categoryToList = new CategoryToList();
			categoryToList.name = string.Empty;
			categoryToList.foldout = true;
			musicCategoriesToList.Add(categoryToList);
		}

		public void InitializeValues()
		{
			soundEnum = defaultSoundEnum;
			musicEnum = defaultMusicEnum;
		}

		public bool IsLoaded()
		{
			return AudioManagerInternal.Instance.IsLibraryLoaded(this);
		}

		public static Type GetEnumType(string enumName)
		{
			if (enumName.IsNullEmptyOrWhiteSpace())
			{
				return null;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type type = assemblies[i].GetType(enumName);
				if (!(type == null) && type.IsEnum)
				{
					return type;
				}
			}
			return null;
		}
	}
}
