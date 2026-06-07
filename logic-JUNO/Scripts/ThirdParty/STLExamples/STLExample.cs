using System;
using UnityEngine;

namespace STLExamples
{
	public class STLExample : MonoBehaviour
	{
		private const int objectCount = 100;

		private GameObject[] _objects;

		private void Start()
		{
			GenerateNewObjects();
		}

		public void GenerateNewObjects()
		{
			if (_objects != null)
			{
				for (int i = 0; i < _objects.Length; i++)
				{
					UnityEngine.Object.Destroy(_objects[i]);
				}
			}
			_objects = new GameObject[100];
			for (int j = 0; j < _objects.Length; j++)
			{
				_objects[j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				_objects[j].transform.parent = base.transform;
				_objects[j].transform.localScale = Vector3.one * UnityEngine.Random.Range(0.1f, 1f);
				_objects[j].transform.position = UnityEngine.Random.insideUnitSphere * 2f;
			}
		}

		public void ExportToBinarySTL()
		{
			string text = DefaultDirectory() + "/stl_example_binary.stl";
			if (STL.Export(_objects, text))
			{
				Debug.Log("Exported " + 100 + " objects to binary STL file." + Environment.NewLine + text);
			}
		}

		public void ExportToTextSTL()
		{
			string text = DefaultDirectory() + "/stl_example_text.stl";
			bool asASCII = true;
			if (STL.Export(_objects, text, asASCII))
			{
				Debug.Log("Exported " + 100 + " objects to text based STL file." + Environment.NewLine + text);
			}
		}

		private static string DefaultDirectory()
		{
			string text = "";
			if (Application.platform == RuntimePlatform.OSXEditor)
			{
				return Environment.GetEnvironmentVariable("HOME") + "/Desktop";
			}
			return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}
	}
}
