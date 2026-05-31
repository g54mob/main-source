using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableMatrix4x4
	{
		public float m00;

		public float m10;

		public float m20;

		public float m30;

		public float m01;

		public float m11;

		public float m21;

		public float m31;

		public float m02;

		public float m12;

		public float m22;

		public float m32;

		public float m03;

		public float m13;

		public float m23;

		public float m33;

		public SerializableMatrix4x4(Matrix4x4 initialValue)
		{
		}

		public static implicit operator SerializableMatrix4x4(Matrix4x4 matrix)
		{
			return null;
		}

		public static implicit operator Matrix4x4(SerializableMatrix4x4 matrix)
		{
			return default(Matrix4x4);
		}
	}
}
