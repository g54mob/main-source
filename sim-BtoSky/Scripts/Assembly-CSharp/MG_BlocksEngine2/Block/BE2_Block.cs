using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.DragDrop;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_Block : MonoBehaviour, I_BE2_Block
	{
		[SerializeField]
		private BlockTypeEnum _type;

		private Transform _transform;

		public BlockTypeEnum Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public Transform Transform
		{
			get
			{
				if (!_transform)
				{
					return base.transform;
				}
				return _transform;
			}
		}

		public I_BE2_BlockLayout Layout { get; set; }

		public I_BE2_Instruction Instruction { get; set; }

		public I_BE2_BlockSection ParentSection { get; set; }

		public I_BE2_Block ParentBlock { get; set; }

		public I_BE2_Drag Drag { get; set; }

		private void OnValidate()
		{
			Awake();
		}

		private void Awake()
		{
			_transform = base.transform;
			Layout = GetComponent<I_BE2_BlockLayout>();
			Instruction = GetComponent<I_BE2_Instruction>();
			Drag = GetComponent<I_BE2_Drag>();
		}

		private void Start()
		{
			GetParentSection();
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetParentSection);
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetParentSection);
		}

		private void GetParentSection()
		{
			ParentBlock = base.transform.parent.GetComponentInParent<I_BE2_Block>();
			ParentSection = GetComponentInParent<I_BE2_BlockSection>();
		}

		public void SetShadowActive(bool value)
		{
			if (Type == BlockTypeEnum.operation)
			{
				return;
			}
			I_BE2_BlockSection[] sectionsArray;
			if (value)
			{
				sectionsArray = Layout.SectionsArray;
				foreach (I_BE2_BlockSection i_BE2_BlockSection in sectionsArray)
				{
					if (i_BE2_BlockSection.Header != null && (bool)i_BE2_BlockSection.Header.Shadow)
					{
						i_BE2_BlockSection.Header.Shadow.enabled = true;
					}
					if (i_BE2_BlockSection.Body != null && (bool)i_BE2_BlockSection.Body.Shadow)
					{
						i_BE2_BlockSection.Body.Shadow.enabled = true;
					}
				}
				return;
			}
			sectionsArray = Layout.SectionsArray;
			foreach (I_BE2_BlockSection i_BE2_BlockSection2 in sectionsArray)
			{
				if (i_BE2_BlockSection2.Header != null && (bool)i_BE2_BlockSection2.Header.Shadow)
				{
					i_BE2_BlockSection2.Header.Shadow.enabled = false;
				}
				if (i_BE2_BlockSection2.Body != null && (bool)i_BE2_BlockSection2.Body.Shadow)
				{
					i_BE2_BlockSection2.Body.Shadow.enabled = false;
				}
			}
		}
	}
}
