using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OVRSimpleJSON;
using UnityEngine;

public class OVRGLTFLoader
{
	private JSONNode m_jsonData;

	private Stream m_glbStream;

	private OVRBinaryChunk m_binaryChunk;

	private List<GameObject> m_Nodes;

	private static readonly Vector3 GLTFToUnitySpace = new Vector3(-1f, 1f, 1f);

	private static readonly Vector3 GLTFToUnityTangent = new Vector4(-1f, 1f, 1f, -1f);

	private Shader m_Shader;

	public OVRGLTFLoader(string fileName)
	{
		m_glbStream = File.Open(fileName, FileMode.Open);
	}

	public OVRGLTFLoader(byte[] data)
	{
		m_glbStream = new MemoryStream(data, 0, data.Length, writable: false, publiclyVisible: true);
	}

	public OVRGLTFScene LoadGLB(bool loadMips = true)
	{
		OVRGLTFScene result = default(OVRGLTFScene);
		m_Nodes = new List<GameObject>();
		int index = 0;
		if (ValidateGLB(m_glbStream))
		{
			byte[] array = ReadChunk(m_glbStream, OVRChunkType.JSON);
			if (array != null)
			{
				string aJSON = Encoding.ASCII.GetString(array);
				m_jsonData = JSON.Parse(aJSON);
			}
			uint chunkLength = 0u;
			if (ValidateChunk(m_glbStream, OVRChunkType.BIN, out chunkLength) && m_jsonData != null)
			{
				m_binaryChunk.chunkLength = chunkLength;
				m_binaryChunk.chunkStart = m_glbStream.Position;
				m_binaryChunk.chunkStream = m_glbStream;
				if (m_Shader == null)
				{
					Debug.LogWarning("A shader was not set before loading the model. Using default mobile shader.");
					m_Shader = Shader.Find("Legacy Shaders/Diffuse");
				}
				index = LoadGLTF(loadMips);
			}
		}
		m_glbStream.Close();
		result.nodes = m_Nodes;
		result.root = m_Nodes[index];
		result.root.transform.Rotate(Vector3.up, 180f);
		return result;
	}

	public void SetModelShader(Shader shader)
	{
		m_Shader = shader;
	}

	private bool ValidateGLB(Stream glbStream)
	{
		int num = 4;
		byte[] array = new byte[num];
		glbStream.Read(array, 0, num);
		if (BitConverter.ToUInt32(array, 0) != 1179937895)
		{
			Debug.LogError("Data stream was not a valid glTF format");
			return false;
		}
		glbStream.Read(array, 0, num);
		if (BitConverter.ToUInt32(array, 0) != 2)
		{
			Debug.LogError("Only glTF 2.0 is supported");
			return false;
		}
		glbStream.Read(array, 0, num);
		if (BitConverter.ToUInt32(array, 0) != glbStream.Length)
		{
			Debug.LogError("glTF header length does not match file length");
			return false;
		}
		return true;
	}

	private byte[] ReadChunk(Stream glbStream, OVRChunkType type)
	{
		if (ValidateChunk(glbStream, type, out var chunkLength))
		{
			byte[] array = new byte[chunkLength];
			glbStream.Read(array, 0, (int)chunkLength);
			return array;
		}
		return null;
	}

	private bool ValidateChunk(Stream glbStream, OVRChunkType type, out uint chunkLength)
	{
		int num = 4;
		byte[] array = new byte[num];
		glbStream.Read(array, 0, num);
		chunkLength = BitConverter.ToUInt32(array, 0);
		glbStream.Read(array, 0, num);
		if (BitConverter.ToUInt32(array, 0) != (uint)type)
		{
			Debug.LogError("Read chunk does not match type.");
			return false;
		}
		return true;
	}

	private int LoadGLTF(bool loadMips)
	{
		if (m_jsonData == null)
		{
			Debug.LogError("m_jsonData was null");
		}
		JSONNode jSONNode = m_jsonData["scenes"];
		if (jSONNode.Count == 0)
		{
			Debug.LogError("No valid scenes in this glTF.");
		}
		JSONArray asArray = m_jsonData["nodes"].AsArray;
		for (int i = 0; i < asArray.Count; i++)
		{
			GameObject item = new GameObject(m_jsonData["nodes"][i]["name"]);
			m_Nodes.Add(item);
		}
		int asInt = jSONNode[0]["nodes"].AsArray[0].AsInt;
		ProcessNode(m_jsonData["nodes"][asInt], asInt, loadMips);
		return asInt;
	}

