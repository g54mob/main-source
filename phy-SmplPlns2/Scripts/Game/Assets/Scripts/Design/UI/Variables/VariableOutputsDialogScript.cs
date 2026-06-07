using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Net;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.Variables
{
	public class VariableOutputsDialogScript : PanelDialogScript
	{
		private List<PartModifierData> _affectedModifiers = new List<PartModifierData>();

		private LayoutWidget _itemsParent;

		private PartScript _partScript;

		private List<VariableOutputRowScript> _rows = new List<VariableOutputRowScript>();

		public void Initialize(PartScript part)
		{
			base.Title = "Variable Outputs";
			_partScript = part;
			_itemsParent = base.Widget.FindWidget<LayoutWidget>("items-parent");
			foreach (PartModifierData modifier in part.Part.Modifiers)
			{
				if (modifier.VariableOutputDefinitions == null || modifier.VariableOutputDefinitions.Count <= 0)
				{
					continue;
				}
				AddHeader(modifier.Id);
				_affectedModifiers.Add(modifier);
				foreach (VariableOutputDefinition variableOutputDefinition in modifier.VariableOutputDefinitions)
				{
					VariableOutputRowScript variableOutputRowScript = AddRow();
					variableOutputRowScript.Definition = variableOutputDefinition;
					variableOutputRowScript.OutputId = variableOutputDefinition.DescriptiveName ?? variableOutputDefinition.Id;
					variableOutputRowScript.Modifier = modifier;
					bool flag = false;
					foreach (VariableOutput variableOutput in modifier.VariableOutputs)
					{
						if (variableOutput.Definition == variableOutputDefinition)
						{
							variableOutputRowScript.Variable = variableOutput.Variable;
							variableOutputRowScript.Activator = variableOutput.Activator;
							variableOutputRowScript.Priority = variableOutput.Priority;
							flag = true;
							break;
						}
					}
					if (!flag && !string.IsNullOrEmpty(variableOutputDefinition.DefaultOutputVariable))
					{
						variableOutputRowScript.Variable = variableOutputDefinition.DefaultOutputVariable;
						variableOutputRowScript.Priority = variableOutputDefinition.DefaultOutputPriority;
					}
					else if (!flag)
					{
						variableOutputRowScript.PriorityText = string.Empty;
					}
				}
			}
		}

		public async UniTask UpdateLayout()
		{
			await UniTask.Yield();
			await UniTask.Yield();
			_itemsParent.ForceRebuildLayout();
		}

		private void AddHeader(string name)
		{
			List<XAttribute> list = new List<XAttribute>();
			list.Add(new XAttribute("title", name));
			base.Widget.Context.CreateWidgetFromTemplate("control-header", _itemsParent, list);
		}

		private VariableOutputRowScript AddRow()
		{
			VariableOutputRowScript component = base.Widget.Context.CreateWidgetFromTemplate("variable-row", _itemsParent).GetComponent<VariableOutputRowScript>();
			component.Initialize(this);
			_rows.Add(component);
			return component;
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
			List<(PartModifierData, VariableOutput)> list = new List<(PartModifierData, VariableOutput)>();
			foreach (PartModifierData affectedModifier in _affectedModifiers)
			{
				foreach (VariableOutput variableOutput in affectedModifier.VariableOutputs)
				{
					list.Add((affectedModifier, variableOutput));
				}
				affectedModifier.VariableOutputs.Clear();
			}
			foreach (VariableOutputRowScript row in _rows)
			{
				if (!string.IsNullOrEmpty(row.Variable))
				{
					row.Modifier.VariableOutputs.Add(new VariableOutput(row.Definition)
					{
						Activator = row.Activator,
						Priority = row.Priority,
						Variable = row.Variable
					});
				}
			}
			try
			{
				_partScript.Aircraft.VariableSystem.RecompileAll();
			}
			catch (Exception ex)
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "Variables Error:\n" + ex.Message);
				foreach (PartModifierData affectedModifier2 in _affectedModifiers)
				{
					affectedModifier2.VariableOutputs.Clear();
				}
				foreach (var (partModifierData, item) in list)
				{
					partModifierData.VariableOutputs.Add(item);
				}
				throw;
			}
			Close();
		}
	}
}
