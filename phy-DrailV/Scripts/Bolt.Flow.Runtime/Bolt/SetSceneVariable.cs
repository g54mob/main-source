using System;
using Ludiq;
using UnityEngine.SceneManagement;

namespace Bolt
{
	[UnitSurtitle("Scene")]
	public sealed class SetSceneVariable : SetVariableUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		FlowGraph IUnit.graph => base.graph;

		public SetSceneVariable()
		{
		}

		public SetSceneVariable(string defaultName)
			: base(defaultName)
		{
		}

		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			Scene? scene = flow.stack.scene;
			if (!scene.HasValue)
			{
				return null;
			}
			return Variables.Scene(scene.Value);
		}
	}
}
