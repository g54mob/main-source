using System;
using ModApi.Craft.Parts;

namespace ModApi.Design
{
	public interface ISelectPartTool
	{
		void Activate(Func<PartData, bool> partFilter, PartData selectedPart, Action<PartData> completeAction, Action cancelAction);
	}
}
