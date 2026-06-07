using System;
using System.Collections.Generic;
using System.Reflection;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	public class CommandBinding : Binding
	{
		private MethodInfo runtimeMethodInfo;

		private List<Type> parameterAssemblyRuntimeTypes;

		public override string CoherenceComponentName => null;

		public override string SignatureRichText => null;

		public override string SignaturePlainText => null;

		public List<string> ParameterAssemblyTypes => null;

		protected CommandBinding()
		{
		}

		public CommandBinding(Descriptor descriptor, Component unityComponent)
		{
		}

		internal override bool Activate()
		{
			return false;
		}

		public override MemberInfo GetMemberInfo()
		{
			return null;
		}

		public override void IsDirty(AbsoluteSimulationFrame simulationFrame, out bool dirty, out bool justStopped)
		{
			dirty = default(bool);
			justStopped = default(bool);
		}

		public override void MarkAsReadyToSend()
		{
		}

		private List<Type> GetParameterAssemblyRuntimeTypes()
		{
			return null;
		}

		public MethodInfo GetMethodInfo()
		{
			return null;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
