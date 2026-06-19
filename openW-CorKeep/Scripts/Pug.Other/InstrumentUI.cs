using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class InstrumentUI : MonoBehaviour
{
	public GameObject root;

	public SpriteRenderer idleNotes;

	public List<SpriteRenderer> playingNotesList;

	public Sprite keyWhite;

	public Sprite keyBlack;

	public Sprite keyWhitePressed;

	public Sprite keyBlackPressed;

	public Animator animator;

	public SpriteRenderer octave;

	public GameObject octaveContainer;

	public List<bool> isSharpNote;

	private float notesAlpha = 1f;

	private float octaveAlpha = 1f;

	private bool uiWasActiveLastFrame;

	private const int MAX_NOTES = 24;

	private bool[] notes = new bool[24];

	private bool[] notesPrevious = new bool[24];

	public bool isShowing => root.activeSelf;

	private void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		PlayerController player = Manager.main.player;
		if (player != null && player.instrumentHandler != null && player.instrumentHandler.IsPlayingInstrument)
		{
			root.SetActive(value: true);
			UpdateVisuals();
			uiWasActiveLastFrame = true;
			if (Manager.ui.isAnyInventoryShowing)
			{
				Manager.ui.HideAllInventoryAndCraftingUI();
			}
		}
		else
		{
			root.SetActive(value: false);
			if (uiWasActiveLastFrame)
			{
				animator.SetTrigger(2043490037);
			}
			uiWasActiveLastFrame = false;
		}
	}

	private void UpdateVisuals()
	{
		PlayedNotes playedNotes = new PlayedNotes
		{
			Value = Manager.main.player.clientInput.playedNotes
		};
		for (int i = 0; i < 24; i++)
		{
			if (playedNotes.GetOctave())
			{
				int num = i;
				bool flag = i < 12;
				num += (flag ? 12 : (-12));
				notes[num] = flag && playedNotes.GetKey(i);
			}
			else
			{
				notes[i] = playedNotes.GetKey(i);
			}
		}
		if (!uiWasActiveLastFrame)
		{
			animator.SetTrigger(2039883312);
		}
		bool num2 = Manager.main.player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.OCTAVE_CHANGE);
		if (Manager.main.player.inputModule.PrefersKeyboardAndMouse())
		{
			octaveContainer.SetActive(value: false);
		}
		else
		{
			octaveContainer.SetActive(value: true);
		}
		if (num2)
		{
			octaveAlpha = 1f;
		}
		else
		{
			octaveAlpha = 0f;
		}
		octave.SetAlpha(octaveAlpha);
		for (int j = 0; j < 24; j++)
		{
			if (notes[j])
			{
				float num3 = 0f;
				if (isSharpNote[j])
				{
					playingNotesList[j].sprite = keyBlackPressed;
					num3 = 0.5f;
				}
				else
				{
					playingNotesList[j].sprite = keyWhitePressed;
				}
				if (!notesPrevious[j] && !Manager.prefs.hideInGameUI)
				{
					Vector3 position = playingNotesList[j].transform.position;
					Vector3 vector = new Vector3(0f, -0.5f + num3, 0f);
					Manager.effects.PlayPuff(PuffID.NoteUI, position + vector, 20);
				}
			}
			else if (isSharpNote[j])
			{
				playingNotesList[j].sprite = keyBlack;
			}
			else
			{
				playingNotesList[j].sprite = keyWhite;
			}
			notesPrevious[j] = notes[j];
		}
	}
}
