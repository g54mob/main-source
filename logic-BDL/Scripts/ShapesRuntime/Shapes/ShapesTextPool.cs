using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ShapesTextPool : MonoBehaviour
	{
		private const int ALLOCATION_COUNT_WARNING = 500;

		private const int ALLOCATION_COUNT_CAP = 1000;

		private Stack<TextMeshPro> elementsPassive = new Stack<TextMeshPro>();

		private Dictionary<int, TextMeshPro> elementsActive = new Dictionary<int, TextMeshPro>();

		private static ShapesTextPool instance;

		private int ElementCount => elementsPassive.Count + elementsActive.Count;

		public TextMeshPro ImmediateModeElement => GetElement(-1);

		public static int InstanceElementCount
		{
			get
			{
				if (!InstanceExists)
				{
					return 0;
				}
				return Instance.ElementCount;
			}
		}

		public static int InstanceElementCountActive
		{
			get
			{
				if (!InstanceExists)
				{
					return 0;
				}
				return Instance.elementsActive.Count;
			}
		}

		public static bool InstanceExists => instance != null;

		public static ShapesTextPool Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<ShapesTextPool>();
					if (instance == null)
					{
						instance = CreatePool();
					}
				}
				return instance;
			}
		}

		private static ShapesTextPool CreatePool()
		{
			GameObject gameObject = new GameObject("Shapes Text Pool");
			if (Application.isPlaying)
			{
				Object.DontDestroyOnLoad(gameObject);
			}
			ShapesTextPool result = gameObject.AddComponent<ShapesTextPool>();
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			return result;
		}

		private void ClearData()
		{
			for (int num = base.transform.childCount - 1; num >= 0; num--)
			{
				base.transform.GetChild(num).gameObject.DestroyBranched();
			}
			elementsPassive.Clear();
			elementsActive.Clear();
		}

		private void OnEnable()
		{
			ClearData();
			instance = this;
		}

		private void OnDisable()
		{
			ClearData();
		}

		public TextMeshPro GetElement(int id)
		{
			if (!elementsActive.TryGetValue(id, out var value))
			{
				return AllocateElement(id);
			}
			return value;
		}

		public TextMeshPro AllocateElement(int id)
		{
			TextMeshPro textMeshPro = null;
			while (textMeshPro == null && elementsPassive.Count > 0)
			{
				textMeshPro = elementsPassive.Pop();
			}
			if (textMeshPro == null)
			{
				textMeshPro = CreateElement(id);
			}
			elementsActive.Add(id, textMeshPro);
			return textMeshPro;
		}

		public void ReleaseElement(int id)
		{
			if (elementsActive.TryGetValue(id, out var value))
			{
				elementsActive.Remove(id);
				elementsPassive.Push(value);
			}
		}

		private TextMeshPro CreateElement(int id)
		{
			int elementCount = ElementCount;
			if (elementCount > 1000)
			{
				Debug.LogError($"Text element allocation cap of {1000} reached. You are probably leaking and not properly disposing text elements");
				return null;
			}
			if (elementCount > 500)
			{
				Debug.LogWarning($"Allocating more than {500} text elements. You are probably leaking and not properly disposing text objects");
			}
			GameObject obj = new GameObject((id == -1) ? "Immediate Mode Text" : id.ToString());
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			obj.transform.localPosition = Vector3.zero;
			obj.hideFlags = HideFlags.HideAndDontSave;
			TextMeshPro textMeshPro = obj.AddComponent<TextMeshPro>();
			textMeshPro.enableWordWrapping = false;
			textMeshPro.overflowMode = TextOverflowModes.Overflow;
			textMeshPro.GetComponent<MeshRenderer>().enabled = false;
			return textMeshPro;
		}
	}
}
