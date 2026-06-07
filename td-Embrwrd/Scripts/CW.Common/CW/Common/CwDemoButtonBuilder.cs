using UnityEngine;

namespace CW.Common
{
	[AddComponentMenu("Common/CW Demo Button Builder")]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwDemoButtonBuilder")]
	public class CwDemoButtonBuilder : MonoBehaviour
	{
		[SerializeField]
		private GameObject buttonPrefab;

		[SerializeField]
		private RectTransform buttonRoot;

		[SerializeField]
		private Sprite icon;

		[SerializeField]
		private Color color;

		[Multiline(3)]
		[SerializeField]
		private string overrideName;

		[SerializeField]
		private GameObject clone;

		public GameObject ButtonPrefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RectTransform ButtonRoot
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Sprite Icon
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public string OverrideName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[ContextMenu("Build")]
		public void Build()
		{
		}

		[ContextMenu("Build All")]
		public void BuildAll()
		{
		}

		private GameObject DoInstantiate()
		{
			return null;
		}
	}
}
