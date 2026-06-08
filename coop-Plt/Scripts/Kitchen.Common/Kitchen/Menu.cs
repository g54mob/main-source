using System;
using System.Collections.Generic;
using Kitchen.Modules;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public abstract class Menu<T>
	{
		public bool PreviousMenuRequested;

		public Transform Container;

		public ModuleList ModuleList;

		private int SelectedIndex = -1;

		protected Vector2 DefaultElementSize = new Vector2(3.5f, 0.5f);

		public virtual ElementStyle Style { get; set; }

		public virtual bool RequiresBackingPanel { get; protected set; } = true;

		protected GlobalLocalisation Localisation => GameData.Main.GlobalLocalisation;

		public event EventHandler<T> OnRequestAction = delegate
		{
		};

		public event EventHandler<(Type, bool)> OnRequestMenu = delegate
		{
		};

		public event EventHandler<(Type, bool)> OnRequestSkipStackMenu = delegate
		{
		};

		public event EventHandler<Type> OnPreviousMenu = delegate
		{
		};

		public event EventHandler OnGoBackToRoot = delegate
		{
		};

		public event EventHandler<string> OnErrorDisplay = delegate
		{
		};

		protected void RequestAction(T action)
		{
			this.OnRequestAction(null, action);
		}

		protected void RequestPreviousMenu()
		{
			if (!PreviousMenuRequested)
			{
				PreviousMenuRequested = true;
				this.OnPreviousMenu(null, null);
			}
		}

		protected void RequestSubMenu(Type type, bool skip_stack = false, bool remove_self_from_stack = false)
		{
			if (skip_stack)
			{
				this.OnRequestSkipStackMenu(null, (type, remove_self_from_stack));
			}
			else
			{
				this.OnRequestMenu(null, (type, remove_self_from_stack));
			}
		}

		protected void RequestErrorDisplay(string message)
		{
			this.OnErrorDisplay(null, message);
		}

		protected void RequestMainMenu()
		{
			this.OnGoBackToRoot(null, null);
		}

		public void TriggerRedraw()
		{
			Redraw();
			if (SelectedIndex == -1)
			{
				return;
			}
			for (int i = SelectedIndex; i < ModuleList.Modules.Count; i++)
			{
				IModule module = ModuleList.Modules[i].Module;
				if (module.IsSelectable)
				{
					ModuleList.Select(module);
					break;
				}
			}
			SelectedIndex = -1;
		}

		public virtual void Update()
		{
		}

		protected virtual void Redraw()
		{
		}

		public Menu(Transform container, ModuleList module_list)
		{
			Container = container;
			ModuleList = module_list;
		}

		public abstract void Setup(int player_id);

		public virtual void TearDown()
		{
		}

		public virtual void CreateSubmenus(ref Dictionary<Type, Menu<T>> menus)
		{
		}

		protected virtual SelectElement AddSelect<TOpt>(Option<TOpt> option)
		{
			return AddSelect(option.Names, option.SetChosen, option.Chosen);
		}

		protected virtual TElement New<TElement>(bool add_to_module_list = true) where TElement : Element
		{
			TElement val = ModuleDirectory.Add<TElement>(Container);
			if (add_to_module_list)
			{
				ModuleList.AddModule(val);
			}
			return val;
		}

		protected virtual LabelElement AddLabel(string text)
		{
			LabelElement labelElement = New<LabelElement>();
			labelElement.SetStyle(Style);
			labelElement.SetSize(DefaultElementSize.x, DefaultElementSize.y);
			labelElement.SetLabel(text);
			return labelElement;
		}

		protected virtual HeadingElement AddHeading(string text)
		{
			HeadingElement headingElement = New<HeadingElement>();
			headingElement.SetStyle(Style);
			headingElement.SetSize(DefaultElementSize.x, DefaultElementSize.y);
			headingElement.SetHeading(text);
			return headingElement;
		}

		protected virtual InfoTextElement AddInfoText(string message)
		{
			InfoTextElement infoTextElement = New<InfoTextElement>();
			infoTextElement.SetStyle(Style);
			infoTextElement.SetSize(DefaultElementSize.x * 2f, DefaultElementSize.y * 2f);
			infoTextElement.SetLabel(message);
			return infoTextElement;
		}

		protected virtual SpinnerElement AddSpinner()
		{
			SpinnerElement spinnerElement = New<SpinnerElement>();
			spinnerElement.SetSize(DefaultElementSize.x, DefaultElementSize.y * 2f);
			return spinnerElement;
		}

		protected virtual InfoBoxElement AddInfo(string text)
		{
			InfoBoxElement infoBoxElement = New<InfoBoxElement>();
			infoBoxElement.SetSize(DefaultElementSize.x, infoBoxElement.BoundingBox.size.y);
			infoBoxElement.SetLabel(text);
			infoBoxElement.SetStyle(Style);
			return infoBoxElement;
		}

		protected virtual SelectElement AddSelect(List<string> options, Action<int> on_activate, int index = 0)
		{
			SelectElement selectElement = New<SelectElement>();
			selectElement.SetSize(DefaultElementSize.x, DefaultElementSize.y);
			selectElement.SetOptions(options);
			selectElement.SetStyle(Style);
			selectElement.Value = index;
			selectElement.OnOptionHighlighted += on_activate;
			return selectElement;
		}

		protected virtual SelectElement AddSelectChooseable(List<string> options, Action<int> on_activate, int index = 0)
		{
			SelectElement selectElement = New<SelectElement>();
			selectElement.SetSize(DefaultElementSize.x, DefaultElementSize.y);
			selectElement.SetOptions(options);
			selectElement.SetStyle(Style);
			selectElement.Value = index;
			selectElement.OnOptionChosen += on_activate;
			return selectElement;
		}

		protected virtual ButtonElement AddButton(string label, Action<int> on_activate, int arg = 0, float scale = 1f, float padding = 0.2f)
		{
			ButtonElement buttonElement = ModuleDirectory.Add<ButtonElement>(Container, Vector2.zero);
			buttonElement.SetSize(DefaultElementSize.x * scale, DefaultElementSize.y * scale);
			buttonElement.SetLabel(label);
			buttonElement.SetStyle(Style);
			buttonElement.OnActivate += delegate
			{
				on_activate(arg);
			};
			ModuleList.AddModule(buttonElement);
			return buttonElement;
		}

		protected virtual PlayerRowElement AddPeerRow(string username, Action<int> on_kick, int arg = 0, float scale = 1f, float padding = 0.2f)
		{
			PlayerRowElement playerRowElement = ModuleDirectory.Add<PlayerRowElement>(Container, Vector2.zero);
			playerRowElement.SetPeer(username);
			playerRowElement.OnKick += delegate
			{
				on_kick(arg);
			};
			ModuleList.AddModule(playerRowElement);
			playerRowElement.AddSubmodules(ModuleList);
			return playerRowElement;
		}

		protected virtual PlayerRowElement AddPlayerRow(string username, PlayerInfo player, Action<int> on_kick, Action<int> on_remove, int arg = 0, float scale = 1f, float padding = 0.2f)
		{
			PlayerRowElement playerRowElement = ModuleDirectory.Add<PlayerRowElement>(Container, Vector2.zero);
			playerRowElement.SetPlayer(username, player);
			playerRowElement.OnKick += delegate
			{
				on_kick(arg);
			};
			playerRowElement.OnRemovePlayer += delegate
			{
				on_remove(arg);
			};
			ModuleList.AddModule(playerRowElement);
			playerRowElement.AddSubmodules(ModuleList);
			return playerRowElement;
		}

		protected virtual ButtonElement AddSubmenuButton(string label, Type menu, bool skip_stack = false)
		{
			return AddButton(label, delegate
			{
				RequestSubMenu(menu, skip_stack);
			});
		}

		protected virtual ButtonElement AddActionButton(string label, T action)
		{
			return AddButton(label, delegate
			{
				RequestAction(action);
			});
		}

		protected virtual ButtonElement AddActionButton(string label, T action, ElementStyle style)
		{
			return AddButton(label, delegate
			{
				RequestAction(action);
			}).SetStyle(style);
		}

		protected Option<TOpt> Add<TOpt>(Option<TOpt> opt)
		{
			AddSelect(opt);
			return opt;
		}

		protected void AddBoolOption(Pref pref, List<string> labels = null)
		{
			Add(new Option<bool>(new List<bool> { false, true }, Preferences.Get<bool>(pref), labels ?? new List<string>
			{
				Localisation["SETTING_DISABLED"],
				Localisation["SETTING_ENABLED"]
			})).OnChanged += delegate(object _, bool f)
			{
				Preferences.Set(pref, f);
			};
		}
	}
}
