using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Net;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.Variables
{
	public class VariableSettersDialogScript : PanelDialogScript
	{
		public const string HelpURL = "https://www.simpleplanes.com/Client/FunkyTrees";

		private LayoutWidget _itemsParent;

		private List<VariableRowScript> _rows = new List<VariableRowScript>();

		private VariableSystemScript _variableSystem;

		public void DeleteRow(VariableRowScript row)
		{
			_rows.Remove(row);
			row.Widget.Hide(delegate
			{
				row.Widget.Destroy();
			});
		}

		public void Initialize(VariableSystemScript variableSystem)
		{
			base.Title = "Variable Setters";
			_variableSystem = variableSystem;
			_itemsParent = base.Widget.FindWidget<LayoutWidget>("items-parent");
			foreach (VariableSetter setter in _variableSystem.Setters)
			{
				VariableRowScript variableRowScript = NewRow();
				variableRowScript.Name = setter.VariableName;
				variableRowScript.Expression = setter.Expression;
				variableRowScript.Priority = setter.Priority;
				variableRowScript.Activator = setter.Activator;
			}
		}

		public void MoveRow(VariableRowScript row, bool up)
		{
			int num = row.Widget.Index + (up ? 1 : (-1));
			if (num < 0)
			{
				num = 0;
			}
			row.Widget.SetIndex(num);
		}

		public async UniTask UpdateLayout()
		{
			await UniTask.Yield();
			await UniTask.Yield();
			_itemsParent.ForceRebuildLayout();
		}

		private VariableRowScript NewRow()
		{
			VariableRowScript component = base.Widget.Context.CreateWidgetFromTemplate("variable-row", _itemsParent).GetComponent<VariableRowScript>();
			component.Initialize(this);
			component.Widget.Show(force: true);
			_rows.Add(component);
			return component;
		}

		private void OnAddVariableButtonClicked(Widget widget)
		{
			VariableRowScript variableRowScript = NewRow();
			variableRowScript.Name = string.Empty;
			variableRowScript.Expression = string.Empty;
			variableRowScript.PriorityText = string.Empty;
			variableRowScript.Activator = string.Empty;
		}

		private void OnCancelButtonClicked(Widget widget)
		{
			Close();
		}

		private void OnHelpButtonClicked(Widget widget)
		{
			if (Game.Instance.Device.IsTouchEnabled)
			{
				Application.OpenURL("https://www.simpleplanes.com/Client/FunkyTrees");
			}
			else
			{
				WebUtility.OpenUrl("https://www.simpleplanes.com/Client/FunkyTrees");
			}
		}

		private void OnOkayButtonClicked(Widget widget)
		{
			List<VariableSetter> collection = new List<VariableSetter>(_variableSystem.Setters);
			_variableSystem.Setters.Clear();
			try
			{
				foreach (VariableRowScript item2 in _rows.OrderBy((VariableRowScript r) => r.transform.GetSiblingIndex()))
				{
					if (item2.gameObject.activeSelf)
					{
						if (string.IsNullOrEmpty(item2.Name))
						{
							throw new Exception("Variable name cannot be empty");
						}
						VariableSetter item = new VariableSetter
						{
							VariableName = item2.Name,
							Expression = item2.Expression,
							Priority = item2.Priority,
							Activator = item2.Activator
						};
						_variableSystem.Setters.Add(item);
					}
				}
				_variableSystem.RefreshVariables();
				foreach (VariableSetter setter in _variableSystem.Setters)
				{
					setter.Compile(_variableSystem.AircraftScript);
				}
				Close();
			}
			catch (Exception ex)
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "Variables Error:\n" + ex.Message);
				_variableSystem.Setters.Clear();
				_variableSystem.Setters.AddRange(collection);
				throw;
			}
		}
	}
}
