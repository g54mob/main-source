using System;
using System.IO;
using OVRSimpleJSON;
using UnityEngine;

public class OVRGLTFAccessor
{
	private int byteOffset;

	private int byteLength;

	private int byteStride;

	private int bufferId;

	private int bufferLength;

	private int additionalOffset;

	private OVRGLTFType dataType;

	private OVRGLTFComponentType componentType;

	private int dataCount;

	public OVRGLTFAccessor(JSONNode node, JSONNode root, bool bufferViewOnly = false)
	{
		JSONNode jSONNode = node;
		if (!bufferViewOnly)
		{
			additionalOffset = node["byteOffset"].AsInt;
			dataType = ToOVRType(node["type"].Value);
			componentType = (OVRGLTFComponentType)node["componentType"].AsInt;
			dataCount = node["count"].AsInt;
			int asInt = node["bufferView"].AsInt;
			jSONNode = root["bufferViews"][asInt];
		}
		int asInt2 = jSONNode["buffer"].AsInt;
		byteOffset = jSONNode["byteOffset"].AsInt;
		byteLength = jSONNode["byteLength"].AsInt;
		byteStride = jSONNode["byteStride"].AsInt;
		JSONNode jSONNode2 = root["buffers"][asInt2];
		bufferLength = jSONNode2["byteLength"].AsInt;
	}

	public int GetDataCount()
	{
		return dataCount;
	}

	private static OVRGLTFType ToOVRType(string type)
	{
		switch (type)
		{
		case "SCALAR":
			return OVRGLTFType.SCALAR;
		case "VEC2":
			return OVRGLTFType.VEC2;
		case "VEC3":
			return OVRGLTFType.VEC3;
		case "VEC4":
			return OVRGLTFType.VEC4;
		case "MAT4":
			return OVRGLTFType.MAT4;
		default:
			Debug.LogError("Unsupported accessor type.");
			return OVRGLTFType.NONE;
		}
	}

