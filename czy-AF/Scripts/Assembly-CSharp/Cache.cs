using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Cache : MonoBehaviour
{
	public delegate void OnLoadingComplete();

	private PanelSplash splash;

	public static event OnLoadingComplete onLoadingComplete;

	private void Start()
	{
		splash = UnityEngine.Object.FindObjectOfType<PanelSplash>();
		StartCoroutine(PrepareCache());
	}

	public static void Clear()
	{
		string folder = Folders.GetFolder("cache");
		if (Directory.Exists(folder))
		{
			Directory.Delete(folder, recursive: true);
		}
	}

	private IEnumerator PrepareCache()
	{
		yield return null;
		int thumbnailResolution = 44;
		Camera thumbnailCamera = Global.elements["cameraRender"].GetComponent<Camera>();
		float time = Time.realtimeSinceStartup;
		string dataFolder = Application.persistentDataPath;
		Directory.CreateDirectory(dataFolder + "/cache");
		foreach (string collections in Collections.collectionsList)
		{
			Directory.CreateDirectory(dataFolder + "/cache/" + collections);
		}
		float orthographicSize = thumbnailCamera.orthographicSize;
		thumbnailCamera.orthographicSize = 1f;
		int index = 0;
		int indexTotal = Collections.blocks.Count;
		int num = 0;
		foreach (Block block in Collections.blocks)
		{
			string objectThumbnail = dataFolder + "/cache/" + block.collection + "\\" + block.type + ".png";
			if (!File.Exists(objectThumbnail))
			{
				GameObject gameObject = Collections.CreateBlock(block.collection, block.type);
				if (gameObject == null)
				{
					continue;
				}
				if ((bool)gameObject.GetComponent<MeshRenderer>())
				{
					Bounds bounds = gameObject.GetComponent<MeshRenderer>().bounds;
					gameObject.transform.localPosition = -gameObject.transform.InverseTransformPoint(bounds.center);
					float num2 = 0.65f;
					Vector3 vector = bounds.max - bounds.min;
					float num3 = Mathf.Max(vector.x, vector.y, vector.z);
					float num4 = 2f * Mathf.Tan(MathF.PI / 360f * thumbnailCamera.fieldOfView);
					float num5 = num2 * num3 / num4;
					num5 += 0.5f * num3;
					thumbnailCamera.orthographicSize = num5;
				}
				Texture2D texture2D = Collections.RenderCamera(thumbnailCamera, thumbnailResolution);
				UnityEngine.Object.DestroyImmediate(gameObject);
				File.WriteAllBytes(objectThumbnail, texture2D.EncodeToPNG());
				UnityEngine.Object.Destroy(texture2D);
				if (num == 10)
				{
					yield return null;
					num = 0;
				}
				num++;
			}
			Texture2D texture2D2 = new Texture2D(thumbnailResolution, thumbnailResolution);
			texture2D2.LoadImage(File.ReadAllBytes(objectThumbnail));
			block.thumbnail = texture2D2;
			splash.SetProgressText($"Caching thumbnails ({index * 100 / indexTotal}%)...");
			splash.SetProgress((float)index * 100f / (float)indexTotal / 100f);
			index++;
		}
		yield return 0;
		splash.SetProgressText("Caching textures...");
		Texture2D[] array = Resources.LoadAll<Texture2D>("Textures");
		foreach (Texture2D texture2D3 in array)
		{
			string[] array2 = texture2D3.name.Split("_"[0]);
			Textures.AddTexture(array2[1], array2[0], texture2D3);
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Global.GetDataFolder("Textures"));
		if (Directory.Exists(Global.GetDataFolder("Textures")))
		{
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				FileInfo[] files = new DirectoryInfo(Global.GetDataFolder("Textures") + directoryInfo2.Name).GetFiles("*.png");
				foreach (FileInfo fileInfo in files)
				{
					Texture2D texture2D4 = new Texture2D(2, 2);
					texture2D4.LoadImage(File.ReadAllBytes(fileInfo.FullName));
					Textures.AddTexture(fileInfo.Name, directoryInfo2.Name, texture2D4);
				}
			}
		}
		splash.SetProgressText("");
		splash.SetProgress(1f);
		thumbnailCamera.orthographicSize = orthographicSize;
		yield return null;
		MonoBehaviour.print("Creation of all thumbnails took " + (Time.realtimeSinceStartup - time).ToString("f4") + " seconds");
		if (Cache.onLoadingComplete != null)
		{
			Cache.onLoadingComplete();
		}
		splash.ProgressComplete();
	}
}
