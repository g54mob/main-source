using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGGameObjectProperties
	{
		[CanBeNull]
		[SerializeField]
		private GameObject m_Object;

		[VectorEx(null, null)]
		[SerializeField]
		private Vector3 m_Translation;

		[VectorEx(null, null)]
		[SerializeField]
		private Vector3 m_Rotation;

		[SerializeField]
		[VectorEx(null, null)]
		private Vector3 m_Scale;

		[CanBeNull]
		public GameObject Object
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 Translation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 Rotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 Scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Matrix4x4 Matrix => default(Matrix4x4);

		public CGGameObjectProperties()
		{
		}

		public CGGameObjectProperties(GameObject gameObject)
		{
		}
	}
}
