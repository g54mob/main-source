using Assets.Nimbatus.GUI.Common.Scripts;
using I2.Loc;
using NGenerics.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public abstract class BuyItemButton : SerializedMonoBehaviour
	{
		private UIButton[] _buttons;

		public UILabel[] Labels;

		public UIButtonScale ButtonScale;

		protected bool HasEnoughResources;

		protected bool IsHovering;

		public void Init()
		{
			HasEnoughResources = CanBeBought();
		}

		protected abstract bool CanBeBought();

		protected abstract void Buy();

		public void Awake()
		{
			_buttons = GetComponents<UIButton>();
		}

		public void OnClick()
		{
			if (HasEnoughResources)
			{
				Buy();
				HasEnoughResources = CanBeBought();
			}
		}

		public void Update()
		{
			HasEnoughResources = CanBeBought();
			if (HasEnoughResources)
			{
				UILabel[] labels = Labels;
				if (labels != null)
				{
					labels.ForEach(delegate(UILabel l)
					{
						l.color = Color.white;
					});
				}
				ButtonScale.enabled = true;
				if (IsHovering)
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Hover, true);
					});
				}
				else
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Normal, true);
					});
				}
				return;
			}
			UILabel[] labels2 = Labels;
			if (labels2 != null)
			{
				labels2.ForEach(delegate(UILabel l)
				{
					l.color = Color.grey;
				});
			}
			ButtonScale.enabled = false;
			_buttons.ForEach(delegate(UIButton b)
			{
				b.SetState(UIButtonColor.State.Disabled, true);
			});
		}

		public void OnHover(bool over)
		{
			IsHovering = over;
		}

		public virtual void OnTooltip(bool show)
		{
			if (show)
			{
				if (!HasEnoughResources)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NotEnoughResources"));
				}
				else
				{
					NimbatusToolTip.Show(null);
				}
			}
		}
	}
}
