using System.Collections.Generic;
using UnityEngine;

namespace UniGLTF
{
	public class BlendShape
	{
		public string Name;

		public List<Vector3> Positions = new List<Vector3>();

		public List<Vector3> Normals = new List<Vector3>();

		public List<Vector3> Tangents = new List<Vector3>();

		public BlendShape(string name)
		{
			Name = name;
		}
	}
}
