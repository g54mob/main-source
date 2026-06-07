using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Console
{
	internal class ConsoleUI : MonoBehaviour
	{
		private const HideFlags HIDE_FLAGS = HideFlags.HideInHierarchy | HideFlags.HideInInspector;

		[SerializeField]
		private GameObject m_PrefabLineSubmit;

		[SerializeField]
		private GameObject m_PrefabLineResponse;

		[SerializeField]
		private GameObject m_PrefabLineError;

		[SerializeField]
		private GameObject m_Panel;

		[SerializeField]
		private InputField m_Input;

		[SerializeField]
		private ScrollRect m_Scroll;

		public bool IsOpen => m_Panel.activeInHierarchy;

		private void Awake()
		{
			base.gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
		}

		public void Submit()
		{
			if (IsOpen)
			{
				string text = m_Input.text;
				if (!string.IsNullOrEmpty(text))
				{
					Input input = new Input(text);
					Print(input.ToString(), m_PrefabLineSubmit);
					m_Input.text = string.Empty;
					Console.Submit(input);
				}
			}
		}

		public void Print(string text)
		{
			Print(text, m_PrefabLineResponse);
		}

		public void Clear()
		{
			for (int num = m_Scroll.content.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(m_Scroll.content.GetChild(num).gameObject);
			}
		}

		public void Close()
		{
			m_Panel.SetActive(value: false);
			m_Input.Select();
		}

		public void Open()
		{
			m_Panel.SetActive(value: true);
			m_Input.Select();
		}

		internal void Print(Output output)
		{
			GameObject prefab = (output.IsError ? m_PrefabLineError : m_PrefabLineResponse);
			Print(output.Text, prefab);
		}

		private void Print(string text, GameObject prefab)
		{
			if (!string.IsNullOrEmpty(text))
			{
				Object.Instantiate(prefab, m_Scroll.content).GetComponent<Text>().text = text;
				m_Input.Select();
				m_Input.ActivateInputField();
				StartCoroutine(ScrollBottom());
			}
		}

		private IEnumerator ScrollBottom()
		{
			yield return new WaitForEndOfFrame();
			m_Scroll.verticalNormalizedPosition = 0f;
		}
	}
}
