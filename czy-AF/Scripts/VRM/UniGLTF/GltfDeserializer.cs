using System.Collections.Generic;
using UniJSON;
using UnityEngine;
using VRM;

namespace UniGLTF
{
	public static class GltfDeserializer
	{
		public static glTF Deserialize(ListTreeNode<JsonValue> parsed)
		{
			glTF glTF2 = new glTF();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "asset":
					glTF2.asset = Deserialize_gltf_asset(item.Value);
					break;
				case "buffers":
					glTF2.buffers = Deserialize_gltf_buffers(item.Value);
					break;
				case "bufferViews":
					glTF2.bufferViews = Deserialize_gltf_bufferViews(item.Value);
					break;
				case "accessors":
					glTF2.accessors = Deserialize_gltf_accessors(item.Value);
					break;
				case "textures":
					glTF2.textures = Deserialize_gltf_textures(item.Value);
					break;
				case "samplers":
					glTF2.samplers = Deserialize_gltf_samplers(item.Value);
					break;
				case "images":
					glTF2.images = Deserialize_gltf_images(item.Value);
					break;
				case "materials":
					glTF2.materials = Deserialize_gltf_materials(item.Value);
					break;
				case "meshes":
					glTF2.meshes = Deserialize_gltf_meshes(item.Value);
					break;
				case "nodes":
					glTF2.nodes = Deserialize_gltf_nodes(item.Value);
					break;
				case "skins":
					glTF2.skins = Deserialize_gltf_skins(item.Value);
					break;
				case "scene":
					glTF2.scene = item.Value.GetInt32();
					break;
				case "scenes":
					glTF2.scenes = Deserialize_gltf_scenes(item.Value);
					break;
				case "animations":
					glTF2.animations = Deserialize_gltf_animations(item.Value);
					break;
				case "cameras":
					glTF2.cameras = Deserialize_gltf_cameras(item.Value);
					break;
				case "extensionsUsed":
					glTF2.extensionsUsed = Deserialize_gltf_extensionsUsed(item.Value);
					break;
				case "extensionsRequired":
					glTF2.extensionsRequired = Deserialize_gltf_extensionsRequired(item.Value);
					break;
				case "extensions":
					glTF2.extensions = Deserialize_gltf_extensions(item.Value);
					break;
				case "extras":
					glTF2.extras = Deserialize_gltf_extras(item.Value);
					break;
				}
			}
			return glTF2;
		}

		public static glTFAssets Deserialize_gltf_asset(ListTreeNode<JsonValue> parsed)
		{
			glTFAssets glTFAssets2 = new glTFAssets();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "generator":
					glTFAssets2.generator = item.Value.GetString();
					break;
				case "version":
					glTFAssets2.version = item.Value.GetString();
					break;
				case "copyright":
					glTFAssets2.copyright = item.Value.GetString();
					break;
				case "minVersion":
					glTFAssets2.minVersion = item.Value.GetString();
					break;
				}
			}
			return glTFAssets2;
		}

		public static List<glTFBuffer> Deserialize_gltf_buffers(ListTreeNode<JsonValue> parsed)
		{
			List<glTFBuffer> list = new List<glTFBuffer>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_buffers_LIST(item));
			}
			return list;
		}

		public static glTFBuffer Deserialize_gltf_buffers_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFBuffer glTFBuffer2 = new glTFBuffer();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "uri":
					glTFBuffer2.uri = item.Value.GetString();
					break;
				case "byteLength":
					glTFBuffer2.byteLength = item.Value.GetInt32();
					break;
				case "name":
					glTFBuffer2.name = item.Value.GetString();
					break;
				}
			}
			return glTFBuffer2;
		}

		public static List<glTFBufferView> Deserialize_gltf_bufferViews(ListTreeNode<JsonValue> parsed)
		{
			List<glTFBufferView> list = new List<glTFBufferView>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_bufferViews_LIST(item));
			}
			return list;
		}

		public static glTFBufferView Deserialize_gltf_bufferViews_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFBufferView glTFBufferView2 = new glTFBufferView();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "buffer":
					glTFBufferView2.buffer = item.Value.GetInt32();
					break;
				case "byteOffset":
					glTFBufferView2.byteOffset = item.Value.GetInt32();
					break;
				case "byteLength":
					glTFBufferView2.byteLength = item.Value.GetInt32();
					break;
				case "byteStride":
					glTFBufferView2.byteStride = item.Value.GetInt32();
					break;
				case "target":
					glTFBufferView2.target = (glBufferTarget)item.Value.GetInt32();
					break;
				case "name":
					glTFBufferView2.name = item.Value.GetString();
					break;
				}
			}
			return glTFBufferView2;
		}

		public static List<glTFAccessor> Deserialize_gltf_accessors(ListTreeNode<JsonValue> parsed)
		{
			List<glTFAccessor> list = new List<glTFAccessor>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_accessors_LIST(item));
			}
			return list;
		}

		public static glTFAccessor Deserialize_gltf_accessors_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFAccessor glTFAccessor2 = new glTFAccessor();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "bufferView":
					glTFAccessor2.bufferView = item.Value.GetInt32();
					break;
				case "byteOffset":
					glTFAccessor2.byteOffset = item.Value.GetInt32();
					break;
				case "type":
					glTFAccessor2.type = item.Value.GetString();
					break;
				case "componentType":
					glTFAccessor2.componentType = (glComponentType)item.Value.GetInt32();
					break;
				case "count":
					glTFAccessor2.count = item.Value.GetInt32();
					break;
				case "max":
					glTFAccessor2.max = Deserialize_gltf_accessors__max(item.Value);
					break;
				case "min":
					glTFAccessor2.min = Deserialize_gltf_accessors__min(item.Value);
					break;
				case "normalized":
					glTFAccessor2.normalized = item.Value.GetBoolean();
					break;
				case "sparse":
					glTFAccessor2.sparse = Deserialize_gltf_accessors__sparse(item.Value);
					break;
				case "name":
					glTFAccessor2.name = item.Value.GetString();
					break;
				}
			}
			return glTFAccessor2;
		}

		public static float[] Deserialize_gltf_accessors__max(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static float[] Deserialize_gltf_accessors__min(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTFSparse Deserialize_gltf_accessors__sparse(ListTreeNode<JsonValue> parsed)
		{
			glTFSparse glTFSparse2 = new glTFSparse();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "count":
					glTFSparse2.count = item.Value.GetInt32();
					break;
				case "indices":
					glTFSparse2.indices = Deserialize_gltf_accessors__sparse_indices(item.Value);
					break;
				case "values":
					glTFSparse2.values = Deserialize_gltf_accessors__sparse_values(item.Value);
					break;
				}
			}
			return glTFSparse2;
		}

		public static glTFSparseIndices Deserialize_gltf_accessors__sparse_indices(ListTreeNode<JsonValue> parsed)
		{
			glTFSparseIndices glTFSparseIndices2 = new glTFSparseIndices();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "bufferView":
					glTFSparseIndices2.bufferView = item.Value.GetInt32();
					break;
				case "byteOffset":
					glTFSparseIndices2.byteOffset = item.Value.GetInt32();
					break;
				case "componentType":
					glTFSparseIndices2.componentType = (glComponentType)item.Value.GetInt32();
					break;
				}
			}
			return glTFSparseIndices2;
		}

		public static glTFSparseValues Deserialize_gltf_accessors__sparse_values(ListTreeNode<JsonValue> parsed)
		{
			glTFSparseValues glTFSparseValues2 = new glTFSparseValues();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "bufferView")
				{
					glTFSparseValues2.bufferView = item.Value.GetInt32();
				}
				else if (text == "byteOffset")
				{
					glTFSparseValues2.byteOffset = item.Value.GetInt32();
				}
			}
			return glTFSparseValues2;
		}

		public static List<glTFTexture> Deserialize_gltf_textures(ListTreeNode<JsonValue> parsed)
		{
			List<glTFTexture> list = new List<glTFTexture>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_textures_LIST(item));
			}
			return list;
		}

		public static glTFTexture Deserialize_gltf_textures_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFTexture glTFTexture2 = new glTFTexture();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "sampler":
					glTFTexture2.sampler = item.Value.GetInt32();
					break;
				case "source":
					glTFTexture2.source = item.Value.GetInt32();
					break;
				case "name":
					glTFTexture2.name = item.Value.GetString();
					break;
				}
			}
			return glTFTexture2;
		}

		public static List<glTFTextureSampler> Deserialize_gltf_samplers(ListTreeNode<JsonValue> parsed)
		{
			List<glTFTextureSampler> list = new List<glTFTextureSampler>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_samplers_LIST(item));
			}
			return list;
		}

		public static glTFTextureSampler Deserialize_gltf_samplers_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFTextureSampler glTFTextureSampler2 = new glTFTextureSampler();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "magFilter":
					glTFTextureSampler2.magFilter = (glFilter)item.Value.GetInt32();
					break;
				case "minFilter":
					glTFTextureSampler2.minFilter = (glFilter)item.Value.GetInt32();
					break;
				case "wrapS":
					glTFTextureSampler2.wrapS = (glWrap)item.Value.GetInt32();
					break;
				case "wrapT":
					glTFTextureSampler2.wrapT = (glWrap)item.Value.GetInt32();
					break;
				case "name":
					glTFTextureSampler2.name = item.Value.GetString();
					break;
				}
			}
			return glTFTextureSampler2;
		}

		public static List<glTFImage> Deserialize_gltf_images(ListTreeNode<JsonValue> parsed)
		{
			List<glTFImage> list = new List<glTFImage>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_images_LIST(item));
			}
			return list;
		}

		public static glTFImage Deserialize_gltf_images_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFImage glTFImage2 = new glTFImage();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTFImage2.name = item.Value.GetString();
					break;
				case "uri":
					glTFImage2.uri = item.Value.GetString();
					break;
				case "bufferView":
					glTFImage2.bufferView = item.Value.GetInt32();
					break;
				case "mimeType":
					glTFImage2.mimeType = item.Value.GetString();
					break;
				}
			}
			return glTFImage2;
		}

		public static List<glTFMaterial> Deserialize_gltf_materials(ListTreeNode<JsonValue> parsed)
		{
			List<glTFMaterial> list = new List<glTFMaterial>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_materials_LIST(item));
			}
			return list;
		}

		public static glTFMaterial Deserialize_gltf_materials_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterial glTFMaterial2 = new glTFMaterial();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTFMaterial2.name = item.Value.GetString();
					break;
				case "pbrMetallicRoughness":
					glTFMaterial2.pbrMetallicRoughness = Deserialize_gltf_materials__pbrMetallicRoughness(item.Value);
					break;
				case "normalTexture":
					glTFMaterial2.normalTexture = Deserialize_gltf_materials__normalTexture(item.Value);
					break;
				case "occlusionTexture":
					glTFMaterial2.occlusionTexture = Deserialize_gltf_materials__occlusionTexture(item.Value);
					break;
				case "emissiveTexture":
					glTFMaterial2.emissiveTexture = Deserialize_gltf_materials__emissiveTexture(item.Value);
					break;
				case "emissiveFactor":
					glTFMaterial2.emissiveFactor = Deserialize_gltf_materials__emissiveFactor(item.Value);
					break;
				case "alphaMode":
					glTFMaterial2.alphaMode = item.Value.GetString();
					break;
				case "alphaCutoff":
					glTFMaterial2.alphaCutoff = item.Value.GetSingle();
					break;
				case "doubleSided":
					glTFMaterial2.doubleSided = item.Value.GetBoolean();
					break;
				case "extensions":
					glTFMaterial2.extensions = Deserialize_gltf_materials__extensions(item.Value);
					break;
				}
			}
			return glTFMaterial2;
		}

		public static glTFPbrMetallicRoughness Deserialize_gltf_materials__pbrMetallicRoughness(ListTreeNode<JsonValue> parsed)
		{
			glTFPbrMetallicRoughness glTFPbrMetallicRoughness2 = new glTFPbrMetallicRoughness();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "baseColorTexture":
					glTFPbrMetallicRoughness2.baseColorTexture = Deserialize_gltf_materials__pbrMetallicRoughness_baseColorTexture(item.Value);
					break;
				case "baseColorFactor":
					glTFPbrMetallicRoughness2.baseColorFactor = Deserialize_gltf_materials__pbrMetallicRoughness_baseColorFactor(item.Value);
					break;
				case "metallicRoughnessTexture":
					glTFPbrMetallicRoughness2.metallicRoughnessTexture = Deserialize_gltf_materials__pbrMetallicRoughness_metallicRoughnessTexture(item.Value);
					break;
				case "metallicFactor":
					glTFPbrMetallicRoughness2.metallicFactor = item.Value.GetSingle();
					break;
				case "roughnessFactor":
					glTFPbrMetallicRoughness2.roughnessFactor = item.Value.GetSingle();
					break;
				}
			}
			return glTFPbrMetallicRoughness2;
		}

		public static glTFMaterialBaseColorTextureInfo Deserialize_gltf_materials__pbrMetallicRoughness_baseColorTexture(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterialBaseColorTextureInfo glTFMaterialBaseColorTextureInfo2 = new glTFMaterialBaseColorTextureInfo();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "index")
				{
					glTFMaterialBaseColorTextureInfo2.index = item.Value.GetInt32();
				}
				else if (text == "texCoord")
				{
					glTFMaterialBaseColorTextureInfo2.texCoord = item.Value.GetInt32();
				}
			}
			return glTFMaterialBaseColorTextureInfo2;
		}

		public static float[] Deserialize_gltf_materials__pbrMetallicRoughness_baseColorFactor(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTFMaterialMetallicRoughnessTextureInfo Deserialize_gltf_materials__pbrMetallicRoughness_metallicRoughnessTexture(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterialMetallicRoughnessTextureInfo glTFMaterialMetallicRoughnessTextureInfo2 = new glTFMaterialMetallicRoughnessTextureInfo();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "index")
				{
					glTFMaterialMetallicRoughnessTextureInfo2.index = item.Value.GetInt32();
				}
				else if (text == "texCoord")
				{
					glTFMaterialMetallicRoughnessTextureInfo2.texCoord = item.Value.GetInt32();
				}
			}
			return glTFMaterialMetallicRoughnessTextureInfo2;
		}

		public static glTFMaterialNormalTextureInfo Deserialize_gltf_materials__normalTexture(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterialNormalTextureInfo glTFMaterialNormalTextureInfo2 = new glTFMaterialNormalTextureInfo();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "scale":
					glTFMaterialNormalTextureInfo2.scale = item.Value.GetSingle();
					break;
				case "index":
					glTFMaterialNormalTextureInfo2.index = item.Value.GetInt32();
					break;
				case "texCoord":
					glTFMaterialNormalTextureInfo2.texCoord = item.Value.GetInt32();
					break;
				}
			}
			return glTFMaterialNormalTextureInfo2;
		}

		public static glTFMaterialOcclusionTextureInfo Deserialize_gltf_materials__occlusionTexture(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterialOcclusionTextureInfo glTFMaterialOcclusionTextureInfo2 = new glTFMaterialOcclusionTextureInfo();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "strength":
					glTFMaterialOcclusionTextureInfo2.strength = item.Value.GetSingle();
					break;
				case "index":
					glTFMaterialOcclusionTextureInfo2.index = item.Value.GetInt32();
					break;
				case "texCoord":
					glTFMaterialOcclusionTextureInfo2.texCoord = item.Value.GetInt32();
					break;
				}
			}
			return glTFMaterialOcclusionTextureInfo2;
		}

		public static glTFMaterialEmissiveTextureInfo Deserialize_gltf_materials__emissiveTexture(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterialEmissiveTextureInfo glTFMaterialEmissiveTextureInfo2 = new glTFMaterialEmissiveTextureInfo();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "index")
				{
					glTFMaterialEmissiveTextureInfo2.index = item.Value.GetInt32();
				}
				else if (text == "texCoord")
				{
					glTFMaterialEmissiveTextureInfo2.texCoord = item.Value.GetInt32();
				}
			}
			return glTFMaterialEmissiveTextureInfo2;
		}

		public static float[] Deserialize_gltf_materials__emissiveFactor(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTFMaterial_extensions Deserialize_gltf_materials__extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFMaterial_extensions glTFMaterial_extensions2 = new glTFMaterial_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				if (item.Key.GetString() == "KHR_materials_unlit")
				{
					glTFMaterial_extensions2.KHR_materials_unlit = Deserialize_gltf_materials__extensions_KHR_materials_unlit(item.Value);
				}
			}
			return glTFMaterial_extensions2;
		}

		public static glTF_KHR_materials_unlit Deserialize_gltf_materials__extensions_KHR_materials_unlit(ListTreeNode<JsonValue> parsed)
		{
			glTF_KHR_materials_unlit result = new glTF_KHR_materials_unlit();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static List<glTFMesh> Deserialize_gltf_meshes(ListTreeNode<JsonValue> parsed)
		{
			List<glTFMesh> list = new List<glTFMesh>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_meshes_LIST(item));
			}
			return list;
		}

		public static glTFMesh Deserialize_gltf_meshes_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFMesh glTFMesh2 = new glTFMesh();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTFMesh2.name = item.Value.GetString();
					break;
				case "primitives":
					glTFMesh2.primitives = Deserialize_gltf_meshes__primitives(item.Value);
					break;
				case "weights":
					glTFMesh2.weights = Deserialize_gltf_meshes__weights(item.Value);
					break;
				}
			}
			return glTFMesh2;
		}

		public static List<glTFPrimitives> Deserialize_gltf_meshes__primitives(ListTreeNode<JsonValue> parsed)
		{
			List<glTFPrimitives> list = new List<glTFPrimitives>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_meshes__primitives_LIST(item));
			}
			return list;
		}

		public static glTFPrimitives Deserialize_gltf_meshes__primitives_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFPrimitives glTFPrimitives2 = new glTFPrimitives();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "mode":
					glTFPrimitives2.mode = item.Value.GetInt32();
					break;
				case "indices":
					glTFPrimitives2.indices = item.Value.GetInt32();
					break;
				case "attributes":
					glTFPrimitives2.attributes = Deserialize_gltf_meshes__primitives__attributes(item.Value);
					break;
				case "material":
					glTFPrimitives2.material = item.Value.GetInt32();
					break;
				case "targets":
					glTFPrimitives2.targets = Deserialize_gltf_meshes__primitives__targets(item.Value);
					break;
				case "extras":
					glTFPrimitives2.extras = Deserialize_gltf_meshes__primitives__extras(item.Value);
					break;
				case "extensions":
					glTFPrimitives2.extensions = Deserialize_gltf_meshes__primitives__extensions(item.Value);
					break;
				}
			}
			return glTFPrimitives2;
		}

		public static glTFAttributes Deserialize_gltf_meshes__primitives__attributes(ListTreeNode<JsonValue> parsed)
		{
			glTFAttributes glTFAttributes2 = new glTFAttributes();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "POSITION":
					glTFAttributes2.POSITION = item.Value.GetInt32();
					break;
				case "NORMAL":
					glTFAttributes2.NORMAL = item.Value.GetInt32();
					break;
				case "TANGENT":
					glTFAttributes2.TANGENT = item.Value.GetInt32();
					break;
				case "TEXCOORD_0":
					glTFAttributes2.TEXCOORD_0 = item.Value.GetInt32();
					break;
				case "COLOR_0":
					glTFAttributes2.COLOR_0 = item.Value.GetInt32();
					break;
				case "JOINTS_0":
					glTFAttributes2.JOINTS_0 = item.Value.GetInt32();
					break;
				case "WEIGHTS_0":
					glTFAttributes2.WEIGHTS_0 = item.Value.GetInt32();
					break;
				}
			}
			return glTFAttributes2;
		}

		public static List<gltfMorphTarget> Deserialize_gltf_meshes__primitives__targets(ListTreeNode<JsonValue> parsed)
		{
			List<gltfMorphTarget> list = new List<gltfMorphTarget>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_meshes__primitives__targets_LIST(item));
			}
			return list;
		}

		public static gltfMorphTarget Deserialize_gltf_meshes__primitives__targets_LIST(ListTreeNode<JsonValue> parsed)
		{
			gltfMorphTarget gltfMorphTarget2 = new gltfMorphTarget();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "POSITION":
					gltfMorphTarget2.POSITION = item.Value.GetInt32();
					break;
				case "NORMAL":
					gltfMorphTarget2.NORMAL = item.Value.GetInt32();
					break;
				case "TANGENT":
					gltfMorphTarget2.TANGENT = item.Value.GetInt32();
					break;
				}
			}
			return gltfMorphTarget2;
		}

		public static glTFPrimitives_extras Deserialize_gltf_meshes__primitives__extras(ListTreeNode<JsonValue> parsed)
		{
			glTFPrimitives_extras glTFPrimitives_extras2 = new glTFPrimitives_extras();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				if (item.Key.GetString() == "targetNames")
				{
					glTFPrimitives_extras2.targetNames = Deserialize_gltf_meshes__primitives__extras_targetNames(item.Value);
				}
			}
			return glTFPrimitives_extras2;
		}

		public static List<string> Deserialize_gltf_meshes__primitives__extras_targetNames(ListTreeNode<JsonValue> parsed)
		{
			List<string> list = new List<string>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(item.GetString());
			}
			return list;
		}

		public static glTFPrimitives_extensions Deserialize_gltf_meshes__primitives__extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFPrimitives_extensions result = new glTFPrimitives_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static float[] Deserialize_gltf_meshes__weights(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static List<glTFNode> Deserialize_gltf_nodes(ListTreeNode<JsonValue> parsed)
		{
			List<glTFNode> list = new List<glTFNode>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_nodes_LIST(item));
			}
			return list;
		}

		public static glTFNode Deserialize_gltf_nodes_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFNode glTFNode2 = new glTFNode();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTFNode2.name = item.Value.GetString();
					break;
				case "children":
					glTFNode2.children = Deserialize_gltf_nodes__children(item.Value);
					break;
				case "matrix":
					glTFNode2.matrix = Deserialize_gltf_nodes__matrix(item.Value);
					break;
				case "translation":
					glTFNode2.translation = Deserialize_gltf_nodes__translation(item.Value);
					break;
				case "rotation":
					glTFNode2.rotation = Deserialize_gltf_nodes__rotation(item.Value);
					break;
				case "scale":
					glTFNode2.scale = Deserialize_gltf_nodes__scale(item.Value);
					break;
				case "mesh":
					glTFNode2.mesh = item.Value.GetInt32();
					break;
				case "skin":
					glTFNode2.skin = item.Value.GetInt32();
					break;
				case "weights":
					glTFNode2.weights = Deserialize_gltf_nodes__weights(item.Value);
					break;
				case "camera":
					glTFNode2.camera = item.Value.GetInt32();
					break;
				case "extensions":
					glTFNode2.extensions = Deserialize_gltf_nodes__extensions(item.Value);
					break;
				case "extras":
					glTFNode2.extras = Deserialize_gltf_nodes__extras(item.Value);
					break;
				}
			}
			return glTFNode2;
		}

		public static int[] Deserialize_gltf_nodes__children(ListTreeNode<JsonValue> parsed)
		{
			int[] array = new int[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetInt32();
			}
			return array;
		}

		public static float[] Deserialize_gltf_nodes__matrix(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static float[] Deserialize_gltf_nodes__translation(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static float[] Deserialize_gltf_nodes__rotation(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static float[] Deserialize_gltf_nodes__scale(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static float[] Deserialize_gltf_nodes__weights(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTFNode_extensions Deserialize_gltf_nodes__extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFNode_extensions result = new glTFNode_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFNode_extra Deserialize_gltf_nodes__extras(ListTreeNode<JsonValue> parsed)
		{
			glTFNode_extra result = new glTFNode_extra();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static List<glTFSkin> Deserialize_gltf_skins(ListTreeNode<JsonValue> parsed)
		{
			List<glTFSkin> list = new List<glTFSkin>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_skins_LIST(item));
			}
			return list;
		}

		public static glTFSkin Deserialize_gltf_skins_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFSkin glTFSkin2 = new glTFSkin();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "inverseBindMatrices":
					glTFSkin2.inverseBindMatrices = item.Value.GetInt32();
					break;
				case "joints":
					glTFSkin2.joints = Deserialize_gltf_skins__joints(item.Value);
					break;
				case "skeleton":
					glTFSkin2.skeleton = item.Value.GetInt32();
					break;
				case "name":
					glTFSkin2.name = item.Value.GetString();
					break;
				}
			}
			return glTFSkin2;
		}

		public static int[] Deserialize_gltf_skins__joints(ListTreeNode<JsonValue> parsed)
		{
			int[] array = new int[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetInt32();
			}
			return array;
		}

		public static List<gltfScene> Deserialize_gltf_scenes(ListTreeNode<JsonValue> parsed)
		{
			List<gltfScene> list = new List<gltfScene>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_scenes_LIST(item));
			}
			return list;
		}

		public static gltfScene Deserialize_gltf_scenes_LIST(ListTreeNode<JsonValue> parsed)
		{
			gltfScene gltfScene2 = new gltfScene();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "nodes")
				{
					gltfScene2.nodes = Deserialize_gltf_scenes__nodes(item.Value);
				}
				else if (text == "name")
				{
					gltfScene2.name = item.Value.GetString();
				}
			}
			return gltfScene2;
		}

		public static int[] Deserialize_gltf_scenes__nodes(ListTreeNode<JsonValue> parsed)
		{
			int[] array = new int[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetInt32();
			}
			return array;
		}

		public static List<glTFAnimation> Deserialize_gltf_animations(ListTreeNode<JsonValue> parsed)
		{
			List<glTFAnimation> list = new List<glTFAnimation>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_animations_LIST(item));
			}
			return list;
		}

		public static glTFAnimation Deserialize_gltf_animations_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFAnimation glTFAnimation2 = new glTFAnimation();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTFAnimation2.name = item.Value.GetString();
					break;
				case "channels":
					glTFAnimation2.channels = Deserialize_gltf_animations__channels(item.Value);
					break;
				case "samplers":
					glTFAnimation2.samplers = Deserialize_gltf_animations__samplers(item.Value);
					break;
				}
			}
			return glTFAnimation2;
		}

		public static List<glTFAnimationChannel> Deserialize_gltf_animations__channels(ListTreeNode<JsonValue> parsed)
		{
			List<glTFAnimationChannel> list = new List<glTFAnimationChannel>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_animations__channels_LIST(item));
			}
			return list;
		}

		public static glTFAnimationChannel Deserialize_gltf_animations__channels_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFAnimationChannel glTFAnimationChannel2 = new glTFAnimationChannel();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "sampler")
				{
					glTFAnimationChannel2.sampler = item.Value.GetInt32();
				}
				else if (text == "target")
				{
					glTFAnimationChannel2.target = Deserialize_gltf_animations__channels__target(item.Value);
				}
			}
			return glTFAnimationChannel2;
		}

		public static glTFAnimationTarget Deserialize_gltf_animations__channels__target(ListTreeNode<JsonValue> parsed)
		{
			glTFAnimationTarget glTFAnimationTarget2 = new glTFAnimationTarget();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "node")
				{
					glTFAnimationTarget2.node = item.Value.GetInt32();
				}
				else if (text == "path")
				{
					glTFAnimationTarget2.path = item.Value.GetString();
				}
			}
			return glTFAnimationTarget2;
		}

		public static List<glTFAnimationSampler> Deserialize_gltf_animations__samplers(ListTreeNode<JsonValue> parsed)
		{
			List<glTFAnimationSampler> list = new List<glTFAnimationSampler>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_animations__samplers_LIST(item));
			}
			return list;
		}

		public static glTFAnimationSampler Deserialize_gltf_animations__samplers_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFAnimationSampler glTFAnimationSampler2 = new glTFAnimationSampler();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "input":
					glTFAnimationSampler2.input = item.Value.GetInt32();
					break;
				case "interpolation":
					glTFAnimationSampler2.interpolation = item.Value.GetString();
					break;
				case "output":
					glTFAnimationSampler2.output = item.Value.GetInt32();
					break;
				}
			}
			return glTFAnimationSampler2;
		}

		public static List<glTFCamera> Deserialize_gltf_cameras(ListTreeNode<JsonValue> parsed)
		{
			List<glTFCamera> list = new List<glTFCamera>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_cameras_LIST(item));
			}
			return list;
		}

		public static glTFCamera Deserialize_gltf_cameras_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTFCamera glTFCamera2 = new glTFCamera();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "orthographic":
					glTFCamera2.orthographic = Deserialize_gltf_cameras__orthographic(item.Value);
					break;
				case "perspective":
					glTFCamera2.perspective = Deserialize_gltf_cameras__perspective(item.Value);
					break;
				case "type":
					glTFCamera2.type = (ProjectionType)item.Value.GetInt32();
					break;
				case "name":
					glTFCamera2.name = item.Value.GetString();
					break;
				case "extensions":
					glTFCamera2.extensions = Deserialize_gltf_cameras__extensions(item.Value);
					break;
				case "extras":
					glTFCamera2.extras = Deserialize_gltf_cameras__extras(item.Value);
					break;
				}
			}
			return glTFCamera2;
		}

		public static glTFOrthographic Deserialize_gltf_cameras__orthographic(ListTreeNode<JsonValue> parsed)
		{
			glTFOrthographic glTFOrthographic2 = new glTFOrthographic();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "xmag":
					glTFOrthographic2.xmag = item.Value.GetSingle();
					break;
				case "ymag":
					glTFOrthographic2.ymag = item.Value.GetSingle();
					break;
				case "zfar":
					glTFOrthographic2.zfar = item.Value.GetSingle();
					break;
				case "znear":
					glTFOrthographic2.znear = item.Value.GetSingle();
					break;
				case "extensions":
					glTFOrthographic2.extensions = Deserialize_gltf_cameras__orthographic_extensions(item.Value);
					break;
				case "extras":
					glTFOrthographic2.extras = Deserialize_gltf_cameras__orthographic_extras(item.Value);
					break;
				}
			}
			return glTFOrthographic2;
		}

		public static glTFOrthographic_extensions Deserialize_gltf_cameras__orthographic_extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFOrthographic_extensions result = new glTFOrthographic_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFOrthographic_extras Deserialize_gltf_cameras__orthographic_extras(ListTreeNode<JsonValue> parsed)
		{
			glTFOrthographic_extras result = new glTFOrthographic_extras();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFPerspective Deserialize_gltf_cameras__perspective(ListTreeNode<JsonValue> parsed)
		{
			glTFPerspective glTFPerspective2 = new glTFPerspective();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "aspectRatio":
					glTFPerspective2.aspectRatio = item.Value.GetSingle();
					break;
				case "yfov":
					glTFPerspective2.yfov = item.Value.GetSingle();
					break;
				case "zfar":
					glTFPerspective2.zfar = item.Value.GetSingle();
					break;
				case "znear":
					glTFPerspective2.znear = item.Value.GetSingle();
					break;
				case "extensions":
					glTFPerspective2.extensions = Deserialize_gltf_cameras__perspective_extensions(item.Value);
					break;
				case "extras":
					glTFPerspective2.extras = Deserialize_gltf_cameras__perspective_extras(item.Value);
					break;
				}
			}
			return glTFPerspective2;
		}

		public static glTFPerspective_extensions Deserialize_gltf_cameras__perspective_extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFPerspective_extensions result = new glTFPerspective_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFPerspective_extras Deserialize_gltf_cameras__perspective_extras(ListTreeNode<JsonValue> parsed)
		{
			glTFPerspective_extras result = new glTFPerspective_extras();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFCamera_extensions Deserialize_gltf_cameras__extensions(ListTreeNode<JsonValue> parsed)
		{
			glTFCamera_extensions result = new glTFCamera_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static glTFCamera_extras Deserialize_gltf_cameras__extras(ListTreeNode<JsonValue> parsed)
		{
			glTFCamera_extras result = new glTFCamera_extras();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}

		public static List<string> Deserialize_gltf_extensionsUsed(ListTreeNode<JsonValue> parsed)
		{
			List<string> list = new List<string>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(item.GetString());
			}
			return list;
		}

		public static List<string> Deserialize_gltf_extensionsRequired(ListTreeNode<JsonValue> parsed)
		{
			List<string> list = new List<string>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(item.GetString());
			}
			return list;
		}

		public static glTF_extensions Deserialize_gltf_extensions(ListTreeNode<JsonValue> parsed)
		{
			glTF_extensions glTF_extensions2 = new glTF_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				if (item.Key.GetString() == "VRM")
				{
					glTF_extensions2.VRM = Deserialize_gltf_extensions_VRM(item.Value);
				}
			}
			return glTF_extensions2;
		}

		public static glTF_VRM_extensions Deserialize_gltf_extensions_VRM(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_extensions glTF_VRM_extensions2 = new glTF_VRM_extensions();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "exporterVersion":
					glTF_VRM_extensions2.exporterVersion = item.Value.GetString();
					break;
				case "specVersion":
					glTF_VRM_extensions2.specVersion = item.Value.GetString();
					break;
				case "meta":
					glTF_VRM_extensions2.meta = Deserialize_gltf_extensions_VRM_meta(item.Value);
					break;
				case "humanoid":
					glTF_VRM_extensions2.humanoid = Deserialize_gltf_extensions_VRM_humanoid(item.Value);
					break;
				case "firstPerson":
					glTF_VRM_extensions2.firstPerson = Deserialize_gltf_extensions_VRM_firstPerson(item.Value);
					break;
				case "blendShapeMaster":
					glTF_VRM_extensions2.blendShapeMaster = Deserialize_gltf_extensions_VRM_blendShapeMaster(item.Value);
					break;
				case "secondaryAnimation":
					glTF_VRM_extensions2.secondaryAnimation = Deserialize_gltf_extensions_VRM_secondaryAnimation(item.Value);
					break;
				case "materialProperties":
					glTF_VRM_extensions2.materialProperties = Deserialize_gltf_extensions_VRM_materialProperties(item.Value);
					break;
				}
			}
			return glTF_VRM_extensions2;
		}

		public static glTF_VRM_Meta Deserialize_gltf_extensions_VRM_meta(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_Meta glTF_VRM_Meta2 = new glTF_VRM_Meta();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "title":
					glTF_VRM_Meta2.title = item.Value.GetString();
					break;
				case "version":
					glTF_VRM_Meta2.version = item.Value.GetString();
					break;
				case "author":
					glTF_VRM_Meta2.author = item.Value.GetString();
					break;
				case "contactInformation":
					glTF_VRM_Meta2.contactInformation = item.Value.GetString();
					break;
				case "reference":
					glTF_VRM_Meta2.reference = item.Value.GetString();
					break;
				case "texture":
					glTF_VRM_Meta2.texture = item.Value.GetInt32();
					break;
				case "allowedUserName":
					glTF_VRM_Meta2.allowedUserName = item.Value.GetString();
					break;
				case "violentUssageName":
					glTF_VRM_Meta2.violentUssageName = item.Value.GetString();
					break;
				case "sexualUssageName":
					glTF_VRM_Meta2.sexualUssageName = item.Value.GetString();
					break;
				case "commercialUssageName":
					glTF_VRM_Meta2.commercialUssageName = item.Value.GetString();
					break;
				case "otherPermissionUrl":
					glTF_VRM_Meta2.otherPermissionUrl = item.Value.GetString();
					break;
				case "licenseName":
					glTF_VRM_Meta2.licenseName = item.Value.GetString();
					break;
				case "otherLicenseUrl":
					glTF_VRM_Meta2.otherLicenseUrl = item.Value.GetString();
					break;
				}
			}
			return glTF_VRM_Meta2;
		}

		public static glTF_VRM_Humanoid Deserialize_gltf_extensions_VRM_humanoid(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_Humanoid glTF_VRM_Humanoid2 = new glTF_VRM_Humanoid();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "humanBones":
					glTF_VRM_Humanoid2.humanBones = Deserialize_gltf_extensions_VRM_humanoid_humanBones(item.Value);
					break;
				case "armStretch":
					glTF_VRM_Humanoid2.armStretch = item.Value.GetSingle();
					break;
				case "legStretch":
					glTF_VRM_Humanoid2.legStretch = item.Value.GetSingle();
					break;
				case "upperArmTwist":
					glTF_VRM_Humanoid2.upperArmTwist = item.Value.GetSingle();
					break;
				case "lowerArmTwist":
					glTF_VRM_Humanoid2.lowerArmTwist = item.Value.GetSingle();
					break;
				case "upperLegTwist":
					glTF_VRM_Humanoid2.upperLegTwist = item.Value.GetSingle();
					break;
				case "lowerLegTwist":
					glTF_VRM_Humanoid2.lowerLegTwist = item.Value.GetSingle();
					break;
				case "feetSpacing":
					glTF_VRM_Humanoid2.feetSpacing = item.Value.GetSingle();
					break;
				case "hasTranslationDoF":
					glTF_VRM_Humanoid2.hasTranslationDoF = item.Value.GetBoolean();
					break;
				}
			}
			return glTF_VRM_Humanoid2;
		}

		public static List<glTF_VRM_HumanoidBone> Deserialize_gltf_extensions_VRM_humanoid_humanBones(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_HumanoidBone> list = new List<glTF_VRM_HumanoidBone>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_humanoid_humanBones_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_HumanoidBone Deserialize_gltf_extensions_VRM_humanoid_humanBones_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_HumanoidBone glTF_VRM_HumanoidBone2 = new glTF_VRM_HumanoidBone();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "bone":
					glTF_VRM_HumanoidBone2.bone = item.Value.GetString();
					break;
				case "node":
					glTF_VRM_HumanoidBone2.node = item.Value.GetInt32();
					break;
				case "useDefaultValues":
					glTF_VRM_HumanoidBone2.useDefaultValues = item.Value.GetBoolean();
					break;
				case "min":
					glTF_VRM_HumanoidBone2.min = Deserialize_gltf_extensions_VRM_humanoid_humanBones__min(item.Value);
					break;
				case "max":
					glTF_VRM_HumanoidBone2.max = Deserialize_gltf_extensions_VRM_humanoid_humanBones__max(item.Value);
					break;
				case "center":
					glTF_VRM_HumanoidBone2.center = Deserialize_gltf_extensions_VRM_humanoid_humanBones__center(item.Value);
					break;
				case "axisLength":
					glTF_VRM_HumanoidBone2.axisLength = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_HumanoidBone2;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_humanoid_humanBones__min(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_humanoid_humanBones__max(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_humanoid_humanBones__center(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static glTF_VRM_Firstperson Deserialize_gltf_extensions_VRM_firstPerson(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_Firstperson glTF_VRM_Firstperson2 = new glTF_VRM_Firstperson();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "firstPersonBone":
					glTF_VRM_Firstperson2.firstPersonBone = item.Value.GetInt32();
					break;
				case "firstPersonBoneOffset":
					glTF_VRM_Firstperson2.firstPersonBoneOffset = Deserialize_gltf_extensions_VRM_firstPerson_firstPersonBoneOffset(item.Value);
					break;
				case "meshAnnotations":
					glTF_VRM_Firstperson2.meshAnnotations = Deserialize_gltf_extensions_VRM_firstPerson_meshAnnotations(item.Value);
					break;
				case "lookAtTypeName":
					glTF_VRM_Firstperson2.lookAtTypeName = item.Value.GetString();
					break;
				case "lookAtHorizontalInner":
					glTF_VRM_Firstperson2.lookAtHorizontalInner = Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalInner(item.Value);
					break;
				case "lookAtHorizontalOuter":
					glTF_VRM_Firstperson2.lookAtHorizontalOuter = Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalOuter(item.Value);
					break;
				case "lookAtVerticalDown":
					glTF_VRM_Firstperson2.lookAtVerticalDown = Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalDown(item.Value);
					break;
				case "lookAtVerticalUp":
					glTF_VRM_Firstperson2.lookAtVerticalUp = Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalUp(item.Value);
					break;
				}
			}
			return glTF_VRM_Firstperson2;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_firstPerson_firstPersonBoneOffset(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static List<glTF_VRM_MeshAnnotation> Deserialize_gltf_extensions_VRM_firstPerson_meshAnnotations(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_MeshAnnotation> list = new List<glTF_VRM_MeshAnnotation>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_firstPerson_meshAnnotations_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_MeshAnnotation Deserialize_gltf_extensions_VRM_firstPerson_meshAnnotations_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_MeshAnnotation glTF_VRM_MeshAnnotation2 = new glTF_VRM_MeshAnnotation();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "mesh")
				{
					glTF_VRM_MeshAnnotation2.mesh = item.Value.GetInt32();
				}
				else if (text == "firstPersonFlag")
				{
					glTF_VRM_MeshAnnotation2.firstPersonFlag = item.Value.GetString();
				}
			}
			return glTF_VRM_MeshAnnotation2;
		}

		public static glTF_VRM_DegreeMap Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalInner(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_DegreeMap glTF_VRM_DegreeMap2 = new glTF_VRM_DegreeMap();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "curve":
					glTF_VRM_DegreeMap2.curve = Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalInner_curve(item.Value);
					break;
				case "xRange":
					glTF_VRM_DegreeMap2.xRange = item.Value.GetSingle();
					break;
				case "yRange":
					glTF_VRM_DegreeMap2.yRange = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_DegreeMap2;
		}

		public static float[] Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalInner_curve(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTF_VRM_DegreeMap Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalOuter(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_DegreeMap glTF_VRM_DegreeMap2 = new glTF_VRM_DegreeMap();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "curve":
					glTF_VRM_DegreeMap2.curve = Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalOuter_curve(item.Value);
					break;
				case "xRange":
					glTF_VRM_DegreeMap2.xRange = item.Value.GetSingle();
					break;
				case "yRange":
					glTF_VRM_DegreeMap2.yRange = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_DegreeMap2;
		}

		public static float[] Deserialize_gltf_extensions_VRM_firstPerson_lookAtHorizontalOuter_curve(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTF_VRM_DegreeMap Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalDown(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_DegreeMap glTF_VRM_DegreeMap2 = new glTF_VRM_DegreeMap();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "curve":
					glTF_VRM_DegreeMap2.curve = Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalDown_curve(item.Value);
					break;
				case "xRange":
					glTF_VRM_DegreeMap2.xRange = item.Value.GetSingle();
					break;
				case "yRange":
					glTF_VRM_DegreeMap2.yRange = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_DegreeMap2;
		}

		public static float[] Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalDown_curve(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTF_VRM_DegreeMap Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalUp(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_DegreeMap glTF_VRM_DegreeMap2 = new glTF_VRM_DegreeMap();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "curve":
					glTF_VRM_DegreeMap2.curve = Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalUp_curve(item.Value);
					break;
				case "xRange":
					glTF_VRM_DegreeMap2.xRange = item.Value.GetSingle();
					break;
				case "yRange":
					glTF_VRM_DegreeMap2.yRange = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_DegreeMap2;
		}

		public static float[] Deserialize_gltf_extensions_VRM_firstPerson_lookAtVerticalUp_curve(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTF_VRM_BlendShapeMaster Deserialize_gltf_extensions_VRM_blendShapeMaster(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_BlendShapeMaster glTF_VRM_BlendShapeMaster2 = new glTF_VRM_BlendShapeMaster();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				if (item.Key.GetString() == "blendShapeGroups")
				{
					glTF_VRM_BlendShapeMaster2.blendShapeGroups = Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups(item.Value);
				}
			}
			return glTF_VRM_BlendShapeMaster2;
		}

		public static List<glTF_VRM_BlendShapeGroup> Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_BlendShapeGroup> list = new List<glTF_VRM_BlendShapeGroup>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_BlendShapeGroup Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_BlendShapeGroup glTF_VRM_BlendShapeGroup2 = new glTF_VRM_BlendShapeGroup();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTF_VRM_BlendShapeGroup2.name = item.Value.GetString();
					break;
				case "presetName":
					glTF_VRM_BlendShapeGroup2.presetName = item.Value.GetString();
					break;
				case "binds":
					glTF_VRM_BlendShapeGroup2.binds = Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__binds(item.Value);
					break;
				case "materialValues":
					glTF_VRM_BlendShapeGroup2.materialValues = Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues(item.Value);
					break;
				case "isBinary":
					glTF_VRM_BlendShapeGroup2.isBinary = item.Value.GetBoolean();
					break;
				}
			}
			return glTF_VRM_BlendShapeGroup2;
		}

		public static List<glTF_VRM_BlendShapeBind> Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__binds(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_BlendShapeBind> list = new List<glTF_VRM_BlendShapeBind>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__binds_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_BlendShapeBind Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__binds_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_BlendShapeBind glTF_VRM_BlendShapeBind2 = new glTF_VRM_BlendShapeBind();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "mesh":
					glTF_VRM_BlendShapeBind2.mesh = item.Value.GetInt32();
					break;
				case "index":
					glTF_VRM_BlendShapeBind2.index = item.Value.GetInt32();
					break;
				case "weight":
					glTF_VRM_BlendShapeBind2.weight = item.Value.GetSingle();
					break;
				}
			}
			return glTF_VRM_BlendShapeBind2;
		}

		public static List<glTF_VRM_MaterialValueBind> Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_MaterialValueBind> list = new List<glTF_VRM_MaterialValueBind>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_MaterialValueBind Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_MaterialValueBind glTF_VRM_MaterialValueBind2 = new glTF_VRM_MaterialValueBind();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "materialName":
					glTF_VRM_MaterialValueBind2.materialName = item.Value.GetString();
					break;
				case "propertyName":
					glTF_VRM_MaterialValueBind2.propertyName = item.Value.GetString();
					break;
				case "targetValue":
					glTF_VRM_MaterialValueBind2.targetValue = Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues__targetValue(item.Value);
					break;
				}
			}
			return glTF_VRM_MaterialValueBind2;
		}

		public static float[] Deserialize_gltf_extensions_VRM_blendShapeMaster_blendShapeGroups__materialValues__targetValue(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static glTF_VRM_SecondaryAnimation Deserialize_gltf_extensions_VRM_secondaryAnimation(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_SecondaryAnimation glTF_VRM_SecondaryAnimation2 = new glTF_VRM_SecondaryAnimation();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "boneGroups")
				{
					glTF_VRM_SecondaryAnimation2.boneGroups = Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups(item.Value);
				}
				else if (text == "colliderGroups")
				{
					glTF_VRM_SecondaryAnimation2.colliderGroups = Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups(item.Value);
				}
			}
			return glTF_VRM_SecondaryAnimation2;
		}

		public static List<glTF_VRM_SecondaryAnimationGroup> Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_SecondaryAnimationGroup> list = new List<glTF_VRM_SecondaryAnimationGroup>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_SecondaryAnimationGroup Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_SecondaryAnimationGroup glTF_VRM_SecondaryAnimationGroup2 = new glTF_VRM_SecondaryAnimationGroup();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "comment":
					glTF_VRM_SecondaryAnimationGroup2.comment = item.Value.GetString();
					break;
				case "stiffiness":
					glTF_VRM_SecondaryAnimationGroup2.stiffiness = item.Value.GetSingle();
					break;
				case "gravityPower":
					glTF_VRM_SecondaryAnimationGroup2.gravityPower = item.Value.GetSingle();
					break;
				case "gravityDir":
					glTF_VRM_SecondaryAnimationGroup2.gravityDir = Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__gravityDir(item.Value);
					break;
				case "dragForce":
					glTF_VRM_SecondaryAnimationGroup2.dragForce = item.Value.GetSingle();
					break;
				case "center":
					glTF_VRM_SecondaryAnimationGroup2.center = item.Value.GetInt32();
					break;
				case "hitRadius":
					glTF_VRM_SecondaryAnimationGroup2.hitRadius = item.Value.GetSingle();
					break;
				case "bones":
					glTF_VRM_SecondaryAnimationGroup2.bones = Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__bones(item.Value);
					break;
				case "colliderGroups":
					glTF_VRM_SecondaryAnimationGroup2.colliderGroups = Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__colliderGroups(item.Value);
					break;
				}
			}
			return glTF_VRM_SecondaryAnimationGroup2;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__gravityDir(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static int[] Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__bones(ListTreeNode<JsonValue> parsed)
		{
			int[] array = new int[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetInt32();
			}
			return array;
		}

		public static int[] Deserialize_gltf_extensions_VRM_secondaryAnimation_boneGroups__colliderGroups(ListTreeNode<JsonValue> parsed)
		{
			int[] array = new int[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetInt32();
			}
			return array;
		}

		public static List<glTF_VRM_SecondaryAnimationColliderGroup> Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_SecondaryAnimationColliderGroup> list = new List<glTF_VRM_SecondaryAnimationColliderGroup>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_SecondaryAnimationColliderGroup Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_SecondaryAnimationColliderGroup glTF_VRM_SecondaryAnimationColliderGroup2 = new glTF_VRM_SecondaryAnimationColliderGroup();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "node")
				{
					glTF_VRM_SecondaryAnimationColliderGroup2.node = item.Value.GetInt32();
				}
				else if (text == "colliders")
				{
					glTF_VRM_SecondaryAnimationColliderGroup2.colliders = Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders(item.Value);
				}
			}
			return glTF_VRM_SecondaryAnimationColliderGroup2;
		}

		public static List<glTF_VRM_SecondaryAnimationCollider> Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_SecondaryAnimationCollider> list = new List<glTF_VRM_SecondaryAnimationCollider>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_SecondaryAnimationCollider Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_SecondaryAnimationCollider glTF_VRM_SecondaryAnimationCollider2 = new glTF_VRM_SecondaryAnimationCollider();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				string text = item.Key.GetString();
				if (text == "offset")
				{
					glTF_VRM_SecondaryAnimationCollider2.offset = Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders__offset(item.Value);
				}
				else if (text == "radius")
				{
					glTF_VRM_SecondaryAnimationCollider2.radius = item.Value.GetSingle();
				}
			}
			return glTF_VRM_SecondaryAnimationCollider2;
		}

		public static Vector3 Deserialize_gltf_extensions_VRM_secondaryAnimation_colliderGroups__colliders__offset(ListTreeNode<JsonValue> parsed)
		{
			Vector3 result = default(Vector3);
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "x":
					result.x = item.Value.GetSingle();
					break;
				case "y":
					result.y = item.Value.GetSingle();
					break;
				case "z":
					result.z = item.Value.GetSingle();
					break;
				}
			}
			return result;
		}

		public static List<glTF_VRM_Material> Deserialize_gltf_extensions_VRM_materialProperties(ListTreeNode<JsonValue> parsed)
		{
			List<glTF_VRM_Material> list = new List<glTF_VRM_Material>();
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				list.Add(Deserialize_gltf_extensions_VRM_materialProperties_LIST(item));
			}
			return list;
		}

		public static glTF_VRM_Material Deserialize_gltf_extensions_VRM_materialProperties_LIST(ListTreeNode<JsonValue> parsed)
		{
			glTF_VRM_Material glTF_VRM_Material2 = new glTF_VRM_Material();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				switch (item.Key.GetString())
				{
				case "name":
					glTF_VRM_Material2.name = item.Value.GetString();
					break;
				case "shader":
					glTF_VRM_Material2.shader = item.Value.GetString();
					break;
				case "renderQueue":
					glTF_VRM_Material2.renderQueue = item.Value.GetInt32();
					break;
				case "floatProperties":
					glTF_VRM_Material2.floatProperties = Deserialize_gltf_extensions_VRM_materialProperties__floatProperties(item.Value);
					break;
				case "vectorProperties":
					glTF_VRM_Material2.vectorProperties = Deserialize_gltf_extensions_VRM_materialProperties__vectorProperties(item.Value);
					break;
				case "textureProperties":
					glTF_VRM_Material2.textureProperties = Deserialize_gltf_extensions_VRM_materialProperties__textureProperties(item.Value);
					break;
				case "keywordMap":
					glTF_VRM_Material2.keywordMap = Deserialize_gltf_extensions_VRM_materialProperties__keywordMap(item.Value);
					break;
				case "tagMap":
					glTF_VRM_Material2.tagMap = Deserialize_gltf_extensions_VRM_materialProperties__tagMap(item.Value);
					break;
				}
			}
			return glTF_VRM_Material2;
		}

		public static Dictionary<string, float> Deserialize_gltf_extensions_VRM_materialProperties__floatProperties(ListTreeNode<JsonValue> parsed)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				dictionary.Add(item.Key.GetString(), item.Value.GetSingle());
			}
			return dictionary;
		}

		public static Dictionary<string, float[]> Deserialize_gltf_extensions_VRM_materialProperties__vectorProperties(ListTreeNode<JsonValue> parsed)
		{
			Dictionary<string, float[]> dictionary = new Dictionary<string, float[]>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				dictionary.Add(item.Key.GetString(), Deserialize_gltf_extensions_VRM_materialProperties__vectorProperties_DICT(item.Value));
			}
			return dictionary;
		}

		public static float[] Deserialize_gltf_extensions_VRM_materialProperties__vectorProperties_DICT(ListTreeNode<JsonValue> parsed)
		{
			float[] array = new float[parsed.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<JsonValue> item in parsed.ArrayItems())
			{
				array[num++] = item.GetSingle();
			}
			return array;
		}

		public static Dictionary<string, int> Deserialize_gltf_extensions_VRM_materialProperties__textureProperties(ListTreeNode<JsonValue> parsed)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				dictionary.Add(item.Key.GetString(), item.Value.GetInt32());
			}
			return dictionary;
		}

		public static Dictionary<string, bool> Deserialize_gltf_extensions_VRM_materialProperties__keywordMap(ListTreeNode<JsonValue> parsed)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				dictionary.Add(item.Key.GetString(), item.Value.GetBoolean());
			}
			return dictionary;
		}

		public static Dictionary<string, string> Deserialize_gltf_extensions_VRM_materialProperties__tagMap(ListTreeNode<JsonValue> parsed)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				dictionary.Add(item.Key.GetString(), item.Value.GetString());
			}
			return dictionary;
		}

		public static gltf_extras Deserialize_gltf_extras(ListTreeNode<JsonValue> parsed)
		{
			gltf_extras result = new gltf_extras();
			foreach (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> item in parsed.ObjectItems())
			{
				item.Key.GetString();
			}
			return result;
		}
	}
}
