using Ludiq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bolt
{
	public sealed class GetVariable : UnifiedVariableUnit
	{
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		[DoNotSerialize]
		public ValueInput fallback { get; private set; }

		[Serialize]
		[Inspectable]
		[InspectorLabel("Fallback")]
		public bool specifyFallback { get; set; }

		protected override void Definition()
		{
			base.Definition();
			value = ValueOutput("value", Get).PredictableIf(IsDefined);
			Requirement(base.name, value);
			if (base.kind == VariableKind.Object)
			{
				Requirement(base.@object, value);
			}
			if (specifyFallback)
			{
				fallback = ValueInput<object>("fallback");
				Requirement(fallback, value);
			}
		}

		private bool IsDefined(Flow flow)
		{
			string variable = flow.GetValue<string>(base.name);
			if (string.IsNullOrEmpty(variable))
			{
				return false;
			}
			GameObject gameObject = null;
			if (base.kind == VariableKind.Object)
			{
				gameObject = flow.GetValue<GameObject>(base.@object);
				if (gameObject == null)
				{
					return false;
				}
			}
			Scene? scene = flow.stack.scene;
			if (base.kind == VariableKind.Scene && (!scene.HasValue || !scene.Value.IsValid() || !scene.Value.isLoaded || !Variables.ExistInScene(scene)))
			{
				return false;
			}
			switch (base.kind)
			{
			case VariableKind.Flow:
				return flow.variables.IsDefined(variable);
			case VariableKind.Graph:
				return Variables.Graph(flow.stack).IsDefined(variable);
			case VariableKind.Object:
				return Variables.Object(gameObject).IsDefined(variable);
			case VariableKind.Scene:
				return Variables.Scene(scene.Value).IsDefined(variable);
			case VariableKind.Application:
				return Variables.Application.IsDefined(variable);
			case VariableKind.Saved:
				return Variables.Saved.IsDefined(variable);
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
		}

		private object Get(Flow flow)
		{
			string variable = flow.GetValue<string>(base.name);
			VariableDeclarations variableDeclarations;
			switch (base.kind)
			{
			case VariableKind.Flow:
				variableDeclarations = flow.variables;
				break;
			case VariableKind.Graph:
				variableDeclarations = Variables.Graph(flow.stack);
				break;
			case VariableKind.Object:
				variableDeclarations = Variables.Object(flow.GetValue<GameObject>(base.@object));
				break;
			case VariableKind.Scene:
				variableDeclarations = Variables.Scene(flow.stack.scene);
				break;
			case VariableKind.Application:
				variableDeclarations = Variables.Application;
				break;
			case VariableKind.Saved:
				variableDeclarations = Variables.Saved;
				break;
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
			if (specifyFallback && !variableDeclarations.IsDefined(variable))
			{
				return flow.GetValue(fallback);
			}
			return variableDeclarations.Get(variable);
		}
	}
}
