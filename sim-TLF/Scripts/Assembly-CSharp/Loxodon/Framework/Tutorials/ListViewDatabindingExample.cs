using System.Collections.Generic;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Binding.Converters;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Views.InteractionActions;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class ListViewDatabindingExample : MonoBehaviour
	{
		private ListViewViewModel viewModel;

		public Button addButton;

		public Button removeButton;

		public Button clearButton;

		public Button changeIconButton;

		public Button changeItems;

		public ListView listView;

		public ListItemDetailView detailView;

		public ListItemEditView editView;

		private AsyncViewInteractionAction editViewInteractionAction;

		private void Awake()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			new BindingServiceBundle(applicationContext.GetContainer()).Start();
			Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();
			Sprite[] array = Resources.LoadAll<Sprite>("EquipTextures");
			foreach (Sprite sprite in array)
			{
				if (sprite != null)
				{
					dictionary.Add(sprite.name, sprite);
				}
			}
			applicationContext.GetContainer().Resolve<IConverterRegistry>().Register("spriteConverter", new SpriteConverter(dictionary));
		}

		private void OnDestroy()
		{
			Context.GetApplicationContext().GetContainer().Resolve<IConverterRegistry>()
				.Unregister("spriteConverter");
		}

		private void Start()
		{
			editViewInteractionAction = new AsyncViewInteractionAction(editView);
			viewModel = new ListViewViewModel();
			this.BindingContext().DataContext = viewModel;
			BindingSet<ListViewDatabindingExample, ListViewViewModel> bindingSet = this.CreateBindingSet<ListViewDatabindingExample, ListViewViewModel>();
			bindingSet.Bind(listView).For((ListView v) => v.Items).To((ListViewViewModel vm) => vm.Items)
				.OneWay();
			bindingSet.Bind(detailView).For((ListItemDetailView v) => v.Item).To((ListViewViewModel vm) => vm.SelectedItem);
			bindingSet.Bind().For((ListViewDatabindingExample v) => v.editViewInteractionAction).To((ListViewViewModel vm) => vm.ItemEditRequest);
			bindingSet.Bind(addButton).For((Button v) => v.onClick).To((ListViewViewModel vm) => vm.AddItem);
			bindingSet.Bind(removeButton).For((Button v) => v.onClick).To((ListViewViewModel vm) => vm.RemoveItem);
			bindingSet.Bind(clearButton).For((Button v) => v.onClick).To((ListViewViewModel vm) => vm.ClearItem);
			bindingSet.Bind(changeIconButton).For((Button v) => v.onClick).To((ListViewViewModel vm) => vm.ChangeItemIcon);
			bindingSet.Bind(changeItems).For((Button v) => v.onClick).To((ListViewViewModel vm) => vm.ChangeItems);
			bindingSet.Build();
			viewModel.SelectItem(0);
		}
	}
}
