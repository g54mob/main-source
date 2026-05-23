using System.Collections.Generic;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Serializer;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public abstract class BE2_FunctionBlocksManager : MonoBehaviour
	{
		private static BE2_FunctionBlocksManager _instance;

		public GameObject DefineFunctionBlockTemplate;

		public GameObject templateSelectionBlock;

		public GameObject templateDefineLocalVariable;

		public GameObject templateDefineCustomHeaderItem;

		public Transform functionBlocksPanel;

		public Vector2 positionToInstantiate = new Vector2(300f, -100f);

		public static BE2_FunctionBlocksManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindObjectOfType<BE2_FunctionBlocksManager>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public virtual void CreateFunctionBlock(List<DefineItem> items)
		{
		}

		public virtual void CreateSelectionFunction(List<DefineItem> items, BE2_Ins_DefineFunction defineBlockIns)
		{
		}
	}
}
