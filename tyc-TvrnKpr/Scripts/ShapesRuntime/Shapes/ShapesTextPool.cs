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

		private Stack<TextMeshPro> elementsPassive;

		private Dictionary<int, TextMeshPro> elementsActive;

		private static ShapesTextPool instance;

		private int ElementCount => 0;

		public TextMeshPro ImmediateModeElement => null;

		public static int InstanceElementCount => 0;

		public static int InstanceElementCountActive => 0;

		public static bool InstanceExists => false;

		public static ShapesTextPool Instance => null;

		private static ShapesTextPool CreatePool()
		{
			return null;
		}

		private void ClearData()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public TextMeshPro GetElement(int id)
		{
			return null;
		}

		public TextMeshPro AllocateElement(int id)
		{
			return null;
		}

		public void ReleaseElement(int id)
		{
		}

		private TextMeshPro CreateElement(int id)
		{
			return null;
		}
	}
}
