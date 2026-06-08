using System.Collections.Generic;
using Controllers;
using KitchenData;
using Platforms;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class InputPromptElement : Element
	{
		public bool CentreAlign;

		[SerializeField]
		private GameObject Container;

		[SerializeField]
		private TextMeshPro Label;

		[SerializeField]
		private HashSet<string> CurrentIcons = new HashSet<string>();

		public Animator Animator;

		private static readonly int Animation = Animator.StringToHash("Animation");

		public override Bounds BoundingBox => default(Bounds);

		private GlobalLocalisation Localisation => GameData.Main.GlobalLocalisation;

		private ControllerIcons Icons => GameData.Main.GlobalLocalisation.ControllerIcons;

		private IInputSource InputSource => InputSourceIdentifier.DefaultInputSource;

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public void SetShown(bool show)
		{
			if (show)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		public void Attach(Element element, bool left_attach = true, float pad = 0.25f)
		{
			Bounds boundingBox = element.BoundingBox;
			base.transform.localPosition = (left_attach ? new Vector3(boundingBox.min.x, boundingBox.min.y, 0f) : new Vector3(boundingBox.max.x, boundingBox.min.y, 0f));
		}

		public void Animate(InputPromptAnimation animation_id)
		{
			if (Animator.gameObject.activeInHierarchy)
			{
				Animator.SetInteger(Animation, (int)animation_id);
				Animator.Play(0);
			}
		}

		public void SetButtonForUser(string action, int player_id)
		{
			Clear();
			AddButton(player_id, action);
		}

		public void SetButtonForAll(string action)
		{
			Clear();
			foreach (PlayerInfo item in Players.Main.All())
			{
				if (item.IsLocalUser)
				{
					AddButton(item.ID, action);
				}
			}
		}

		private void AddButton(int player, string action)
		{
			ControllerType currentController = InputSource.GetCurrentController(player);
			string bindingName = InputSource.GetBindingName(player, action);
			string tMPIcon = Icons.GetTMPIcon(currentController, bindingName);
			AddButton(tMPIcon);
		}

		private void AddButton(string button_text)
		{
			if (!CurrentIcons.Contains(button_text))
			{
				CurrentIcons.Add(button_text);
				if (Label.text != "")
				{
					Label.text = Label.text + "/" + button_text;
				}
				else
				{
					Label.text = button_text ?? "";
				}
			}
		}

		private void Clear()
		{
			CurrentIcons.Clear();
			Label.text = "";
		}
	}
}
