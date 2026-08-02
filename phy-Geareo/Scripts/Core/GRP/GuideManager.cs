using UnityEngine;

namespace GRP
{
	public class GuideManager : MonoBehaviour
	{
		public Guide guide;

		public static GuideManager instance { get; private set; }

		private void Awake()
		{
		}

		public static void Set(uint order, string key, string text, bool active, params Sprite[] sprites)
		{
		}

		public static void Set(uint order, string key, string text, bool active, params GuideIcon[] icons)
		{
		}

		public static void Set(uint order, string key, string text, params GuideIcon[] icons)
		{
		}

		public static void Set(uint order, string key, GuideData data)
		{
		}

		public static void Remove(uint order, string key)
		{
		}

		public static bool Has(uint order, string key)
		{
			return false;
		}
	}
}
