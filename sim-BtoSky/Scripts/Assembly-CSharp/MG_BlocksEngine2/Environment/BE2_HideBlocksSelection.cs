using System.Collections.Generic;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_HideBlocksSelection : MonoBehaviour
	{
		private BE2_Canvas _blocksSelectionCanvas;

		private Vector3 _hidePosition;

		private Dictionary<RectTransform, Vector3> _envs = new Dictionary<RectTransform, Vector3>();

		private void Start()
		{
			_blocksSelectionCanvas = GetComponentInParent<BE2_Canvas>();
			_hidePosition = (_blocksSelectionCanvas.transform.GetChild(0) as RectTransform).anchoredPosition;
			GetComponent<Button>().onClick.AddListener(HideBlocksSelection);
			BE2_UI_SelectionButton[] array = Object.FindObjectsOfType<BE2_UI_SelectionButton>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GetComponent<Button>().onClick.AddListener(ShowBlocksSelection);
			}
			foreach (I_BE2_ProgrammingEnv programmingEnvs in BE2_ExecutionManager.Instance.ProgrammingEnvsList)
			{
				_envs.Add(programmingEnvs.Transform.GetComponentInParent<BE2_Canvas>().Canvas.transform.GetChild(0) as RectTransform, (programmingEnvs.Transform.GetComponentInParent<BE2_Canvas>().Canvas.transform.GetChild(0) as RectTransform).anchoredPosition);
			}
		}

		public void HideBlocksSelection()
		{
			_blocksSelectionCanvas.gameObject.SetActive(value: false);
			foreach (KeyValuePair<RectTransform, Vector3> env in _envs)
			{
				env.Key.anchoredPosition = _hidePosition;
			}
		}

		public void ShowBlocksSelection()
		{
			if (_blocksSelectionCanvas.gameObject.activeSelf)
			{
				return;
			}
			_blocksSelectionCanvas.gameObject.SetActive(value: true);
			foreach (KeyValuePair<RectTransform, Vector3> env in _envs)
			{
				env.Key.anchoredPosition = env.Value;
			}
		}
	}
}
