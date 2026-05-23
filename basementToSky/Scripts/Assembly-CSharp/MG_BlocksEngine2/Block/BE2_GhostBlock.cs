using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.DragDrop;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_GhostBlock : MonoBehaviour, I_BE2_Block
	{
		private Transform _transform;

		public BlockTypeEnum Type
		{
			get
			{
				return BlockTypeEnum.none;
			}
			set
			{
			}
		}

		public I_BE2_BlockLayout Layout { get; set; }

		public I_BE2_Instruction Instruction { get; set; }

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

		public I_BE2_BlockSection ParentSection { get; set; }

		public I_BE2_Block ParentBlock { get; set; }

		public I_BE2_Drag Drag { get; set; }

		private void Awake()
		{
			_transform = base.transform;
			Layout = GetComponent<I_BE2_BlockLayout>();
		}

		public void SetShadowActive(bool value)
		{
		}
	}
}