	public void ReadAsInt(OVRBinaryChunk chunk, ref int[] data, int offset)
	{
		if (dataType != OVRGLTFType.SCALAR)
		{
			Debug.LogError("Tried to read non-scalar data as a uint array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int num = ((byteStride > 0) ? byteStride : GetStrideForType(componentType));
		for (int i = 0; i < dataCount; i++)
		{
			data[offset + i] = (int)ReadElementAsUint(array, i * num, componentType);
		}
	}

	public void ReadAsVector2(OVRBinaryChunk chunk, ref Vector2[] data, int offset)
	{
		if (dataType != OVRGLTFType.VEC2)
		{
			Debug.LogError("Tried to read non-vec3 data as a vec2 array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int strideForType = GetStrideForType(componentType);
		int num = ((byteStride > 0) ? byteStride : (strideForType * 2));
		for (int i = 0; i < dataCount; i++)
		{
			if (componentType == OVRGLTFComponentType.FLOAT)
			{
				data[offset + i].x = ReadElementAsFloat(array, i * num);
				data[offset + i].y = ReadElementAsFloat(array, i * num + strideForType);
			}
		}
	}

	public void ReadAsVector3(OVRBinaryChunk chunk, ref Vector3[] data, int offset, Vector3 conversionScale)
	{
		if (dataType != OVRGLTFType.VEC3)
		{
			Debug.LogError("Tried to read non-vec3 data as a vec3 array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int strideForType = GetStrideForType(componentType);
		int num = ((byteStride > 0) ? byteStride : (strideForType * 3));
		for (int i = 0; i < dataCount; i++)
		{
			if (componentType == OVRGLTFComponentType.FLOAT)
			{
				data[offset + i].x = ReadElementAsFloat(array, i * num);
				data[offset + i].y = ReadElementAsFloat(array, i * num + strideForType);
				data[offset + i].z = ReadElementAsFloat(array, i * num + strideForType * 2);
			}
			else
			{
				data[offset + i].x = ReadElementAsUint(array, i * num, componentType);
				data[offset + i].y = ReadElementAsUint(array, i * num + strideForType, componentType);
				data[offset + i].z = ReadElementAsUint(array, i * num + strideForType * 2, componentType);
			}
			data[offset + i].Scale(conversionScale);
		}
	}

	public void ReadAsVector4(OVRBinaryChunk chunk, ref Vector4[] data, int offset, Vector4 conversionScale)
	{
		if (dataType != OVRGLTFType.VEC4)
		{
			Debug.LogError("Tried to read non-vec4 data as a vec4 array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int strideForType = GetStrideForType(componentType);
		int num = ((byteStride > 0) ? byteStride : (strideForType * 4));
		for (int i = 0; i < dataCount; i++)
		{
			if (componentType == OVRGLTFComponentType.FLOAT)
			{
				data[offset + i].x = ReadElementAsFloat(array, i * num);
				data[offset + i].y = ReadElementAsFloat(array, i * num + strideForType);
				data[offset + i].z = ReadElementAsFloat(array, i * num + strideForType * 2);
				data[offset + i].w = ReadElementAsFloat(array, i * num + strideForType * 3);
			}
			else
			{
				data[offset + i].x = ReadElementAsUint(array, i * num, componentType);
				data[offset + i].y = ReadElementAsUint(array, i * num + strideForType, componentType);
				data[offset + i].z = ReadElementAsUint(array, i * num + strideForType * 2, componentType);
				data[offset + i].w = ReadElementAsUint(array, i * num + strideForType * 3, componentType);
			}
			data[offset + i].Scale(conversionScale);
		}
	}

	public void ReadAsColor(OVRBinaryChunk chunk, ref Color[] data, int offset)
	{
		if (dataType != OVRGLTFType.VEC4 && dataType != OVRGLTFType.VEC3)
		{
			Debug.LogError("Tried to read non-color type as a color array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int num = ((dataType == OVRGLTFType.VEC3) ? 3 : 4);
		int strideForType = GetStrideForType(componentType);
		int num2 = ((byteStride > 0) ? byteStride : (strideForType * num));
		float maxValueForType = GetMaxValueForType(componentType);
		for (int i = 0; i < dataCount; i++)
		{
			if (componentType == OVRGLTFComponentType.FLOAT)
			{
				data[offset + i].r = ReadElementAsFloat(array, i * num2);
				data[offset + i].g = ReadElementAsFloat(array, i * num2 + strideForType);
				data[offset + i].b = ReadElementAsFloat(array, i * num2 + strideForType * 2);
				data[offset + i].a = ((dataType == OVRGLTFType.VEC3) ? 1f : ReadElementAsFloat(array, i * num2 + strideForType * 3));
			}
			else
			{
				data[offset + i].r = (float)ReadElementAsUint(array, i * num2, componentType) / maxValueForType;
				data[offset + i].g = (float)ReadElementAsUint(array, i * num2 + strideForType, componentType) / maxValueForType;
				data[offset + i].b = (float)ReadElementAsUint(array, i * num2 + strideForType * 2, componentType) / maxValueForType;
				data[offset + i].a = ((dataType == OVRGLTFType.VEC3) ? 1f : ((float)ReadElementAsUint(array, i * num2 + strideForType * 3, componentType) / maxValueForType));
			}
		}
	}

	public void ReadAsMatrix4x4(OVRBinaryChunk chunk, ref Matrix4x4[] data, int offset, Vector3 conversionScale)
	{
		if (dataType != OVRGLTFType.MAT4)
		{
			Debug.LogError("Tried to read non-vec3 data as a vec3 array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int strideForType = GetStrideForType(componentType);
		int num = ((byteStride > 0) ? byteStride : (strideForType * 16));
		Matrix4x4 matrix4x = Matrix4x4.Scale(conversionScale);
		for (int i = 0; i < dataCount; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				data[offset + i][j] = ReadElementAsFloat(array, i * num + strideForType * j);
			}
			data[offset + i] = matrix4x * data[offset + i] * matrix4x;
		}
	}

	public byte[] ReadAsKtxTexture(OVRBinaryChunk chunk)
	{
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return null;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		return array;
	}

	public void ReadAsBoneWeights(OVRBinaryChunk chunk, ref Vector4[] data, int offset)
	{
		if (dataType != OVRGLTFType.VEC4)
		{
			Debug.LogError("Tried to read bone weights data as a non-vec4 array.");
			return;
		}
		if (chunk.chunkLength != bufferLength)
		{
			Debug.LogError("Chunk length is not equal to buffer length.");
			return;
		}
		byte[] array = new byte[byteLength];
		chunk.chunkStream.Seek(chunk.chunkStart + byteOffset + additionalOffset, SeekOrigin.Begin);
		chunk.chunkStream.Read(array, 0, byteLength);
		int strideForType = GetStrideForType(componentType);
		int num = ((byteStride > 0) ? byteStride : (strideForType * 4));
		for (int i = 0; i < dataCount; i++)
		{
			data[offset + i].x = ReadElementAsFloat(array, i * num);
			data[offset + i].y = ReadElementAsFloat(array, i * num + strideForType);
			data[offset + i].z = ReadElementAsFloat(array, i * num + strideForType * 2);
			data[offset + i].w = ReadElementAsFloat(array, i * num + strideForType * 3);
			float num2 = data[offset + i].x + data[offset + i].y + data[offset + i].z + data[offset + i].w;
			if (!Mathf.Approximately(num2, 0f))
			{
				data[offset + i] /= num2;
			}
		}
	}

	private int GetStrideForType(OVRGLTFComponentType type)
	{
		switch (type)
		{
		case OVRGLTFComponentType.BYTE:
			return 1;
		case OVRGLTFComponentType.UNSIGNED_BYTE:
			return 1;
		case OVRGLTFComponentType.SHORT:
			return 2;
		case OVRGLTFComponentType.UNSIGNED_SHORT:
			return 2;
		case OVRGLTFComponentType.UNSIGNED_INT:
			return 4;
		case OVRGLTFComponentType.FLOAT:
			return 4;
		default:
			return 0;
		}
	}

	private float GetMaxValueForType(OVRGLTFComponentType type)
	{
		switch (type)
		{
		case OVRGLTFComponentType.BYTE:
			return 127f;
		case OVRGLTFComponentType.UNSIGNED_BYTE:
			return 255f;
		case OVRGLTFComponentType.SHORT:
			return 32767f;
		case OVRGLTFComponentType.UNSIGNED_SHORT:
			return 65535f;
		case OVRGLTFComponentType.UNSIGNED_INT:
			return 4.2949673E+09f;
		case OVRGLTFComponentType.FLOAT:
			return float.MaxValue;
		default:
			return 0f;
		}
	}

	private uint ReadElementAsUint(byte[] data, int index, OVRGLTFComponentType type)
	{
		switch (type)
		{
		case OVRGLTFComponentType.BYTE:
			return (uint)Convert.ToSByte(data[index]);
		case OVRGLTFComponentType.UNSIGNED_BYTE:
			return data[index];
		case OVRGLTFComponentType.SHORT:
			return (uint)BitConverter.ToInt16(data, index);
		case OVRGLTFComponentType.UNSIGNED_SHORT:
			return BitConverter.ToUInt16(data, index);
		case OVRGLTFComponentType.UNSIGNED_INT:
			return BitConverter.ToUInt32(data, index);
		default:
			Debug.Log($"Failed to read Component Type {type} as a uint.");
			return 0u;
		}
	}

	private float ReadElementAsFloat(byte[] data, int index)
	{
		return BitConverter.ToSingle(data, index);
	}
}
