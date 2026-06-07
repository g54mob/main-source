using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Xml.Examples
{
	[ExecuteInEditMode]
	internal class DataTableExampleController : XmlLayoutController<DataTableExampleViewModel>
	{
		private List<Dictionary<string, string>> myData3 = new List<Dictionary<string, string>>
		{
			new Dictionary<string, string>
			{
				{ "A", "1" },
				{ "B", "2" },
				{ "C", "3" }
			},
			new Dictionary<string, string>
			{
				{ "A", "1" },
				{ "B", "2" },
				{ "C", "3" }
			},
			new Dictionary<string, string>
			{
				{ "A", "1" },
				{ "B", "2" },
				{ "C", "3" }
			},
			new Dictionary<string, string>
			{
				{ "A", "1" },
				{ "B", "2" },
				{ "C", "3" }
			}
		};

		private XmlElementReference<XmlLayoutDataTable> dataTable3;

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (dataTable3 == null)
			{
				dataTable3 = XmlElementReference<XmlLayoutDataTable>("dataTable3");
			}
			dataTable3.element.SetData(myData3);
		}

		private void MVC_AddItem()
		{
			myData3.Add(new Dictionary<string, string>
			{
				{ "A", "New" },
				{ "B", "New" },
				{ "C", "New" }
			});
			dataTable3.element.SetData(myData3);
		}

		private void MVC_RemoveLast()
		{
			if (myData3.Any())
			{
				myData3.RemoveAt(myData3.Count - 1);
			}
			dataTable3.element.SetData(myData3);
		}

		private void MVC_ChangeLast()
		{
			if (myData3.Any())
			{
				myData3.Last()["B"] = "+++";
			}
			dataTable3.element.SetData(myData3);
		}

		private void MVC_ReplaceLast()
		{
			if (myData3.Any())
			{
				myData3[myData3.Count - 1] = new Dictionary<string, string>
				{
					{ "A", "***" },
					{ "B", "***" },
					{ "C", "***" }
				};
			}
			dataTable3.element.SetData(myData3);
		}

		protected override void PrepopulateViewModelData()
		{
			base.viewModel.myData = new ObservableList<DataTableExampleListItem>
			{
				new DataTableExampleListItem("A", "B", "C", "D"),
				new DataTableExampleListItem("E", "F", "G", "H"),
				new DataTableExampleListItem("I", "J", "K", "L"),
				new DataTableExampleListItem("M", "N", "O", "P")
			};
			base.viewModel.myData2 = new ObservableList<Dictionary<string, string>>
			{
				new Dictionary<string, string>
				{
					{ "A", "1" },
					{ "B", "2" },
					{ "C", "3" }
				},
				new Dictionary<string, string>
				{
					{ "A", "4" },
					{ "B", "5" },
					{ "C", "6" }
				},
				new Dictionary<string, string>
				{
					{ "A", "7" },
					{ "B", "8" },
					{ "C", "9" }
				},
				new Dictionary<string, string>
				{
					{ "A", "10" },
					{ "B", "11" },
					{ "C", "12" }
				}
			};
		}

		private void MVVM1_AddItem()
		{
			base.viewModel.myData.Add(new DataTableExampleListItem("New", "New", "New", "New"));
		}

		private void MVVM1_RemoveLast()
		{
			if (base.viewModel.myData.Any())
			{
				base.viewModel.myData.RemoveAt(base.viewModel.myData.Count - 1);
			}
		}

		private void MVVM1_ChangeLast()
		{
			if (base.viewModel.myData.Any())
			{
				base.viewModel.myData.Last().col3 = "+++";
			}
		}

		private void MVVM1_ReplaceLast()
		{
			if (base.viewModel.myData.Any())
			{
				base.viewModel.myData[base.viewModel.myData.Count - 1] = new DataTableExampleListItem("***", "***", "***", "***");
			}
		}

		private void MVVM2_AddItem()
		{
			base.viewModel.myData2.Add(new Dictionary<string, string>
			{
				{ "A", "New" },
				{ "B", "New" },
				{ "C", "New" },
				{ "D", "New" }
			});
		}

		private void MVVM2_RemoveLast()
		{
			if (base.viewModel.myData2.Any())
			{
				base.viewModel.myData2.Remove(base.viewModel.myData2.Last());
			}
		}

		private void MVVM2_ReplaceLast()
		{
			if (base.viewModel.myData2.Any())
			{
				base.viewModel.myData2[base.viewModel.myData2.Count - 1] = new Dictionary<string, string>
				{
					{ "A", "***" },
					{ "B", "***" },
					{ "C", "***" },
					{ "D", "***" }
				};
			}
		}
	}
}
