using System.Text;
using UnityEngine;

namespace PajamaLlama.Debugs
{
	public class Debugger : MonoBehaviour
	{
		private const string PATH_SEPERATOR = "->";

		private static StringBuilder _stringBuilder;

		public static void Log(object message, Object referencedObject = null, int level = 2)
		{
		}

		public static void Warning(object message, Object referencedObject = null, bool onlyShowInEditor = false)
		{
			if (!onlyShowInEditor || Application.isEditor)
			{
				string text = "";
				Debug.LogWarning("<color=maroon><b>" + text + message?.ToString() + "</b></color>", referencedObject);
			}
		}

		public static void Error(object message, Object referencedObject = null)
		{
			Debug.LogError("" + message, referencedObject);
		}

		public static void ComponentPath(Component component)
		{
		}

		public static string ReturnComponentPath(Component component)
		{
			using ListPool<string>.List list = ListPool<string>.Get(10);
			Transform parent = component.transform;
			while ((bool)parent)
			{
				list.Insert(0, parent.name);
				parent = parent.parent;
			}
			return string.Join(">", list);
		}

		public static string ReturnPathFromComponentInParent<T>(Component component) where T : Component
		{
			return component.name;
		}

		private static StringBuilder ReturnStringBuilder()
		{
			if (_stringBuilder == null)
			{
				_stringBuilder = new StringBuilder();
			}
			else
			{
				_stringBuilder.Clear();
			}
			return _stringBuilder;
		}
	}
}
