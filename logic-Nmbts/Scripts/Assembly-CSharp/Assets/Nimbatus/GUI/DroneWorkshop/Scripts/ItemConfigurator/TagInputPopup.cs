using System.Collections;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class TagInputPopup : SerializedMonoBehaviour
	{
		public static TagInputPopup Instance;

		public SimpleInputLabel Label;

		[HideInInspector]
		public bool IsShown;

		public bool TagSaved;

		public bool TagRemoved;

		public string TagText;

		public TweenPosition Tween;

		public IEnumerator Show(string tag)
		{
			RuntimeGlobals.StopInteraction = true;
			TagText = tag;
			TagSaved = false;
			TagRemoved = false;
			Tween.PlayForward();
			IsShown = true;
			Label.Reset();
			Label.SetAutoCompletionList(KeyBinding.GetUsedStrings());
			Label.StartListen();
			Label.OnSubmit += Label_OnSubmit;
			if (string.IsNullOrEmpty(TagText))
			{
				Label.CurrentText = LocalizationManager.GetTermTranslation("DroneWorkshop/TagDefaultString");
			}
			else
			{
				Label.CurrentText = TagText;
			}
			while (IsShown)
			{
				yield return true;
			}
			RuntimeGlobals.StopInteraction = false;
		}

		private void Label_OnSubmit(string text)
		{
			SaveTag(Label.CurrentText);
		}

		public void SaveTag(string tagText)
		{
			TagText = tagText;
			Close(true);
		}

		public void Close(bool save)
		{
			TagSaved = save;
			Tween.PlayReverse();
			IsShown = false;
		}

		public void RemoveTag()
		{
			TagRemoved = true;
			TagText = "";
			Close(true);
		}

		protected void Awake()
		{
			Instance = this;
			IsShown = false;
			TagSaved = false;
			TagRemoved = false;
			TagText = "";
		}
	}
}
