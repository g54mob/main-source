using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class MipmapVisualiser : MonoBehaviour
	{
		[SerializeField]
		private Color[] _mipMapColors;

		[SerializeField]
		private Material _referenceMaterial;

		private readonly Dictionary<int, Material> _materials = new Dictionary<int, Material>();

		private readonly Dictionary<int, Texture2D> _textures = new Dictionary<int, Texture2D>();

		private readonly Dictionary<GameObject, Material[]> _allGameObjects = new Dictionary<GameObject, Material[]>();

		public bool IsActive { get; private set; }

		private void Start()
		{
			_textures.Add(2, CreateTexture(2));
			_textures.Add(4, CreateTexture(4));
			_textures.Add(8, CreateTexture(8));
			_textures.Add(16, CreateTexture(16));
			_textures.Add(32, CreateTexture(32));
			_textures.Add(64, CreateTexture(64));
			_textures.Add(128, CreateTexture(128));
			_textures.Add(256, CreateTexture(256));
			_textures.Add(512, CreateTexture(512));
			_textures.Add(1024, CreateTexture(1024));
			_textures.Add(2048, CreateTexture(2048));
			_materials.Add(2, CreateMaterial(2));
			_materials.Add(4, CreateMaterial(4));
			_materials.Add(8, CreateMaterial(8));
			_materials.Add(16, CreateMaterial(16));
			_materials.Add(32, CreateMaterial(32));
			_materials.Add(64, CreateMaterial(64));
			_materials.Add(128, CreateMaterial(128));
			_materials.Add(256, CreateMaterial(256));
			_materials.Add(512, CreateMaterial(512));
			_materials.Add(1024, CreateMaterial(1024));
			_materials.Add(2048, CreateMaterial(2048));
			CollectAllMaterials();
			ReplaceAllMaterials();
		}

		private void OnDestroy()
		{
			RevertAllMaterials();
		}

		private void CollectAllMaterials()
		{
			_allGameObjects.Clear();
			GameObject[] array = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
			for (int i = 0; i < array.Length; i++)
			{
				Renderer component = array[i].GetComponent<Renderer>();
				if (!(component == null))
				{
					_allGameObjects[array[i]] = component.materials;
				}
			}
		}

		private void ReplaceAllMaterials()
		{
			foreach (KeyValuePair<GameObject, Material[]> allGameObject in _allGameObjects)
			{
				Renderer component = allGameObject.Key.GetComponent<Renderer>();
				Material[] materials = component.materials;
				for (int i = 0; i < allGameObject.Value.Length; i++)
				{
					if (!(materials[i] == null) && !(materials[i].mainTexture == null))
					{
						int width = materials[i].mainTexture.width;
						_materials.TryGetValue(width, out var value);
						materials[i] = value;
					}
				}
				component.materials = materials;
			}
		}

		private void RevertAllMaterials()
		{
			foreach (KeyValuePair<GameObject, Material[]> allGameObject in _allGameObjects)
			{
				allGameObject.Key.GetComponent<Renderer>().materials = allGameObject.Value;
			}
		}

		private Texture2D CreateTexture(int width)
		{
			Texture2D texture2D = new Texture2D(width, width, TextureFormat.RGB24, mipChain: true);
			int num = width;
			int num2 = 0;
			while (true)
			{
				FillTextureColor(texture2D, num2, _mipMapColors[num2]);
				if (num == 1)
				{
					break;
				}
				num2++;
				num /= 2;
			}
			texture2D.Apply(updateMipmaps: false);
			return texture2D;
		}

		private Material CreateMaterial(int width)
		{
			_textures.TryGetValue(width, out var value);
			Material material = new Material(_referenceMaterial);
			material.SetTexture("_MainTex", value);
			return material;
		}

		private void FillTextureColor(Texture2D tex, int mipmap, Color color)
		{
			Color[] pixels = tex.GetPixels(mipmap);
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = color;
			}
			tex.SetPixels(pixels, mipmap);
		}

		public bool IsPowerOfTwo(int x)
		{
			if (x != 0)
			{
				return (x & (~x + 1)) == x;
			}
			return false;
		}
	}
}
