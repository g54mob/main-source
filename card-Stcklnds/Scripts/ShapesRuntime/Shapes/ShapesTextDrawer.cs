using TMPro;
using UnityEngine;

namespace Shapes
{
	public class ShapesTextDrawer : MonoBehaviour
	{
		private static ShapesTextDrawer instance;

		public TextMeshPro tmp;

		public static ShapesTextDrawer Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<ShapesTextDrawer>();
					if (instance == null)
					{
						instance = Create();
					}
				}
				return instance;
			}
		}

		private static ShapesTextDrawer Create()
		{
			GameObject gameObject = new GameObject("TEXT DRAWER");
			if (Application.isPlaying)
			{
				Object.DontDestroyOnLoad(gameObject);
			}
			ShapesTextDrawer shapesTextDrawer = gameObject.AddComponent<ShapesTextDrawer>();
			shapesTextDrawer.tmp = gameObject.AddComponent<TextMeshPro>();
			shapesTextDrawer.tmp.enableWordWrapping = false;
			shapesTextDrawer.tmp.overflowMode = TextOverflowModes.Overflow;
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			Hide(gameObject);
			return shapesTextDrawer;
		}

		private static void Hide(params Object[] objs)
		{
			objs.ForEach(delegate(Object o)
			{
				o.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor;
			});
		}
	}
}
