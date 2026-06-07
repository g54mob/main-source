using System;
using System.IO;
using System.Text.RegularExpressions;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Serializer;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_SaveLoadContextMenu : MonoBehaviour, I_BE2_UI_ContextMenu
	{
		private string _codesPath;

		private BE2_UI_ContextMenuManager _contextMenuManager;

		private I_BE2_ProgrammingEnv _targetProgrammingEnv;

		private BE2_DragDropManager _dragDropManager;

		public ToggleGroup scrollContentTG;

		public Toggle itemToggleTemplate;

		public TMP_InputField fileInputField;

		public GameObject panelDefaultButtonsGO;

		public GameObject panelConfirmDeleteGO;

		public GameObject panelConfirmReplaceGO;

		public BE2_Text Title { get; set; }

		private void Awake()
		{
			_contextMenuManager = GetComponentInParent<BE2_UI_ContextMenuManager>();
			Title = BE2_Text.GetBE2Text(base.transform.GetChild(0));
			_codesPath = BE2_Paths.TranslateMarkupPath(BE2_Paths.SavedCodesPath);
		}

		private void Start()
		{
			_dragDropManager = BE2_DragDropManager.Instance;
		}

		public void Open<T>(T target, params string[] options)
		{
			Awake();
			Start();
			_targetProgrammingEnv = target as I_BE2_ProgrammingEnv;
			panelDefaultButtonsGO.SetActive(value: true);
			panelConfirmDeleteGO.SetActive(value: false);
			panelConfirmReplaceGO.SetActive(value: false);
			RefreshScrollValues();
			base.gameObject.SetActive(value: true);
		}

		public void Close()
		{
			_targetProgrammingEnv = null;
			base.gameObject.SetActive(value: false);
		}

		private void RefreshScrollValues()
		{
			for (int num = itemToggleTemplate.transform.parent.childCount - 1; num > 0; num--)
			{
				UnityEngine.Object.Destroy(itemToggleTemplate.transform.parent.GetChild(num).gameObject);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(_codesPath);
			if (!Directory.Exists(_codesPath))
			{
				Directory.CreateDirectory(_codesPath);
			}
			try
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					if (files[i].Extension.ToLower() == ".be2")
					{
						string text = files[i].Name;
						GameObject gameObject = UnityEngine.Object.Instantiate(itemToggleTemplate.gameObject);
						Toggle toggle = gameObject.GetComponent<Toggle>();
						BE2_Text.GetBE2TextInChildren(toggle.transform).text = text;
						toggle.transform.SetParent(itemToggleTemplate.transform.parent);
						toggle.transform.localScale = Vector3.one;
						toggle.group = itemToggleTemplate.transform.parent.GetComponent<ToggleGroup>();
						toggle.transform.SetAsLastSibling();
						gameObject.SetActive(value: true);
						toggle.transform.localPosition = new Vector3(toggle.transform.localPosition.x, toggle.transform.localPosition.y, 0f);
						toggle.transform.localEulerAngles = Vector3.zero;
						toggle.onValueChanged.AddListener(delegate
						{
							fileInputField.text = BE2_Text.GetBE2TextInChildren(toggle.transform).text;
						});
					}
				}
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
		}

		public void Save()
		{
			BE2_BlocksSerializer.SaveCode(GetFullPath(), _targetProgrammingEnv);
			RefreshScrollValues();
			CancelConfirm();
		}

		private string GetFileName()
		{
			string text = fileInputField.text;
			if (text.Length >= 4 && text.Substring(text.Length - 4, 4).ToLower() == ".be2")
			{
				text = text.Substring(0, text.Length - 4);
			}
			return Regex.Replace(text, "[^\\w\\._]", "");
		}

		private string GetFullPath()
		{
			return _codesPath + GetFileName() + ".BE2";
		}

		public void ConfirmSave()
		{
			if (fileInputField.text != "")
			{
				if (!File.Exists(GetFullPath()))
				{
					Save();
					return;
				}
				panelDefaultButtonsGO.SetActive(value: false);
				panelConfirmReplaceGO.SetActive(value: true);
			}
		}

		public void Load()
		{
			if (BE2_BlocksSerializer.LoadCode(GetFullPath(), _targetProgrammingEnv))
			{
				_contextMenuManager.CloseContextMenu();
			}
		}

		public void Delete()
		{
			File.Delete(GetFullPath());
			RefreshScrollValues();
			CancelConfirm();
		}

		public void ConfirmDelete()
		{
			if (File.Exists(GetFullPath()))
			{
				panelDefaultButtonsGO.SetActive(value: false);
				panelConfirmDeleteGO.SetActive(value: true);
			}
		}

		public void Cancel()
		{
			_contextMenuManager.CloseContextMenu();
		}

		public void CancelConfirm()
		{
			panelConfirmDeleteGO.SetActive(value: false);
			panelConfirmReplaceGO.SetActive(value: false);
			panelDefaultButtonsGO.SetActive(value: true);
		}
	}
}
