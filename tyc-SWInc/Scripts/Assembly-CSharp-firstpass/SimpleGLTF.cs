using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyJson;
using UnityEngine;

public static class SimpleGLTF
{
	public struct GLTFBufferView
	{
		public int buffer;

		public int byteLength;

		public int byteOffset;
	}

	public struct GLTFAccessor
	{
		public int bufferView;

		public int componentType;

		public int count;

		public string type;
	}

	public struct GLTFBuffer
	{
		public int byteLength;

		public string uri;

		public byte[] data;

		public GLTFBuffer(byte[] d, string u)
		{
			data = d;
			byteLength = d.Length;
			uri = u;
		}

		public GLTFBuffer Init()
		{
			if (data == null)
			{
				return new GLTFBuffer(ParseEmbeddedBuffer(uri, "data:application/octet-stream;base64,", "data:application/gltf-buffer;base64,"), uri);
			}
			return this;
		}

		private static byte[] ParseEmbeddedBuffer(string buffer, params string[] prefix)
		{
			if (buffer != null)
			{
				foreach (string text in prefix)
				{
					if (buffer.StartsWith(text))
					{
						return Convert.FromBase64String(buffer.Substring(text.Length));
					}
				}
			}
			throw new Exception("Only embedded gltf files are supported");
		}
	}

	public struct GLTFPrimitive
	{
		public Dictionary<string, int> attributes;

		public List<Dictionary<string, int>> targets;

		public int indices;

		public int GetAttributeAccessor(string name)
		{
			if (attributes != null)
			{
				return attributes.GetOrDefault(name, -1);
			}
			return -1;
		}

		public int GetTargetAccessor(string name, int i)
		{
			if (targets == null || i < 0 || i >= targets.Count)
			{
				return -1;
			}
			return targets[i].GetOrDefault(name, -1);
		}
	}

	public struct GLTFMesh
	{
		public string name;

		public List<float> weights;

		public Dictionary<string, object> extras;

		public List<GLTFPrimitive> primitives;

		public List<string> GetMorphTargetNames()
		{
			Dictionary<string, object> dictionary = extras;
			List<object> obj = ((dictionary != null) ? dictionary.GetOrNull("targetNames") : null) as List<object>;
			if (obj == null)
			{
				return null;
			}
			return obj.OfType<string>().ToList();
		}
	}

	public struct GLTFFile
	{
		public List<GLTFMesh> meshes;

		public List<GLTFAccessor> accessors;

		public List<GLTFBufferView> bufferViews;

		public List<GLTFBuffer> buffers;

		public byte[] GetBuffer(int i)
		{
			buffers[i] = buffers[i].Init();
			return buffers[i].data;
		}

		public bool GetAccAndView(GLTFPrimitive prim, string name, out GLTFAccessor acc, out GLTFBufferView view)
		{
			if (accessors != null && bufferViews != null)
			{
				int attributeAccessor = prim.GetAttributeAccessor(name);
				if (attributeAccessor >= 0 && attributeAccessor < accessors.Count)
				{
					acc = accessors[attributeAccessor];
					if (acc.bufferView >= 0 && acc.bufferView < bufferViews.Count)
					{
						view = bufferViews[acc.bufferView];
						return true;
					}
				}
			}
			acc = default(GLTFAccessor);
			view = default(GLTFBufferView);
			return false;
		}

		public bool GetTargetAccAndView(GLTFPrimitive prim, string name, int id, out GLTFAccessor acc, out GLTFBufferView view)
		{
			if (accessors != null && bufferViews != null)
			{
				int targetAccessor = prim.GetTargetAccessor(name, id);
				if (targetAccessor >= 0 && targetAccessor < accessors.Count)
				{
					acc = accessors[targetAccessor];
					if (acc.bufferView >= 0 && acc.bufferView < bufferViews.Count)
					{
						view = bufferViews[acc.bufferView];
						return true;
					}
				}
			}
			acc = default(GLTFAccessor);
			view = default(GLTFBufferView);
			return false;
		}

		public List<int> GetScalar(GLTFAccessor ac, GLTFBufferView view)
		{
			if (ac.componentType == 5123)
			{
				byte[] buffer = GetBuffer(view.buffer);
				if (buffer != null)
				{
					List<int> list = new List<int>();
					for (int i = 0; i < ac.count; i++)
					{
						list.Add(BitConverter.ToUInt16(buffer, view.byteOffset + i * 2));
					}
					return list;
				}
			}
			return null;
		}

		public List<float> GetFloat(GLTFAccessor ac, GLTFBufferView view, List<float> result)
		{
			if (result == null)
			{
				result = new List<float>();
			}
			else
			{
				result.Clear();
			}
			if (ac.componentType == 5126)
			{
				byte[] buffer = GetBuffer(view.buffer);
				if (buffer != null)
				{
					int num = view.byteLength / 4;
					for (int i = 0; i < num; i++)
					{
						result.Add(BitConverter.ToSingle(buffer, view.byteOffset + i * 4));
					}
					return result;
				}
			}
			return null;
		}
	}

	private static TValue GetOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : class
	{
		TValue value;
		if (!dict.TryGetValue(key, out value))
		{
			return null;
		}
		return value;
	}

	private static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
	{
		TValue value;
		if (dict.TryGetValue(key, out value))
		{
			return value;
		}
		return defaultValue;
	}

	private static bool ToVec4(this List<float> f, List<Vector4> res)
	{
		if (f == null)
		{
			return false;
		}
		res.Clear();
		for (int i = 0; i < f.Count; i += 4)
		{
			res.Add(new Vector4(f[i], f[i + 1], f[i + 2], f[i + 3]));
		}
		return true;
	}

