using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rhizomatic.Reactive;

namespace GRP
{
	public class UndoController
	{
		public List<UndoStep> steps;

		public State<int> currentStep;

		public StateSelector<bool> canUndo;

		public StateSelector<bool> canRedo;

		public event Action onChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onUndoRedo
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<UndoStep> onUndo
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<UndoStep> onRedo
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public UndoStep AddStep(string name, Action undo, Action redo)
		{
			return null;
		}

		public void Clear()
		{
		}

		public bool CanUndo()
		{
			return false;
		}

		public void Undo()
		{
		}

		public bool CanRedo()
		{
			return false;
		}

		public void Redo()
		{
		}
	}
}