	private void ProcessNode(JSONNode node, int nodeId, bool loadMips)
	{
		JSONNode jSONNode = node["children"];
		if (jSONNode.Count > 0)
		{
			for (int i = 0; i < jSONNode.Count; i++)
			{
				int asInt = jSONNode[i].AsInt;
				m_Nodes[asInt].transform.SetParent(m_Nodes[nodeId].transform);
				ProcessNode(m_jsonData["nodes"][asInt], asInt, loadMips);
			}
		}
		if (node["name"].ToString().Contains("batteryIndicator"))
		{
			UnityEngine.Object.Destroy(m_Nodes[nodeId]);
			return;
		}
		if (node["mesh"] != null)
		{
			int asInt2 = node["mesh"].AsInt;
			OVRMeshData oVRMeshData = ProcessMesh(m_jsonData["meshes"][asInt2], loadMips);
			if (node["skin"] != null)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = m_Nodes[nodeId].AddComponent<SkinnedMeshRenderer>();
				skinnedMeshRenderer.sharedMesh = oVRMeshData.mesh;
				skinnedMeshRenderer.sharedMaterial = oVRMeshData.material;
				int asInt3 = node["skin"].AsInt;
				ProcessSkin(m_jsonData["skins"][asInt3], skinnedMeshRenderer);
			}
			else
			{
				m_Nodes[nodeId].AddComponent<MeshFilter>().sharedMesh = oVRMeshData.mesh;
				m_Nodes[nodeId].AddComponent<MeshRenderer>().sharedMaterial = oVRMeshData.material;
			}
		}
		JSONArray asArray = node["translation"].AsArray;
		JSONArray asArray2 = node["rotation"].AsArray;
		JSONArray asArray3 = node["scale"].AsArray;
		if (asArray.Count > 0)
		{
			Vector3 position = new Vector3((float)asArray[0] * GLTFToUnitySpace.x, (float)asArray[1] * GLTFToUnitySpace.y, (float)asArray[2] * GLTFToUnitySpace.z);
			m_Nodes[nodeId].transform.position = position;
		}
		if (asArray2.Count > 0)
		{
			Vector3 vector = new Vector3((float)asArray2[0] * GLTFToUnitySpace.x, (float)asArray2[1] * GLTFToUnitySpace.y, (float)asArray2[2] * GLTFToUnitySpace.z);
			vector *= -1f;
			m_Nodes[nodeId].transform.rotation = new Quaternion(vector.x, vector.y, vector.z, asArray2[3]);
		}
		if (asArray3.Count > 0)
		{
			Vector3 localScale = new Vector3(asArray3[0], asArray3[1], asArray3[2]);
			m_Nodes[nodeId].transform.localScale = localScale;
		}
	}

	private OVRMeshData ProcessMesh(JSONNode meshNode, bool loadMips)
	{
		OVRMeshData result = default(OVRMeshData);
		int num = 0;
		JSONNode jSONNode = meshNode["primitives"];
		int[] array = new int[jSONNode.Count];
		for (int i = 0; i < jSONNode.Count; i++)
		{
			JSONNode jSONNode2 = jSONNode[i]["attributes"]["POSITION"];
			JSONNode jSONNode3 = m_jsonData["accessors"][jSONNode2.AsInt];
			array[i] = jSONNode3["count"];
			num += array[i];
		}
		int[][] array2 = new int[jSONNode.Count][];
		Vector3[] data = new Vector3[num];
		Vector3[] data2 = null;
		if (jSONNode[0]["attributes"]["NORMAL"] != null)
		{
			data2 = new Vector3[num];
		}
		Vector4[] data3 = null;
		if (jSONNode[0]["attributes"]["TANGENT"] != null)
		{
			data3 = new Vector4[num];
		}
		Vector2[] data4 = null;
		if (jSONNode[0]["attributes"]["TEXCOORD_0"] != null)
		{
			data4 = new Vector2[num];
		}
		Color[] data5 = null;
		if (jSONNode[0]["attributes"]["COLOR_0"] != null)
		{
			data5 = new Color[num];
		}
		BoneWeight[] array3 = null;
		if (jSONNode[0]["attributes"]["WEIGHTS_0"] != null)
		{
			array3 = new BoneWeight[num];
		}
		OVRMaterialData matData = default(OVRMaterialData);
		Task task = null;
		JSONNode jSONNode4 = jSONNode[0]["material"];
		if (jSONNode4 != null)
		{
			matData = ProcessMaterial(jSONNode4.AsInt);
			matData.texture = ProcessTexture(matData.textureId);
			task = Task.Run(delegate
			{
				TranscodeTexture(ref matData.texture);
			});
		}
		int num2 = 0;
		for (int num3 = 0; num3 < jSONNode.Count; num3++)
		{
			JSONNode jSONNode5 = jSONNode[num3];
			int asInt = jSONNode5["indices"].AsInt;
			OVRGLTFAccessor oVRGLTFAccessor = new OVRGLTFAccessor(m_jsonData["accessors"][asInt], m_jsonData);
			array2[num3] = new int[oVRGLTFAccessor.GetDataCount()];
			oVRGLTFAccessor.ReadAsInt(m_binaryChunk, ref array2[num3], 0);
			FlipTraingleIndices(ref array2[num3]);
			JSONNode jSONNode6 = jSONNode5["attributes"]["POSITION"];
			if (jSONNode6 != null)
			{
				new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData).ReadAsVector3(m_binaryChunk, ref data, num2, GLTFToUnitySpace);
			}
			jSONNode6 = jSONNode5["attributes"]["NORMAL"];
			if (jSONNode6 != null)
			{
				new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData).ReadAsVector3(m_binaryChunk, ref data2, num2, GLTFToUnitySpace);
			}
			jSONNode6 = jSONNode5["attributes"]["TANGENT"];
			if (jSONNode6 != null)
			{
				new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData).ReadAsVector4(m_binaryChunk, ref data3, num2, GLTFToUnityTangent);
			}
			jSONNode6 = jSONNode5["attributes"]["TEXCOORD_0"];
			if (jSONNode6 != null)
			{
				new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData).ReadAsVector2(m_binaryChunk, ref data4, num2);
			}
			jSONNode6 = jSONNode5["attributes"]["COLOR_0"];
			if (jSONNode6 != null)
			{
				new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData).ReadAsColor(m_binaryChunk, ref data5, num2);
			}
			jSONNode6 = jSONNode5["attributes"]["WEIGHTS_0"];
			if (jSONNode6 != null)
			{
				OVRGLTFAccessor oVRGLTFAccessor2 = new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode6.AsInt], m_jsonData);
				JSONNode jSONNode7 = jSONNode5["attributes"]["JOINTS_0"];
				OVRGLTFAccessor oVRGLTFAccessor3 = new OVRGLTFAccessor(m_jsonData["accessors"][jSONNode7.AsInt], m_jsonData);
				Vector4[] data6 = new Vector4[oVRGLTFAccessor2.GetDataCount()];
				Vector4[] data7 = new Vector4[oVRGLTFAccessor3.GetDataCount()];
				oVRGLTFAccessor2.ReadAsBoneWeights(m_binaryChunk, ref data6, 0);
				oVRGLTFAccessor3.ReadAsVector4(m_binaryChunk, ref data7, 0, Vector4.one);
				for (int num4 = 0; num4 < data6.Length; num4++)
				{
					array3[num2 + num4].boneIndex0 = (int)data7[num4].x;
					array3[num2 + num4].boneIndex1 = (int)data7[num4].y;
					array3[num2 + num4].boneIndex2 = (int)data7[num4].z;
					array3[num2 + num4].boneIndex3 = (int)data7[num4].w;
					array3[num2 + num4].weight0 = data6[num4].x;
					array3[num2 + num4].weight1 = data6[num4].y;
					array3[num2 + num4].weight2 = data6[num4].z;
					array3[num2 + num4].weight3 = data6[num4].w;
				}
			}
			num2 += array[num3];
		}
		Mesh mesh = new Mesh();
		mesh.vertices = data;
		mesh.normals = data2;
		mesh.tangents = data3;
		mesh.colors = data5;
		mesh.uv = data4;
		mesh.boneWeights = array3;
		mesh.subMeshCount = jSONNode.Count;
		int num5 = 0;
		for (int num6 = 0; num6 < jSONNode.Count; num6++)
		{
			mesh.SetIndices(array2[num6], MeshTopology.Triangles, num6, calculateBounds: false, num5);
			num5 += array[num6];
		}
		mesh.RecalculateBounds();
		result.mesh = mesh;
		if (task != null)
		{
			task.Wait();
			result.material = CreateUnityMaterial(matData, loadMips);
		}
		return result;
	}

	private static void FlipTraingleIndices(ref int[] indices)
	{
		for (int i = 0; i < indices.Length; i += 3)
		{
			int num = indices[i];
			indices[i] = indices[i + 2];
			indices[i + 2] = num;
		}
	}

	private void ProcessSkin(JSONNode skinNode, SkinnedMeshRenderer renderer)
	{
		Matrix4x4[] data = null;
		if (skinNode["inverseBindMatrices"] != null)
		{
			int asInt = skinNode["inverseBindMatrices"].AsInt;
			OVRGLTFAccessor oVRGLTFAccessor = new OVRGLTFAccessor(m_jsonData["accessors"][asInt], m_jsonData);
			data = new Matrix4x4[oVRGLTFAccessor.GetDataCount()];
			oVRGLTFAccessor.ReadAsMatrix4x4(m_binaryChunk, ref data, 0, GLTFToUnitySpace);
		}
		if (skinNode["skeleton"] != null)
		{
			int asInt2 = skinNode["skeleton"].AsInt;
			renderer.rootBone = m_Nodes[asInt2].transform;
		}
		Transform[] array = null;
		if (skinNode["joints"] != null)
		{
			JSONArray asArray = skinNode["joints"].AsArray;
			array = new Transform[asArray.Count];
			for (int i = 0; i < asArray.Count; i++)
			{
				array[i] = m_Nodes[asArray[i]].transform;
			}
		}
		renderer.sharedMesh.bindposes = data;
		renderer.bones = array;
	}

	private OVRMaterialData ProcessMaterial(int matId)
	{
		OVRMaterialData result = default(OVRMaterialData);
		JSONNode jSONNode = m_jsonData["materials"][matId];
		JSONNode jSONNode2 = jSONNode["pbrMetallicRoughness"]["baseColorTexture"];
		if (jSONNode2 != null)
		{
			int asInt = jSONNode2["index"].AsInt;
			result.textureId = asInt;
		}
		else
		{
			JSONNode jSONNode3 = jSONNode["emissiveTexture"];
			if (jSONNode3 != null)
			{
				int asInt2 = jSONNode3["index"].AsInt;
				result.textureId = asInt2;
			}
		}
		result.shader = m_Shader;
		return result;
	}

	private OVRTextureData ProcessTexture(int textureId)
	{
		JSONNode jSONNode = m_jsonData["textures"][textureId];
		int aIndex = -1;
		JSONNode jSONNode2 = jSONNode["extensions"];
		if (jSONNode2 != null)
		{
			JSONNode jSONNode3 = jSONNode2["KHR_texture_basisu"];
			if (jSONNode3 != null)
			{
				aIndex = jSONNode3["source"].AsInt;
			}
		}
		else
		{
			aIndex = jSONNode["source"].AsInt;
		}
		JSONNode jSONNode4 = m_jsonData["images"][aIndex];
		int asInt = jSONNode["sampler"].AsInt;
		_ = m_jsonData["samplers"][asInt];
		int asInt2 = jSONNode4["bufferView"].AsInt;
		OVRGLTFAccessor oVRGLTFAccessor = new OVRGLTFAccessor(m_jsonData["bufferViews"][asInt2], m_jsonData, bufferViewOnly: true);
		OVRTextureData result = default(OVRTextureData);
		if (jSONNode4["mimeType"].Value == "image/ktx2")
		{
			result.data = oVRGLTFAccessor.ReadAsKtxTexture(m_binaryChunk);
			result.format = OVRTextureFormat.KTX2;
		}
		else
		{
			Debug.LogWarning("Unsupported image mimeType.");
		}
		return result;
	}

	private void TranscodeTexture(ref OVRTextureData textureData)
	{
		if (textureData.format == OVRTextureFormat.KTX2)
		{
			OVRKtxTexture.Load(textureData.data, ref textureData);
		}
		else
		{
			Debug.LogWarning("Only KTX2 textures can be trascoded.");
		}
	}

	private Material CreateUnityMaterial(OVRMaterialData matData, bool loadMips)
	{
		Material material = new Material(matData.shader);
		if (matData.texture.format == OVRTextureFormat.KTX2)
		{
			Texture2D texture2D = new Texture2D(matData.texture.width, matData.texture.height, matData.texture.transcodedFormat, loadMips);
			texture2D.LoadRawTextureData(matData.texture.data);
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			material.mainTexture = texture2D;
		}
		return material;
	}
}
