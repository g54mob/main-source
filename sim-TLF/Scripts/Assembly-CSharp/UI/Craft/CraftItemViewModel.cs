using System;
using System.Linq;
using AssembleSystem;
using AssembleSystem.Utils;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.Craft
{
	public class CraftItemViewModel : ViewModelBase
	{
		private Action<CraftItemViewModel> onCraftEvent;

		private Color color;

		private string name;

		private SimpleCommand craftCommand;

		private InteractionRequest<Notification> clickRequest;

		private int _mainPartsAmount;

		public ObservableProperty<bool> CanCraft = new ObservableProperty<bool>();

		public ObservableProperty<int> CurrentPartsAmount = new ObservableProperty<int>();

		public ObservableProperty<int> CurrentBasePartsAmount = new ObservableProperty<int>();

		private AssembleObjectParent parent;

		private Sprite _craftItemImage;

		public IInteractionRequest ClickRequest => clickRequest;

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				Set(ref color, value, "Color");
			}
		}

		public AssembleObjectParent Parent
		{
			get
			{
				return parent;
			}
			set
			{
				Set(ref parent, value, "Parent");
			}
		}

		public int MainPartsAmount
		{
			get
			{
				return _mainPartsAmount;
			}
			set
			{
				Set(ref _mainPartsAmount, value, "MainPartsAmount");
			}
		}

		public ICommand CraftCommand => craftCommand;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				Set(ref name, value, "Name");
			}
		}

		public Sprite CraftItemImage
		{
			get
			{
				return _craftItemImage;
			}
			set
			{
				Set(ref _craftItemImage, value, "CraftItemImage");
			}
		}

		public CraftItemViewModel(AssembleObjectParent parent, Action<CraftItemViewModel> onCraftEvent)
		{
			color = Color.yellow;
			craftCommand = new SimpleCommand(OnCraft);
			this.parent = parent;
			this.onCraftEvent = onCraftEvent;
			_craftItemImage = parent.ItemConfig.CraftItemIcon;
			_mainPartsAmount = parent.ItemConfig.PartsConfig.Count((PartConfig part) => part.NecessaryAssembleParts.Count == 0);
			clickRequest = new InteractionRequest<Notification>(this);
		}

		private void OnCraft()
		{
			parent.StateMachine.ReadyToBuild = true;
			onCraftEvent?.Invoke(this);
		}
	}
}
