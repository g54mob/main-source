using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class ControlPoint
	{
		[SerializeField]
		public Vector3 position = Vector3.zero;

		[SerializeField]
		public Quaternion rotation = Quaternion.identity;

		public override string ToString()
		{
			string[] obj = new string[5] { "ControlPoint = [ position = ", null, null, null, null };
			Vector3 vector = position;
			obj[1] = vector.ToString();
			obj[2] = ", rotation = ";
			Quaternion quaternion = rotation;
			obj[3] = quaternion.ToString();
			obj[4] = "]";
			return string.Concat(obj);
		}
	}
}
