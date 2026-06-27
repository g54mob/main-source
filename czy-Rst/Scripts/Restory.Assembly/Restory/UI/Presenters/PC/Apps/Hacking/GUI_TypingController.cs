using System.Collections;
using System.Collections.Generic;
using Restory.Data.PC;
using Restory.ObjectPools;
using Restory.UI.Pools;
using Restory.UI.Presenters.PC.Apps.Hacking.Lines;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	public class GUI_TypingController : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private RectTransform contentContainer;

		[SerializeField]
		private GUI_TypingCaret typingCaret;

		private readonly List<string> typingContent = new List<string>();

		private readonly Queue<GUI_TypingLine> linesQueue = new Queue<GUI_TypingLine>();

		private readonly int maxActiveLines = 20;

		private GUI_TypingLinePool pool;

		private TypingSettings settings;

		private GUI_TypingLine currentLine;

		private int contentLength;

		private int contentIndex;

		[Inject]
		private void Construct(GUI_TypingLinePool pool)
		{
			this.pool = pool;
		}

		public void Init(string hackingContent, TypingSettings settings)
		{
			this.settings = settings;
			typingCaret.gameObject.SetActive(value: false);
			InitContent(hackingContent);
		}

		public void ActivateTypingCaret()
		{
			typingCaret.gameObject.SetActive(value: true);
		}

		public void PerformTyping()
		{
			if (!currentLine)
			{
				UpdateLine();
				return;
			}
			currentLine.PerformTyping(settings.SymbolsPerKeyDown, out var isLineComplete);
			if (isLineComplete)
			{
				UpdateLine();
			}
		}

		public void Clear()
		{
			typingCaret.transform.SetParent(contentContainer);
			typingCaret.gameObject.SetActive(value: false);
			foreach (GUI_TypingLine item in linesQueue)
			{
				pool.Release(item);
			}
			linesQueue.Clear();
			typingContent.Clear();
		}

		private void InitContent(string content)
		{
			string[] array = content.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
			foreach (string item in array)
			{
				typingContent.Add(item);
			}
			contentLength = typingContent.Count;
			contentIndex = 0;
		}

		private void UpdateLine()
		{
			if (contentLength == 0)
			{
				Debug.LogError("Failed to perform typing, typingContent is not initialized");
				return;
			}
			if (linesQueue.Count >= maxActiveLines)
			{
				GUI_TypingLine instance = linesQueue.Dequeue();
				pool.Release(instance);
			}
			currentLine = pool.Get<GUI_TypingLine>(contentContainer);
			currentLine.Init(typingContent[contentIndex], typingCaret.transform);
			linesQueue.Enqueue(currentLine);
			contentIndex++;
			if (contentIndex >= contentLength)
			{
				contentIndex = 0;
			}
			StartCoroutine(ScrollToBottomNextFrame());
		}

		private IEnumerator ScrollToBottomNextFrame()
		{
			yield return null;
			scrollRect.verticalNormalizedPosition = 0f;
		}
	}
}
