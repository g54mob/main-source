using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Modules
{
	[CreateAssetMenu(menuName = "Tiny Giant Studio/Modular 3D Text/Modules/Play Particle")]
	public class PlayParticles : Module
	{
		[CompilerGenerated]
		private sealed class _003CModuleRoutine_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VariableHolder[] variableHolders;

			public GameObject obj;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CModuleRoutine_003Ed__0(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[IteratorStateMachine(typeof(_003CModuleRoutine_003Ed__0))]
		public override IEnumerator ModuleRoutine(GameObject obj, VariableHolder[] variableHolders)
		{
			return null;
		}

		public override string VariableWarnings(VariableHolder[] variableHolders)
		{
			return null;
		}
	}
}
