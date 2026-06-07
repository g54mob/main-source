using UnityEngine;
using UnityEngine.UI;

public class RandomScreenPicker : MonoBehaviour
{
	private const string BundleName = "loading_screens";

	public RawImage displayComponent;

	private AssetBundle assetBundle;

	private static string BundlePath => Application.streamingAssetsPath + "/game/";

	private void OnEnable()
	{
		string path = BundlePath + "loading_screens";
		assetBundle = AssetBundle.LoadFromFile(path);
		if (assetBundle == null)
		{
			Debug.LogError("Failed to load AssetBundle!");
			return;
		}
		string[] allAssetNames = assetBundle.GetAllAssetNames();
		string text = allAssetNames[Random.Range(0, allAssetNames.Length)];
		Texture2D texture2D = assetBundle.LoadAsset<Texture2D>(text);
		if (texture2D == null)
		{
			Debug.LogError("Failed to load texture from AssetBundle!");
			return;
		}
		displayComponent.texture = texture2D;
		displayComponent.color = Color.white;
	}

	private void OnDisable()
	{
		displayComponent.texture = null;
		displayComponent.color = Color.black;
		if (assetBundle != null)
		{
			assetBundle.Unload(unloadAllLoadedObjects: true);
			assetBundle = null;
		}
	}
}
