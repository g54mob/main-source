using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTF : JsonSerializableBase, IEquatable<glTF>
	{
		[JsonSchema(Required = true)]
		public glTFAssets asset = new glTFAssets();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFBuffer> buffers = new List<glTFBuffer>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFBufferView> bufferViews = new List<glTFBufferView>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFAccessor> accessors = new List<glTFAccessor>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFTexture> textures = new List<glTFTexture>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFTextureSampler> samplers = new List<glTFTextureSampler>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFImage> images = new List<glTFImage>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFMaterial> materials = new List<glTFMaterial>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFMesh> meshes = new List<glTFMesh>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFNode> nodes = new List<glTFNode>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFSkin> skins = new List<glTFSkin>();

		[JsonSchema(Dependencies = new string[] { "scenes" }, Minimum = 0.0)]
		public int scene;

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<gltfScene> scenes = new List<gltfScene>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFAnimation> animations = new List<glTFAnimation>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<glTFCamera> cameras = new List<glTFCamera>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<string> extensionsUsed = new List<string>();

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		public List<string> extensionsRequired = new List<string>();

		public glTF_extensions extensions = new glTF_extensions();

		public gltf_extras extras = new gltf_extras();

		private static Utf8String s_extensions = Utf8String.From("extensions");

		public int[] rootnodes => scenes[scene].nodes;

		public int AddBuffer(IBytesBuffer bytesBuffer)
		{
			int count = buffers.Count;
			buffers.Add(new glTFBuffer(bytesBuffer));
			return count;
		}

		public int AddBufferView(glTFBufferView view)
		{
			int count = bufferViews.Count;
			bufferViews.Add(view);
			return count;
		}

		private T[] GetAttrib<T>(glTFAccessor accessor, glTFBufferView view) where T : struct
		{
			return GetAttrib<T>(accessor.count, accessor.byteOffset, view);
		}

		private T[] GetAttrib<T>(int count, int byteOffset, glTFBufferView view) where T : struct
		{
			T[] array = new T[count];
			ArraySegment<byte> bytes = buffers[view.buffer].GetBytes();
			new ArraySegment<byte>(bytes.Array, bytes.Offset + view.byteOffset + byteOffset, count * view.byteStride).MarshalCopyTo(array);
			return array;
		}

		public ArraySegment<byte> GetViewBytes(int bufferView)
		{
			glTFBufferView glTFBufferView2 = bufferViews[bufferView];
			ArraySegment<byte> bytes = buffers[glTFBufferView2.buffer].GetBytes();
			return new ArraySegment<byte>(bytes.Array, bytes.Offset + glTFBufferView2.byteOffset, glTFBufferView2.byteLength);
		}

		private IEnumerable<int> _GetIndices(glTFAccessor accessor, out int count)
		{
			count = accessor.count;
			glTFBufferView view = bufferViews[accessor.bufferView];
			return accessor.componentType switch
			{
				glComponentType.UNSIGNED_BYTE => ((IEnumerable<byte>)GetAttrib<byte>(accessor, view)).Select((Func<byte, int>)((byte x) => x)), 
				glComponentType.UNSIGNED_SHORT => ((IEnumerable<ushort>)GetAttrib<ushort>(accessor, view)).Select((Func<ushort, int>)((ushort x) => x)), 
				glComponentType.UNSIGNED_INT => from x in GetAttrib<uint>(accessor, view)
					select (int)x, 
				_ => throw new NotImplementedException("GetIndices: unknown componenttype: " + accessor.componentType), 
			};
		}

		private IEnumerable<int> _GetIndices(glTFBufferView view, int count, int byteOffset, glComponentType componentType)
		{
			return componentType switch
			{
				glComponentType.UNSIGNED_BYTE => ((IEnumerable<byte>)GetAttrib<byte>(count, byteOffset, view)).Select((Func<byte, int>)((byte x) => x)), 
				glComponentType.UNSIGNED_SHORT => ((IEnumerable<ushort>)GetAttrib<ushort>(count, byteOffset, view)).Select((Func<ushort, int>)((ushort x) => x)), 
				glComponentType.UNSIGNED_INT => from x in GetAttrib<uint>(count, byteOffset, view)
					select (int)x, 
				_ => throw new NotImplementedException("GetIndices: unknown componenttype: " + componentType), 
			};
		}

		public int[] GetIndices(int accessorIndex)
		{
			int count;
			IEnumerable<int> enumerable = _GetIndices(accessors[accessorIndex], out count);
			int[] array = new int[count];
			IEnumerator<int> enumerator = enumerable.GetEnumerator();
			for (int i = 0; i < count; i += 3)
			{
				enumerator.MoveNext();
				array[i + 2] = enumerator.Current;
				enumerator.MoveNext();
				array[i + 1] = enumerator.Current;
				enumerator.MoveNext();
				array[i] = enumerator.Current;
			}
			return array;
		}

		public T[] GetArrayFromAccessor<T>(int accessorIndex) where T : struct
		{
			glTFAccessor glTFAccessor2 = accessors[accessorIndex];
			if (glTFAccessor2.count <= 0)
			{
				return new T[0];
			}
			T[] array = ((glTFAccessor2.bufferView != -1) ? GetAttrib<T>(glTFAccessor2, bufferViews[glTFAccessor2.bufferView]) : new T[glTFAccessor2.count]);
			glTFSparse sparse = glTFAccessor2.sparse;
			if (sparse != null && sparse.count > 0)
			{
				IEnumerable<int> enumerable = _GetIndices(bufferViews[sparse.indices.bufferView], sparse.count, sparse.indices.byteOffset, sparse.indices.componentType);
				T[] attrib = GetAttrib<T>(sparse.count, sparse.values.byteOffset, bufferViews[sparse.values.bufferView]);
				IEnumerator<int> enumerator = enumerable.GetEnumerator();
				for (int i = 0; i < sparse.count; i++)
				{
					enumerator.MoveNext();
					array[enumerator.Current] = attrib[i];
				}
			}
			return array;
		}

		public glTFTextureSampler GetSampler(int index)
		{
			if (samplers.Count == 0)
			{
				samplers.Add(new glTFTextureSampler());
			}
			return samplers[index];
		}

		public int GetImageIndexFromTextureIndex(int textureIndex)
		{
			return textures[textureIndex].source;
		}

		public glTFImage GetImageFromTextureIndex(int textureIndex)
		{
			return images[GetImageIndexFromTextureIndex(textureIndex)];
		}

		public glTFTextureSampler GetSamplerFromTextureIndex(int textureIndex)
		{
			int sampler = textures[textureIndex].sampler;
			return GetSampler(sampler);
		}

		public ArraySegment<byte> GetImageBytes(IStorage storage, int imageIndex, out string textureName)
		{
			glTFImage glTFImage2 = images[imageIndex];
			if (string.IsNullOrEmpty(glTFImage2.uri))
			{
				textureName = ((!string.IsNullOrEmpty(glTFImage2.name)) ? glTFImage2.name : $"{imageIndex:00}#GLB");
				return GetViewBytes(glTFImage2.bufferView);
			}
			if (glTFImage2.uri.StartsWith("data:"))
			{
				textureName = ((!string.IsNullOrEmpty(glTFImage2.name)) ? glTFImage2.name : $"{imageIndex:00}#Base64Embedded");
			}
			else
			{
				textureName = ((!string.IsNullOrEmpty(glTFImage2.name)) ? glTFImage2.name : Path.GetFileNameWithoutExtension(glTFImage2.uri));
			}
			return storage.Get(glTFImage2.uri);
		}

		public string GetUniqueMaterialName(int index)
		{
			if (materials.Any((glTFMaterial x) => string.IsNullOrEmpty(x.name)) || materials.Select((glTFMaterial x) => x.name).Distinct().Count() != materials.Count)
			{
				return $"{index:00}_{materials[index].name}";
			}
			return materials[index].name;
		}

		public bool MaterialHasVertexColor(glTFMaterial material)
		{
			if (material == null)
			{
				return false;
			}
			int num = materials.IndexOf(material);
			if (num == -1)
			{
				return false;
			}
			return MaterialHasVertexColor(num);
		}

		public bool MaterialHasVertexColor(int materialIndex)
		{
			if (materialIndex < 0 || materialIndex >= materials.Count)
			{
				return false;
			}
			return meshes.SelectMany((glTFMesh x) => x.primitives).Any((glTFPrimitives x) => x.material == materialIndex && x.HasVertexColor);
		}

		public override string ToString()
		{
			return $"{asset}";
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (extensionsUsed.Count > 0)
			{
				f.Key("extensionsUsed");
				f.GLTFValue(extensionsUsed);
			}
			if (extensions.__count > 0)
			{
				f.Key("extensions");
				f.GLTFValue(extensions);
			}
			if (extras.__count > 0)
			{
				f.Key("extras");
				f.GLTFValue(extras);
			}
			f.Key("asset");
			f.GLTFValue(asset);
			if (buffers.Any())
			{
				f.Key("buffers");
				f.GLTFValue(buffers);
			}
			if (bufferViews.Any())
			{
				f.Key("bufferViews");
				f.GLTFValue(bufferViews);
			}
			if (accessors.Any())
			{
				f.Key("accessors");
				f.GLTFValue(accessors);
			}
			if (images.Any())
			{
				f.Key("images");
				f.GLTFValue(images);
				if (samplers.Count == 0)
				{
					samplers.Add(new glTFTextureSampler());
				}
			}
			if (samplers.Any())
			{
				f.Key("samplers");
				f.GLTFValue(samplers);
			}
			if (textures.Any())
			{
				f.Key("textures");
				f.GLTFValue(textures);
			}
			if (materials.Any())
			{
				f.Key("materials");
				f.GLTFValue(materials);
			}
			if (meshes.Any())
			{
				f.Key("meshes");
				f.GLTFValue(meshes);
			}
			if (skins.Any())
			{
				f.Key("skins");
				f.GLTFValue(skins);
			}
			if (nodes.Any())
			{
				f.Key("nodes");
				f.GLTFValue(nodes);
			}
			if (scenes.Any())
			{
				f.Key("scenes");
				f.GLTFValue(scenes);
				if (scene >= 0)
				{
					f.KeyValue(() => scene);
				}
			}
			if (animations.Any())
			{
				f.Key("animations");
				f.GLTFValue(animations);
			}
		}

		public bool Equals(glTF other)
		{
			if (textures.SequenceEqual(other.textures) && samplers.SequenceEqual(other.samplers) && images.SequenceEqual(other.images) && materials.SequenceEqual(other.materials) && meshes.SequenceEqual(other.meshes) && nodes.SequenceEqual(other.nodes) && skins.SequenceEqual(other.skins) && scene == other.scene && scenes.SequenceEqual(other.scenes))
			{
				return animations.SequenceEqual(other.animations);
			}
			return false;
		}

		private bool UsedExtension(string key)
		{
			if (extensionsUsed.Contains(key))
			{
				return true;
			}
			return false;
		}

		private void Traverse(ListTreeNode<JsonValue> node, JsonFormatter f, Utf8String parentKey)
		{
			if (node.IsMap())
			{
				f.BeginMap();
				foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in node.ObjectItems())
				{
					if (!(parentKey == s_extensions) || UsedExtension(item.Key.GetString()))
					{
						f.Key(item.Key.GetUtf8String());
						Traverse(item.Value, f, item.Key.GetUtf8String());
					}
				}
				f.EndMap();
			}
			else if (node.IsArray())
			{
				f.BeginList();
				foreach (ListTreeNode<JsonValue> item2 in node.ArrayItems())
				{
					Traverse(item2, f, default(Utf8String));
				}
				f.EndList();
			}
			else
			{
				f.Value(node);
			}
		}

		private string RemoveUnusedExtensions(string json)
		{
			JsonFormatter jsonFormatter = new JsonFormatter();
			Traverse(JsonParser.Parse(json), jsonFormatter, default(Utf8String));
			return jsonFormatter.ToString();
		}

		public byte[] ToGlbBytes(SerializerTypes serializer = SerializerTypes.UniJSON)
		{
			string json;
			switch (serializer)
			{
			case SerializerTypes.UniJSON:
			{
				JsonSchemaValidationContext c = new JsonSchemaValidationContext(this)
				{
					EnableDiagnosisForNotRequiredFields = true
				};
				json = JsonSchema.FromType(GetType()).Serialize(this, c);
				break;
			}
			case SerializerTypes.Generated:
			{
				JsonFormatter jsonFormatter = new JsonFormatter();
				jsonFormatter.GenSerialize(this);
				json = jsonFormatter.ToString().ParseAsJson().ToString("  ");
				break;
			}
			case SerializerTypes.JsonSerializable:
				json = ToJson();
				break;
			default:
				throw new Exception("[UniVRM Export Error] unknown serializer type");
			}
			RemoveUnusedExtensions(json);
			return Glb.ToBytes(json, buffers[0].GetBytes());
		}
	}
}
