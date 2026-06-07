using System;
using Ludiq;

namespace Bolt
{
	[TypeIcon(typeof(FlowGraph))]
	[UnitCategory("Nesting")]
	public sealed class SuperUnit : NesterUnit<FlowGraph, FlowMacro>, IGraphEventListener, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		public sealed class Data : IGraphElementData
		{
			public bool isListening;
		}

		public IGraphElementData CreateData()
		{
			return new Data();
		}

		public SuperUnit()
		{
		}

		public SuperUnit(FlowMacro macro)
			: base(macro)
		{
		}

		public static SuperUnit WithInputOutput()
		{
			SuperUnit superUnit = new SuperUnit();
			superUnit.nest.source = GraphSource.Embed;
			superUnit.nest.embed = FlowGraph.WithInputOutput();
			return superUnit;
		}

		public static SuperUnit WithStartUpdate()
		{
			SuperUnit superUnit = new SuperUnit();
			superUnit.nest.source = GraphSource.Embed;
			superUnit.nest.embed = FlowGraph.WithStartUpdate();
			return superUnit;
		}

		public override FlowGraph DefaultGraph()
		{
			return FlowGraph.WithInputOutput();
		}

		protected override void Definition()
		{
			isControlRoot = true;
			foreach (IUnitPortDefinition validPortDefinition in base.nest.graph.validPortDefinitions)
			{
				if (validPortDefinition is ControlInputDefinition)
				{
					ControlInputDefinition controlInputDefinition = (ControlInputDefinition)validPortDefinition;
					string key = controlInputDefinition.key;
					ControlInput(key, delegate(Flow flow)
					{
						foreach (IUnit unit in base.nest.graph.units)
						{
							if (unit is GraphInput)
							{
								GraphInput graphInput = (GraphInput)unit;
								flow.stack.EnterParentElement(this);
								return graphInput.controlOutputs[key];
							}
						}
						return (ControlOutput)null;
					});
				}
				else if (validPortDefinition is ValueInputDefinition)
				{
					ValueInputDefinition valueInputDefinition = (ValueInputDefinition)validPortDefinition;
					string key2 = valueInputDefinition.key;
					Type type = valueInputDefinition.type;
					bool hasDefaultValue = valueInputDefinition.hasDefaultValue;
					object defaultValue = valueInputDefinition.defaultValue;
					ValueInput valueInput = ValueInput(type, key2);
					if (hasDefaultValue)
					{
						valueInput.SetDefaultValue(defaultValue);
					}
				}
				else if (validPortDefinition is ControlOutputDefinition)
				{
					ControlOutputDefinition controlOutputDefinition = (ControlOutputDefinition)validPortDefinition;
					string key3 = controlOutputDefinition.key;
					ControlOutput(key3);
				}
				else
				{
					if (!(validPortDefinition is ValueOutputDefinition))
					{
						continue;
					}
					ValueOutputDefinition valueOutputDefinition = (ValueOutputDefinition)validPortDefinition;
					string key4 = valueOutputDefinition.key;
					Type type2 = valueOutputDefinition.type;
					ValueOutput(type2, key4, delegate(Flow flow)
					{
						flow.stack.EnterParentElement(this);
						foreach (IUnit unit2 in base.nest.graph.units)
						{
							if (unit2 is GraphOutput)
							{
								GraphOutput graphOutput = (GraphOutput)unit2;
								object value = flow.GetValue(graphOutput.valueInputs[key4]);
								flow.stack.ExitParentElement();
								return value;
							}
						}
						flow.stack.ExitParentElement();
						throw new InvalidOperationException("Missing output unit when to get value.");
					});
				}
			}
		}

		public void StartListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StartListening(stack);
				stack.ExitParentElement();
			}
			stack.GetElementData<Data>(this).isListening = true;
		}

		public void StopListening(GraphStack stack)
		{
			stack.GetElementData<Data>(this).isListening = false;
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StopListening(stack);
				stack.ExitParentElement();
			}
		}

		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<Data>(this).isListening;
		}

		public override void AfterAdd()
		{
			base.AfterAdd();
			base.nest.beforeGraphChange += StopWatchingPortDefinitions;
			base.nest.afterGraphChange += StartWatchingPortDefinitions;
			StartWatchingPortDefinitions();
		}

		public override void BeforeRemove()
		{
			base.BeforeRemove();
			StopWatchingPortDefinitions();
			base.nest.beforeGraphChange -= StopWatchingPortDefinitions;
			base.nest.afterGraphChange -= StartWatchingPortDefinitions;
		}

		private void StopWatchingPortDefinitions()
		{
			if (base.nest.graph != null)
			{
				base.nest.graph.onPortDefinitionsChanged -= Define;
			}
		}

		private void StartWatchingPortDefinitions()
		{
			if (base.nest.graph != null)
			{
				base.nest.graph.onPortDefinitionsChanged += Define;
			}
		}
	}
}
