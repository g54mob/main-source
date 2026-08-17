using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupContentReferences
{
	public List<UIButton> Buttons;

	public List<Image> Images;

	public List<GameObject> Labels;

	public int ButtonsCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<UIButton> buttons = Buttons;
			if (Buttons != null)
			{
				return buttons._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public bool HasButtons
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<UIButton> buttons = Buttons;
			if (Buttons != null)
			{
				int num = buttons._size ^ buttons._size;
				int num2 = buttons._size & num;
				bool flag = num2 < 0;
				bool flag2 = buttons._size < 0;
				bool flag3 = buttons._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasImages
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<Image> images = Images;
			if (Images != null)
			{
				int num = images._size ^ images._size;
				int num2 = images._size & num;
				bool flag = num2 < 0;
				bool flag2 = images._size < 0;
				bool flag3 = images._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasLabels
	{
		get
		{
			//IL_009e: Expected I4, but got O
			List<GameObject> labels = Labels;
			if (Labels != null)
			{
				int num = labels._size ^ labels._size;
				int num2 = labels._size & num;
				bool flag = num2 < 0;
				bool flag2 = labels._size < 0;
				bool flag3 = labels._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public int ImagesCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<Image> images = Images;
			if (Images != null)
			{
				return images._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public int LabelsCount
	{
		get
		{
			//IL_001d: Expected I4, but got O
			List<GameObject> labels = Labels;
			if (Labels != null)
			{
				return labels._size;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public void SetButtonsCallbacks(UnityAction[] callbacks)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		if (callbacks == null || callbacks.Length == 0)
		{
			return;
		}
		List<UIButton> buttons = Buttons;
		if (buttons._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= buttons._size)
			{
				return;
			}
			List<UIButton> buttons2 = Buttons;
			if ((nint)obj >= buttons2._size)
			{
				break;
			}
			UIButton[] items = buttons2._items;
			UIButton uIButton = items[obj];
			if ((object)items[obj] != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v8 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0 && callbacks[obj] != null)
				{
					UIButtonBehavior onClick = uIButton.OnClick;
					UIAction onTrigger = onClick.OnTrigger;
					onTrigger.Event.AddListener(callbacks[obj]);
				}
			}
			buttons = Buttons;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetButtonsLabels(string[] buttonLabels)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		if (buttonLabels == null || buttonLabels.Length == 0)
		{
			return;
		}
		List<UIButton> buttons = Buttons;
		if (buttons._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= buttons._size)
			{
				return;
			}
			List<UIButton> buttons2 = Buttons;
			if ((nint)obj >= buttons2._size)
			{
				break;
			}
			UIButton[] items = buttons2._items;
			UIButton uIButton = items[obj];
			if ((object)items[obj] != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v8 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0)
				{
					items[obj].SetLabelText(buttonLabels[obj]);
				}
			}
			buttons = Buttons;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetButtonsNames(string[] buttonNames)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		if (buttonNames == null || buttonNames.Length == 0)
		{
			return;
		}
		List<UIButton> buttons = Buttons;
		if (buttons._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= buttons._size)
			{
				return;
			}
			List<UIButton> buttons2 = Buttons;
			if ((nint)obj >= buttons2._size)
			{
				break;
			}
			UIButton[] items = buttons2._items;
			UIButton uIButton = items[obj];
			if ((object)items[obj] != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdi_v9 (Doozy.Engine.UI.UIButton)+10]");
				if ((nint)0 != 0)
				{
					string customButtonCategory = UIButton.CustomButtonCategory;
					uIButton.ButtonCategory = customButtonCategory;
					uIButton.ButtonName = buttonNames[obj];
				}
			}
			buttons = Buttons;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetContentData(UIPopupContentData data)
	{
		if (data != null)
		{
			string[] labelsTexts = data.Labels.ToArray();
			SetLabelsTexts(labelsTexts);
			Sprite[] imagesSprites = data.Sprites.ToArray();
			SetImagesSprites(imagesSprites);
			string[] buttonsNames = data.ButtonNames.ToArray();
			SetButtonsNames(buttonsNames);
			string[] buttonsLabels = data.ButtonLabels.ToArray();
			SetButtonsLabels(buttonsLabels);
			UnityAction[] buttonsCallbacks = data.ButtonCallbacks.ToArray();
			SetButtonsCallbacks(buttonsCallbacks);
		}
	}

	public void SetImagesSprites(Sprite[] sprites)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		if (sprites == null || sprites.Length == 0)
		{
			return;
		}
		List<Image> images = Images;
		if (images._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < images._size)
			{
				List<Image> images2 = Images;
				if ((nint)obj >= images2._size)
				{
					break;
				}
				Image[] items = images2._items;
				Image image = items[obj];
				if ((object)items[obj] != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
				{
					items[obj].sprite = sprites[obj];
				}
				images = Images;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetLabelsTexts(string[] labels)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		if (labels == null || labels.Length == 0)
		{
			return;
		}
		List<GameObject> labels2 = Labels;
		if (labels2._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < labels2._size)
			{
				List<GameObject> labels3 = Labels;
				if ((nint)obj >= labels3._size)
				{
					break;
				}
				GameObject[] items = labels3._items;
				Text component = items[obj].GetComponent<Text>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					component.text = labels[obj];
				}
				labels2 = Labels;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public UIPopupContentReferences()
	{
		List<UIButton> buttons = new List<UIButton>();
		Buttons = buttons;
		List<Image> images = new List<Image>();
		Images = images;
		List<GameObject> labels = new List<GameObject>();
		Labels = labels;
	}
}
