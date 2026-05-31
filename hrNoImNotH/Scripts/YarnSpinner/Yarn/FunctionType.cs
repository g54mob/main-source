using System;
using System.Collections.Generic;

namespace Yarn
{
	public class FunctionType : IType
	{
		public string Name => null;

		public string Description
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IType Parent => null;

		public IType ReturnType { get; internal set; }

		public List<IType> Parameters { get; }

		public IReadOnlyDictionary<string, Delegate> Methods => null;

		internal void AddParameter(IType parameterType)
		{
		}
	}
}
