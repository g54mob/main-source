using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public class FuselageCube
	{
		private VectorLine[] _lines;

		public FuselageScript FuselageScript { get; internal set; }

		public FuselageCube()
		{
			_lines = new VectorLine[12];
			for (int i = 0; i < _lines.Length; i++)
			{
				_lines[i] = new VectorLine("FuselageCubeLine", new List<Vector3>(2)
				{
					Vector3.zero,
					Vector3.zero
				}, null, 2f);
				_lines[i].color = Constants.Colors.Primary.Gamma;
				_lines[i].layer = 10;
				_lines[i].Draw3DAuto();
			}
		}

		public void Destroy()
		{
			for (int i = 0; i < _lines.Length; i++)
			{
				VectorLine.Destroy(ref _lines[i]);
			}
			_lines = null;
		}

		public void Update()
		{
			FuselageData data = FuselageScript.Data;
			Vector3 start = data.Offset - new Vector3(data.TopScale.x, 0f, data.TopScale.y);
			Vector3 start2 = data.Offset + new Vector3(data.TopScale.x, 0f, data.TopScale.y);
			Vector3 vector = new Vector3(start.x, start.y, start2.z);
			Vector3 vector2 = new Vector3(start2.x, start.y, start.z);
			Vector3 vector3 = -data.Offset - new Vector3(data.BottomScale.x, 0f, data.BottomScale.y);
			Vector3 vector4 = -data.Offset + new Vector3(data.BottomScale.x, 0f, data.BottomScale.y);
			Vector3 end = new Vector3(vector3.x, vector3.y, vector4.z);
			Vector3 end2 = new Vector3(vector4.x, vector3.y, vector3.z);
			int num = 0;
			UpdateLine(num++, start, vector);
			UpdateLine(num++, start2, vector);
			UpdateLine(num++, start, vector2);
			UpdateLine(num++, start2, vector2);
			UpdateLine(num++, vector3, end);
			UpdateLine(num++, vector4, end);
			UpdateLine(num++, vector3, end2);
			UpdateLine(num++, vector4, end2);
			UpdateLine(num++, start, vector3);
			UpdateLine(num++, vector, end);
			UpdateLine(num++, vector2, end2);
			UpdateLine(num++, start2, vector4);
		}

		private void UpdateLine(int i, Vector3 start, Vector3 end)
		{
			IPartScript partScript = FuselageScript.PartScript;
			VectorLine obj = _lines[i];
			obj.points3[0] = partScript.Transform.TransformPoint(start);
			obj.points3[1] = partScript.Transform.TransformPoint(end);
		}
	}
}
