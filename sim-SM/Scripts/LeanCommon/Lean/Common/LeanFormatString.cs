using System;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanFormatString")]
	[AddComponentMenu("Lean/Common/Lean Format String")]
	public class LeanFormatString : MonoBehaviour
	{
		[Serializable]
		public class StringEvent : UnityEvent<string>
		{
		}

		[SerializeField]
		[Multiline]
		private string format;

		[SerializeField]
		private StringEvent onString;

		public string Format
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public StringEvent OnString => null;

		public void SetString(string a)
		{
		}

		public void SetString(string a, string b)
		{
		}

		public void SetString(int a)
		{
		}

		public void SetString(int a, int b)
		{
		}

		public void SetString(float a)
		{
		}

		public void SetString(float a, float b)
		{
		}

		public void SetString(Vector2 a)
		{
		}

		public void SetString(Vector2 a, Vector2 b)
		{
		}

		public void SetString(Vector3 a)
		{
		}

		public void SetString(Vector3 a, Vector3 b)
		{
		}

		public void SetString(Vector4 a)
		{
		}

		public void SetString(Vector4 a, Vector4 b)
		{
		}

		public void SetString(float a, int b)
		{
		}

		public void SetString(int a, float b)
		{
		}

		private void SendString(object a)
		{
		}

		private void SendString(object a, object b)
		{
		}
	}
}
