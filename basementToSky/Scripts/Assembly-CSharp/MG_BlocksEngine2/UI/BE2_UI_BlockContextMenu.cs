using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_BlockContextMenu : MonoBehaviour, I_BE2_UI_ContextMenu
	{
		private BE2_UI_ContextMenuManager _contextMenuManager;

		private I_BE2_Block _targetBlock;

		private BE2_DragDropManager _dragDropManager;

		public BE2_Text Title { get; set; }

		private void Awake()
		{
			_contextMenuManager = GetComponentInParent<BE2_UI_ContextMenuManager>();
			Title = BE2_Text.GetBE2Text(base.transform.GetChild(0));
		}

		private void Start()
		{
			_dragDropManager = BE2_DragDropManager.Instance;
		}

		public void Open<T>(T target, params string[] options)
		{
			Awake();
			Start();
			_targetBlock = target as I_BE2_Block;
			Title.text = _targetBlock.Instruction.GetType().ToString().Split('_')[2];
			base.transform.position = BE2_Pointer.Instance.transform.position;
			Button[] componentsInChildren = base.transform.GetComponentsInChildren<Button>();
			Button[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].interactable = true;
			}
			for (int i = 0; i < options.Length; i++)
			{
				if (options[i] == "noDuplicate")
				{
					componentsInChildren[0].interactable = false;
				}
			}
			base.gameObject.SetActive(value: true);
		}

		public void Close()
		{
			_targetBlock = null;
			base.gameObject.SetActive(value: false);
		}

		public void Duplicate()
		{
			BE2_BlockUtils.DuplicateBlock(_targetBlock);
			_contextMenuManager.CloseContextMenu();
		}

		public void Delete()
		{
			BE2_BlockUtils.RemoveBlock(_targetBlock);
			_contextMenuManager.CloseContextMenu();
		}

		public void Cancel()
		{
			_contextMenuManager.CloseContextMenu();
		}
	}
}
