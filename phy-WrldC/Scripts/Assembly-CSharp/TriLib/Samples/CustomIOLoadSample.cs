using System;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using STB;
using UnityEngine;

namespace TriLib.Samples
{
	public class CustomIOLoadSample : MonoBehaviour
	{
		private const string ObjData = "mtllib cube.mtl\n\nv -1.000000 -1.000000 1.000000\nv 1.000000 -1.000000 1.000000\nv -1.000000 1.000000 1.000000\nv 1.000000 1.000000 1.000000\nv -1.000000 1.000000 -1.000000\nv 1.000000 1.000000 -1.000000\nv -1.000000 -1.000000 -1.000000\nv 1.000000 -1.000000 -1.000000\n\nvt 0.000000 0.000000\nvt 1.000000 0.000000\nvt 0.000000 1.000000\nvt 1.000000 1.000000\n\nvn 0.000000 0.000000 1.000000\nvn 0.000000 1.000000 0.000000\nvn 0.000000 0.000000 -1.000000\nvn 0.000000 -1.000000 0.000000\nvn 1.000000 0.000000 0.000000\nvn -1.000000 0.000000 0.000000\n\ng cube\nusemtl cube\ns 1\nf 1/1/1 2/2/1 3/3/1\nf 3/3/1 2/2/1 4/4/1\ns 2\nf 3/1/2 4/2/2 5/3/2\nf 5/3/2 4/2/2 6/4/2\ns 3\nf 5/4/3 6/3/3 7/2/3\nf 7/2/3 6/3/3 8/1/3\ns 4\nf 7/1/4 8/2/4 1/3/4\nf 1/3/4 8/2/4 2/4/4\ns 5\nf 2/1/5 8/2/5 4/3/5\nf 4/3/5 8/2/5 6/4/5\ns 6\nf 7/1/6 1/2/6 5/3/6\nf 5/3/6 1/2/6 3/4/6";

		private const string MtlFilename = "cube.mtl";

		private const string MtlData = "newmtl cube\n  Ns 10.0000\n  Ni 1.5000\n  d 1.0000\n  Tr 0.0000\n  Tf 1.0000 1.0000 1.0000 \n  illum 2\n  Ka 0.0000 0.0000 0.0000\n  Kd 0.5880 0.5880 0.5880\n  Ks 0.0000 0.0000 0.0000\n  Ke 0.0000 0.0000 0.0000\n  map_Ka cube.png\n  map_Kd cube.png";

		private const string TextureFilename = "cube.png";

		private const string TextureData = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABTSURBVDhPrYrJDcAwDMO8/7hdoAegKAbtJo+W4EdH/MB5TDfka7YHJ0gwt05QOdZGIDvWRjhvFWgXCgcPMH8e6pDFQTTV4HXy0NqDk12B6+03Ii7udAgYy29ORgAAAABJRU5ErkJggg==";

		private void Start()
		{
			using (AssetLoader assetLoader = new AssetLoader())
			{
				byte[] bytes = Encoding.UTF8.GetBytes("mtllib cube.mtl\n\nv -1.000000 -1.000000 1.000000\nv 1.000000 -1.000000 1.000000\nv -1.000000 1.000000 1.000000\nv 1.000000 1.000000 1.000000\nv -1.000000 1.000000 -1.000000\nv 1.000000 1.000000 -1.000000\nv -1.000000 -1.000000 -1.000000\nv 1.000000 -1.000000 -1.000000\n\nvt 0.000000 0.000000\nvt 1.000000 0.000000\nvt 0.000000 1.000000\nvt 1.000000 1.000000\n\nvn 0.000000 0.000000 1.000000\nvn 0.000000 1.000000 0.000000\nvn 0.000000 0.000000 -1.000000\nvn 0.000000 -1.000000 0.000000\nvn 1.000000 0.000000 0.000000\nvn -1.000000 0.000000 0.000000\n\ng cube\nusemtl cube\ns 1\nf 1/1/1 2/2/1 3/3/1\nf 3/3/1 2/2/1 4/4/1\ns 2\nf 3/1/2 4/2/2 5/3/2\nf 5/3/2 4/2/2 6/4/2\ns 3\nf 5/4/3 6/3/3 7/2/3\nf 7/2/3 6/3/3 8/1/3\ns 4\nf 7/1/4 8/2/4 1/3/4\nf 1/3/4 8/2/4 2/4/4\ns 5\nf 2/1/5 8/2/5 4/3/5\nf 4/3/5 8/2/5 6/4/5\ns 6\nf 7/1/6 1/2/6 5/3/6\nf 5/3/6 1/2/6 3/4/6");
				assetLoader.LoadFromMemory(bytes, ".obj", null, base.gameObject, null, CustomDataCallback, CustomExistsCallback, CustomTextureDataCallback);
			}
		}

		private static EmbeddedTextureData CustomTextureDataCallback(string path, string basePath)
		{
			if (path == "cube.png")
			{
				EmbeddedTextureData embeddedTextureData = new EmbeddedTextureData();
				byte[] bytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABTSURBVDhPrYrJDcAwDMO8/7hdoAegKAbtJo+W4EdH/MB5TDfka7YHJ0gwt05QOdZGIDvWRjhvFWgXCgcPMH8e6pDFQTTV4HXy0NqDk12B6+03Ii7udAgYy29ORgAAAABJRU5ErkJggg==");
				embeddedTextureData.DataPointer = STBImageLoader.LoadTextureDataFromByteArray(bytes, out embeddedTextureData.Width, out embeddedTextureData.Height, out embeddedTextureData.NumChannels, out embeddedTextureData.DataLength);
				embeddedTextureData.OnDataDisposal = STBImageLoader.UnloadTextureData;
				return embeddedTextureData;
			}
			return null;
		}

		[MonoPInvokeCallback(typeof(AssimpInterop.DataCallback))]
		private static IntPtr CustomDataCallback(string resourceFilename, int resourceId, ref int fileSize)
		{
			if (resourceFilename == "cube.mtl")
			{
				byte[] bytes = Encoding.UTF8.GetBytes("newmtl cube\n  Ns 10.0000\n  Ni 1.5000\n  d 1.0000\n  Tr 0.0000\n  Tf 1.0000 1.0000 1.0000 \n  illum 2\n  Ka 0.0000 0.0000 0.0000\n  Kd 0.5880 0.5880 0.5880\n  Ks 0.0000 0.0000 0.0000\n  Ke 0.0000 0.0000 0.0000\n  map_Ka cube.png\n  map_Kd cube.png");
				fileSize = bytes.Length;
				GCHandle bufferHandle = AssimpInterop.LockGc(bytes);
				AssetLoaderBase.FilesLoadData[resourceId].AddBuffer(bufferHandle);
				return bufferHandle.AddrOfPinnedObject();
			}
			return IntPtr.Zero;
		}

		[MonoPInvokeCallback(typeof(AssimpInterop.ExistsCallback))]
		private static bool CustomExistsCallback(string resourceFilename, int resourceId)
		{
			return resourceFilename == "cube.mtl";
		}
	}
}
