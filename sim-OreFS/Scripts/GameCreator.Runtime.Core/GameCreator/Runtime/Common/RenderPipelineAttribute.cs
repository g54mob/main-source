using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	public class RenderPipelineAttribute : Attribute
	{
		public bool Builtin { get; }

		public bool URP { get; }

		public bool HDRP { get; }

		public RenderPipelineAttribute(bool builtin, bool universal, bool highDefinition)
		{
			Builtin = builtin;
			URP = universal;
			HDRP = highDefinition;
		}

		public override string ToString()
		{
			List<string> list = new List<string>();
			if (Builtin)
			{
				list.Add("Built-in");
			}
			if (URP)
			{
				list.Add("URP");
			}
			if (HDRP)
			{
				list.Add("HDRP");
			}
			return string.Join(",", list.Select((string renderingPipeline) => renderingPipeline));
		}
	}
}
