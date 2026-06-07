using System;
using UnityEngine;

namespace UniMerge.Demo
{
	public class TestScript : MonoBehaviour
	{
		[Serializable]
		public class Test
		{
			public Vector3 vec3;

			public Quaternion quat;

			public Test nested;
		}

		public GameObject ref1;

		public GameObject ref2;

		public GameObject ref3;

		public Collider col1;

		public MonoBehaviour mb;

		public Rigidbody rigid;

		public Bounds bounds;

		public Quaternion quat;

		public Rect rect;

		public Vector2 vec2;

		public Vector3 vec3;

		public Vector4 vec4;

		public string str;

		public int i;

		public bool b;

		public float f;

		public Color c;

		public LayerMask l;

		public Transform[] arr;

		public char ch;

		public AnimationCurve anim;

		public Gradient g;

		public Test test;
	}
}
