using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepthFirstScheduler;
using UniGLTF.Zip;
using UniJSON;
using UnityEngine;

namespace UniGLTF
{
	public class ImporterContext : IDisposable
	{
		public struct KeyElapsed
		{
			public string Key;

			public TimeSpan Elapsed;

			public KeyElapsed(string key, TimeSpan elapsed)
			{
				Key = key;
				Elapsed = elapsed;
			}
		}

		public struct MeasureScope : IDisposable
		{
			private Action m_onDispose;

			public MeasureScope(Action onDispose)
			{
				m_onDispose = onDispose;
			}

			public void Dispose()
			{
				m_onDispose();
			}
		}

		private bool m_showSpeedLog;

		public List<KeyElapsed> m_speedReports = new List<KeyElapsed>();

		private IShaderStore m_shaderStore;

		private IMaterialImporter m_materialImporter;

		public string Json;

		public glTF GLTF;

		public IStorage Storage;

		private SerializerTypes _serializerType = SerializerTypes.UniJSON;

		public bool EnableLoadBalancing;

		public GameObject Root;

		public List<Transform> Nodes = new List<Transform>();

		private List<TextureItem> m_textures = new List<TextureItem>();

		private List<Material> m_materials = new List<Material>();

		public List<MeshWithMaterials> Meshes = new List<MeshWithMaterials>();

		public List<AnimationClip> AnimationClips = new List<AnimationClip>();

		public bool ShowSpeedLog
		{
			set
			{
				m_showSpeedLog = value;
			}
		}

		public IShaderStore ShaderStore
		{
			get
			{
				if (m_shaderStore == null)
				{
					m_shaderStore = new ShaderStore(this);
				}
				return m_shaderStore;
			}
		}

		public IMaterialImporter MaterialImporter
		{
			get
			{
				if (m_materialImporter == null)
				{
					m_materialImporter = new MaterialImporter(ShaderStore, (int index) => GetTexture(index));
				}
				return m_materialImporter;
			}
		}

		public SerializerTypes SerializerType
		{
			get
			{
				return _serializerType;
			}
			set
			{
				_serializerType = value;
			}
		}

		public IDisposable MeasureTime(string key)
		{
			Stopwatch sw = Stopwatch.StartNew();
			return new MeasureScope(delegate
			{
				m_speedReports.Add(new KeyElapsed(key, sw.Elapsed));
			});
		}

		public string GetSpeedLog()
		{
			TimeSpan zero = TimeSpan.Zero;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("【SpeedLog】");
			foreach (KeyElapsed speedReport in m_speedReports)
			{
				string key = speedReport.Key;
				TimeSpan elapsed = speedReport.Elapsed;
				stringBuilder.AppendLine($"{key}: {(int)elapsed.TotalMilliseconds}ms");
				zero += speedReport.Elapsed;
			}
			stringBuilder.AppendLine($"total: {(int)zero.TotalMilliseconds}ms");
			return stringBuilder.ToString();
		}

		protected void SetMaterialImporter(IMaterialImporter importer)
		{
			m_materialImporter = importer;
		}

		public ImporterContext(IShaderStore shaderStore)
		{
			m_shaderStore = shaderStore;
		}

		public ImporterContext(IMaterialImporter materialImporter)
		{
			m_materialImporter = materialImporter;
		}

		public ImporterContext()
		{
		}

