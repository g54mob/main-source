using System;
using System.Collections.Generic;
using Assets.Scripts.Terrain.Pooling;
using ModApi.Common.Collections;
using ModApi.Common.SimpleTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush
{
	public class BrushSphereScript : MonoBehaviour
	{
		private class BrushPixelDataCache
		{
			private List<BrushPixelData> _brushPixelData;

			private int _brushPixelDataIndex;

			private List<BrushPixelFaceData> _brushPixelFaceData;

			private int _brushPixelFaceDataIndex;

			private List<BrushPixel> _brushPixels;

			private int _brushPixelsIndex;

			public BrushPixelDataCache()
			{
				_brushPixelData = new List<BrushPixelData>(1);
				_brushPixelFaceData = new List<BrushPixelFaceData>(3);
				_brushPixels = new List<BrushPixel>(1024);
			}

			public void Cleanup()
			{
				foreach (BrushPixelFaceData brushPixelFaceDatum in _brushPixelFaceData)
				{
					brushPixelFaceDatum.Cleanup();
				}
			}

			public BrushPixel GetBrushPixel(int index, Vector2i pixelPosition, float strength)
			{
				BrushPixel brushPixel;
				if (_brushPixelsIndex < _brushPixels.Count)
				{
					brushPixel = _brushPixels[_brushPixelsIndex];
				}
				else
				{
					_brushPixels.Add(brushPixel = new BrushPixel());
				}
				_brushPixelsIndex++;
				brushPixel.Initialize(index, pixelPosition, strength);
				return brushPixel;
			}

			public BrushPixelData GetBrushPixelData()
			{
				BrushPixelData brushPixelData;
				if (_brushPixelDataIndex < _brushPixelData.Count)
				{
					brushPixelData = _brushPixelData[_brushPixelDataIndex];
				}
				else
				{
					_brushPixelData.Add(brushPixelData = new BrushPixelData());
				}
				_brushPixelDataIndex++;
				brushPixelData.Initialize();
				return brushPixelData;
			}

			public BrushPixelFaceData GetBrushPixelFaceData(int faceIndex, Texture2D texture, Vector2i brushCenterPixelPosition)
			{
				BrushPixelFaceData brushPixelFaceData;
				if (_brushPixelFaceDataIndex < _brushPixelFaceData.Count)
				{
					brushPixelFaceData = _brushPixelFaceData[_brushPixelFaceDataIndex];
				}
				else
				{
					_brushPixelFaceData.Add(brushPixelFaceData = new BrushPixelFaceData());
				}
				_brushPixelFaceDataIndex++;
				brushPixelFaceData.Initialize(faceIndex, texture, brushCenterPixelPosition);
				return brushPixelFaceData;
			}

			public void PrepareCache()
			{
				_brushPixelDataIndex = 0;
				_brushPixelFaceDataIndex = 0;
				_brushPixelsIndex = 0;
			}
		}

		private static readonly Quaternion[] _faceRotations = new Quaternion[6]
		{
			Quaternion.Euler(0f, 180f, 0f),
			Quaternion.identity,
			Quaternion.Euler(0f, 90f, -90f),
			Quaternion.Euler(0f, 90f, 90f),
			Quaternion.Euler(0f, 90f, 0f),
			Quaternion.Euler(0f, -90f, 0f)
		};

		private static readonly Quaternion[] _faceRotationsInverse = new Quaternion[6]
		{
			Quaternion.Inverse(_faceRotations[0]),
			Quaternion.Inverse(_faceRotations[1]),
			Quaternion.Inverse(_faceRotations[2]),
			Quaternion.Inverse(_faceRotations[3]),
			Quaternion.Inverse(_faceRotations[4]),
			Quaternion.Inverse(_faceRotations[5])
		};

		private BrushPixelDataCache _cache;

		private Texture2D _colorGradientTexture;

		private BrushSphereFaceScript[] _faces;

		private Mesh[] _meshes;

		private Texture2D[] _textures;

		private int _textureSize;

		private int _textureSizeMinusOne;

		public bool CubemapLoaded
		{
			get
			{
				if (_textures != null)
				{
					return _textures[0] != null;
				}
				return false;
			}
		}

		public int TextureSize
		{
			get
			{
				return _textureSize;
			}
			private set
			{
				_textureSize = value;
				_textureSizeMinusOne = value - 1;
			}
		}

		public CelestialBodyViewerScript Viewer { get; private set; }

		public void BeginBrushEditing()
		{
		}

		public void EndBrushEditing()
		{
			CleanupFaceTextures();
			CleanupGradientTexture();
		}

		public BrushPixelData GetBrushPixelData(Vector3 sphereNormalBrushCenter, float brushSize)
		{
			_cache.PrepareCache();
			BrushPixelData brushPixelData = _cache.GetBrushPixelData();
			for (int i = 0; i < 6; i++)
			{
				Vector3 vector = _faceRotationsInverse[i] * sphereNormalBrushCenter;
				if (!(vector.x >= 0f))
				{
					Vector3 vector2 = vector / (0f - vector.x);
					Vector2i brushCenterPixelPosition = new Vector2i(Mathf.RoundToInt((vector2.z * 0.5f + 0.5f) * (float)_textureSizeMinusOne), Mathf.RoundToInt((vector2.y * 0.5f + 0.5f) * (float)_textureSizeMinusOne));
					BrushPixelFaceData brushPixelFaceData = _cache.GetBrushPixelFaceData(i, _textures[i], brushCenterPixelPosition);
					GetBrushPixels(brushPixelFaceData, vector, brushSize);
					if (brushPixelFaceData.PixelData.Count > 0)
					{
						brushPixelData.Faces.Add(brushPixelFaceData);
					}
				}
			}
			return brushPixelData;
		}

		public ColorRGB24[] GetTextureData(int faceIndex)
		{
			if (faceIndex >= 0)
			{
				Texture2D[] textures = _textures;
				if (faceIndex < ((textures != null) ? textures.Length : 0))
				{
					return _textures[faceIndex].GetRawTextureData<ColorRGB24>().ToArray();
				}
			}
			object arg = faceIndex;
			Texture2D[] textures2 = _textures;
			throw new IndexOutOfRangeException($"{arg} not in range of 0 to {((textures2 == null) ? 1 : textures2.Length) - 1}");
		}

		public void HideBrushSphere()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Initialize(CelestialBodyViewerScript viewer)
		{
			Viewer = viewer;
			_textures = new Texture2D[6];
			_cache = new BrushPixelDataCache();
			InitializeMeshes();
			InitializeFaces();
		}

		public Texture2D SaveCubemap()
		{
			int textureSize = TextureSize;
			Texture2D texture2D = new Texture2D(textureSize * 6, textureSize, TextureFormat.RGB24, mipChain: false, linear: true);
			NativeArray<ColorRGB24> rawTextureData = texture2D.GetRawTextureData<ColorRGB24>();
			for (int i = 0; i < 6; i++)
			{
				NativeArray<ColorRGB24> rawTextureData2 = _textures[i].GetRawTextureData<ColorRGB24>();
				for (int j = 0; j < textureSize; j++)
				{
					int num = j * textureSize * 6;
					for (int k = 0; k < textureSize; k++)
					{
						int num2 = i * textureSize + k;
						rawTextureData[num + num2] = rawTextureData2[j * textureSize + k];
					}
				}
			}
			return texture2D;
		}

		public void SetBrushInfo(Vector3? brushPosition, float brushRadius)
		{
			BrushSphereFaceScript[] faces = _faces;
			for (int i = 0; i < faces.Length; i++)
			{
				faces[i].SetBrushInfo(brushPosition, brushRadius);
			}
		}

		public void SetTextureData(int faceIndex, ColorRGB24[] textureData)
		{
			if (faceIndex >= 0)
			{
				Texture2D[] textures = _textures;
				if (faceIndex < ((textures != null) ? textures.Length : 0))
				{
					_textures[faceIndex].SetPixelData(textureData, 0);
					_textures[faceIndex].Apply(updateMipmaps: true);
					return;
				}
			}
			object arg = faceIndex;
			Texture2D[] textures2 = _textures;
			throw new IndexOutOfRangeException($"{arg} not in range of 0 to {((textures2 == null) ? 1 : textures2.Length) - 1}");
		}

		public void ShowBrushSphere()
		{
			float num = (float)Viewer.PlanetScript.QuadSphere.PlanetData.Radius;
			base.transform.localScale = new Vector3(num, num, num);
			base.gameObject.SetActive(value: true);
		}

		public void UpdateFaceTextures(Texture2D cubemap)
		{
			CleanupFaceTextures();
			if (cubemap == null)
			{
				return;
			}
			int num = (TextureSize = cubemap.height);
			RawTextureDataWrapperRGB24 rawTextureDataWrapperRGB = RawTextureDataWrapperRGB24.Create(cubemap);
			for (int i = 0; i < 6; i++)
			{
				Texture2D texture2D = new Texture2D(num, num, TextureFormat.RGB24, mipChain: true, linear: true);
				texture2D.wrapMode = TextureWrapMode.Clamp;
				texture2D.filterMode = FilterMode.Bilinear;
				NativeArray<ColorRGB24> rawTextureData = texture2D.GetRawTextureData<ColorRGB24>();
				for (int j = 0; j < num; j++)
				{
					int num2 = j * num * 6;
					for (int k = 0; k < num; k++)
					{
						int num3 = i * num + k;
						rawTextureData[j * num + k] = rawTextureDataWrapperRGB[num2 + num3];
					}
				}
				texture2D.Apply(updateMipmaps: true);
				_textures[i] = texture2D;
				_faces[i].SetMainTexture(texture2D);
			}
		}

		public void UpdateGradient(Gradient gradient)
		{
			CleanupGradientTexture();
			if (gradient == null)
			{
				return;
			}
			int num = 2;
			int num2 = 256;
			float num3 = num2 - 1;
			_colorGradientTexture = new Texture2D(num2, num, TextureFormat.RGBA32, mipChain: true, linear: false);
			_colorGradientTexture.wrapMode = TextureWrapMode.Clamp;
			_colorGradientTexture.filterMode = FilterMode.Bilinear;
			NativeArray<Color32> rawTextureData = _colorGradientTexture.GetRawTextureData<Color32>();
			for (int i = 0; i < num2; i++)
			{
				Color color = gradient.Evaluate((float)i / num3);
				for (int j = 0; j < num; j++)
				{
					rawTextureData[j * num2 + i] = color;
				}
			}
			_colorGradientTexture.Apply(updateMipmaps: true);
			BrushSphereFaceScript[] faces = _faces;
			for (int k = 0; k < faces.Length; k++)
			{
				faces[k].SetGradientTexture(_colorGradientTexture);
			}
		}

		private void CleanupFaceTextures()
		{
			_cache.Cleanup();
			if (_faces != null)
			{
				BrushSphereFaceScript[] faces = _faces;
				for (int i = 0; i < faces.Length; i++)
				{
					faces[i].SetMainTexture(Texture2D.grayTexture);
				}
			}
			if (_textures == null)
			{
				return;
			}
			for (int j = 0; j < _textures.Length; j++)
			{
				if (_textures[j] != null)
				{
					UnityEngine.Object.Destroy(_textures[j]);
					_textures[j] = null;
				}
			}
		}

		private void CleanupGradientTexture()
		{
			if (_faces != null)
			{
				BrushSphereFaceScript[] faces = _faces;
				for (int i = 0; i < faces.Length; i++)
				{
					faces[i].SetGradientTexture(Texture2D.grayTexture);
				}
			}
			if (_colorGradientTexture != null)
			{
				UnityEngine.Object.Destroy(_colorGradientTexture);
				_colorGradientTexture = null;
			}
		}

		private void GetBrushPixel(BrushPixelFaceData face, Vector2i position, Vector3 brushCenter, float brushSize)
		{
			float magnitude = (new Vector3(-1f, (float)position.y / (float)_textureSizeMinusOne * 2f - 1f, (float)position.x / (float)_textureSizeMinusOne * 2f - 1f).normalized - brushCenter).magnitude;
			float num = 1f - magnitude / brushSize;
			if (num > 0f)
			{
				BrushPixel brushPixel = _cache.GetBrushPixel(position.y * _textureSize + position.x, position, num);
				face.PixelData.Add(brushPixel);
			}
		}

		private void GetBrushPixels(BrushPixelFaceData face, Vector3 brushCenter, float brushSize)
		{
			Vector2i brushCenterPixelPosition = face.BrushCenterPixelPosition;
			int num = 0;
			if (brushCenterPixelPosition.x < 0)
			{
				num = -brushCenterPixelPosition.x;
			}
			else if (brushCenterPixelPosition.x > _textureSizeMinusOne)
			{
				num = brushCenterPixelPosition.x - _textureSizeMinusOne;
			}
			if (brushCenterPixelPosition.y < 0)
			{
				num = Mathf.Max(num, -brushCenterPixelPosition.y);
			}
			else if (brushCenterPixelPosition.y > _textureSizeMinusOne)
			{
				num = Mathf.Max(num, brushCenterPixelPosition.y - _textureSizeMinusOne);
			}
			if ((float)num < (float)_textureSize * 0.5f)
			{
				GetBrushPixels(face, brushCenter, brushSize, num);
			}
		}

		private void GetBrushPixels(BrushPixelFaceData face, Vector3 brushCenter, float brushSize, int pixelOffset)
		{
			Vector2i brushCenterPixelPosition = face.BrushCenterPixelPosition;
			int count = face.PixelData.Count;
			if (pixelOffset == 0)
			{
				GetBrushPixel(face, brushCenterPixelPosition, brushCenter, brushSize);
			}
			else
			{
				int num = brushCenterPixelPosition.x - pixelOffset;
				int num2 = brushCenterPixelPosition.y - pixelOffset;
				int num3 = brushCenterPixelPosition.x + pixelOffset;
				int num4 = brushCenterPixelPosition.y + pixelOffset;
				if (num2 < _textureSize && num4 >= 0)
				{
					int num5 = ((num2 >= 0) ? num2 : 0);
					int num6 = ((num4 > _textureSizeMinusOne) ? _textureSizeMinusOne : num4);
					if (num >= 0 && num < _textureSize)
					{
						for (int i = num5; i <= num6; i++)
						{
							GetBrushPixel(face, new Vector2i(num, i), brushCenter, brushSize);
						}
					}
					if (num3 >= 0 && num3 < _textureSize)
					{
						for (int j = num5; j <= num6; j++)
						{
							GetBrushPixel(face, new Vector2i(num3, j), brushCenter, brushSize);
						}
					}
				}
				if (num < _textureSizeMinusOne && num3 > 0)
				{
					int num7 = Mathf.Clamp(num + 1, 0, _textureSizeMinusOne);
					int num8 = Mathf.Clamp(num3 - 1, 0, _textureSizeMinusOne);
					if (num2 >= 0 && num2 < _textureSize)
					{
						for (int k = num7; k <= num8; k++)
						{
							GetBrushPixel(face, new Vector2i(k, num2), brushCenter, brushSize);
						}
					}
					if (num4 >= 0 && num4 < _textureSize)
					{
						for (int l = num7; l <= num8; l++)
						{
							GetBrushPixel(face, new Vector2i(l, num4), brushCenter, brushSize);
						}
					}
				}
			}
			if (face.PixelData.Count > count)
			{
				GetBrushPixels(face, brushCenter, brushSize, ++pixelOffset);
			}
		}

		private void InitializeFaces()
		{
			_faces = new BrushSphereFaceScript[6];
			for (int i = 0; i < 6; i++)
			{
				BrushSphereFaceScript brushSphereFaceScript = Game.Instance.ResourceLoader.InstantiatePrefab<BrushSphereFaceScript>("PlanetStudio/Prefabs/BrushSphereFace");
				brushSphereFaceScript.transform.SetParent(base.transform, worldPositionStays: false);
				brushSphereFaceScript.Initialize();
				brushSphereFaceScript.SetMesh(_meshes[i]);
				brushSphereFaceScript.SetMainTexture(Texture2D.grayTexture);
				brushSphereFaceScript.SetGradientTexture(Texture2D.grayTexture);
				_faces[i] = brushSphereFaceScript;
			}
		}

		private void InitializeMeshes()
		{
			int num = 64;
			int num2 = num * num;
			float num3 = num - 1;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			Vector2[] array3 = new Vector2[num2];
			int[] quadMeshTriangles = QuadSpherePoolManager.Instance.GetQuadMeshTriangles(num2);
			_meshes = new Mesh[6];
			for (int i = 0; i < 6; i++)
			{
				Quaternion quaternion = _faceRotations[i];
				int num4 = 0;
				for (int j = 0; j < num; j++)
				{
					for (int k = 0; k < num; k++)
					{
						float num5 = (float)k / num3;
						float num6 = (float)j / num3;
						float z = num5 * 2f - 1f;
						float y = num6 * 2f - 1f;
						Vector3 vector = quaternion * new Vector3(-1f, y, z);
						vector.Normalize();
						array[num4] = vector;
						array2[num4] = vector;
						array3[num4] = new Vector2(num5, num6);
						num4++;
					}
				}
				Mesh mesh = new Mesh();
				mesh.name = $"BrushSphereMesh{i}";
				mesh.vertices = array;
				mesh.normals = array2;
				mesh.uv = array3;
				mesh.triangles = quadMeshTriangles;
				_meshes[i] = mesh;
			}
		}
	}
}
