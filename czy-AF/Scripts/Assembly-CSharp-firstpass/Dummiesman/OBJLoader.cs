using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Dummiesman
{
	public class OBJLoader
	{
		public SplitMode SplitMode = SplitMode.Object;

		internal List<Vector3> Vertices = new List<Vector3>();

		internal List<Vector3> Normals = new List<Vector3>();

		internal List<Vector2> UVs = new List<Vector2>();

		internal Dictionary<string, Material> Materials;

		private FileInfo _objInfo;

		private void LoadMaterialLibrary(string mtlLibPath)
		{
			if (_objInfo != null && File.Exists(Path.Combine(_objInfo.Directory.FullName, mtlLibPath)))
			{
				Materials = new MTLLoader().Load(Path.Combine(_objInfo.Directory.FullName, mtlLibPath));
			}
			else if (File.Exists(mtlLibPath))
			{
				Materials = new MTLLoader().Load(mtlLibPath);
			}
		}

		public GameObject Load(Stream input)
		{
			StreamReader reader = new StreamReader(input);
			Dictionary<string, OBJObjectBuilder> builderDict = new Dictionary<string, OBJObjectBuilder>();
			OBJObjectBuilder currentBuilder = null;
			string material = "default";
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			Action<string> action = delegate(string objectName)
			{
				if (!builderDict.TryGetValue(objectName, out currentBuilder))
				{
					currentBuilder = new OBJObjectBuilder(objectName, this);
					builderDict[objectName] = currentBuilder;
				}
			};
			action("default");
			CharWordReader charWordReader = new CharWordReader(reader, 4096);
			float num = 5f;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			while (true)
			{
				if (Time.realtimeSinceStartup - realtimeSinceStartup > num)
				{
					Debug.LogError("OBJ loading timed out!");
					return null;
				}
				charWordReader.SkipWhitespaces();
				if (charWordReader.endReached)
				{
					break;
				}
				charWordReader.ReadUntilWhiteSpace();
				if (charWordReader.Is("#"))
				{
					charWordReader.SkipUntilNewLine();
				}
				else if (Materials == null && charWordReader.Is("mtllib"))
				{
					charWordReader.SkipWhitespaces();
					charWordReader.ReadUntilNewLine();
					string mtlLibPath = charWordReader.GetString();
					LoadMaterialLibrary(mtlLibPath);
				}
				else if (charWordReader.Is("v"))
				{
					Vertices.Add(charWordReader.ReadVector());
				}
				else if (charWordReader.Is("vn"))
				{
					Normals.Add(charWordReader.ReadVector());
				}
				else if (charWordReader.Is("vt"))
				{
					UVs.Add(charWordReader.ReadVector());
				}
				else if (charWordReader.Is("usemtl"))
				{
					charWordReader.SkipWhitespaces();
					charWordReader.ReadUntilNewLine();
					string text = charWordReader.GetString();
					material = text;
					if (SplitMode == SplitMode.Material)
					{
						action(text);
					}
				}
				else if ((charWordReader.Is("o") || charWordReader.Is("g")) && SplitMode == SplitMode.Object)
				{
					charWordReader.ReadUntilNewLine();
					string obj = charWordReader.GetString(1);
					action(obj);
				}
				else if (charWordReader.Is("f"))
				{
					while (true)
					{
						charWordReader.SkipWhitespaces(out var newLinePassed);
						if (newLinePassed)
						{
							break;
						}
						int num2 = int.MinValue;
						int num3 = int.MinValue;
						int num4 = int.MinValue;
						num2 = charWordReader.ReadInt();
						if (charWordReader.currentChar == '/')
						{
							charWordReader.MoveNext();
							if (charWordReader.currentChar != '/')
							{
								num4 = charWordReader.ReadInt();
							}
							if (charWordReader.currentChar == '/')
							{
								charWordReader.MoveNext();
								num3 = charWordReader.ReadInt();
							}
						}
						if (num2 > int.MinValue)
						{
							if (num2 < 0)
							{
								num2 = Vertices.Count - num2;
							}
							num2--;
						}
						if (num3 > int.MinValue)
						{
							if (num3 < 0)
							{
								num3 = Normals.Count - num3;
							}
							num3--;
						}
						if (num4 > int.MinValue)
						{
							if (num4 < 0)
							{
								num4 = UVs.Count - num4;
							}
							num4--;
						}
						list.Add(num2);
						list2.Add(num3);
						list3.Add(num4);
					}
					currentBuilder.PushFace(material, list, list2, list3);
					list.Clear();
					list2.Clear();
					list3.Clear();
				}
				else
				{
					charWordReader.SkipUntilNewLine();
				}
			}
			GameObject gameObject = new GameObject((_objInfo != null) ? Path.GetFileNameWithoutExtension(_objInfo.Name) : "WavefrontObject");
			gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
			foreach (KeyValuePair<string, OBJObjectBuilder> item in builderDict)
			{
				if (item.Value.PushedFaceCount != 0)
				{
					item.Value.Build().transform.SetParent(gameObject.transform, worldPositionStays: false);
				}
			}
			return gameObject;
		}

		public GameObject Load(Stream input, Stream mtlInput)
		{
			MTLLoader mTLLoader = new MTLLoader();
			Materials = mTLLoader.Load(mtlInput);
			return Load(input);
		}

		public GameObject Load(string path, string mtlPath)
		{
			_objInfo = new FileInfo(path);
			if (!string.IsNullOrEmpty(mtlPath) && File.Exists(mtlPath))
			{
				MTLLoader mTLLoader = new MTLLoader();
				Materials = mTLLoader.Load(mtlPath);
				using FileStream input = new FileStream(path, FileMode.Open);
				return Load(input);
			}
			using FileStream input2 = new FileStream(path, FileMode.Open);
			return Load(input2);
		}

		public GameObject Load(string path)
		{
			return Load(path, null);
		}
	}
}