		public static bool IsGeneratedUniGLTFAndOlderThan(string generatorVersion, int major, int minor)
		{
			if (string.IsNullOrEmpty(generatorVersion))
			{
				return false;
			}
			if (generatorVersion == "UniGLTF")
			{
				return true;
			}
			if (!generatorVersion.StartsWith("UniGLTF-"))
			{
				return false;
			}
			try
			{
				int num = generatorVersion.IndexOf('.');
				int num2 = int.Parse(generatorVersion.Substring(8, num - 8));
				int num3 = int.Parse(generatorVersion.Substring(num + 1));
				if (num2 < major)
				{
					return true;
				}
				if (num3 >= minor)
				{
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogWarningFormat("{0}: {1}", generatorVersion, ex);
				return false;
			}
		}

		public bool IsGeneratedUniGLTFAndOlder(int major, int minor)
		{
			if (GLTF == null)
			{
				return false;
			}
			if (GLTF.asset == null)
			{
				return false;
			}
			return IsGeneratedUniGLTFAndOlderThan(GLTF.asset.generator, major, minor);
		}

		public void Parse(string path)
		{
			Parse(path, File.ReadAllBytes(path));
		}

		public virtual void Parse(string path, byte[] bytes)
		{
			switch (Path.GetExtension(path).ToLower())
			{
			case ".gltf":
				ParseJson(Encoding.UTF8.GetString(bytes), new FileSystemStorage(Path.GetDirectoryName(path)));
				break;
			case ".zip":
			{
				ZipArchiveStorage zipArchiveStorage = ZipArchiveStorage.Parse(bytes);
				CentralDirectoryFileHeader centralDirectoryFileHeader = zipArchiveStorage.Entries.FirstOrDefault((CentralDirectoryFileHeader x) => x.FileName.ToLower().EndsWith(".gltf"));
				if (centralDirectoryFileHeader == null)
				{
					throw new Exception("no gltf in archive");
				}
				byte[] bytes2 = zipArchiveStorage.Extract(centralDirectoryFileHeader);
				string json = Encoding.UTF8.GetString(bytes2);
				ParseJson(json, zipArchiveStorage);
				break;
			}
			case ".glb":
				ParseGlb(bytes);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public void ParseGlb(byte[] bytes)
		{
			List<GlbChunk> list = glbImporter.ParseGlbChunks(bytes);
			if (list.Count != 2)
			{
				throw new Exception("unknown chunk count: " + list.Count);
			}
			if (list[0].ChunkType != GlbChunkType.JSON)
			{
				throw new Exception("chunk 0 is not JSON");
			}
			if (list[1].ChunkType != GlbChunkType.BIN)
			{
				throw new Exception("chunk 1 is not BIN");
			}
			try
			{
				ArraySegment<byte> bytes2 = list[0].Bytes;
				ParseJson(Encoding.UTF8.GetString(bytes2.Array, bytes2.Offset, bytes2.Count), new SimpleStorage(list[1].Bytes));
			}
			catch (StackOverflowException ex)
			{
				throw new Exception("[UniVRM Import Error] json parsing failed, nesting is too deep.\n" + ex);
			}
			catch
			{
				throw;
			}
		}

		public virtual void ParseJson(string json, IStorage storage)
		{
			Json = json;
			Storage = storage;
			if (_serializerType == SerializerTypes.UniJSON)
			{
				Json.ParseAsJson().Deserialize(ref GLTF);
			}
			else if (_serializerType == SerializerTypes.Generated)
			{
				GLTF = GltfDeserializer.Deserialize(json.ParseAsJson());
			}
			else if (_serializerType == SerializerTypes.JsonSerializable)
			{
				GLTF = JsonUtility.FromJson<glTF>(Json);
			}
			if (GLTF.asset.version != "2.0")
			{
				throw new UniGLTFException("unknown gltf version {0}", GLTF.asset.version);
			}
			RestoreOlderVersionValues();
			foreach (glTFBuffer buffer in GLTF.buffers)
			{
				buffer.OpenStorage(storage);
			}
		}

		private void RestoreOlderVersionValues()
		{
			ListTreeNode<JsonValue> listTreeNode = JsonParser.Parse(Json);
			for (int i = 0; i < GLTF.images.Count; i++)
			{
				if (!string.IsNullOrEmpty(GLTF.images[i].name))
				{
					continue;
				}
				try
				{
					string text = listTreeNode["images"][i]["extra"]["name"].Value.GetString();
					if (!string.IsNullOrEmpty(text))
					{
						GLTF.images[i].name = text;
					}
				}
				catch (Exception)
				{
				}
			}
			for (int j = 0; j < GLTF.meshes.Count; j++)
			{
				glTFMesh glTFMesh2 = GLTF.meshes[j];
				try
				{
					for (int k = 0; k < glTFMesh2.primitives.Count; k++)
					{
						glTFPrimitives glTFPrimitives2 = glTFMesh2.primitives[k];
						for (int l = 0; l < glTFPrimitives2.targets.Count; l++)
						{
							string item = listTreeNode["meshes"][j]["primitives"][k]["targets"][l]["extra"]["name"].Value.GetString();
							glTFPrimitives2.extras.targetNames.Add(item);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public void Load(string path)
		{
			byte[] bytes = File.ReadAllBytes(path);
			Load(path, bytes);
		}

		public void Load(string path, byte[] bytes)
		{
			Parse(path, bytes);
			Load();
			Root.name = Path.GetFileNameWithoutExtension(path);
		}

		public virtual ITextureLoader CreateTextureLoader(int index)
		{
			return new TextureLoader(index);
		}

		public void CreateTextureItems(UnityPath imageBaseDir = default(UnityPath))
		{
			if (!m_textures.Any())
			{
				for (int i = 0; i < GLTF.textures.Count; i++)
				{
					TextureItem textureItem = null;
					textureItem = new TextureItem(i, CreateTextureLoader(i));
					AddTexture(textureItem);
				}
			}
		}

		public void Load()
		{
			LoadAsync().ExecuteAll();
		}

		[Obsolete("Action<Unit> to Action")]
		public IEnumerator LoadCoroutine(Action<Unit> onLoaded, Action<Exception> onError = null)
		{
			return LoadCoroutine((Action)delegate
			{
				onLoaded(Unit.Default);
			}, onError);
		}

		public IEnumerator LoadCoroutine(Action<Exception> onError = null)
		{
			return LoadCoroutine((Action)delegate
			{
			}, onError);
		}

		public IEnumerator LoadCoroutine(Action onLoaded, Action<Exception> onError = null)
		{
			if (onLoaded == null)
			{
				onLoaded = delegate
				{
				};
			}
			if (onError == null)
			{
				onError = UnityEngine.Debug.LogError;
			}
			Schedulable<Unit> self = LoadAsync();
			foreach (ISchedulable x in self.GetRoot().Traverse())
			{
				while (x.Execute() == ExecutionStatus.Continue)
				{
					yield return null;
				}
			}
			onLoaded();
		}

		[Obsolete("Action<Unit> to Action")]
		public void LoadAsync(Action<Unit> onLoaded, Action<Exception> onError = null)
		{
			LoadAsync((Action)delegate
			{
				onLoaded(Unit.Default);
			}, onError);
		}

		public void LoadAsync(Action onLoaded, Action<Exception> onError = null)
		{
			if (onError == null)
			{
				onError = UnityEngine.Debug.LogError;
			}
			LoadAsync().Subscribe(Scheduler.MainThread, delegate
			{
				onLoaded();
			}, onError);
		}

		public async Task<GameObject> LoadAsyncTask()
		{
			await LoadAsync().ToTask();
			return Root;
		}

		protected virtual Schedulable<Unit> LoadAsync()
		{
			return Schedulable.Create().AddTask(Scheduler.ThreadPool, delegate
			{
				if (m_textures.Count == 0)
				{
					CreateTextureItems();
				}
			}).ContinueWithCoroutine(Scheduler.ThreadPool, TexturesProcessOnAnyThread)
				.ContinueWithCoroutine(Scheduler.MainThread, TexturesProcessOnMainThread)
				.ContinueWithCoroutine(Scheduler.MainThread, LoadMaterials)
				.OnExecute(Scheduler.ThreadPool, delegate(Schedulable<Unit> parent)
				{
					if (GLTF.extensionsRequired.Contains("KHR_draco_mesh_compression"))
					{
						throw new UniGLTFNotSupportedException("draco is not supported");
					}
					MeshImporter meshImporter = new MeshImporter();
					for (int i = 0; i < GLTF.meshes.Count; i++)
					{
						int index = i;
						parent.AddTask(Scheduler.ThreadPool, delegate
						{
							using (MeasureTime("ReadMesh"))
							{
								return meshImporter.ReadMesh(this, index);
							}
						}).ContinueWithCoroutine<MeshWithMaterials>(Scheduler.MainThread, (MeshImporter.MeshContext x) => BuildMesh(x, index)).ContinueWith(Scheduler.ThreadPool, delegate(MeshWithMaterials x)
						{
							Meshes.Add(x);
						});
					}
				})
				.ContinueWithCoroutine(Scheduler.MainThread, LoadNodes)
				.ContinueWithCoroutine(Scheduler.MainThread, BuildHierarchy)
				.ContinueWith(Scheduler.MainThread, delegate
				{
					using (MeasureTime("AnimationImporter"))
					{
						AnimationImporter.ImportAnimation(this);
					}
				})
				.ContinueWithCoroutine(Scheduler.MainThread, OnLoadModel)
				.ContinueWith(Scheduler.CurrentThread, delegate
				{
					if (m_showSpeedLog)
					{
						UnityEngine.Debug.Log(GetSpeedLog());
					}
					return Unit.Default;
				});
		}

		protected virtual IEnumerator OnLoadModel()
		{
			Root.name = "GLTF";
			yield break;
		}

		private IEnumerator TexturesProcessOnAnyThread()
		{
			using (MeasureTime("TexturesProcessOnAnyThread"))
			{
				foreach (TextureItem texture in GetTextures())
				{
					texture.ProcessOnAnyThread(GLTF, Storage);
					yield return null;
				}
			}
		}

		private IEnumerator TexturesProcessOnMainThread()
		{
			using (MeasureTime("TexturesProcessOnMainThread"))
			{
				foreach (TextureItem texture in GetTextures())
				{
					yield return texture.ProcessOnMainThreadCoroutine(GLTF);
				}
			}
		}

		private IEnumerator LoadMaterials()
		{
			using (MeasureTime("LoadMaterials"))
			{
				if (GLTF.materials == null || !GLTF.materials.Any())
				{
					AddMaterial(MaterialImporter.CreateMaterial(0, null, hasVertexColor: false));
				}
				else
				{
					for (int i = 0; i < GLTF.materials.Count; i++)
					{
						AddMaterial(MaterialImporter.CreateMaterial(i, GLTF.materials[i], GLTF.MaterialHasVertexColor(i)));
					}
				}
			}
			yield return null;
		}

		private IEnumerator BuildMesh(MeshImporter.MeshContext x, int i)
		{
			using (MeasureTime("BuildMesh"))
			{
				MeshWithMaterials meshWithMaterials;
				if (EnableLoadBalancing)
				{
					IEnumerator buildMesh = MeshImporter.BuildMeshCoroutine(this, x);
					yield return buildMesh;
					meshWithMaterials = buildMesh.Current as MeshWithMaterials;
				}
				else
				{
					meshWithMaterials = MeshImporter.BuildMesh(this, x);
				}
				Mesh mesh = meshWithMaterials.Mesh;
				if (string.IsNullOrEmpty(mesh.name))
				{
					mesh.name = $"UniGLTF import#{i}";
				}
				string name = mesh.name;
				int num = 1;
				while (Meshes.Any((MeshWithMaterials y) => y.Mesh.name == mesh.name))
				{
					mesh.name = $"{name}({num})";
					num++;
				}
				yield return meshWithMaterials;
			}
		}

		private IEnumerator LoadMeshes()
		{
			MeshImporter meshImporter = new MeshImporter();
			int i = 0;
			while (i < GLTF.meshes.Count)
			{
				MeshImporter.MeshContext meshContext = meshImporter.ReadMesh(this, i);
				MeshWithMaterials meshWithMaterials = MeshImporter.BuildMesh(this, meshContext);
				Mesh mesh = meshWithMaterials.Mesh;
				if (string.IsNullOrEmpty(mesh.name))
				{
					mesh.name = $"UniGLTF import#{i}";
				}
				Meshes.Add(meshWithMaterials);
				yield return null;
				int num = i + 1;
				i = num;
			}
		}

		private IEnumerator LoadNodes()
		{
			using (MeasureTime("LoadNodes"))
			{
				for (int i = 0; i < GLTF.nodes.Count; i++)
				{
					Nodes.Add(NodeImporter.ImportNode(GLTF.nodes[i], i).transform);
				}
			}
			yield return null;
		}

		private IEnumerator BuildHierarchy()
		{
			using (MeasureTime("BuildHierarchy"))
			{
				List<NodeImporter.TransformWithSkin> list = new List<NodeImporter.TransformWithSkin>();
				for (int i = 0; i < Nodes.Count; i++)
				{
					list.Add(NodeImporter.BuildHierarchy(this, i));
				}
				NodeImporter.FixCoordinate(this, list);
				for (int j = 0; j < list.Count; j++)
				{
					NodeImporter.SetupSkinning(this, list, j);
				}
				if (Root == null)
				{
					Root = new GameObject("_root_");
				}
				int[] rootnodes = GLTF.rootnodes;
				foreach (int index in rootnodes)
				{
					list[index].Transform.SetParent(Root.transform, worldPositionStays: false);
				}
			}
			yield return null;
		}

		public IList<TextureItem> GetTextures()
		{
			return m_textures;
		}

		public TextureItem GetTexture(int i)
		{
			if (i < 0 || i >= m_textures.Count)
			{
				return null;
			}
			return m_textures[i];
		}

		public void AddTexture(TextureItem item)
		{
			m_textures.Add(item);
		}

		public void AddMaterial(Material material)
		{
			string name = material.name;
			int num = 2;
			while (m_materials.Any((Material x) => x.name == material.name))
			{
				material.name = $"{name}({num++})";
			}
			m_materials.Add(material);
		}

		public IList<Material> GetMaterials()
		{
			return m_materials;
		}

		public Material GetMaterial(int index)
		{
			if (index < 0)
			{
				return null;
			}
			if (index >= m_materials.Count)
			{
				return null;
			}
			return m_materials[index];
		}

		public void ShowMeshes()
		{
			foreach (MeshWithMaterials mesh in Meshes)
			{
				foreach (Renderer renderer in mesh.Renderers)
				{
					renderer.enabled = true;
				}
			}
		}

		public void EnableUpdateWhenOffscreen()
		{
			foreach (MeshWithMaterials mesh in Meshes)
			{
				foreach (Renderer renderer in mesh.Renderers)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
					if (skinnedMeshRenderer != null)
					{
						skinnedMeshRenderer.updateWhenOffscreen = true;
					}
				}
			}
		}

		protected virtual IEnumerable<UnityEngine.Object> ObjectsForSubAsset()
		{
			HashSet<Texture2D> hashSet = new HashSet<Texture2D>();
			foreach (Texture2D item in m_textures.SelectMany((TextureItem y) => y.GetTexturesForSaveAssets()))
			{
				if (!hashSet.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			foreach (Texture2D item2 in hashSet)
			{
				yield return item2;
			}
			foreach (Material material in m_materials)
			{
				yield return material;
			}
			foreach (MeshWithMaterials mesh in Meshes)
			{
				yield return mesh.Mesh;
			}
			foreach (AnimationClip animationClip in AnimationClips)
			{
				yield return animationClip;
			}
		}

		[Obsolete("Use Dispose for runtime loader resource management")]
		public void Destroy(bool destroySubAssets)
		{
			if (Root != null)
			{
				UnityEngine.Object.DestroyImmediate(Root);
			}
		}

		public void Dispose()
		{
			DestroyRootAndResources();
		}

		public void DestroyRootAndResources()
		{
			if (!Application.isPlaying)
			{
				UnityEngine.Debug.LogWarningFormat("Dispose called in editor mode. This function is for runtime");
			}
			if (Root != null)
			{
				UnityEngine.Object.Destroy(Root);
			}
			foreach (UnityEngine.Object item in ObjectsForSubAsset())
			{
				UnityEngine.Object.DestroyImmediate(item, allowDestroyingAssets: true);
			}
		}
	}
}
