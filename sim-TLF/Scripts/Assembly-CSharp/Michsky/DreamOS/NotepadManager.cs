using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class NotepadManager : MonoBehaviour
	{
		[Serializable]
		public class NoteItem
		{
			public string noteID;

			public string noteTitle = "Title";

			[TextArea(3, 6)]
			public string noteContent = "Content";

			[HideInInspector]
			public bool isCustom;

			[HideInInspector]
			public bool isRemoved;

			[HideInInspector]
			public NotepadPreset preset;

			[Header("Localization")]
			public string titleKey;

			public string contentKey;
		}

		public List<NoteItem> noteItems = new List<NoteItem>();

		private NotepadPreset currentPreset;

		[SerializeField]
		private Transform noteLibraryParent;

		[SerializeField]
		private GameObject noteLibraryPreset;

		public WindowManager windowManager;

		[SerializeField]
		private Animator viewerAnimator;

		[SerializeField]
		private TMP_InputField viewerTitle;

		[SerializeField]
		private TMP_InputField viewerContent;

		[SerializeField]
		private ButtonManager deleteButton;

		public NotepadStoring notepadStoring;

		public bool saveCustomNotes;

		public bool openNoteOnEnable = true;

		public bool useLocalization = true;

		private bool bypassUpdate;

		private float cachedTemplateLength = 0.5f;

		private void Start()
		{
			Initialize();
		}

		private void OnEnable()
		{
			if (!openNoteOnEnable || noteItems.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < noteItems.Count; i++)
			{
				if (!noteItems[i].isRemoved)
				{
					OpenNote(i);
					break;
				}
			}
		}

		public void Initialize()
		{
			if (viewerAnimator != null)
			{
				cachedTemplateLength = DreamOSInternalTools.GetAnimatorClipLength(viewerAnimator, "NoteViewer_In") + 0.1f;
			}
			foreach (Transform item in noteLibraryParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < noteItems.Count; i++)
			{
				if (!noteItems[i].isRemoved)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(noteLibraryPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.transform.SetParent(noteLibraryParent, worldPositionStays: false);
					gameObject.gameObject.name = noteItems[i].noteTitle;
					LocalizedObject component = base.gameObject.GetComponent<LocalizedObject>();
					if (!noteItems[i].isCustom && useLocalization && !string.IsNullOrEmpty(noteItems[i].titleKey) && component != null && component.CheckLocalizationStatus())
					{
						noteItems[i].noteTitle = component.GetKeyOutput(noteItems[i].titleKey);
						noteItems[i].noteContent = component.GetKeyOutput(noteItems[i].contentKey);
					}
					NotepadPreset preset = gameObject.GetComponent<NotepadPreset>();
					preset.noteID = noteItems[i].noteID;
					preset.noteIndex = i;
					preset.manager = this;
					preset.titleText.text = noteItems[i].noteTitle;
					noteItems[i].preset = preset;
					gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
					{
						OpenNote(preset.noteIndex);
					});
					if (currentPreset == null)
					{
						currentPreset = preset;
					}
				}
			}
			if (notepadStoring != null)
			{
				notepadStoring.ReadNoteData();
			}
			viewerTitle.onEndEdit.RemoveAllListeners();
			viewerContent.onEndEdit.RemoveAllListeners();
			viewerTitle.onEndEdit.AddListener(delegate
			{
				UpdateNote(currentPreset.noteIndex);
			});
			viewerContent.onEndEdit.AddListener(delegate
			{
				UpdateNote(currentPreset.noteIndex);
			});
		}

		public void CreateNote(string noteID, string title, string content, bool isCustom = true)
		{
			NoteItem noteItem = new NoteItem();
			noteItem.noteID = noteID;
			noteItem.noteTitle = title;
			noteItem.noteContent = content;
			noteItem.isCustom = isCustom;
			noteItems.Add(noteItem);
			int num = noteItems.Count - 1;
			GameObject gameObject = UnityEngine.Object.Instantiate(noteLibraryPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(noteLibraryParent, worldPositionStays: false);
			gameObject.gameObject.name = noteItems[num].noteTitle;
			NotepadPreset preset = gameObject.GetComponent<NotepadPreset>();
			preset.noteID = noteID;
			preset.noteIndex = num;
			preset.manager = this;
			preset.titleText.text = title;
			preset.isCustom = isCustom;
			noteItem.preset = preset;
			gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
			{
				OpenNote(preset.noteIndex);
			});
		}

		public void CreateEmptyNote()
		{
			CreateNote("UserNote#" + (noteItems.Count - 1), "My new note", null);
			if (base.gameObject.activeInHierarchy)
			{
				OpenNote(noteItems.Count - 1);
			}
		}

		public void DeleteNote(int index)
		{
			noteItems[index].isRemoved = true;
			if (!(noteItems[index].preset == null))
			{
				UnityEngine.Object.Destroy(noteItems[index].preset.gameObject);
				HideViewer();
			}
		}

		public void DeleteNote(string noteID)
		{
			for (int i = 0; i < noteItems.Count; i++)
			{
				if (noteItems[i].noteID == noteID)
				{
					DeleteNote(noteItems[i].preset.noteIndex);
					break;
				}
			}
		}

		public void UpdateNote(int index)
		{
			if (!bypassUpdate && !(currentPreset == null))
			{
				noteItems[index].noteTitle = viewerTitle.text;
				noteItems[index].noteContent = viewerContent.text;
				noteItems[index].preset.titleText.text = viewerTitle.text;
				if (notepadStoring != null && noteItems[index].isCustom)
				{
					notepadStoring.UpdateData();
				}
			}
		}

		public void UpdateNote(string noteID)
		{
			for (int i = 0; i < noteItems.Count; i++)
			{
				if (noteItems[i].noteID == noteID)
				{
					UpdateNote(i);
					break;
				}
			}
		}

		public void OpenNote(int index)
		{
			currentPreset = noteItems[index].preset;
			viewerTitle.text = noteItems[index].noteTitle;
			viewerContent.text = noteItems[index].noteContent;
			deleteButton.Interactable(value: true);
			deleteButton.onClick.RemoveAllListeners();
			deleteButton.onClick.AddListener(delegate
			{
				DeleteNote(currentPreset.noteIndex);
			});
			bypassUpdate = false;
			ShowViewer();
		}

		public void OpenNote(string noteID)
		{
			for (int i = 0; i < noteItems.Count; i++)
			{
				if (noteItems[i].noteID == noteID)
				{
					OpenNote(i);
					break;
				}
			}
		}

		public void OpenCustomNote(string title, string note)
		{
			viewerTitle.text = title;
			viewerContent.text = note;
			deleteButton.Interactable(value: false);
			bypassUpdate = true;
			ShowViewer();
		}

		public void ShowViewer()
		{
			viewerAnimator.enabled = true;
			viewerAnimator.Play("In");
			StopCoroutine("DisableViewerAnimator");
			StartCoroutine("DisableViewerAnimator");
		}

		public void HideViewer()
		{
			viewerAnimator.enabled = true;
			viewerAnimator.Play("Out");
			StopCoroutine("DisableViewerAnimator");
			StartCoroutine("DisableViewerAnimator");
		}

		private IEnumerator DisableViewerAnimator()
		{
			yield return new WaitForSeconds(cachedTemplateLength);
			viewerAnimator.enabled = false;
		}
	}
}