	private static bool ToVec3(this List<float> f, List<Vector3> res)
	{
		if (f == null)
		{
			return false;
		}
		res.Clear();
		for (int i = 0; i < f.Count; i += 3)
		{
			res.Add(new Vector3(f[i], f[i + 1], f[i + 2]));
		}
		return true;
	}

	private static bool ToVec2(this List<float> f, List<Vector2> res)
	{
		if (f == null)
		{
			return false;
		}
		res.Clear();
		for (int i = 0; i < f.Count; i += 2)
		{
			res.Add(new Vector2(f[i], f[i + 1]));
		}
		return true;
	}

	public static Mesh Parse(byte[] content, string fileName)
	{
		uint index = 12u;
		byte[] nextChunk = GetNextChunk(content, ref index);
		GLTFFile json;
		try
		{
			json = Encoding.UTF8.GetString(nextChunk).FromJson<GLTFFile>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Error loading " + fileName + ":\nCouldn't parse JSON chunk", innerException);
		}
		for (int i = 0; i < json.buffers.Count; i++)
		{
			byte[] nextChunk2 = GetNextChunk(content, ref index);
			if (nextChunk2 == null)
			{
				throw new Exception("Error loading " + fileName + ":\nMissing buffer data for buffer " + i);
			}
			json.buffers[i] = new GLTFBuffer(nextChunk2, json.buffers[i].uri);
		}
		return SubParse(json, fileName);
	}

	private static byte[] GetNextChunk(byte[] buffer, ref uint index)
	{
		if (index >= buffer.Length)
		{
			return null;
		}
		uint num = BitConverter.ToUInt32(buffer, (int)index);
		index += 8u;
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = buffer[i + index];
		}
		index += num;
		return array;
	}

	public static Mesh Parse(string content, string fileName)
	{
		GLTFFile json;
		try
		{
			json = content.FromJson<GLTFFile>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Error loading " + fileName + ":\nOnly json-based gltf files are supported", innerException);
		}
		return SubParse(json, fileName);
	}

	private static Mesh SubParse(GLTFFile json, string fileName)
	{
		if (json.meshes != null && json.meshes.Count > 0)
		{
			GLTFMesh gLTFMesh = json.meshes[0];
			if (gLTFMesh.primitives != null && gLTFMesh.primitives.Count > 0)
			{
				GLTFPrimitive prim = gLTFMesh.primitives[0];
				List<Vector3> list = new List<Vector3>();
				List<Vector3> list2 = new List<Vector3>();
				List<Vector2> list3 = new List<Vector2>();
				List<Vector4> list4 = new List<Vector4>();
				GLTFAccessor acc = json.accessors[prim.indices];
				GLTFBufferView view = json.bufferViews[acc.bufferView];
				List<int> scalar = json.GetScalar(acc, view);
				List<float> result = new List<float>();
				if (!json.GetAccAndView(prim, "POSITION", out acc, out view) || !json.GetFloat(acc, view, result).ToVec3(list))
				{
					throw new Exception("Error loading " + fileName + ":\n" + gLTFMesh.name + " is missing vertex coodinates");
				}
				if (!json.GetAccAndView(prim, "NORMAL", out acc, out view) || !json.GetFloat(acc, view, result).ToVec3(list2))
				{
					throw new Exception("Error loading " + fileName + ":\n" + gLTFMesh.name + " is missing vertex normals");
				}
				if (!json.GetAccAndView(prim, "TEXCOORD_0", out acc, out view) || !json.GetFloat(acc, view, result).ToVec2(list3))
				{
					throw new Exception("Error loading " + fileName + ":\n" + gLTFMesh.name + " is missing uv coordinates");
				}
				if (json.GetAccAndView(prim, "TANGENT", out acc, out view))
				{
					json.GetFloat(acc, view, result).ToVec4(list4);
				}
				Mesh mesh = new Mesh();
				mesh.name = gLTFMesh.name;
				mesh.SetVertices(list);
				mesh.SetNormals(list2);
				if (list4.Count > 0)
				{
					mesh.SetTangents(list4);
				}
				for (int i = 0; i < list3.Count; i++)
				{
					list3[i] = new Vector2(list3[i].x, 1f - list3[i].y);
				}
				mesh.SetUVs(0, list3);
				mesh.SetTriangles(scalar.ToArray(), 0, true);
				if (list4.Count == 0)
				{
					mesh.RecalculateTangents();
				}
				if (prim.targets != null && prim.targets.Count > 0)
				{
					Vector3[] deltaTangents = new Vector3[list.Count];
					List<string> morphTargetNames = gLTFMesh.GetMorphTargetNames();
					for (int j = 0; j < prim.targets.Count; j++)
					{
						if (json.GetTargetAccAndView(prim, "POSITION", j, out acc, out view) && json.GetFloat(acc, view, result).ToVec3(list) && json.GetTargetAccAndView(prim, "NORMAL", j, out acc, out view) && json.GetFloat(acc, view, result).ToVec3(list2))
						{
							string shapeName = ((morphTargetNames != null && j < morphTargetNames.Count) ? morphTargetNames[j] : ("Blend" + (j + 1)));
							mesh.AddBlendShapeFrame(shapeName, 100f, list.ToArray(), list2.ToArray(), deltaTangents);
						}
					}
				}
				return mesh;
			}
			throw new Exception("Error loading " + fileName + ":\n" + gLTFMesh.name + " has no vertex data");
		}
		throw new Exception("Error loading " + fileName + ":\nNo meshes present in file");
	}
}
