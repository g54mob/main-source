using System;
using System.Collections;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Febucci.UI.Examples
{
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	internal class ExampleEvents : MonoBehaviour
	{
		[SerializeField]
		private TypewriterComponent typewriter;

		[SerializeField]
		[TextArea(1, 5)]
		private string[] dialoguesLines;

		[SerializeField]
		private Sprite[] faces;

		[SerializeField]
		private SpriteRenderer faceRenderer;

		[SerializeField]
		private GameObject continueText;

		[SerializeField]
		private Transform[] crates;

		private Vector3[] cratesInitialScale;

		private bool inputSystemPassed;

		private IDisposable eventListener;

		private int dialogueIndex;

		private int dialogueLength;

		private bool currentLineShown;

		private bool CurrentLineShown
		{
			get
			{
				return currentLineShown;
			}
			set
			{
				currentLineShown = value;
				continueText.SetActive(value);
			}
		}

		private void Start()
		{
			typewriter.onMessage.AddListener(OnMessage);
			inputSystemPassed = false;
			eventListener = InputSystem.onAnyButtonPress.CallOnce(delegate
			{
				inputSystemPassed = true;
			});
			dialogueIndex = 0;
			CurrentLineShown = false;
			typewriter.ShowText(dialoguesLines[dialogueIndex]);
		}

		private void OnDestroy()
		{
			if ((bool)typewriter)
			{
				typewriter.onMessage.RemoveListener(OnMessage);
			}
			eventListener?.Dispose();
		}

		private bool TryGetInt(string parameter, out int result)
		{
			if (FormatUtils.TryGetFloat(parameter, 0f, out var result2))
			{
				result = (int)result2;
				return true;
			}
			result = -1;
			return false;
		}

		private void OnMessage(EventMarker eventData)
		{
			string text = eventData.name;
			int result2;
			if (!(text == "face"))
			{
				if (!(text == "crate"))
				{
					return;
				}
				int result;
				if (eventData.parameters.Length == 0)
				{
					Debug.LogWarning($"You need to specify a crate index! Dialogue: {dialogueIndex}");
				}
				else if (TryGetInt(eventData.parameters[0], out result))
				{
					if (result >= 0 && result < crates.Length)
					{
						StartCoroutine(AnimateCrate(result));
					}
					else
					{
						Debug.Log($"Sprite index was out of range. Dialogue: {dialogueIndex}");
					}
				}
			}
			else if (eventData.parameters.Length == 0)
			{
				Debug.LogWarning($"You need to specify a sprite index! Dialogue: {dialogueIndex}");
			}
			else if (TryGetInt(eventData.parameters[0], out result2))
			{
				if (result2 >= 0 && result2 < faces.Length)
				{
					faceRenderer.sprite = faces[result2];
				}
				else
				{
					Debug.Log($"Sprite index was out of range. Dialogue: {dialogueIndex}");
				}
			}
		}

		private void Awake()
		{
			cratesInitialScale = new Vector3[crates.Length];
			for (int i = 0; i < crates.Length; i++)
			{
				cratesInitialScale[i] = crates[i].localScale;
			}
			dialogueLength = dialoguesLines.Length;
			typewriter.onTextShowed.AddListener(delegate
			{
				CurrentLineShown = true;
			});
		}

		private void ContinueSequence()
		{
			CurrentLineShown = false;
			dialogueIndex++;
			if (dialogueIndex < dialogueLength)
			{
				typewriter.ShowText(dialoguesLines[dialogueIndex]);
			}
			else
			{
				typewriter.StartDisappearingText();
			}
		}

		private void Update()
		{
			if (!CurrentLineShown)
			{
				return;
			}
			bool flag = false;
			if (inputSystemPassed)
			{
				flag = true;
				inputSystemPassed = false;
				eventListener = InputSystem.onAnyButtonPress.CallOnce(delegate
				{
					inputSystemPassed = true;
				});
			}
			if (flag)
			{
				ContinueSequence();
			}
		}

		private IEnumerator AnimateCrate(int crateIndex)
		{
			Transform crate = crates[crateIndex];
			Vector3 initialScale = cratesInitialScale[crateIndex];
			Vector3 targetScale = new Vector3(initialScale.x * 1.2f, initialScale.y * 0.6f, initialScale.z);
			float t = 0f;
			while (t <= 0.4f)
			{
				t += Time.unscaledDeltaTime;
				float num = t / 0.4f;
				num = ((!(num < 0.5f)) ? (1f - (num - 0.5f) / 0.5f) : (num / 0.5f));
				crate.localScale = Vector3.LerpUnclamped(initialScale, targetScale, num);
				yield return null;
			}
			crate.localScale = initialScale;
		}
	}
}
