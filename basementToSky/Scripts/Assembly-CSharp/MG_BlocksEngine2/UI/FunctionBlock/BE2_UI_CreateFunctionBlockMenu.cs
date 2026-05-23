using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Serializer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI.FunctionBlock
{
	public class BE2_UI_CreateFunctionBlockMenu : MonoBehaviour
	{
		public Transform editorBlockTransform;

		private I_BE2_Block _editorBlock;

		public GameObject templateInput;

		public GameObject templateLabel;

		private void Awake()
		{
			_editorBlock = editorBlockTransform.GetComponent<I_BE2_Block>();
		}

		private void OnEnable()
		{
			bool flag = true;
			I_BE2_BlockSectionHeaderItem[] itemsArray = _editorBlock.Layout.SectionsArray[0].Header.ItemsArray;
			foreach (I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem in itemsArray)
			{
				if ((bool)i_BE2_BlockSectionHeaderItem.Transform.GetComponent<Label>())
				{
					i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_InputField>().Select();
					flag = false;
					break;
				}
			}
			if (flag)
			{
				AddLabel();
			}
		}

		public void AddInput()
		{
			GameObject input = Object.Instantiate(templateInput, Vector3.zero, Quaternion.identity, _editorBlock.Layout.SectionsArray[0].Header.RectTransform);
			input.GetComponentInChildren<Button>(includeInactive: true).onClick.AddListener(delegate
			{
				RemoveItem(input);
			});
			input.GetComponent<TMP_InputField>().Select();
		}

		public void AddLabel()
		{
			GameObject label = Object.Instantiate(templateLabel, Vector3.zero, Quaternion.identity, _editorBlock.Layout.SectionsArray[0].Header.RectTransform);
			label.GetComponentInChildren<Button>(includeInactive: true).onClick.AddListener(delegate
			{
				RemoveItem(label);
			});
			label.GetComponent<TMP_InputField>().Select();
		}

		public void RemoveItem(GameObject item)
		{
			item.transform.SetParent(null);
			_editorBlock.Layout.SectionsArray[0].Header.UpdateItemsArray();
			Object.Destroy(item);
		}

		public void OnButtonCreateFunctionBlock()
		{
			List<DefineItem> list = new List<DefineItem>();
			I_BE2_BlockSectionHeaderItem[] itemsArray = _editorBlock.Layout.SectionsArray[0].Header.ItemsArray;
			foreach (I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem in itemsArray)
			{
				if ((bool)i_BE2_BlockSectionHeaderItem.Transform.GetComponent<Label>())
				{
					list.Add(new DefineItem("label", i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_InputField>().text));
				}
				else
				{
					list.Add(new DefineItem("variable", i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_InputField>().text));
				}
			}
			BE2_FunctionBlocksManager.Instance.CreateFunctionBlock(list);
		}
	}
}
