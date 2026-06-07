using System.Linq;

namespace UI.Xml.Examples
{
	public class MVVMExampleListController : XmlLayoutController<MVVMExampleListViewModel>
	{
		protected override void PrepopulateViewModelData()
		{
			base.viewModel.listItems = new ObservableList<ExampleListItem>
			{
				new ExampleListItem
				{
					column1 = 1,
					column2 = 4
				},
				new ExampleListItem
				{
					column1 = 2,
					column2 = 5
				},
				new ExampleListItem
				{
					column1 = 3,
					column2 = 6
				}
			};
		}

		private void AddElement()
		{
			base.viewModel.listItems.Add(new ExampleListItem
			{
				column1 = 5,
				column2 = 5
			});
		}

		private void ChangeLast()
		{
			ExampleListItem exampleListItem = base.viewModel.listItems.LastOrDefault();
			if (exampleListItem != null)
			{
				exampleListItem.column1 = 9;
			}
		}

		private void Remove(ExampleListItem item)
		{
			base.viewModel.listItems.Remove(item);
		}
	}
}
