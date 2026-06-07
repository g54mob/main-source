using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockNoViewLayout : MonoBehaviour, I_BE2_BlockLayout
	{
		private RectTransform _rectTransform;

		private I_BE2_BlockSection[] _sectionsArray;

		public RectTransform RectTransform
		{
			get
			{
				return _rectTransform;
			}
			set
			{
				_rectTransform = value;
			}
		}

		public I_BE2_BlockSection[] SectionsArray => _sectionsArray;

		public Color Color { get; set; }

		public Vector2 Size => Vector2.zero;

		public BE2_OuterArea OuterArea { get; set; }

		private void OnValidate()
		{
			Awake();
		}

		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			_rectTransform = GetComponent<RectTransform>();
			_sectionsArray = new I_BE2_BlockSection[0];
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				I_BE2_BlockSection component = base.transform.GetChild(i).GetComponent<I_BE2_BlockSection>();
				if (component != null)
				{
					BE2_ArrayUtils.Add(ref _sectionsArray, component);
				}
			}
		}

		public void UpdateLayout()
		{
			int num = SectionsArray.Length;
			for (int i = 0; i < num; i++)
			{
				SectionsArray[i].UpdateLayout();
			}
		}
	}
}
