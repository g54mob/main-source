using System.IO;
using Crosstales.FB;
using Kengine;
using UnityEngine;

public class CollectionBundle : MonoBehaviour
{
	public static void CreateBundleSelect()
	{
		string text = FileBrowser.OpenSingleFolder();
		string text2 = FileBrowser.SaveFile("bundle", "collection");
		if (text != "" && text2 != "")
		{
			CreateBundle(text, text2);
		}
	}

	public static void InstallBundleSelect()
	{
		ExtensionFilter extensionFilter = new ExtensionFilter("Asset Forge (.collection)", "collection");
		string text = FileBrowser.OpenSingleFile(null, null, extensionFilter);
		if (text != "")
		{
			InstallBundle(text);
		}
	}

	public static void CreateBundle(string _inputFolder, string _outputFile)
	{
		CollectionBundleFile collectionBundleFile = new CollectionBundleFile();
		collectionBundleFile.name = Path.GetFileNameWithoutExtension(_outputFile);
		MonoBehaviour.print(collectionBundleFile.name);
		FileInfo[] files = new DirectoryInfo(_inputFolder).GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			if (!(fileInfo.Extension != ".obj") || !(fileInfo.Extension != ".mtl"))
			{
				CollectionBundleFragment collectionBundleFragment = new CollectionBundleFragment();
				collectionBundleFragment.name = fileInfo.Name;
				collectionBundleFragment.data = File.ReadAllText(fileInfo.FullName);
				collectionBundleFile.fragments.Add(collectionBundleFragment);
			}
		}
		byte[] bytes = Saving.Zip(JsonUtility.ToJson(collectionBundleFile));
		File.WriteAllBytes(_outputFile, bytes);
	}

	public static void InstallBundle(string _inputFile)
	{
		CollectionBundleFile collectionBundleFile = JsonUtility.FromJson<CollectionBundleFile>(Saving.Unzip(File.ReadAllBytes(_inputFile)));
		string text = $"{Collections.customCollectionPath}/{collectionBundleFile.name}";
		Directory.CreateDirectory(text);
		foreach (CollectionBundleFragment fragment in collectionBundleFile.fragments)
		{
			File.WriteAllText($"{text}/{fragment.name}", fragment.data);
		}
		Global.ShowMessage("Collection loaded, restart Asset Forge to see changes", 4f);
	}
}
