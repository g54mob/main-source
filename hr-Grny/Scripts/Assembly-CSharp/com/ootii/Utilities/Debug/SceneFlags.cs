using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	public class SceneFlags : MonoBehaviour
	{
		public struct SceneFlag
		{
			public Vector3 Position;

			public Quaternion Rotation;

			public float Height;

			public Color Color;

			public string Text;

			public Vector3 Vector;
		}

		public static bool IsActive;

		public static List<SceneFlag> Flags;

		public bool _IsEnabled;

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor, string rText)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor, string rText)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, Color rColor, Vector3 rVector)
		{
		}

		public static void AddFlag(Vector3 rPosition, Quaternion rRotation, float rHeight, Color rColor, string rText, Vector3 rVector)
		{
		}

		private void Awake()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
