using System;
using UnityEngine;

namespace TriLib.Samples
{
	public class LoadSampleAsync : MonoBehaviour
	{
		protected void Start()
		{
			using (AssetLoaderAsync assetLoaderAsync = new AssetLoaderAsync())
			{
				try
				{
					AssetLoaderOptions assetLoaderOptions = AssetLoaderOptions.CreateInstance();
					assetLoaderOptions.RotationAngles = new Vector3(90f, 180f, 0f);
					assetLoaderOptions.AutoPlayAnimations = true;
					assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
					assetLoaderAsync.LoadFromFile(Application.dataPath + "/TriLib/TriLib/Samples/Models/Bouncing.fbx", assetLoaderOptions, null, delegate(GameObject loadedGameObject)
					{
						loadedGameObject.transform.position = new Vector3(128f, 0f, 0f);
					});
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.ToString());
				}
			}
		}
	}
}
