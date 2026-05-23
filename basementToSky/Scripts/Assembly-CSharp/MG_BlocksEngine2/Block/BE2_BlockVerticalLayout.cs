using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockVerticalLayout : MonoBehaviour, I_BE2_BlockLayout
	{
		public Color blockColor = Color.white;

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

		public Color Color
		{
			get
			{
				return blockColor;
			}
			set
			{
				blockColor = value;
			}
		}

		public Vector2 Size
		{
			get
			{
				Vector2 zero = Vector2.zero;
				int num = SectionsArray.Length;
				for (int i = 0; i < num; i++)
				{
					I_BE2_BlockSection i_BE2_BlockSection = SectionsArray[i];
					zero.y += i_BE2_BlockSection.Size.y;
					if (i_BE2_BlockSection.Size.x > zero.x)
					{
						zero.x = i_BE2_BlockSection.Size.x;
					}
				}
				return zero;
			}
		}

		public BE2_OuterArea OuterArea { get; set; }

		private void Awake()
		{
			Initialize();
		}

		private void Start()
		{
			_rectTransform.pivot = new Vector2(0f, 1f);
			UpdateLayout();
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
		}

		private void OnEnable()
		{
			BE2_ExecutionManager.Instance.AddToLateUpdate(UpdateLayout);
		}

		private void OnDisable()
		{
			BE2_ExecutionManager.Instance?.RemoveFromLateUpdate(UpdateLayout);
		}

		public void Initialize()
		{
			_rectTransform = GetComponent<RectTransform>();
			_sectionsArray = new I_BE2_BlockSection[0];
			BE2_SpotOuterArea bE2_SpotOuterArea = null;
			foreach (Transform item in base.transform)
			{
				bE2_SpotOuterArea = item.GetComponent<BE2_SpotOuterArea>();
				if ((bool)bE2_SpotOuterArea)
				{
					break;
				}
			}
			if ((bool)bE2_SpotOuterArea)
			{
				OuterArea = new BE2_OuterAreaVertical(bE2_SpotOuterArea.transform);
			}
			else
			{
				foreach (Transform item2 in base.transform)
				{
					if (item2.name == "OuterArea")
					{
						OuterArea = new BE2_OuterAreaVertical(item2);
						break;
					}
				}
			}
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
			_rectTransform.sizeDelta = Size;
			int num = SectionsArray.Length;
			for (int i = 0; i < num; i++)
			{
				SectionsArray[i].UpdateLayout();
			}
			if (OuterArea != null)
			{
				OuterArea.UpdateLayout();
			}
		}
	}
}
